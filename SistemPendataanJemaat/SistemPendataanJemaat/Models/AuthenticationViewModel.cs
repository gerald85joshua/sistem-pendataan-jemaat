using Microsoft.AspNetCore.Mvc;
using SistemPendataanJemaat.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemPendataanJemaat.Models
{
    public class AuthenticationViewModel
    {
        public UserEntityModel User { get; set; }
        
        public string Token { get; set; }

        public string ErrorMessage { get; set; }
    }
}
