using Microsoft.AspNetCore.Mvc;
using SistemPendataanJemaat.Interfaces;
using SistemPendataanJemaat.Models;
using System;
using System.Text.Json;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        public IActionResult JemaatIndex()
        {
            JemaatViewModel viewModel = new JemaatViewModel();

            try
            {
                var jemaat = _repository.Jemaat.FindAll();
                var vw_jemaat = _repository.VwJemaat.FindAll();
                viewModel.List = jemaat.OrderBy(o => o.Nama_Lengkap).ToList();
                viewModel.VwList = vw_jemaat.OrderBy(o => o.Nama_Lengkap).ToList();
                viewModel.ddlGolonganDarah = addGolonganDarah();
                viewModel.DataCount = viewModel.List.Count;

                var cacheValue = JsonSerializer.Serialize(viewModel);
                _cache.SetCache("DataJemaat_Jemaat", cacheValue);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return View(viewModel);
        }

        private List<SelectListItem> addGolonganDarah()
        {
            List<SelectListItem> result = new List<SelectListItem>();

            result.Add(new SelectListItem
            {
                Text = "<unknown>",
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
            ViewBag.IsEdit = haveId ? true : false;
            JemaatViewModel viewModel = new JemaatViewModel();

            try
            {
                var cacheValue = _cache.GetCache("DataJemaat_Jemaat");
                viewModel = JsonSerializer.Deserialize<JemaatViewModel>(cacheValue);

                if (haveId)
                {
                    viewModel.Single = viewModel.List.Where(p => p.ID.ToString() == id).FirstOrDefault();
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
        public IActionResult JemaatAddEdit(JemaatViewModel req)
        {
            var jemaat = req.Single;

            try
            {
                if (jemaat.ID == null)
                {
                    jemaat.ID = Guid.NewGuid();
                    _repository.Jemaat.Create(jemaat);
                }
                else
                {
                    _repository.Jemaat.Update(jemaat);
                }

                _repository.Save();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return RedirectToAction("JemaatIndex");
        }

        public IActionResult JemaatDetail(string id)
        {
            JemaatViewModel viewModel = new JemaatViewModel();

            try
            {
                var cacheValue = _cache.GetCache("DataJemaat_Jemaat");
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
        public IActionResult JemaatDelete(string id)
        {
            JemaatViewModel viewModel = new JemaatViewModel();

            try
            {
                var cacheValue = _cache.GetCache("DataJemaat_Jemaat");
                viewModel = JsonSerializer.Deserialize<JemaatViewModel>(cacheValue);
                var jemaat = viewModel.List.Where(p => p.ID.ToString() == id).FirstOrDefault();
                _repository.Jemaat.Delete(jemaat);
                _repository.Save();
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
