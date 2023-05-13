using SistemPendataanJemaat.Models.Entities;
using System.Collections.Generic;

namespace SistemPendataanJemaat.Models
{
    public class StatusKeaktifanViewModel
    {
        public List<StatusKeaktifanEntityModel> List { get; set; }
        public StatusKeaktifanEntityModel Single { get; set; }
        public int DataCount { get; set; }
    }
}
