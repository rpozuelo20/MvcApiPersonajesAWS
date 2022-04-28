using Microsoft.AspNetCore.Mvc;
using MvcApiPersonajesAWS.Models;
using MvcApiPersonajesAWS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcApiPersonajesAWS.Controllers
{
    public class PersonajesController : Controller
    {
        private ServiceApiPersonajes service;
        public PersonajesController(ServiceApiPersonajes service)
        {
            this.service = service;
        }


        public IActionResult IndexCliente()
        {
            return View();
        }
        public async Task<IActionResult> IndexServidor()
        {
            List<Personaje> personajes = await this.service.GetPersonajesAsync();
            return View(personajes);
        }
        public IActionResult CreateServidor()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateServidor(Personaje personaje)
        {
            await this.service.InsertPersonajeAsync(personaje);
            return RedirectToAction("IndexServidor");
        }
    }
}
