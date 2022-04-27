using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcApiPersonajesAWS.Controllers
{
    public class PersonajesController : Controller
    {
        public IActionResult IndexCliente()
        {
            return View();
        }
    }
}
