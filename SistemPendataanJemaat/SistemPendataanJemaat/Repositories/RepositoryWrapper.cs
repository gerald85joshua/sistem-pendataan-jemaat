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
        private IPernikahanRepository _pernikahan;
        private IPernikahanDetailRepository _pernikahanDetail;
        private IJemaatRepository _jemaat;
        private IDdlAreaRepository _ddlArea;
        private IDdlJemaatRepository _ddlJemaat;
        private IDdlKomselRepository _ddlKomsel;
        private IDdlKelompokIbadahRepository _ddlKelompokIbadah;
        private IDdlStatusAnggotaRepository _ddlStatusAnggota;
        private IDdlStatusKeaktifanRepository _ddlStatusKeaktifan;
        private IDdlStatusPernikahanRepository _ddlStatusPernikahan;
        private IVwAreaRepository _vwArea;
        private IVwJemaatRepository _vwJemaat;
        private IVwKomselRepository _vwKomsel;
        private IVwPernikahanRepository _vwPernikahan;
        private IVwPernikahanDetailRepository _vwPernikahanDetail;
        private IStatusAnggotaRepository _statusAnggota;
        private IStatusKeaktifanRepository _statusKeaktifan;
        private IUserRepository _user;

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
                if (_area == null)
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

        public IPernikahanRepository Pernikahan
        {
            get
            {
                if (_pernikahan == null)
                {
                    _pernikahan = new PernikahanRepository(_repoContext);
                }
                return _pernikahan;
            }
        }

        public IPernikahanDetailRepository PernikahanDetail
        {
            get
            {
                if (_pernikahanDetail == null)
                {
                    _pernikahanDetail = new PernikahanDetailRepository(_repoContext);
                }
                return _pernikahanDetail;
            }
        }

        public IStatusAnggotaRepository StatusAnggota
        {
            get
            {
                if (_statusAnggota == null)
                {
                    _statusAnggota = new StatusAnggotaRepository(_repoContext);
                }
                return _statusAnggota;
            }
        }

        public IStatusKeaktifanRepository StatusKeaktifan
        {
            get
            {
                if (_statusKeaktifan == null)
                {
                    _statusKeaktifan = new StatusKeaktifanRepository(_repoContext);
                }
                return _statusKeaktifan;
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

        public IDdlJemaatRepository DdlJemaat
        {
            get
            {
                if (_ddlJemaat == null)
                    _ddlJemaat = new DdlJemaatRepository(_repoContext);

                return _ddlJemaat;
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

        public IUserRepository User
        {
            get
            {
                if (_user == null)
                    _user = new UserRepository(_repoContext);

                return _user;
            }
        }

        public IVwAreaRepository VwArea
        {
            get
            {
                if (_vwArea == null)
                {
                    _vwArea = new VwAreaRepository(_repoContext);
                }
                return _vwArea;
            }
        }

        public IVwJemaatRepository VwJemaat
        {
            get
            {
                if (_vwJemaat == null)
                    _vwJemaat = new VwJemaatRepository(_repoContext);

                return _vwJemaat;
            }
        }

        public IVwKomselRepository VwKomsel
        {
            get
            {
                if (_vwKomsel == null)
                    _vwKomsel = new VwKomselRepository(_repoContext);

                return _vwKomsel;
            }
        }

        public IVwPernikahanRepository VwPernikahan
        {
            get
            {
                if (_vwPernikahan == null)
                {
                    _vwPernikahan = new VwPernikahanRepository(_repoContext);
                }
                return _vwPernikahan;
            }
        }

        public IVwPernikahanDetailRepository VwPernikahanDetail
        {
            get
            {
                if (_vwPernikahanDetail == null)
                {
                    _vwPernikahanDetail = new VwPernikahanDetailRepository(_repoContext);
                }
                return _vwPernikahanDetail;
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
