using Microsoft.AspNetCore.Mvc.Rendering;
using SistemPendataanJemaat.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemPendataanJemaat.Models
{
    public class HomeViewModel
    {
        public List<VwJemaatEntityModel> VwList { get; set; }
        public VwJemaatEntityModel VwSingle { get; set; }
        public IEnumerable<SelectListItem> DdlKomsel { get; set; }
        public string TypedKey { get; set; }
        public string SelectedKomsel { get; set; }
        public bool SearchTriggered { get; set; }
    }
}
