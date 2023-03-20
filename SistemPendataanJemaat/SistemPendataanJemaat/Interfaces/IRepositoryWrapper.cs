using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemPendataanJemaat.Interfaces
{
    public interface IRepositoryWrapper
    {
        IKelompokIbadahRepository KelompokIbadah { get; }
        void Save();
    }
}
