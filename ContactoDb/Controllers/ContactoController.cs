using Microsoft.AspNetCore.Mvc;
using ContactoDb.Datos;
using ContactoDb.Models;
using System.Security.Cryptography.X509Certificates;

namespace ContactoDb.Controllers
{
    public class ContactoController : Controller
    {
        ContactosDatos contactosDatos=new ContactosDatos();
        public IActionResult Listar()
        {
            var lista = contactosDatos.Listar();
            return View(lista);//hola
        }
        [HttpGet]
        public IActionResult Guardar()
        {
            return View();  
        }
        [HttpPost]
        public IActionResult Guardar(ContactoModel model)
        {
            if (!ModelState.IsValid) 
            {
                return View();
            }
            var respuesta= contactosDatos.GuardarContacto(model);
            if (respuesta)
                return RedirectToAction("Listar");
            else
            {
                return View();
            }
            
        }
        [HttpGet]
        public IActionResult Editar(int IdContacto)
        {
            ContactoModel contacto = contactosDatos.ObtenerContacto(IdContacto);
            return View(contacto);
        }
        [HttpPost]
        public IActionResult Editar(ContactoModel model)
        {
            var resultado = contactosDatos.EditarContacto(model);
            if (resultado)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }
        //Eliminar
        [HttpGet]
        public IActionResult Eliminar(int idContacto) {
            var contacto = contactosDatos.ObtenerContacto(idContacto);
            return View(contacto);
        }
        [HttpPost]
        public IActionResult Eliminar(ContactoModel model)
        {
            var resultado = contactosDatos.EliminarContacto(model);
            if(resultado)
            {
                return RedirectToAction("Listar");
            }
            else
            { 
                return View();    
            }
        }
    }
}
