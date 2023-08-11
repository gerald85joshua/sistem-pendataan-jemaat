using SistemPendataanJemaat.Interfaces;
using SistemPendataanJemaat.Models.Entities;

namespace SistemPendataanJemaat.Repositories
{
    public class VwPernikahanRepository : RepositoryBase<VwPernikahanEntityModel>, IVwPernikahanRepository
    {
        public VwPernikahanRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        { }
    }
}
