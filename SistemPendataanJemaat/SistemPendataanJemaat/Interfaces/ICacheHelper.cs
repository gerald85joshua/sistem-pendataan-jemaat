using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemPendataanJemaat.Interfaces
{
    public interface ICacheHelper
    {
        string GetCache(string key);
        void SetCache(string key, string value);
    }
}
