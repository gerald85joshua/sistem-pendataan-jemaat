using SistemPendataanJemaat.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemPendataanJemaat.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IKelompokIbadahRepository _kelompokIbadah;

        public IKelompokIbadahRepository KelompokIbadah
        {
            get
            {
                if (_kelompokIbadah == null)
                {
                    _kelompokIbadah = new KelompokIbadahRepository(_repoContext);
                }
                return _kelompokIbadah;
            }
        }
        
        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
