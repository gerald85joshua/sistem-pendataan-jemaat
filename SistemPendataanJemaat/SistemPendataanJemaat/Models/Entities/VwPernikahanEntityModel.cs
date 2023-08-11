using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemPendataanJemaat.Models.Entities
{
    [Table("vw_pernikahan")]
    public class VwPernikahanEntityModel
    {
        public string ID { get; set; }

        [Display(Name = "Pasangan")]
        public string Pasangan { get; set; }

        [Display(Name = "Tanggal Pernikahan")]
        public DateTime Tanggal_Pernikahan { get; set; }

        [Display(Name = "Menikah di")]
        public string Gereja { get; set; }

        [Display(Name = "Diberkati oleh")]
        public string Pendeta { get; set; }

        [Display(Name = "Sudah Catatan Sipil?")]
        public bool Catatan_Sipil { get; set; }

        [Display(Name = "No. Surat Nikah")]
        public string No_Surat_Nikah { get; set; }
    }
}
