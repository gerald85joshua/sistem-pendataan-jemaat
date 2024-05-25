using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Mvc.Filters;
using SistemPendataanJemaat.Models.Entities;
using System.Collections.Generic;
using SistemPendataanJemaat.Interfaces;
using System.Text.Json;

namespace SistemPendataanJemaat.Controllers
{
    public class BaseController : Controller
    {
        private readonly ICacheHelper _cache;

        public BaseController(ICacheHelper cache)
        {
            _cache = cache;
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

        public void OnLogin(UserEntityModel user)
        {
            var token = generateToken();
            _cache.SetCache("User_Token", token);
            _cache.SetCache(token, JsonSerializer.Serialize(user));
        }

        public void OnLogout()
        {
            var token = _cache.GetCache("User_Token");
            _cache.SetCache(token, null);
            _cache.SetCache("User_Token", null);
        }

        public UserEntityModel UserLogin()
        {
            var token = _cache.GetCache("User_Token");
            var userJson = _cache.GetCache(token);

            return JsonSerializer.Deserialize<UserEntityModel>(userJson);
        }

        private bool _validUser()
        {
            bool result = false;
            var token = _cache.GetCache("User_Token");

            if (token != null)
            {
                var userJson = _cache.GetCache(token);

                if (userJson != null)
                {
                    result = true;
                }
            }

            return result;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!_validUser() && context.ActionDescriptor.RouteValues["controller"] != "Authentication")
            {
                context.Result = RedirectToAction("Login", "Authentication");
            }

            base.OnActionExecuting(context);
        }
    }
}
