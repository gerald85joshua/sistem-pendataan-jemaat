using SistemPendataanJemaat.Interfaces;
using SistemPendataanJemaat.Models.Entities;

namespace SistemPendataanJemaat.Repositories
{
    public class DdlJemaatRepository : RepositoryBase<DdlJemaatEntityModel>, IDdlJemaatRepository
    {
        public DdlJemaatRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        { }
    }
}
