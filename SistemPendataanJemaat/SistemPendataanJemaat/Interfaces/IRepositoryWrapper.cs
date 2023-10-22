using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemPendataanJemaat.Interfaces
{
    public interface IRepositoryWrapper
    {
        IAreaRepository Area { get; }
        IDdlAreaRepository DdlArea { get; }
        IDdlJemaatRepository DdlJemaat { get; }
        IDdlKelompokIbadahRepository DdlKelompokIbadah { get; }
        IDdlKomselRepository DdlKomsel { get; }
        IDdlStatusAnggotaRepository DdlStatusAnggota { get; }
        IDdlStatusKeaktifanRepository DdlStatusKeaktifan { get; }
        IDdlStatusPernikahanRepository DdlStatusPernikahan { get; }
        IJemaatRepository Jemaat { get; }
        IKelompokIbadahRepository KelompokIbadah { get; }
        IKomselRepository Komsel { get; }
        IPernikahanRepository Pernikahan { get; }
        IPernikahanDetailRepository PernikahanDetail { get; }
        IStatusAnggotaRepository StatusAnggota { get; }
        IStatusKeaktifanRepository StatusKeaktifan { get; }
        IUserRepository User { get; }
        IVwAreaRepository VwArea { get; }
        IVwJemaatRepository VwJemaat { get; }
        IVwKomselRepository VwKomsel { get; }
        IVwPernikahanRepository VwPernikahan { get; }
        IVwPernikahanDetailRepository VwPernikahanDetail { get; }
        void Save();
    }
}
