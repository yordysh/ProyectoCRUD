using Microsoft.AspNetCore.Mvc.Rendering;

namespace CRUDCORE.Models.ViewModels
{
    public class TrabajadorVM
    {
        public Trabajadore oTrabajador { get; set; }
        public List<SelectListItem> oListaProvincia { get; set; }
        public List<SelectListItem> oListaDistrito { get; set; }
        public List<SelectListItem> oListaDepartamento { get; set; }
    }
}
