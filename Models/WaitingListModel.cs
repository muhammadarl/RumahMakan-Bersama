using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RumahMakan_Bersama.Models
{
    public class WaitingListModel
    {
        public int Id { get; set; }
        public string Nama { get; set; }

        [Display(Name = "Tanggal"), DataType(DataType.Date)]
        public DateTime Tanggal { get; set; } = DateTime.Now;
        public int Kursi { get; set; }
        public string Status { get; set; } = "Pending";
    }
}