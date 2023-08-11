using SistemPendataanJemaat.Interfaces;
using SistemPendataanJemaat.Models.Entities;

namespace SistemPendataanJemaat.Repositories
{
    public class PernikahanDetailRepository : RepositoryBase<PernikahanDetailEntityModel>, IPernikahanDetailRepository
    {
        public PernikahanDetailRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        { }
    }
}
