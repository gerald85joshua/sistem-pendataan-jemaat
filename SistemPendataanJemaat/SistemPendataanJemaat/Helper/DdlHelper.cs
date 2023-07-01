using Microsoft.AspNetCore.Mvc.Rendering;
using SistemPendataanJemaat.Models.Entities;
using System.Collections.Generic;

namespace SistemPendataanJemaat.Helper
{
    public static class DdlHelper
    {
        public static List<SelectListItem> addEditableDdl(IEnumerable<DdlEntityModel> entities)
        {
            var result = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "-",
                    Value = null
                }
            };

            foreach (var item in entities)
            {
                result.Add(new SelectListItem
                {
                    Text = item.Text,
                    Value = item.Value
                });
            }

            return result;
        }

        public static List<SelectListItem> addDdl(IEnumerable<DdlEntityModel> entities)
        {
            var result = new List<SelectListItem>();

            foreach (var item in entities)
            {
                result.Add(new SelectListItem
                {
                    Text = item.Text,
                    Value = item.Value
                });
            }

            return result;
        }
    }
}
