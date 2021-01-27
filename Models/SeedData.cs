using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using RumahMakan_Bersama.Data;

namespace RumahMakan_Bersama.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new WaitingListContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<WaitingListContext>>()))
            {
                // Waiting listnya.
                if (context.WaitingListModel.Any())
                {
                    return;   // DB has been seeded
                }
                context.WaitingListModel.AddRange(
                    new WaitingListModel
                    {
                        Nama = "When Harry Met Sally",
                        Tanggal = DateTime.Parse("1989-2-12"),
                        Kursi = 2,
                        Status = "pending"
                    },
                    new WaitingListModel
                    {
                        Nama = "Harry",
                        Tanggal = DateTime.Parse("1990-2-12"),
                        Kursi = 3,
                        Status = "pending",
                    }
                );
                context.SaveChanges();
            }
        }
    }
}