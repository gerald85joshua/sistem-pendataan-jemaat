using Microsoft.AspNetCore.Mvc.Rendering;
using SistemPendataanJemaat.Models.Entities;
using System.Collections.Generic;

namespace SistemPendataanJemaat.Models
{
    public class KomselViewModel
    {
        public List<KomselEntityModel> List { get; set; }
        public KomselEntityModel Single { get; set; }
        public List<VwKomselEntityModel> VwList { get; set; }
        public VwKomselEntityModel VwSingle { get; set; }
        public IEnumerable<SelectListItem> DdlArea { get; set; }
        public IEnumerable<SelectListItem> DdlJemaat { get; set; }
        public int DataCount { get; set; }
    }
}
