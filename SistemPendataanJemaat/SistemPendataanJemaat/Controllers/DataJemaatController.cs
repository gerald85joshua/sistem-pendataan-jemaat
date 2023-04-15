using Microsoft.AspNetCore.Mvc;
using SistemPendataanJemaat.Interfaces;
using SistemPendataanJemaat.Models;
using System;
using System.Text.Json;
using System.Linq;

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

        public IActionResult JemaatIndex()
        {
            JemaatViewModel viewModel = new JemaatViewModel();

            try
            {
                var jemaat = _repository.Jemaat.FindAll();
                viewModel.List = jemaat.OrderBy(o => o.Nama_Lengkap).ToList();
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
    }
}
