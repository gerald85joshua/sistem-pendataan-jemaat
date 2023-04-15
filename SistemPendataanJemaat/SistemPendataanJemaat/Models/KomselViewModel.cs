using SistemPendataanJemaat.Models.Entities;
using System.Collections.Generic;

namespace SistemPendataanJemaat.Models
{
    public class KomselViewModel
    {
        public List<KomselEntityModel> List { get; set; }
        public KomselEntityModel Single { get; set; }
        public int DataCount { get; set; }
    }
}
