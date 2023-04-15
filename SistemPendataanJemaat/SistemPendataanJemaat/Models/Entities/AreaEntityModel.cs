using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemPendataanJemaat.Models.Entities
{
    [Table("tbl_area")]
    public class AreaEntityModel
    {
        public string Area_ID { get; set; }

        [Display(Name = "Area")]
        [Required(ErrorMessage = "Area is required")]
        [StringLength(100, ErrorMessage = "Area can't be longer than 100 characters")]
        public string Area { get; set; }

        [Display(Name = "PIC")]
        public string PIC_ID { get; set; }

        [Display(Name = "Keterangan")]
        [StringLength(200, ErrorMessage = "Keterangan can't be longer than 200 characters")]
        public string Keterangan { get; set; }
    }
}
