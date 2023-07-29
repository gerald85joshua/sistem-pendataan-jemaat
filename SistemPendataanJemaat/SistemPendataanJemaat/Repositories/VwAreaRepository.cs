using SistemPendataanJemaat.Interfaces;
using SistemPendataanJemaat.Models.Entities;

namespace SistemPendataanJemaat.Repositories
{
    public class VwAreaRepository : RepositoryBase<VwAreaEntityModel>, IVwAreaRepository
    {
        public VwAreaRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        { }
    }
}
