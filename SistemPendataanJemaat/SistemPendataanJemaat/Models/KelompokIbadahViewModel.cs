using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemPendataanJemaat.Models
{
    public class KelompokIbadahViewModel
    {
        public List<KelompokIbadahModel> List { get; set; }
        public KelompokIbadahModel Single { get; set; }
        public int DataCount { get; set; }
    }

    public class KelompokIbadahModel
    {
        public string KelompokIbadahID { get; set; }
        public string KelompokIbadah { get; set; }
        public string PicID { get; set; }
        public string Keterangan { get; set; }
    }
}
