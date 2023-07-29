using Microsoft.AspNetCore.Mvc;
using SistemPendataanJemaat.Interfaces;
using SistemPendataanJemaat.Models;
using System;
using System.Text.Json;
using System.Linq;
using System.Threading.Tasks;
using SistemPendataanJemaat.Helper;

namespace SistemPendataanJemaat.Controllers
{
    public class MasterDataController : Controller
    {
        private readonly IRepositoryWrapper _repository;
        private readonly ICacheHelper _cache;

        public MasterDataController(IRepositoryWrapper repository, ICacheHelper cache)
        {
            _repository = repository;
            _cache = cache;
        }

        #region Kelompok Ibadah
        public async Task<IActionResult> KelompokIbadahIndex()
        {
            KelompokIbadahViewModel viewModel = new KelompokIbadahViewModel();

            try
            {
                var kelompokIbadah = await _repository.KelompokIbadah.FindAll();
                viewModel.List = kelompokIbadah.ToList();
                viewModel.DataCount = viewModel.List.Count;

                var cacheValue = JsonSerializer.Serialize(viewModel);
                _cache.SetCache("MasterData_KelompokIbadah", cacheValue);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return View(viewModel);
        }

        public IActionResult KelompokIbadahAddEdit(string id)
        {
            bool haveId = !string.IsNullOrEmpty(id);
            ViewBag.PageName = haveId ? "Edit Kelompok Ibadah" : "Create Kelompok Ibadah";
            ViewBag.IsEdit = haveId ? true : false;
            KelompokIbadahViewModel viewModel = new KelompokIbadahViewModel();

            try
            {
                var cacheValue = _cache.GetCache("MasterData_KelompokIbadah");
                viewModel = JsonSerializer.Deserialize<KelompokIbadahViewModel>(cacheValue);

                if (haveId)
                {
                    viewModel.Single = viewModel.List.Where(p => p.Kelompok_Ibadah_ID == id).FirstOrDefault();
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
        public async Task<IActionResult> KelompokIbadahAddEdit(KelompokIbadahViewModel req)
        {
            KelompokIbadahViewModel viewModel = new KelompokIbadahViewModel();
            var kelompokIbadah = req.Single;

            try
            {
                if (string.IsNullOrEmpty(kelompokIbadah.Kelompok_Ibadah_ID))
                {
                    var cacheValue = _cache.GetCache("MasterData_KelompokIbadah");
                    viewModel = JsonSerializer.Deserialize<KelompokIbadahViewModel>(cacheValue);
                    var lastID = viewModel.List.OrderBy(o => o.Kelompok_Ibadah_ID).LastOrDefault().Kelompok_Ibadah_ID;
                    var lastRow = int.Parse(lastID.Replace("KELIB", string.Empty));

                    kelompokIbadah.Kelompok_Ibadah_ID = GeneralHelper.GenerateId("KELIB", lastRow);
                    await _repository.KelompokIbadah.Create(kelompokIbadah);
                }
                else
                {
                    await _repository.KelompokIbadah.Update(kelompokIbadah);
                }

                _repository.Save();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return RedirectToAction("KelompokIbadahIndex");
        }

        public IActionResult KelompokIbadahDetail(string id)
        {
            KelompokIbadahViewModel viewModel = new KelompokIbadahViewModel();

            try
            {
                var cacheValue = _cache.GetCache("MasterData_KelompokIbadah");
                viewModel = JsonSerializer.Deserialize<KelompokIbadahViewModel>(cacheValue);
                viewModel.Single = viewModel.List.Where(p => p.Kelompok_Ibadah_ID == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> KelompokIbadahDelete(string id)
        {
            KelompokIbadahViewModel viewModel = new KelompokIbadahViewModel();

            try
            {
                var cacheValue = _cache.GetCache("MasterData_KelompokIbadah");
                viewModel = JsonSerializer.Deserialize<KelompokIbadahViewModel>(cacheValue);
                var kelompokIbadah = viewModel.List.Where(p => p.Kelompok_Ibadah_ID == id).FirstOrDefault();
                await _repository.KelompokIbadah.Delete(kelompokIbadah);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return RedirectToAction("KelompokIbadahIndex");
        }
        #endregion

        #region Area
        public async Task<IActionResult> AreaIndex()
        {
            AreaViewModel viewModel = new AreaViewModel();

            try
            {
                var area = await _repository.Area.FindAll();
                var vw_area = await _repository.VwArea.FindAll();
                var ddl_jemaat = await _repository.DdlJemaat.FindAll();

                viewModel.List = area.ToList();
                viewModel.VwList = vw_area.ToList();
                viewModel.DdlJemaat = GeneralHelper.addDdl(ddl_jemaat.ToList());
                viewModel.DataCount = viewModel.List.Count;

                var cacheValue = JsonSerializer.Serialize(viewModel);
                _cache.SetCache("MasterData_Area", cacheValue);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return View(viewModel);
        }

        public IActionResult AreaAddEdit(string id)
        {
            bool haveId = !string.IsNullOrEmpty(id);
            ViewBag.PageName = haveId ? "Edit Area" : "Create Area";
            ViewBag.IsEdit = haveId;
            AreaViewModel viewModel = new AreaViewModel();

            try
            {
                var cacheValue = _cache.GetCache("MasterData_Area");
                viewModel = JsonSerializer.Deserialize<AreaViewModel>(cacheValue);

                if (haveId)
                {
                    viewModel.Single = viewModel.List.Where(p => p.Area_ID == id).FirstOrDefault();
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
        public async Task<IActionResult> AreaAddEdit(AreaViewModel req)
        {
            AreaViewModel viewModel = new AreaViewModel();
            var area = req.Single;

            try
            {
                if (string.IsNullOrEmpty(area.Area_ID))
                {
                    var cacheValue = _cache.GetCache("MasterData_Area");
                    viewModel = JsonSerializer.Deserialize<AreaViewModel>(cacheValue);
                    var lastID = viewModel.List.OrderBy(o => o.Area_ID).LastOrDefault().Area_ID;
                    var lastRow = int.Parse(lastID.Replace("AREA", string.Empty));

                    area.Area_ID = GeneralHelper.GenerateId("AREA", lastRow);
                    await _repository.Area.Create(area);
                }
                else
                {
                    await _repository.Area.Update(area);
                }

                _repository.Save();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return RedirectToAction("AreaIndex");
        }

        public IActionResult AreaDetail(string id)
        {
            AreaViewModel viewModel = new AreaViewModel();

            try
            {
                var cacheValue = _cache.GetCache("MasterData_Area");
                viewModel = JsonSerializer.Deserialize<AreaViewModel>(cacheValue);
                viewModel.VwSingle = viewModel.VwList.Where(p => p.Area_ID == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AreaDelete(string id)
        {
            AreaViewModel viewModel = new AreaViewModel();

            try
            {
                var cacheValue = _cache.GetCache("MasterData_Area");
                viewModel = JsonSerializer.Deserialize<AreaViewModel>(cacheValue);
                var area = viewModel.List.Where(p => p.Area_ID == id).FirstOrDefault();
                await _repository.Area.Delete(area);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return RedirectToAction("AreaIndex");
        }
        #endregion

        #region Komsel
        public async Task<IActionResult> KomselIndex()
        {
            KomselViewModel viewModel = new KomselViewModel();

            try
            {
                var komsel = await _repository.Komsel.FindAll();
                viewModel.List = komsel.ToList();
                viewModel.DataCount = viewModel.List.Count;

                var cacheValue = JsonSerializer.Serialize(viewModel);
                _cache.SetCache("MasterData_Area", cacheValue);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return View(viewModel);
        }
        #endregion

        #region StatusAnggota
        public async Task<IActionResult> StatusAnggotaIndex()
        {
            StatusAnggotaViewModel viewModel = new StatusAnggotaViewModel();

            try
            {
                var statusanggota = await _repository.StatusAnggota.FindAll();
                viewModel.List = statusanggota.ToList();
                viewModel.DataCount = viewModel.List.Count;

                var cacheValue = JsonSerializer.Serialize(viewModel);
                _cache.SetCache("MasterData_StatusAnggota", cacheValue);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return View(viewModel);
        }
        #endregion

        #region StatusKeaktifan
        public async Task<IActionResult> StatusKeaktifanIndex()
        {
            StatusKeaktifanViewModel viewModel = new StatusKeaktifanViewModel();

            try
            {
                var statuskeaktifan = await _repository.StatusKeaktifan.FindAll();
                viewModel.List = statuskeaktifan.ToList();
                viewModel.DataCount = viewModel.List.Count;

                var cacheValue = JsonSerializer.Serialize(viewModel);
                _cache.SetCache("MasterData_StatusKeaktifan", cacheValue);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return View(viewModel);
        }
        #endregion
    }
}