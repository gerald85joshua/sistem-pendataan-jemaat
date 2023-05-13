using SistemPendataanJemaat.Interfaces;
using SistemPendataanJemaat.Models.Entities;

namespace SistemPendataanJemaat.Repositories
{
    public class DdlKelompokIbadahRepository : RepositoryBase<DdlKelompokIbadahEntityModel>, IDdlKelompokIbadahRepository
    {
        public DdlKelompokIbadahRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        { }
    }
}
