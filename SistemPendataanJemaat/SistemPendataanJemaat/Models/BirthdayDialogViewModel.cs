using SistemPendataanJemaat.Models.Entities;
using System;
using System.Collections.Generic;

namespace SistemPendataanJemaat.Models
{
    public class BirthdayDialogViewModel
    {
        public List<VwJemaatEntityModel> ListDewasa { get; set; }
        public List<VwJemaatEntityModel> ListPemuda { get; set; }
        public List<VwJemaatEntityModel> ListAnak {  get; set; }
    }
}
