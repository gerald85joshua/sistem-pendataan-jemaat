using SistemPendataanJemaat.Interfaces;
using SistemPendataanJemaat.Models.Entities;

namespace SistemPendataanJemaat.Repositories
{
    public class StatusAnggotaRepository : RepositoryBase<StatusAnggotaEntityModel>, IStatusAnggotaRepository
    {
        public StatusAnggotaRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        { }
    }
}
