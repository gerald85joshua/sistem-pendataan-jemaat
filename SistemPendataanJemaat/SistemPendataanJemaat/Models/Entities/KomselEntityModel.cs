using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemPendataanJemaat.Models.Entities
{
    [Table("tbl_Komsel")]
    public class KomselEntityModel
    {
        public string Komsel_ID { get; set; }

        [Display(Name = "Komsel")]
        [Required(ErrorMessage = "Komsel is required")]
        [StringLength(100, ErrorMessage = "Komsel can't be longer than 100 characters")]
        public string Komsel { get; set; }

        [Display(Name = "PIC")]
        public string PIC_ID { get; set; }

        [Display(Name = "Keterangan")]
        [StringLength(200, ErrorMessage = "Keterangan can't be longer than 200 characters")]
        public string Keterangan { get; set; }
    }
}
