using Microsoft.AspNetCore.Mvc;
using SistemPendataanJemaat.Interfaces;
using SistemPendataanJemaat.Models;
using SistemPendataanJemaat.Models.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;
using bc = BCrypt.Net.BCrypt;

namespace SistemPendataanJemaat.Controllers
{
    public class AuthenticationController : BaseController
    {
        private readonly IRepositoryWrapper _repository;

        public AuthenticationController(IRepositoryWrapper repository, ICacheHelper cache) : base(cache)
        {
            _repository = repository;
        }

        public IActionResult Login()
        {
            var viewModel = new AuthenticationViewModel();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AuthenticationViewModel req)
        {
            try
            {
                var repoUser = await _repository.User.FindByCondition(p => p.User_Name == req.User.User_Name);
                var user = repoUser.FirstOrDefault();
                if (user == null)
                {
                    req.ErrorMessage = "User Name not found!";
                    return View(req);
                }

                bool isUserValid = bc.Verify(req.User.User_Password, user.User_Password);
                if (!isUserValid)
                {
                    req.ErrorMessage = "Wrong password!";
                    return View(req);
                }

                user.Is_Login = true;
                await _repository.User.Update(user);
                OnLogin(user);

                return RedirectToAction("Index", "Home");
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            try
            {
                var userLogin = UserLogin();
                var repoUser = await _repository.User.FindByCondition(p => p.User_Name == userLogin.User_Name);
                var user = repoUser.FirstOrDefault();
                user.Is_Login = false;
                await _repository.User.Update(user);

                OnLogout();

                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IActionResult Register()
        {
            var viewModel = new AuthenticationViewModel();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(AuthenticationViewModel req)
        {
            try
            {
                var repoUserName = await _repository.User.FindByCondition(p => p.User_Name == req.User.User_Name);
                var userName = repoUserName.FirstOrDefault();
                if (userName != null)
                {
                    req.ErrorMessage = "User Name already exist!";
                    return View(req);
                }

                var repoEmail = await _repository.User.FindByCondition(p => p.User_Email == req.User.User_Email);
                var email = repoEmail.FirstOrDefault();
                if (email != null)
                {
                    req.ErrorMessage = "Email already exist!";
                    return View(req);
                }

                var payload = new UserEntityModel {
                    User_Name = req.User.User_Name,
                    User_Email = req.User.User_Email,
                    User_Password = bc.HashPassword(req.User.User_Password),
                    User_Role = "User",
                    Is_Login = false
                };

                await _repository.User.Create(payload);
                return RedirectToAction("RegisterSuccess");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IActionResult RegisterAdminRole()
        {
            var viewModel = new AuthenticationViewModel();
            return View(viewModel);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterAdminRole(AuthenticationViewModel req)
        {
            try
            {
                var repoUserName = await _repository.User.FindByCondition(p => p.User_Name == req.User.User_Name);
                var userName = repoUserName.FirstOrDefault();
                if (userName != null)
                {
                    req.ErrorMessage = "User Name already exist!";
                    return View(req);
                }

                var repoEmail = await _repository.User.FindByCondition(p => p.User_Email == req.User.User_Email);
                var email = repoEmail.FirstOrDefault();
                if (email != null)
                {
                    req.ErrorMessage = "Email already exist!";
                    return View(req);
                }

                var payload = new UserEntityModel
                {
                    User_Name = req.User.User_Name,
                    User_Email = req.User.User_Email,
                    User_Password = BCrypt.Net.BCrypt.HashPassword(req.User.User_Password),
                    User_Role = "Admin",
                    Is_Login = false
                };
                await _repository.User.Create(payload);
                return RedirectToAction("RegisterSuccess");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IActionResult RegisterSuccess()
        {
            return View();
        }
    }
}
