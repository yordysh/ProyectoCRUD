using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUDCORE.Models;
using CRUDCORE.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace CRUDCORE.Controllers
{
    public class HomeController : Controller
    {
        private readonly LUGARContext _DBContext;

        public HomeController(LUGARContext context)
        {
            _DBContext = context;
        }

        public IActionResult Index()
        {
            List<Trabajadore> lista = _DBContext.Trabajadores.Include(t => t.oDistrito).Include(p => p.oProvincium).Include(d => d.oDepartamento).ToList();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Trabajador_Detalle(int idTrabajador)
        {
            TrabajadorVM oTrabajadorVM = new TrabajadorVM()
            {
                oTrabajador = new Trabajadore(),
                oListaDepartamento = _DBContext.Departamentos.Select(departamento => new SelectListItem()
                {
                    Text = departamento.NombreDepartamento,
                    Value = departamento.Id.ToString()
                }).ToList(),
                oListaProvincia = _DBContext.Provincia.Select(provincia => new SelectListItem()
                {
                    Text = provincia.NombreProvincia,
                    Value = provincia.Id.ToString()
                }
                ).ToList(),
                oListaDistrito = _DBContext.Distritos.Select(distrito =>new SelectListItem()
                {
                    Text=distrito.NombreDistrito,
                    Value = distrito.Id.ToString()
                }).ToList()
                

            };

            if(idTrabajador != 0)
            {
                oTrabajadorVM.oTrabajador = _DBContext.Trabajadores.Find(idTrabajador);
            }
            return View(oTrabajadorVM);

        }

        [HttpPost]
        public IActionResult Trabajador_Detalle(TrabajadorVM oTrabajadorVM)
        {
            if (oTrabajadorVM.oTrabajador.Id == 0)
            {
                _DBContext.Trabajadores.Add(oTrabajadorVM.oTrabajador);
            }
            else
            {
                _DBContext.Trabajadores.Update(oTrabajadorVM.oTrabajador);
            }
            _DBContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Eliminar(int idTrabajador)
        {
            Trabajadore oTrabajador = _DBContext.Trabajadores.Include(d => d.oDepartamento).Include(p=>p.oProvincium).Include(d=>d.oDistrito).Where(t => t.Id == idTrabajador).FirstOrDefault();
            return View(oTrabajador);

        }

        [HttpPost]
        public IActionResult Eliminar(Trabajadore oTrabajador)
        {
            _DBContext.Trabajadores.Remove(oTrabajador);
            _DBContext.SaveChanges();
            //return View(oTrabajador);

            return RedirectToAction("Index", "Home");

        }
    }
}