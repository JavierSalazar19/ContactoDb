using Microsoft.AspNetCore.Mvc;
using ContactoDb.Datos;
using ContactoDb.Models;
using ContactoDb.Datos;

namespace ContactoDb.Controllers
{
    public class ContactoController : Controller
    {
        ContactoDatos contactosDatos=new ContactoDatos();
        public IActionResult Listar()
        {
            var lista = contactosDatos.Listar();
            return View(lista);
        }
        [HttpGet]
        public IActionResult Guardar()
        {
            return View();  
        }
        [HttpPost]
        public IActionResult Guardar(ContactoModel model)
        {
            var respuesta= contactosDatos.GuardarContacto(model);
            if (respuesta)
                return RedirectToAction("Listar");
            else
            {
                return View();
            }
            return View();
        }
    }
}
