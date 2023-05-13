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
        IJemaatRepository Jemaat { get; }
        IStatusAnggotaRepository StatusAnggota { get; }
        IStatusKeaktifanRepository StatusKeaktifan { get; }
        IVwJemaatRepository VwJemaat { get; }
        void Save();
    }
}
