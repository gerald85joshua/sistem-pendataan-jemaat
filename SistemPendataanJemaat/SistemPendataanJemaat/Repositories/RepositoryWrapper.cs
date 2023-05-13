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
        private IAreaRepository _area;
        private IKomselRepository _komsel;
        private IJemaatRepository _jemaat;
        private IVwJemaatRepository _vw_jemaat;
        private IStatusAnggotaRepository _status_anggota;
        private IStatusKeaktifanRepository _status_keaktifan;

        public IKelompokIbadahRepository KelompokIbadah
        {
            get
            {
                if (_kelompokIbadah == null)
                    _kelompokIbadah = new KelompokIbadahRepository(_repoContext);

                return _kelompokIbadah;
            }
        }

        public IAreaRepository Area
        {
            get
            {
                if (_komsel == null)
                {
                    _area = new AreaRepository(_repoContext);
                }
                return _area;
            }
        }

        public IKomselRepository Komsel
        {
            get
            {
                if (_komsel == null)
                {
                    _komsel= new KomselRepository(_repoContext);
                }
                return _komsel;
            }
        }
        public IStatusAnggotaRepository StatusAnggota
        {
            get
            {
                if (_status_anggota == null)
                {
                    _status_anggota = new StatusAnggotaRepository(_repoContext);
                }
                return _status_anggota;
            }
        }

        public IStatusKeaktifanRepository StatusKeaktifan
        {
            get
            {
                if (_status_keaktifan == null)
                {
                    _status_keaktifan = new StatusKeaktifanRepository(_repoContext);
                }
                return _status_keaktifan;
            }
        }

        public IJemaatRepository Jemaat
        {
            get
            {
                if (_jemaat == null)
                    _jemaat = new JemaatRepository(_repoContext);

                return _jemaat;
            }
        }
        public IVwJemaatRepository VwJemaat
        {
            get
            {
                if (_vw_jemaat == null)
                    _vw_jemaat = new VwJemaatRepository(_repoContext);

                return _vw_jemaat;
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
