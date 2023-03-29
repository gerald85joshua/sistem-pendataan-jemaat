﻿using Microsoft.AspNetCore.Mvc;
using SistemPendataanJemaat.Interfaces;
using SistemPendataanJemaat.Models;
using System;
using System.Text.Json;
using System.Linq;
using SistemPendataanJemaat.Models.Entities;

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

        private static string GenerateId(int totalRow)
        {
            string result = "KELIB";
            int newRow = totalRow + 1;

            if(newRow < 10)
            {
                result += "0000" + newRow;
            } else if(newRow < 100)
            {
                result += "000" + newRow;
            } else if(newRow < 1000)
            {
                result += "00" + newRow;
            } else if(newRow < 10000)
            {
                result += "0" + newRow;
            } else
            {
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
            } catch(Exception ex)
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
            } catch(Exception ex)
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

                    kelompokIbadah.Kelompok_Ibadah_ID = GenerateId(viewModel.DataCount);
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
    }
}
