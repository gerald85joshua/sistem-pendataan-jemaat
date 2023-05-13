using SistemPendataanJemaat.Interfaces;
using SistemPendataanJemaat.Models.Entities;

namespace SistemPendataanJemaat.Repositories
{
    public class DdlStatusPernikahanRepository : RepositoryBase<DdlStatusPernikahanEntityModel>, IDdlStatusPernikahanRepository
    {
        public DdlStatusPernikahanRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        { }
    }
}
