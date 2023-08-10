using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemPendataanJemaat.Interfaces
{
    public interface IRepositoryWrapper
    {
        IKelompokIbadahRepository KelompokIbadah { get; }
        IAreaRepository Area { get; }
        IKomselRepository Komsel { get; }        
	    IStatusAnggotaRepository StatusAnggota { get; }
        IStatusKeaktifanRepository StatusKeaktifan { get; }
        IJemaatRepository Jemaat { get; }
        IDdlAreaRepository DdlArea { get; }
        IDdlJemaatRepository DdlJemaat { get; }
        IDdlKomselRepository DdlKomsel { get; }
        IDdlKelompokIbadahRepository DdlKelompokIbadah { get; }
        IDdlStatusAnggotaRepository DdlStatusAnggota { get; }
        IDdlStatusKeaktifanRepository DdlStatusKeaktifan { get; }
        IDdlStatusPernikahanRepository DdlStatusPernikahan { get; }
        IVwAreaRepository VwArea { get; }
        IVwJemaatRepository VwJemaat { get; }
        IVwKomselRepository VwKomsel { get; }
        void Save();
    }
}
