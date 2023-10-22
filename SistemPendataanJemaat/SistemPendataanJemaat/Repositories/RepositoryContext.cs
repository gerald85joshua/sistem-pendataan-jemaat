﻿using SistemPendataanJemaat.Models.Entities;
using Microsoft.EntityFrameworkCore;


namespace SistemPendataanJemaat.Repositories
{
    public class RepositoryContext : DbContext
    {
        public DbSet<KelompokIbadahEntityModel> KelompokIbadahModels { get; set; }
        public DbSet<JemaatEntityModel> Jemaat { get; set; }
        public DbSet<AreaEntityModel> Area { get; set; }
        public DbSet<KomselEntityModel> Komsel { get; set; }
        public DbSet<PernikahanEntityModel> Pernikahan { get; set; }
        public DbSet<PernikahanDetailEntityModel> PernikahanDetail { get; set; }
        public DbSet<StatusAnggotaEntityModel> StatusAnggota { get; set; }
        public DbSet<StatusKeaktifanEntityModel> StatusKeaktifan { get; set; }
        public DbSet<UserEntityModel> User { get; set; }

        public RepositoryContext(DbContextOptions<RepositoryContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KelompokIbadahEntityModel>(u =>
            {
                u.HasKey(e => e.Kelompok_Ibadah_ID);
                u.Property(e => e.Kelompok_Ibadah);
                u.Property(e => e.PIC_ID);
                u.Property(e => e.Keterangan);
            });

            modelBuilder.Entity<AreaEntityModel>(u =>
            {
                u.HasKey(e => e.Area_ID);
                u.Property(e => e.Area);
                u.Property(e => e.PIC_ID);
                u.Property(e => e.Keterangan);
            });

            modelBuilder.Entity<KomselEntityModel>(u =>
            {
                u.HasKey(e => e.Komsel_ID);
                u.Property(e => e.Komsel);
                u.Property(e => e.Area_ID);
                u.Property(e => e.PIC_ID);
                u.Property(e => e.Keterangan);
            });

            modelBuilder.Entity<PernikahanEntityModel>(u =>
            {
                u.HasKey(e => e.ID);
                u.Property(e => e.Tanggal_Pernikahan);
                u.Property(e => e.Gereja);
                u.Property(e => e.Pendeta);
                u.Property(e => e.Catatan_Sipil);
                u.Property(e => e.No_Surat_Nikah);
                u.Property(e => e.Created_By);
                u.Property(e => e.Created_Date);
                u.Property(e => e.Updated_By);
                u.Property(e => e.Updated_Date);
            });

            modelBuilder.Entity<PernikahanDetailEntityModel>(u =>
            {
                u.HasKey(e => e.ID);
                u.Property(e => e.ID_Pernikahan);
                u.Property(e => e.ID_Jemaat);
                u.Property(e => e.Anggota_Gereja);
                u.Property(e => e.Created_By);
                u.Property(e => e.Created_Date);
                u.Property(e => e.Updated_By);
                u.Property(e => e.Updated_Date);
            });

            modelBuilder.Entity<StatusAnggotaEntityModel>(u =>
            {
                u.HasKey(e => e.Status_Anggota_ID);
                u.Property(e => e.Status_Anggota);
                u.Property(e => e.Keterangan);
            });

            modelBuilder.Entity<StatusKeaktifanEntityModel>(u =>
            {
                u.HasKey(e => e.Status_Keaktifan_ID);
                u.Property(e => e.Status_Keaktifan);
                u.Property(e => e.Keterangan);
            });

            modelBuilder.Entity<JemaatEntityModel>(u =>
            {
                u.HasKey(e => e.ID);
                u.Property(e => e.KTP);
                u.Property(e => e.Nama_Lengkap);
                u.Property(e => e.Nama_Panggilan);
                u.Property(e => e.Jenis_Kelamin);
                u.Property(e => e.Pendidikan_Terakhir);
                u.Property(e => e.Pekerjaan);
                u.Property(e => e.Alamat);
                u.Property(e => e.Status_Anggota_ID);
                u.Property(e => e.Status_Keaktifan_ID);
                u.Property(e => e.Kelompok_Ibadah_ID);
                u.Property(e => e.Komsel_ID);
                u.Property(e => e.Tempat_Lahir);
                u.Property(e => e.Tanggal_Lahir);
                u.Property(e => e.Golongan_Darah);
                u.Property(e => e.Bersedia_Donor_Darah);
                u.Property(e => e.No_HP);
                u.Property(e => e.Alamat_Email);
                u.Property(e => e.Status_Pernikahan_ID);
                u.Property(e => e.Created_By);
                u.Property(e => e.Created_Date);
                u.Property(e => e.Updated_By);
                u.Property(e => e.Updated_Date);
            });

            modelBuilder.Entity<DdlAreaEntityModel>(u =>
            {
                u.HasKey(e => e.Value);
                u.Property(e => e.Text);
            });

            modelBuilder.Entity<DdlJemaatEntityModel>(u =>
            {
                u.HasKey(e => e.Value);
                u.Property(e => e.Text);
            });

            modelBuilder.Entity<DdlKomselEntityModel>(u =>
            {
                u.HasKey(e => e.Value);
                u.Property(e => e.Text);
            });

            modelBuilder.Entity<DdlKelompokIbadahEntityModel>(u =>
            {
                u.HasKey(e => e.Value);
                u.Property(e => e.Text);
            });

            modelBuilder.Entity<DdlStatusAnggotaEntityModel>(u =>
            {
                u.HasKey(e => e.Value);
                u.Property(e => e.Text);
            });

            modelBuilder.Entity<DdlStatusKeaktifanEntityModel>(u =>
            {
                u.HasKey(e => e.Value);
                u.Property(e => e.Text);
            });

            modelBuilder.Entity<DdlStatusPernikahanEntityModel>(u =>
            {
                u.HasKey(e => e.Value);
                u.Property(e => e.Text);
            });

            modelBuilder.Entity<UserEntityModel>(u =>
            {
                u.HasKey(e => e.User_ID);
                u.Property(e => e.User_Name);
                u.Property(e => e.User_Email);
                u.Property(e => e.User_Password);
                u.Property(e => e.Is_Login);
                u.Property(e => e.Last_Login);
            });

            modelBuilder.Entity<VwAreaEntityModel>(u =>
            {
                u.HasKey(e => e.Area_ID);
                u.Property(e => e.Area);
                u.Property(e => e.PIC_ID);
                u.Property(e => e.Nama_Panggilan_PIC);
                u.Property(e => e.Nama_Lengkap_PIC);
                u.Property(e => e.Keterangan);
            });

            modelBuilder.Entity<VwJemaatEntityModel>(u =>
            {
                u.HasKey(e => e.ID);
                u.Property(e => e.KTP);
                u.Property(e => e.Nama_Lengkap);
                u.Property(e => e.Nama_Panggilan);
                u.Property(e => e.Jenis_Kelamin);
                u.Property(e => e.Pendidikan_Terakhir);
                u.Property(e => e.Pekerjaan);
                u.Property(e => e.Alamat);
                u.Property(e => e.Status_Anggota_ID);
                u.Property(e => e.Status_Anggota);
                u.Property(e => e.Status_Keaktifan_ID);
                u.Property(e => e.Status_Keaktifan);
                u.Property(e => e.Kelompok_Ibadah_ID);
                u.Property(e => e.Kelompok_Ibadah);
                u.Property(e => e.Komsel_ID);
                u.Property(e => e.Komsel);
                u.Property(e => e.Tempat_Lahir);
                u.Property(e => e.Tanggal_Lahir);
                u.Property(e => e.Golongan_Darah);
                u.Property(e => e.Bersedia_Donor_Darah);
                u.Property(e => e.No_HP);
                u.Property(e => e.Alamat_Email);
                u.Property(e => e.Status_Pernikahan_ID);
                u.Property(e => e.Status_Pernikahan);
                u.Property(e => e.ID_Pernikahan);
                u.Property(e => e.ID_Keluarga);
            });

            modelBuilder.Entity<VwKomselEntityModel>(u =>
            {
                u.HasKey(e => e.Komsel_ID);
                u.Property(e => e.Komsel);
                u.Property(e => e.Area_ID);
                u.Property(e => e.Area);
                u.Property(e => e.PIC_ID);
                u.Property(e => e.Nama_Panggilan_PIC);
                u.Property(e => e.Nama_Lengkap_PIC);
                u.Property(e => e.Keterangan);
            });

            modelBuilder.Entity<VwPernikahanEntityModel>(u =>
            {
                u.HasKey(e => e.ID);
                u.Property(e => e.Pasangan);
                u.Property(e => e.Tanggal_Pernikahan);
                u.Property(e => e.Gereja);
                u.Property(e => e.Pendeta);
                u.Property(e => e.Catatan_Sipil);
                u.Property(e => e.No_Surat_Nikah);
            });

            modelBuilder.Entity<VwPernikahanDetailEntityModel>(u =>
            {
                u.HasKey(e => e.ID);
                u.Property(e => e.ID_Pernikahan);
                u.Property(e => e.ID_Jemaat);
                u.Property(e => e.Nama_Lengkap);
                u.Property(e => e.Jenis_Kelamin);
                u.Property(e => e.Status_Keaktifan_ID);
                u.Property(e => e.Status_Keaktifan);
                u.Property(e => e.Anggota_Gereja);
            });
        }
    }
}
