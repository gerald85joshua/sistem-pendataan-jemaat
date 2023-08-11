using SistemPendataanJemaat.Interfaces;
using SistemPendataanJemaat.Models.Entities;

namespace SistemPendataanJemaat.Repositories
{
    public class PernikahanRepository : RepositoryBase<PernikahanEntityModel>, IPernikahanRepository
    {
        public PernikahanRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        { }
    }
}
