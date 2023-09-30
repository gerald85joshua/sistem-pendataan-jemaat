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

            await LoadDataJemaat();
            var cacheValue = _cache.GetCache("DataJemaat_Jemaat");
            viewModel = JsonSerializer.Deserialize<JemaatViewModel>(cacheValue);

            return View(viewModel);
        }

        private async Task LoadDataJemaat()
        {
            JemaatViewModel viewModel = new JemaatViewModel();

            try
            {
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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
                    await LoadDataJemaat();
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

        #region Pernikahan
        public async Task<IActionResult> PernikahanIndex()
        {
            PernikahanViewModel viewModel;

            await LoadDataPernikahan();
            var cacheValue = _cache.GetCache("DataJemaat_Pernikahan");
            viewModel = JsonSerializer.Deserialize<PernikahanViewModel>(cacheValue);

            return View(viewModel);
        }

        private async Task LoadDataPernikahan()
        {
            PernikahanViewModel viewModel = new PernikahanViewModel();

            try
            {
                var pernikahan = await _repository.Pernikahan.FindAll();
                var vw_pernikahan = await _repository.VwPernikahan.FindAll();
                var pernikahan_detail = await _repository.PernikahanDetail.FindAll();
                var vw_pernikahan_detail = await _repository.VwPernikahanDetail.FindAll();
                // get jemaat yg belum menikah dan yg bukan status = meninggal
                var jemaat = await _repository.Jemaat.FindByCondition(p => p.Status_Pernikahan_ID != "STPER00001" && p.Status_Keaktifan_ID != "JM");
                var id_jemaat = jemaat.Select(s => s.ID.ToString()).ToList();
                var ddl_jemaat = await _repository.DdlJemaat.FindByCondition(p => id_jemaat.Contains(p.Value));
                var ddl_status_keaktifan = await _repository.DdlStatusKeaktifan.FindAll();

                viewModel.List = pernikahan.ToList();
                viewModel.VwList = vw_pernikahan.OrderBy(o => o.Pasangan).ToList();
                viewModel.ListDetail = pernikahan_detail.ToList();
                viewModel.VwListDetail = vw_pernikahan_detail.ToList();
                viewModel.DdlJemaat = GeneralHelper.addDdl(ddl_jemaat);
                viewModel.DdlStatusKeaktifan = GeneralHelper.addDdl(ddl_status_keaktifan);
                viewModel.DataCount = viewModel.List.Count;

                var cacheValue = JsonSerializer.Serialize(viewModel);
                _cache.SetCache("DataJemaat_Pernikahan", cacheValue);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IActionResult> _PernikahanDataJemaat(string idJemaat, string dataSource)
        {
            PernikahanViewModel viewModel = new PernikahanViewModel();

            try
            {
                var data_jemaat = await _repository.Jemaat.FindByCondition(p => idJemaat == p.ID.ToString());
                var cacheValue = _cache.GetCache("DataJemaat_Pernikahan");
                viewModel = JsonSerializer.Deserialize<PernikahanViewModel>(cacheValue);

                if (data_jemaat != null)
                {
                    var existingCache = _cache.GetCache("DataJemaat_Pernikahan_Detail");
                    PernikahanViewModel existingData = new PernikahanViewModel();
                    if (existingCache != null)
                    {
                        existingData = JsonSerializer.Deserialize<PernikahanViewModel>(existingCache);
                    }

                    if (dataSource == "jemaat")
                    {
                        viewModel.DataJemaatDetail = data_jemaat.FirstOrDefault();
                        viewModel.DataPasanganDetail = existingData.DataPasanganDetail;
                    }
                    else
                    {
                        viewModel.DataPasanganDetail = data_jemaat.FirstOrDefault();
                        viewModel.DataJemaatDetail = existingData.DataJemaatDetail;
                    }
                }

                cacheValue = JsonSerializer.Serialize(viewModel);
                _cache.SetCache("DataJemaat_Pernikahan_Detail", cacheValue);
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            ViewBag.DataSource = dataSource;
            return PartialView(viewModel);
        }

        public async Task<IActionResult> PernikahanAddEdit(string id)
        {
            bool haveId = !string.IsNullOrEmpty(id);
            ViewBag.PageName = haveId ? "Edit Data Pernikahan" : "Create Data Pernikahan";
            ViewBag.IsEdit = haveId;
            PernikahanViewModel viewModel = new PernikahanViewModel();

            try
            {
                var cacheValue = _cache.GetCache("DataJemaat_Pernikahan");
                viewModel = JsonSerializer.Deserialize<PernikahanViewModel>(cacheValue);

                if (haveId)
                {
                    viewModel.Single = viewModel.List.Where(p => p.ID.ToString() == id).FirstOrDefault();
                    var pernikahan_detail = viewModel.VwListDetail.Where(p => p.ID_Pernikahan.ToString() == id).ToList();
                    var suggestion_jemaat = viewModel.VwListDetail.Where(p => p.ID_Pernikahan.ToString() == id && p.Status_Keaktifan_ID == "JA").FirstOrDefault();

                    if (pernikahan_detail.Where(p => p.Status_Keaktifan_ID == "JA").Any())
                    {
                        viewModel.VwJemaatDetail = pernikahan_detail.Where(p => p.Status_Keaktifan_ID == "JA").FirstOrDefault();
                    } else
                    {
                        viewModel.VwJemaatDetail = pernikahan_detail.FirstOrDefault();
                    }

                    viewModel.VwPasanganDetail = pernikahan_detail.Where(p => p.ID != viewModel.VwJemaatDetail.ID).FirstOrDefault();
                    viewModel.IsPasanganJemaat = viewModel.VwPasanganDetail.Status_Keaktifan_ID == "JA";

                    List<Guid> id_jemaat = new List<Guid>();
                    id_jemaat.Add((Guid)viewModel.VwJemaatDetail.ID_Jemaat);
                    id_jemaat.Add((Guid)viewModel.VwPasanganDetail.ID_Jemaat);
                    var data_jemaat = await _repository.Jemaat.FindByCondition(p => id_jemaat.Contains((Guid)p.ID));

                    viewModel.DataJemaatDetail = data_jemaat.Where(p => p.ID == viewModel.VwJemaatDetail.ID_Jemaat).FirstOrDefault();
                    viewModel.DataPasanganDetail = data_jemaat.Where(p => p.ID == viewModel.VwPasanganDetail.ID_Jemaat).FirstOrDefault();
                }
                else
                {
                    viewModel.Single = new PernikahanEntityModel();
                    viewModel.Single.Tanggal_Pernikahan = DateTime.Now;
                    viewModel.JemaatDetail = new PernikahanDetailEntityModel();
                    viewModel.PasanganDetail = new PernikahanDetailEntityModel();
                    viewModel.DataJemaatDetail = new JemaatEntityModel();
                    viewModel.DataPasanganDetail = new JemaatEntityModel();
                    viewModel.DataPasanganDetail.Tanggal_Lahir = DateTime.Now;
                }

                cacheValue = JsonSerializer.Serialize(viewModel);
                _cache.SetCache("DataJemaat_Pernikahan", cacheValue);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return View(viewModel);
        }

        private void _postPernikahanFallback(PernikahanViewModel req, PernikahanViewModel dataPernikahan)
        {
            if (req.DdlJemaat == null)
            {
                req.DdlJemaat = dataPernikahan.DdlJemaat;
            }

            if (req.DdlStatusKeaktifan == null)
            {
                req.DdlStatusKeaktifan = dataPernikahan.DdlStatusKeaktifan;
            }

            if (req.DataJemaatDetail == null)
            {
                req.DataJemaatDetail = dataPernikahan.DataJemaatDetail;
            }

            if (req.DataPasanganDetail == null)
            {
                req.DataPasanganDetail = dataPernikahan.DataPasanganDetail;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PernikahanAddEdit(PernikahanViewModel req)
        {
            var pernikahan = req.Single;
            var jemaat_detail = req.JemaatDetail;
            var pasangan_detail = req.PasanganDetail;

            try
            {
                if (pernikahan.ID == null)
                {
                    ViewBag.IsEdit = false;
                    var cacheValue = _cache.GetCache("DataJemaat_Pernikahan");
                    var cacheValueDetail = _cache.GetCache("DataJemaat_Pernikahan_Detail");
                    var data_pernikahan = JsonSerializer.Deserialize<PernikahanViewModel>(cacheValue);

                    if (cacheValueDetail == null)
                    {
                        ViewBag.ValidationMessage = "Lengkapi data!";
                        _postPernikahanFallback(req, data_pernikahan);

                        return View(req);
                    }

                    var data_pernikahan_detail = JsonSerializer.Deserialize<PernikahanViewModel>(cacheValueDetail);
                    if (req.DataJemaatDetail == null)
                    {
                        if (data_pernikahan_detail.DataJemaatDetail.Nama_Lengkap == null)
                        {
                            ViewBag.ValidationMessage = "Lengkapi data jemaat!";
                            _postPernikahanFallback(req, data_pernikahan);

                            return View(req);
                        }
                        
                        req.DataJemaatDetail = data_pernikahan_detail.DataJemaatDetail;
                    }

                    if (req.DataPasanganDetail.Nama_Lengkap == null)
                    {
                        if (data_pernikahan_detail.DataPasanganDetail.Nama_Lengkap == null)
                        {
                            ViewBag.ValidationMessage = "Lengkapi data pasangan!";
                            _postPernikahanFallback(req, data_pernikahan);

                            return View(req);
                        }

                        req.DataPasanganDetail = data_pernikahan_detail.DataPasanganDetail;
                    }

                    // check valid pernikahan
                    if (req.IsPasanganJemaat && req.DataJemaatDetail.Jenis_Kelamin == req.DataPasanganDetail.Jenis_Kelamin)
                    {
                        ViewBag.ValidationMessage = "Jenis kelamin tidak boleh sama!";
                        _postPernikahanFallback(req, data_pernikahan);

                        return View(req);
                    }

                    pernikahan.ID = Guid.NewGuid();
                    pernikahan.Created_By = "System";
                    pernikahan.Created_Date = DateTime.Now;
                    pernikahan.Updated_By = "System";
                    pernikahan.Updated_Date = DateTime.Now;
                    await _repository.Pernikahan.Create(pernikahan);

                    jemaat_detail.ID = Guid.NewGuid();
                    jemaat_detail.ID_Pernikahan = pernikahan.ID;
                    jemaat_detail.Created_By = "System";
                    jemaat_detail.Created_Date = DateTime.Now;
                    jemaat_detail.Updated_By = "System";
                    jemaat_detail.Updated_Date = DateTime.Now;
                    await _repository.PernikahanDetail.Create(jemaat_detail);

                    var data_jemaat = req.DataJemaatDetail;
                    data_jemaat.Status_Keaktifan_ID = data_jemaat.Status_Keaktifan_ID != "JA" ? "JS" : "JA";
                    data_jemaat.Status_Pernikahan_ID = "STPER00001";
                    data_jemaat.Updated_By = "System";
                    data_jemaat.Updated_Date = DateTime.Now;
                    await _repository.Jemaat.Update(data_jemaat);

                    pasangan_detail.ID = Guid.NewGuid();
                    pasangan_detail.ID_Pernikahan = pernikahan.ID;
                    pasangan_detail.ID_Jemaat = Guid.NewGuid();
                    var data_pasangan = req.DataPasanganDetail;
                    if (!req.IsPasanganJemaat)
                    {
                        data_pasangan.ID = pasangan_detail.ID_Jemaat;
                        data_pasangan.Jenis_Kelamin = req.DataJemaatDetail.Jenis_Kelamin == 'L' ? 'P' : 'L';
                        data_pasangan.Status_Keaktifan_ID ??= "JS";
                        data_pasangan.Status_Pernikahan_ID = "STPER00001";
                        data_pasangan.Created_By = "System";
                        data_pasangan.Created_Date = DateTime.Now;
                        data_pasangan.Updated_By = "System";
                        data_pasangan.Updated_Date = DateTime.Now;
                        await _repository.Jemaat.Create(data_pasangan);
                    } else
                    {
                        data_pasangan.Status_Keaktifan_ID = data_pasangan.Status_Keaktifan_ID != "JA" ? "JS" : "JA";
                        data_pasangan.Status_Pernikahan_ID = "STPER00001";
                        data_pasangan.Updated_By = "System";
                        data_pasangan.Updated_Date = DateTime.Now;
                        await _repository.Jemaat.Update(data_pasangan);
                    }
                    pasangan_detail.Created_By = "System";
                    pasangan_detail.Created_Date = DateTime.Now;
                    pasangan_detail.Updated_By = "System";
                    pasangan_detail.Updated_Date = DateTime.Now;
                    await _repository.PernikahanDetail.Create(pasangan_detail);
                }
                else
                {
                    pernikahan.Updated_Date = DateTime.Now;
                    pernikahan.Updated_By = "System";
                    await _repository.Pernikahan.Update(pernikahan);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return RedirectToAction("PernikahanIndex");
        }

        public async Task<IActionResult> PernikahanDetail(string id)
        {
            PernikahanViewModel viewModel = new PernikahanViewModel();

            try
            {
                var cacheValue = _cache.GetCache("DataJemaat_Pernikahan");

                if (cacheValue == null)
                {
                    await LoadDataPernikahan();
                    cacheValue = _cache.GetCache("DataJemaat_Pernikahan");
                }

                viewModel = JsonSerializer.Deserialize<PernikahanViewModel>(cacheValue);
                viewModel.VwSingle = viewModel.VwList.Where(p => p.ID.ToString() == id).FirstOrDefault();
                var detail = viewModel.VwListDetail.Where(p => p.ID_Pernikahan.ToString() == id).ToList();
                var suggestion_jemaat = detail.Where(p => p.Status_Keaktifan_ID == "JA").FirstOrDefault();

                if (suggestion_jemaat != null)
                {
                    viewModel.VwJemaatDetail = detail.Where(p => p.ID == suggestion_jemaat.ID).FirstOrDefault();
                } else
                {
                    viewModel.VwJemaatDetail = detail.FirstOrDefault();
                }

                viewModel.VwPasanganDetail = detail.Where(p => p.ID != viewModel.VwJemaatDetail.ID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PernikahanDelete(string id)
        {
            PernikahanViewModel viewModel = new PernikahanViewModel();

            try
            {
                var cacheValue = _cache.GetCache("DataJemaat_Pernikahan");
                viewModel = JsonSerializer.Deserialize<PernikahanViewModel>(cacheValue);
                var pernikahan = viewModel.List.Where(p => p.ID.ToString() == id).FirstOrDefault();
                var pernikahanDetail = viewModel.ListDetail.Where(p => p.ID_Pernikahan.ToString() == id).FirstOrDefault();

                await _repository.Pernikahan.Delete(pernikahan);
                await _repository.PernikahanDetail.Delete(pernikahanDetail);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return RedirectToAction("PernikahanIndex");
        }
        #endregion
    }
}
