using SistemPendataanJemaat.Models.Entities;
using Microsoft.EntityFrameworkCore;


namespace SistemPendataanJemaat.Repositories
{
    public class RepositoryContext : DbContext
    {
        public DbSet<KelompokIbadahModel> KelompokIbadahModels { get; set; }

        public RepositoryContext(DbContextOptions<RepositoryContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KelompokIbadahModel>(u =>
            {
                u.HasKey(e => e.Kelompok_Ibadah_ID);
                u.Property(e => e.Kelompok_Ibadah);
                u.Property(e => e.PIC_ID);
                u.Property(e => e.Keterangan);
            });
        }
    }
}
