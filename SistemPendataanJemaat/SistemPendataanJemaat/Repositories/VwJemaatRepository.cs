using SistemPendataanJemaat.Interfaces;
using SistemPendataanJemaat.Models.Entities;

namespace SistemPendataanJemaat.Repositories
{
    public class VwJemaatRepository : RepositoryBase<VwJemaatEntityModel>, IVwJemaatRepository
    {
        public VwJemaatRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        { }
    }
}
