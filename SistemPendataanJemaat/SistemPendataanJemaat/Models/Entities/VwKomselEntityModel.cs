using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemPendataanJemaat.Models.Entities
{
    [Table("vw_komsel")]
    public class VwKomselEntityModel
    {
        public string Komsel_ID { get; set; }

        [Display(Name = "Komsel")]
        public string Komsel { get; set; }
        public string Area_ID { get; set; }

        [Display(Name = "Area")]
        public string Area { get; set; }

        [Display(Name = "PIC_ID")]
        public string PIC_ID { get; set; }

        [Display(Name = "PIC")]
        public string Nama_Panggilan_PIC { get; set; }

        [Display(Name = "PIC")]
        public string Nama_Lengkap_PIC { get; set; }

        [Display(Name = "Keterangan")]
        public string Keterangan { get; set; }
    }
}
