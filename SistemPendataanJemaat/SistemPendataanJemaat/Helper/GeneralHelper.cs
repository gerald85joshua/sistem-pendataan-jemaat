using Microsoft.AspNetCore.Mvc.Rendering;
using SistemPendataanJemaat.Models.Entities;
using System.Collections.Generic;

namespace SistemPendataanJemaat.Helper
{
    public static class GeneralHelper
    {
        public static string GenerateId(string code, int lastRow)
        {
            string result = code;
            int newRow = lastRow + 1;
            var countZero = 10 - (code.Length + newRow.ToString().Length);
            var stringZero = string.Empty;

            for (var i = 0; i < countZero; i++)
            {
                stringZero += "0";
            }

            result += stringZero + newRow;
            return result;
        }

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

        public static List<SelectListItem> addDdlStatusDashboard()
        {
            var result = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "Aktif",
                    Value = "JA"
                },
                new SelectListItem
                {
                    Text = "Non aktif",
                    Value = "TA"
                }
            };

            return result;
        }

        public static List<SelectListItem> addDdlGolonganDarah(string placeholder)
        {
            List<SelectListItem> result = new List<SelectListItem>
            {
                //new SelectListItem
                //{
                //    Text = "Pilih golongan darah..",
                //    Value = null
                //},
                new SelectListItem
                {
                    Text = "AB",
                    Value = "AB"
                },
                new SelectListItem
                {
                    Text = "A",
                    Value = "A"
                },
                new SelectListItem
                {
                    Text = "B",
                    Value = "B"
                },
                new SelectListItem
                {
                    Text = "O",
                    Value = "O"
                }
            };

            return result;
        }

    }
}
