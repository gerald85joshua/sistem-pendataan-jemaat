using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemPendataanJemaat.Models.Entities
{
    [Table("tbl_status_anggota")]
    public class StatusAnggotaEntityModel
    {
        public string Status_Anggota_ID { get; set; }

        [Display(Name = "Status Anggota")]
        [Required(ErrorMessage = "Status Anggota is required")]
        [StringLength(100, ErrorMessage = "Status Anggota can't be longer than 100 characters")]
        public string Status_Anggota { get; set; }


        [Display(Name = "Keterangan")]
        [StringLength(200, ErrorMessage = "Keterangan can't be longer than 200 characters")]
        public string Keterangan { get; set; }
    }
}
