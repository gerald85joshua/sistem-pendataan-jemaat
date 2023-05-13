using SistemPendataanJemaat.Interfaces;
using SistemPendataanJemaat.Models.Entities;

namespace SistemPendataanJemaat.Repositories
{
    public class StatusKeaktifanRepository : RepositoryBase<StatusKeaktifanEntityModel>, IStatusKeaktifanRepository
    {
        public StatusKeaktifanRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        { }
    }
}
