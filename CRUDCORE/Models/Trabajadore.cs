﻿using System;
using System.Collections.Generic;

namespace CRUDCORE.Models
{
    public partial class Trabajadore
    {
        public int Id { get; set; }
        public string? TipoDocumento { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? Nombres { get; set; }
        public string? Sexo { get; set; }
        public int? IdDepartamento { get; set; }
        public int? IdProvincia { get; set; }
        public int? IdDistrito { get; set; }

        public virtual Departamento? oDepartamento { get; set; }
        public virtual Distrito? oDistrito { get; set; }
        public virtual Provincium? oProvincium { get; set; }
    }
}
