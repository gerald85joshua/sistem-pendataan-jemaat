using SistemPendataanJemaat.Interfaces;
using SistemPendataanJemaat.Models.Entities;

namespace SistemPendataanJemaat.Repositories
{
    public class KelompokIbadahRepository : RepositoryBase<KelompokIbadahEntityModel>, IKelompokIbadahRepository
    {
        public KelompokIbadahRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        { }
    }
}
