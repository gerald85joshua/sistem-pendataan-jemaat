using Microsoft.AspNetCore.Mvc;
using SistemPendataanJemaat.Interfaces;
using SistemPendataanJemaat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemPendataanJemaat.Controllers
{
    public class MasterDataController : Controller
    {
        private IRepositoryWrapper _repository;

        public MasterDataController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public IActionResult KelompokIbadahIndex()
        {
            KelompokIbadahViewModel result = new KelompokIbadahViewModel();

            try
            {
                var kelompokIbadah = _repository.KelompokIbadah.FindAll();
                result.List = kelompokIbadah.Select(s => new KelompokIbadahModel
                {
                    KelompokIbadahID = s.Kelompok_Ibadah_ID,
                    KelompokIbadah = s.Kelompok_Ibadah,
                    PicID = s.PIC_ID,
                    Keterangan = s.Keterangan
                }).ToList();
                result.DataCount = result.List.Count();
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return View(result);
        }
    }
}
