using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemPendataanJemaat.Models.Entities
{
    public abstract class DdlEntityModel
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }
}
