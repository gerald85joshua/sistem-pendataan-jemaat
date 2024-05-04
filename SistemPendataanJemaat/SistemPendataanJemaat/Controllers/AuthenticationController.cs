using Microsoft.AspNetCore.Mvc;
using SistemPendataanJemaat.Interfaces;
using SistemPendataanJemaat.Models;
using SistemPendataanJemaat.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using bc = BCrypt.Net.BCrypt;

namespace SistemPendataanJemaat.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IRepositoryWrapper _repository;
        private readonly ICacheHelper _cache;

        public AuthenticationController(IRepositoryWrapper repository, ICacheHelper cache)
        {
            _repository = repository;
            _cache = cache;
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

                var token = generateToken();
                _cache.SetCache("User_Token", token);
                _cache.SetCache(token, JsonSerializer.Serialize(user));

                return RedirectToAction("Index", "Home");
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private string generateToken()
        {
            string result = string.Empty;
            const string AllowedChars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz#@$^*()";
            Random rng = new Random();

            foreach (string randomString in nextStrings(rng, AllowedChars, (15, 64), 25))
            {
                result += randomString;
            }

            return result;
        }

        private static IEnumerable<string> nextStrings(
            Random rnd,
            string allowedChars,
            (int Min, int Max) length,
            int count)
        {
            ISet<string> usedRandomStrings = new HashSet<string>();
            (int min, int max) = length;
            char[] chars = new char[max];
            int setLength = allowedChars.Length;

            while (count-- > 0)
            {
                int stringLength = rnd.Next(min, max + 1);

                for (int i = 0; i < stringLength; ++i)
                {
                    chars[i] = allowedChars[rnd.Next(setLength)];
                }

                string randomString = new string(chars, 0, stringLength);

                if (usedRandomStrings.Add(randomString))
                {
                    yield return randomString;
                }
                else
                {
                    count++;
                }
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
