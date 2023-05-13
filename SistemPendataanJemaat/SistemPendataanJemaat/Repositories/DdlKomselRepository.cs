using SistemPendataanJemaat.Interfaces;
using SistemPendataanJemaat.Models.Entities;

namespace SistemPendataanJemaat.Repositories
{
    public class DdlKomselRepository : RepositoryBase<DdlKomselEntityModel>, IDdlKomselRepository
    {
        public DdlKomselRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        { }
    }
}
