using SistemPendataanJemaat.Interfaces;
using SistemPendataanJemaat.Models.Entities;

namespace SistemPendataanJemaat.Repositories
{
    public class KelompokIbadahRepository : RepositoryBase<KelompokIbadahModel>, IKelompokIbadahRepository
    {
        public KelompokIbadahRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        { }
    }
}
