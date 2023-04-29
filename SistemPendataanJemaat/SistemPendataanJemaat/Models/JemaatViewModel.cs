using Microsoft.AspNetCore.Mvc.Rendering;
using SistemPendataanJemaat.Models.Entities;
using System.Collections.Generic;

namespace SistemPendataanJemaat.Models
{
    public class JemaatViewModel
    {
        public List<JemaatEntityModel> List { get; set; }
        public JemaatEntityModel Single { get; set; }
        public List<VwJemaatEntityModel> VwList { get; set; }
        public VwJemaatEntityModel VwSingle { get; set; }
        public IEnumerable<SelectListItem> ddlGolonganDarah { get; set; }
        public int DataCount { get; set; }
    }
}
