using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SistemPendataanJemaat.Helper;
using SistemPendataanJemaat.Interfaces;
using SistemPendataanJemaat.Models;
using System;
using System.Diagnostics;
using System.Text.Json;
using System.Threading.Tasks;
using System.Linq;
using SistemPendataanJemaat.Models.Entities;
using System.Collections.Generic;

namespace SistemPendataanJemaat.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IRepositoryWrapper _repository;
        private readonly ICacheHelper _cache;

        public HomeController(ILogger<HomeController> logger, IRepositoryWrapper repository, ICacheHelper cache) : base(cache)
        {
            _repository = repository;
            _cache = cache;
        }

        private List<JemaatChartDataModel> GenerateChart(IEnumerable<VwJemaatEntityModel> jemaat, List<StatusAnggotaEntityModel> statusAnggota)
        {
            var totalJemaat = jemaat.Count();
            var result = new List<JemaatChartDataModel>
            {
                new JemaatChartDataModel
                {
                    DimensionOne = $"Total Jemaat: {totalJemaat}",
                    Quantity = 0
                }
            };
            foreach (var status in statusAnggota)
            {
                double total = jemaat.Where(p => p.Status_Anggota_ID == status.Status_Anggota_ID).Count();
                double percentage = Math.Round(total / totalJemaat * 100, 2);
                result.Add(new JemaatChartDataModel
                {
                    DimensionOne = $"{status.Status_Anggota} ({percentage}%)",
                    Quantity = jemaat.Where(p => p.Status_Anggota_ID == status.Status_Anggota_ID).Count()
                });
            }

            return result;
        }

        public async Task<IActionResult> Index(HomeViewModel req)
        {
            var viewModel = new HomeViewModel();
            var vw_jemaat = await _repository.VwJemaat.FindAll();

            if (!req.SearchTriggered)
            {
                var ddl_komsel = await _repository.DdlKomsel.FindAll();
                var status_anggota = await _repository.StatusAnggota.FindAll();
                viewModel.JemaatChartDataModels = GenerateChart(vw_jemaat, status_anggota.ToList());
                viewModel.TotalJemaat = vw_jemaat.Count();
                viewModel.SearchTriggered = true;
                viewModel.DdlKomsel = GeneralHelper.addDdl(ddl_komsel);
                viewModel.DdlStatus = GeneralHelper.addDdlStatusDashboard();
                viewModel.VwList = new List<VwJemaatEntityModel>();
            } else
            {
                var cacheGet = _cache.GetCache("Home_Jemaat");
                viewModel = JsonSerializer.Deserialize<HomeViewModel>(cacheGet);

                if (!String.IsNullOrEmpty(req.TypedKey))
                {
                    viewModel.TypedKey = req.TypedKey;
                    var key = req.TypedKey.ToLower();
                    vw_jemaat = vw_jemaat.Where(p => p.Nama_Lengkap.ToLower().Contains(key) || p.Nama_Panggilan.ToLower().Contains(key));
                }

                if (!String.IsNullOrEmpty(req.SelectedKomsel))
                {
                    viewModel.SelectedKomsel = req.SelectedKomsel;
                    vw_jemaat = vw_jemaat.Where(p => p.Komsel_ID == req.SelectedKomsel);
                    viewModel.DdlKomsel.ToList().Find(p => p.Value == req.SelectedKomsel).Selected = true;
                }

                if (!String.IsNullOrEmpty(req.SelectedStatus))
                {
                    viewModel.SelectedStatus = req.SelectedStatus;
                    vw_jemaat = vw_jemaat.Where(p => p.Status_Keaktifan_ID == req.SelectedStatus);
                    viewModel.DdlStatus.ToList().Find(p => p.Value == req.SelectedStatus).Selected = true;
                } else
                {
                    vw_jemaat = vw_jemaat.Where(p => p.Status_Keaktifan_ID == "JA" || p.Status_Keaktifan_ID == "TA");
                }

                viewModel.VwList = vw_jemaat.OrderBy(o => o.Nama_Lengkap).ToList();
            }

            var cacheSet = JsonSerializer.Serialize(viewModel);
            _cache.SetCache("Home_Jemaat", cacheSet);
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
