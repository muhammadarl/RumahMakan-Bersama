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
    public class HomeController : Controller
    {
        private readonly WaitingListContext _context;

        public HomeController(WaitingListContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.WaitingListModel.ToListAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Nama, Kursi, Tanggal, Status")] WaitingListModel WaitingListModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(WaitingListModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(WaitingListModel);
        }

        // // GET: Movies/Edit/5
        // public async Task<IActionResult> Edit(int? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var movie = await _context.Movie.FindAsync(id);
        //     if (movie == null)
        //     {
        //         return NotFound();
        //     }
        //     return View(movie);
        // }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Create_List()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
