using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemPendataanJemaat.Models.Entities
{
    [Table("tbl_jemaat")]
    public class JemaatEntityModel
    {
        public Guid ID { get; set; }

        [StringLength(16, ErrorMessage = "KTP can't be longer than 16 characters")]
        public string KTP { get; set; }

        [Display(Name = "Nama Lengkap")]
        [Required(ErrorMessage = "Nama Lengkap is required")]
        [StringLength(100, ErrorMessage = "Nama Lengkap can't be longer than 100 characters")]
        public string Nama_Lengkap { get; set; }

        [Display(Name = "Nama Lengkap")]
        [StringLength(50, ErrorMessage = "Nama Lengkap can't be longer than 50 characters")]
        public string Nama_Panggilan { get; set; }

        [Display(Name = "Jenis Kelamin")]
        public char Jenis_Kelamin { get; set; }

        [Display(Name = "Pendidikan Terakhir")]
        [StringLength(50, ErrorMessage = "Pendidikan Terakhir can't be longer than 50 characters")]
        public string Pendidikan_Terakhir { get; set; }

        [Display(Name = "Pekerjaan")]
        [StringLength(100, ErrorMessage = "Pekerjaan can't be longer than 100 characters")]
        public string Pekerjaan { get; set; }

        [Display(Name = "Alamat")]
        [StringLength(200, ErrorMessage = "Alamat can't be longer than 200 characters")]
        public string Alamat { get; set; }

        [Display(Name = "Status Anggota")]
        [StringLength(2, ErrorMessage = "Status Anggota can't be longer than 2 characters")]
        public string Status_Anggota_ID { get; set; }

        [Display(Name = "Status Keaktifan")]
        [StringLength(5, ErrorMessage = "Status Keaktifan can't be longer than 5 characters")]
        public string Status_Keaktifan_ID { get; set; }

        [Display(Name = "Kelompok Ibadah")]
        [StringLength(10, ErrorMessage = "Kelompok Ibadah can't be longer than 10 characters")]
        public string Kelompok_Ibadah_ID { get; set; }

        [Display(Name = "Area")]
        [StringLength(10, ErrorMessage = "Area can't be longer than 10 characters")]
        public string Area_ID { get; set; }

        [Display(Name = "Komsel")]
        [StringLength(10, ErrorMessage = "Komsel can't be longer than 10 characters")]
        public string Komsel_ID { get; set; }

        [Display(Name = "Tempat Lahir")]
        [StringLength(50, ErrorMessage = "Tempat Lahir can't be longer than 50 characters")]
        public string Tempat_Lahir { get; set; }

        [Display(Name = "Tanggal Lahir")]
        public DateTime Tanggal_Lahir { get; set; }

        [Display(Name = "Golongan Darah")]
        [StringLength(5, ErrorMessage = "Golongan Darah can't be longer than 5 characters")]
        public string Golongan_Darah { get; set; }

        [Display(Name = "Bersedia Donor Darah")]
        public bool Bersedia_Donor_Darah { get; set; }

        [Display(Name = "No. HP")]
        [StringLength(20, ErrorMessage = "No. HP can't be longer than 20 characters")]
        public string No_HP { get; set; }

        [Display(Name = "Alamat Email")]
        [StringLength(50, ErrorMessage = "Alamat Email can't be longer than 50 characters")]
        public string Alamat_Email { get; set; }

        [Display(Name = "Status Pernikahan")]
        [StringLength(50, ErrorMessage = "Status Pernikahan can't be longer than 50 characters")]
        public string Status_Pernikahan_ID { get; set; }

        public string Created_By { get; set; }

        public DateTime Created_Date { get; set; }

        public string Updated_By { get; set; }

        public DateTime Updated_Date { get; set; }
    }
}
