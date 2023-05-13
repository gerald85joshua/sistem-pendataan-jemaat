using SistemPendataanJemaat.Interfaces;
using SistemPendataanJemaat.Models.Entities;

namespace SistemPendataanJemaat.Repositories
{
    public class DdlAreaRepository : RepositoryBase<DdlAreaEntityModel>, IDdlAreaRepository
    {
        public DdlAreaRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        { }
    }
}
