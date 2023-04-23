using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemPendataanJemaat.Models.Entities
{
    [Table("vw_jemaat")]
    public class VwJemaatEntityModel
    {
        public Guid? ID { get; set; }

        [Display(Name = "KTP")]
        public string KTP { get; set; }

        [Display(Name = "Nama Lengkap")]
        public string Nama_Lengkap { get; set; }

        [Display(Name = "Nama Lengkap")]
        public string Nama_Panggilan { get; set; }

        [Display(Name = "Jenis Kelamin")]
        public char Jenis_Kelamin { get; set; }

        [Display(Name = "Pendidikan Terakhir")]
        public string Pendidikan_Terakhir { get; set; }

        [Display(Name = "Pekerjaan")]
        public string Pekerjaan { get; set; }

        [Display(Name = "Alamat")]
        public string Alamat { get; set; }

        [Display(Name = "Status Anggota ID")]
        public string Status_Anggota_ID { get; set; }

        [Display(Name = "Status Anggota")]
        public string Status_Anggota { get; set; }

        [Display(Name = "Status Keaktifan ID")]
        public string Status_Keaktifan_ID { get; set; }

        [Display(Name = "Status Keaktifan")]
        public string Status_Keaktifan { get; set; }

        [Display(Name = "Kelompok Ibadah ID")]
        public string Kelompok_Ibadah_ID { get; set; }

        [Display(Name = "Kelompok Ibadah")]
        public string Kelompok_Ibadah { get; set; }

        [Display(Name = "Area ID")]
        public string Area_ID { get; set; }

        [Display(Name = "Area")]
        public string Area { get; set; }

        [Display(Name = "Komsel ID")]
        public string Komsel_ID { get; set; }

        [Display(Name = "Komsel")]
        public string Komsel { get; set; }

        [Display(Name = "Tempat Lahir")]
        public string Tempat_Lahir { get; set; }

        [Display(Name = "Tanggal Lahir")]
        public DateTime Tanggal_Lahir { get; set; }

        [Display(Name = "Golongan Darah")]
        public string Golongan_Darah { get; set; }

        [Display(Name = "Bersedia Donor Darah")]
        public bool Bersedia_Donor_Darah { get; set; }

        [Display(Name = "No. HP")]
        public string No_HP { get; set; }

        [Display(Name = "Alamat Email")]
        public string Alamat_Email { get; set; }

        [Display(Name = "Status Pernikahan ID")]
        public string Status_Pernikahan_ID { get; set; }

        [Display(Name = "Status Pernikahan")]
        public string Status_Pernikahan { get; set; }
    }
}
