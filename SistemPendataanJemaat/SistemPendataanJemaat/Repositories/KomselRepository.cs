using SistemPendataanJemaat.Interfaces;
using SistemPendataanJemaat.Models.Entities;

namespace SistemPendataanJemaat.Repositories
{
    public class KomselRepository : RepositoryBase<KomselEntityModel>, IKomselRepository
    {
        public KomselRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        { }
    }
}
