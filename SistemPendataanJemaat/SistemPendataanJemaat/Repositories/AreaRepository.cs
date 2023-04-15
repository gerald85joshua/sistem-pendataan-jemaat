using SistemPendataanJemaat.Interfaces;
using SistemPendataanJemaat.Models.Entities;

namespace SistemPendataanJemaat.Repositories
{
    public class AreaRepository : RepositoryBase<AreaEntityModel>, IAreaRepository
    {
        public AreaRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        { }
    }
}
