using SistemPendataanJemaat.Models.Entities;
using System.Collections.Generic;

namespace SistemPendataanJemaat.Models
{
    public class AreaViewModel
    {
        public List<AreaEntityModel> List { get; set; }
        public AreaEntityModel Single { get; set; }
        public int DataCount { get; set; }
    }
}
