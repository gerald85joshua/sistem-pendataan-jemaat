using Microsoft.AspNetCore.Mvc;
using SistemPendataanJemaat.Interfaces;
using SistemPendataanJemaat.Models;
using SistemPendataanJemaat.Models.Entities;
using System;
using System.Text.Json;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using SistemPendataanJemaat.Helper;

namespace SistemPendataanJemaat.Controllers
{
    public class DataJemaatController : Controller
    {
        private readonly IRepositoryWrapper _repository;
        private readonly ICacheHelper _cache;

        public DataJemaatController(IRepositoryWrapper repository, ICacheHelper cache)
        {
            _repository = repository;
            _cache = cache;
        }

        #region Jemaat
        public async Task<IActionResult> JemaatIndex()
        {
            JemaatViewModel viewModel;

            try
            {
                await LoadData();
                var cacheValue = _cache.GetCache("DataJemaat_Jemaat");
                viewModel = JsonSerializer.Deserialize<JemaatViewModel>(cacheValue);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return View(viewModel);
        }

        private async Task LoadData()
        {
            JemaatViewModel viewModel = new JemaatViewModel();
            var jemaat = await _repository.Jemaat.FindAll();
            var vw_jemaat = await _repository.VwJemaat.FindAll();
            var ddl_area = await _repository.DdlArea.FindAll();
            var ddl_komsel = await _repository.DdlKomsel.FindAll();
            var ddl_kelompok_ibadah = await _repository.DdlKelompokIbadah.FindAll();
            var ddl_status_anggota = await _repository.DdlStatusAnggota.FindAll();
            var ddl_status_keaktifan = await _repository.DdlStatusKeaktifan.FindAll();
            var ddl_status_pernikahan = await _repository.DdlStatusPernikahan.FindAll();

            viewModel.List = jemaat.OrderBy(o => o.Nama_Lengkap).ToList();
            viewModel.VwList = vw_jemaat.OrderBy(o => o.Nama_Lengkap).ToList();
            viewModel.DdlKomsel = GeneralHelper.addDdl(ddl_komsel.ToList());
            viewModel.DdlKelompokIbadah = GeneralHelper.addDdl(ddl_kelompok_ibadah.ToList());
            viewModel.DdlStatusAnggota = GeneralHelper.addDdl(ddl_status_anggota.ToList());
            viewModel.DdlStatusKeaktifan = GeneralHelper.addDdl(ddl_status_keaktifan.ToList());
            viewModel.DdlStatusPernikahan = GeneralHelper.addDdl(ddl_status_pernikahan.ToList());
            viewModel.DdlGolonganDarah = addGolonganDarah();
            viewModel.DataCount = viewModel.List.Count;

            var cacheValue = JsonSerializer.Serialize(viewModel);
            _cache.SetCache("DataJemaat_Jemaat", cacheValue);
        }

        private List<SelectListItem> addGolonganDarah()
        {
            List<SelectListItem> result = new List<SelectListItem>();

            result.Add(new SelectListItem
            {
                Text = "Pilih golongan darah..",
                Value = null
            });
            result.Add(new SelectListItem{
                Text = "AB",
                Value = "AB"
            });
            result.Add(new SelectListItem
            {
                Text = "A",
                Value = "A"
            });
            result.Add(new SelectListItem
            {
                Text = "B",
                Value = "B"
            });
            result.Add(new SelectListItem
            {
                Text = "O",
                Value = "O"
            });

            return result;
        }

        public IActionResult JemaatAddEdit(string id)
        {
            bool haveId = !string.IsNullOrEmpty(id);
            ViewBag.PageName = haveId ? "Edit Data Jemaat" : "Create Data Jemaat";
            ViewBag.IsEdit = haveId;
            JemaatViewModel viewModel = new JemaatViewModel();

            try
            {
                var cacheValue = _cache.GetCache("DataJemaat_Jemaat");
                viewModel = JsonSerializer.Deserialize<JemaatViewModel>(cacheValue);

                if (haveId)
                {
                    viewModel.Single = viewModel.List.Where(p => p.ID.ToString() == id).FirstOrDefault();
                } else
                {
                    viewModel.Single = new JemaatEntityModel();
                    viewModel.Single.Tanggal_Lahir = DateTime.Now;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> JemaatAddEdit(JemaatViewModel req)
        {
            var jemaat = req.Single;

            try
            {
                if (jemaat.ID == null)
                {
                    jemaat.ID = Guid.NewGuid();
                    jemaat.Created_By = "System";
                    jemaat.Created_Date = DateTime.Now;
                    jemaat.Updated_By = "System";
                    jemaat.Updated_Date = DateTime.Now;
                    await _repository.Jemaat.Create(jemaat);
                }
                else
                {
                    jemaat.Updated_Date = DateTime.Now;
                    jemaat.Updated_By = "System";
                    await _repository.Jemaat.Update(jemaat);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return RedirectToAction("JemaatIndex");
        }

        public async Task<IActionResult> JemaatDetail(string id)
        {
            JemaatViewModel viewModel = new JemaatViewModel();

            try
            {
                var cacheValue = _cache.GetCache("DataJemaat_Jemaat");

                if (cacheValue == null)
                {
                    await LoadData();
                    cacheValue = _cache.GetCache("DataJemaat_Jemaat");
                }
                viewModel = JsonSerializer.Deserialize<JemaatViewModel>(cacheValue);
                viewModel.VwSingle = viewModel.VwList.Where(p => p.ID.ToString() == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> JemaatDelete(string id)
        {
            JemaatViewModel viewModel = new JemaatViewModel();

            try
            {
                var cacheValue = _cache.GetCache("DataJemaat_Jemaat");
                viewModel = JsonSerializer.Deserialize<JemaatViewModel>(cacheValue);
                var jemaat = viewModel.List.Where(p => p.ID.ToString() == id).FirstOrDefault();
                await _repository.Jemaat.Delete(jemaat);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return RedirectToAction("JemaatIndex");
        }
        #endregion
    }
}
