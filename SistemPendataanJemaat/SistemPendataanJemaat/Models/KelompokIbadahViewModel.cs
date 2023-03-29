using SistemPendataanJemaat.Models.Entities;
using System.Collections.Generic;

namespace SistemPendataanJemaat.Models
{
    public class KelompokIbadahViewModel
    {
        public List<KelompokIbadahEntityModel> List { get; set; }
        public KelompokIbadahEntityModel Single { get; set; }
        public int DataCount { get; set; }
    }
}
