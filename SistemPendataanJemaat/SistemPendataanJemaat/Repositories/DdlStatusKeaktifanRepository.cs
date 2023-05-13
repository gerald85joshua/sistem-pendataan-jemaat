using SistemPendataanJemaat.Interfaces;
using SistemPendataanJemaat.Models.Entities;

namespace SistemPendataanJemaat.Repositories
{
    public class DdlStatusKeaktifanRepository : RepositoryBase<DdlStatusKeaktifanEntityModel>, IDdlStatusKeaktifanRepository
    {
        public DdlStatusKeaktifanRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        { }
    }
}
