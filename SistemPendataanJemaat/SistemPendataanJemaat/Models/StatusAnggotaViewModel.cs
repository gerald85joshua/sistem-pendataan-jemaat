using SistemPendataanJemaat.Models.Entities;
using System.Collections.Generic;

namespace SistemPendataanJemaat.Models
{
    public class StatusAnggotaViewModel
    {
        public List<StatusAnggotaEntityModel> List { get; set; }
        public StatusAnggotaEntityModel Single { get; set; }
        public int DataCount { get; set; }
    }
}
