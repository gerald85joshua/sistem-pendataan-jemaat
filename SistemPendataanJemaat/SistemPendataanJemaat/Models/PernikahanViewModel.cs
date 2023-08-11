using Microsoft.AspNetCore.Mvc.Rendering;
using SistemPendataanJemaat.Models.Entities;
using System.Collections.Generic;

namespace SistemPendataanJemaat.Models
{
    public class PernikahanViewModel
    {
        public List<PernikahanEntityModel> List { get; set; }
        public PernikahanEntityModel Single { get; set; }
        public PernikahanDetailEntityModel Detail { get; set; }
        public List<VwPernikahanEntityModel> VwList { get; set; }
        public VwPernikahanEntityModel VwSingle { get; set; }
        public VwPernikahanDetailEntityModel VwDetail { get; set; }
        public IEnumerable<SelectListItem> DdlJemaat { get; set; }
        public int DataCount { get; set; }
    }
}
