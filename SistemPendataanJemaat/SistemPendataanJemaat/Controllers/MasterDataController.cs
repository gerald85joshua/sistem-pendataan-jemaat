using Microsoft.AspNetCore.Mvc;
using SistemPendataanJemaat.Interfaces;
using SistemPendataanJemaat.Models;
using System;
using System.Text.Json;
using System.Linq;

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
        private static string GenerateId(string code, int lastRow)
        {
            string result = code;
            int newRow = lastRow + 1;

            if (newRow < 10)
            {
                result += "0000";
                if (code.Length < 5)
                    result += "0";

                result += newRow;
            }
            else if (newRow < 100)
            {
                result += "000";
                if (code.Length < 5)
                    result += "0";

                result += newRow;
            }
            else if (newRow < 1000)
            {
                result += "00";
                if (code.Length < 5)
                    result += "0";

                result += newRow;
            }
            else if (newRow < 10000)
            {
                result += "0";
                if (code.Length < 5)
                    result += "0";

                result += newRow;
            }
            else
            {
                if (code.Length < 5)
                    result += "0";

                result += newRow;
            }

            return result;
        }

        public IActionResult KelompokIbadahIndex()
        {
            KelompokIbadahViewModel viewModel = new KelompokIbadahViewModel();

            try
            {
                var kelompokIbadah = _repository.KelompokIbadah.FindAll();
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
        public IActionResult KelompokIbadahAddEdit(KelompokIbadahViewModel req)
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

                    kelompokIbadah.Kelompok_Ibadah_ID = GenerateId("KELIB", lastRow);
                    _repository.KelompokIbadah.Create(kelompokIbadah);
                }
                else
                {
                    _repository.KelompokIbadah.Update(kelompokIbadah);
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
        public IActionResult KelompokIbadahDelete(string id)
        {
            KelompokIbadahViewModel viewModel = new KelompokIbadahViewModel();

            try
            {
                var cacheValue = _cache.GetCache("MasterData_KelompokIbadah");
                viewModel = JsonSerializer.Deserialize<KelompokIbadahViewModel>(cacheValue);
                var kelompokIbadah = viewModel.List.Where(p => p.Kelompok_Ibadah_ID == id).FirstOrDefault();
                _repository.KelompokIbadah.Delete(kelompokIbadah);
                _repository.Save();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return RedirectToAction("KelompokIbadahIndex");
        }
        #endregion

        #region Area
        public IActionResult AreaIndex()
        {
            AreaViewModel viewModel = new AreaViewModel();

            try
            {
                var area = _repository.Area.FindAll();
                viewModel.List = area.ToList();
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

        #region Komsel
        public IActionResult KomselIndex()
        {
            KomselViewModel viewModel = new KomselViewModel();

            try
            {
                var komsel = _repository.Komsel.FindAll();
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
        public IActionResult StatusAnggotaIndex()
        {
            StatusAnggotaViewModel viewModel = new StatusAnggotaViewModel();

            try
            {
                var statusanggota = _repository.StatusAnggota.FindAll();
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
        public IActionResult StatusKeaktifanIndex()
        {
            StatusKeaktifanViewModel viewModel = new StatusKeaktifanViewModel();

            try
            {
                var statuskeaktifan = _repository.StatusKeaktifan.FindAll();
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