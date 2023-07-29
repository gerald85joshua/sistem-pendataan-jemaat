using Microsoft.AspNetCore.Mvc.Rendering;
using SistemPendataanJemaat.Models.Entities;
using System.Collections.Generic;

namespace SistemPendataanJemaat.Models
{
    public class AreaViewModel
    {
        public List<AreaEntityModel> List { get; set; }
        public AreaEntityModel Single { get; set; }
        public List<VwAreaEntityModel> VwList { get; set; }
        public VwAreaEntityModel VwSingle { get; set; }
        public IEnumerable<SelectListItem> DdlJemaat { get; set; }
        public int DataCount { get; set; }
    }
}
