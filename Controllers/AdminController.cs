using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using RumahMakan_Bersama.Models;
using RumahMakan_Bersama.Data;

namespace RumahMakan_Bersama.Controllers
{
    public class AdminController : Controller
    {
        private readonly WaitingListContext _context;

        public AdminController(WaitingListContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.WaitingListModel.ToListAsync());
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public async Task<IActionResult> EditList(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var WaitingListModel = await _context.WaitingListModel.FindAsync(id);
            if (WaitingListModel == null)
            {
                return NotFound();
            }
            return View(WaitingListModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditList(int id, [Bind("Id, Nama, Kursi, Tanggal, Status")] WaitingListModel WaitingListModel)
        {
            if (id != WaitingListModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(WaitingListModel);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WaitingListModelExists(WaitingListModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(WaitingListModel);

        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var WaitingListModel = await _context.WaitingListModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (WaitingListModel == null)
            {
                return NotFound();
            }

            return View(WaitingListModel);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var WaitingListModel = await _context.WaitingListModel.FindAsync(id);
            _context.WaitingListModel.Remove(WaitingListModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WaitingListModelExists(int id)
        {
            return _context.WaitingListModel.Any(e => e.Id == id);
        }
    }
}
