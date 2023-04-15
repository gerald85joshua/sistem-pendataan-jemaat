using SistemPendataanJemaat.Interfaces;
using SistemPendataanJemaat.Models.Entities;

namespace SistemPendataanJemaat.Repositories
{
    public class JemaatRepository : RepositoryBase<JemaatEntityModel>, IJemaatRepository
    {
        public JemaatRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        { }
    }
}
