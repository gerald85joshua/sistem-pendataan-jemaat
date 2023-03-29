using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemPendataanJemaat.Models.Entities
{
    [Table("tbl_kelompok_ibadah")]
    public class KelompokIbadahEntityModel
    {
        public string Kelompok_Ibadah_ID { get; set; }

        [Display(Name = "Kelompok Ibadah")]
        [Required(ErrorMessage = "Kelompok Ibadah is required")]
        [StringLength(100, ErrorMessage = "Kelompok Ibadah can't be longer than 100 characters")]
        public string Kelompok_Ibadah { get; set; }

        [Display(Name = "PIC")]
        public string PIC_ID { get; set; }

        [Display(Name = "Keterangan")]
        [StringLength(200, ErrorMessage = "Keterangan can't be longer than 200 characters")]
        public string Keterangan { get; set; }
    }
}
