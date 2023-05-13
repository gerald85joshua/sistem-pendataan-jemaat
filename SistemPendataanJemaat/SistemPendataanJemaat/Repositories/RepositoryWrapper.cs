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
        private IDdlAreaRepository _ddlArea;
        private IDdlKomselRepository _ddlKomsel;
        private IDdlKelompokIbadahRepository _ddlKelompokIbadah;
        private IDdlStatusAnggotaRepository _ddlStatusAnggota;
        private IDdlStatusKeaktifanRepository _ddlStatusKeaktifan;
        private IDdlStatusPernikahanRepository _ddlStatusPernikahan;
        private IVwJemaatRepository _vw_jemaat;

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

        public IJemaatRepository Jemaat
        {
            get
            {
                if (_jemaat == null)
                    _jemaat = new JemaatRepository(_repoContext);

                return _jemaat;
            }
        }

        public IDdlAreaRepository DdlArea
        {
            get
            {
                if (_ddlArea == null)
                    _ddlArea = new DdlAreaRepository(_repoContext);

                return _ddlArea;
            }
        }

        public IDdlKomselRepository DdlKomsel
        {
            get
            {
                if (_ddlKomsel == null)
                    _ddlKomsel = new DdlKomselRepository(_repoContext);

                return _ddlKomsel;
            }
        }

        public IDdlKelompokIbadahRepository DdlKelompokIbadah
        {
            get
            {
                if (_ddlKelompokIbadah == null)
                    _ddlKelompokIbadah = new DdlKelompokIbadahRepository(_repoContext);

                return _ddlKelompokIbadah;
            }
        }

        public IDdlStatusAnggotaRepository DdlStatusAnggota
        {
            get
            {
                if (_ddlStatusAnggota == null)
                    _ddlStatusAnggota = new DdlStatusAnggotaRepository(_repoContext);

                return _ddlStatusAnggota;
            }
        }

        public IDdlStatusKeaktifanRepository DdlStatusKeaktifan
        {
            get
            {
                if (_ddlStatusKeaktifan == null)
                    _ddlStatusKeaktifan = new DdlStatusKeaktifanRepository(_repoContext);

                return _ddlStatusKeaktifan;
            }
        }

        public IDdlStatusPernikahanRepository DdlStatusPernikahan
        {
            get
            {
                if (_ddlStatusPernikahan == null)
                    _ddlStatusPernikahan = new DdlStatusPernikahanRepository(_repoContext);

                return _ddlStatusPernikahan;
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
