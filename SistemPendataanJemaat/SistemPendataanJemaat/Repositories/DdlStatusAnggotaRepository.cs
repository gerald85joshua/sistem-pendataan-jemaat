using SistemPendataanJemaat.Interfaces;
using SistemPendataanJemaat.Models.Entities;

namespace SistemPendataanJemaat.Repositories
{
    public class DdlStatusAnggotaRepository : RepositoryBase<DdlStatusAnggotaEntityModel>, IDdlStatusAnggotaRepository
    {
        public DdlStatusAnggotaRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        { }
    }
}
