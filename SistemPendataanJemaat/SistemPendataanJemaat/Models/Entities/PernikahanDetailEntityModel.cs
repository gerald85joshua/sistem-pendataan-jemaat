using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemPendataanJemaat.Models.Entities
{
    [Table("tbl_pernikahan_detail")]
    public class PernikahanDetailEntityModel
    {
        public Guid? ID { get; set; }

        public Guid? ID_Pernikahan { get; set; }

        [Display(Name = "Nama Jemaat")]
        public Guid? ID_Jemaat { get; set; }

        [Display(Name = "Anggota Gereja")]
        [StringLength(100, ErrorMessage = "Anggota Gereja can't be longer than 100 characters")]
        public string Anggota_Gereja { get; set; }

        public string Created_By { get; set; }

        public DateTime Created_Date { get; set; }

        public string Updated_By { get; set; }

        public DateTime Updated_Date { get; set; }
    }
}
