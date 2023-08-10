using SistemPendataanJemaat.Interfaces;
using SistemPendataanJemaat.Models.Entities;

namespace SistemPendataanJemaat.Repositories
{
    public class VwKomselRepository : RepositoryBase<VwKomselEntityModel>, IVwKomselRepository
    {
        public VwKomselRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        { }
    }
}
