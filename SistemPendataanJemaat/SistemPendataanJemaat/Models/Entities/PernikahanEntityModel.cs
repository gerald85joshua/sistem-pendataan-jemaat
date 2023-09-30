using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemPendataanJemaat.Models.Entities
{
    [Table("tbl_pernikahan")]
    public class PernikahanEntityModel
    {
        public Guid? ID { get; set; }

        [Display(Name = "Tanggal Pernikahan")]
        [Required]
        public DateTime Tanggal_Pernikahan { get; set; }

        [Display(Name = "Menikah di")]
        [Required]
        [StringLength(100, ErrorMessage = "Gereja can't be longer than 100 characters")]
        public string Gereja { get; set; }

        [Display(Name = "Diberkati oleh")]
        [Required]
        [StringLength(100, ErrorMessage = "Pendeta can't be longer than 100 characters")]
        public string Pendeta { get; set; }

        [Display(Name = "Sudah Catatan Sipil?")]
        public bool Catatan_Sipil { get; set; }

        [Display(Name = "No. Surat Nikah")]
        [StringLength(100, ErrorMessage = "No. Surat Nikah can't be longer than 100 characters")]
        public string No_Surat_Nikah { get; set; }

        public string Created_By { get; set; }

        public DateTime Created_Date { get; set; }

        public string Updated_By { get; set; }

        public DateTime Updated_Date { get; set; }
    }
}
