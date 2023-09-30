using Microsoft.AspNetCore.Mvc.Rendering;
using SistemPendataanJemaat.Models.Entities;
using System.Collections.Generic;

namespace SistemPendataanJemaat.Models
{
    public class PernikahanViewModel
    {
        public List<PernikahanEntityModel> List { get; set; }
        public PernikahanEntityModel Single { get; set; }
        public List<PernikahanDetailEntityModel> ListDetail { get; set; }
        public PernikahanDetailEntityModel JemaatDetail { get; set; }
        public JemaatEntityModel DataJemaatDetail { get; set; }
        public PernikahanDetailEntityModel PasanganDetail { get; set; }
        public JemaatEntityModel DataPasanganDetail { get; set; }
        public bool IsPasanganJemaat { get; set; }
        public bool DataSourceJemaat { get; set; }
        public List<VwPernikahanEntityModel> VwList { get; set; }
        public VwPernikahanEntityModel VwSingle { get; set; }
        public List<VwPernikahanDetailEntityModel> VwListDetail { get; set; }
        public VwPernikahanDetailEntityModel VwJemaatDetail { get; set; }
        public VwPernikahanDetailEntityModel VwPasanganDetail { get; set; }
        public IEnumerable<SelectListItem> DdlJemaat { get; set; }
        public IEnumerable<SelectListItem> DdlStatusKeaktifan { get; set; }
        public int DataCount { get; set; }
    }
}
