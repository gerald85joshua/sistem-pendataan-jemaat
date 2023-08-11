using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemPendataanJemaat.Models.Entities
{
    [Table("vw_pernikahan_detail")]
    public class VwPernikahanDetailEntityModel
    {
        public string ID { get; set; }

        public string ID_Pernikahan { get; set; }

        [Display(Name = "ID Jemaat")]
        public string ID_Jemaat { get; set; }

        [Display(Name = "Nama Jemaat")]
        public string Nama_Lengkap { get; set; }

        [Display(Name = "Jenis Kelamin")]
        public char Jenis_Kelamin { get; set; }

        [Display(Name = "Status Keaktifan ID")]
        public string Status_Keaktifan_ID { get; set; }

        [Display(Name = "Status Keaktifan")]
        public string Status_Keaktifan { get; set; }

        [Display(Name = "Anggota Gereja")]
        public string Anggota_Gereja { get; set; }
    }
}
