using Microsoft.EntityFrameworkCore;
using RumahMakan_Bersama.Models;

namespace RumahMakan_Bersama.Data
{
    public class WaitingListContext : DbContext
    {
        public WaitingListContext (DbContextOptions<WaitingListContext> options)
            : base(options)
        {
        }

        public DbSet<WaitingListModel> WaitingListModel { get; set; }
    }
}