using SistemPendataanJemaat.Interfaces;
using SistemPendataanJemaat.Models.Entities;

namespace SistemPendataanJemaat.Repositories
{
    public class VwPernikahanDetailRepository : RepositoryBase<VwPernikahanDetailEntityModel>, IVwPernikahanDetailRepository
    {
        public VwPernikahanDetailRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        { }
    }
}
