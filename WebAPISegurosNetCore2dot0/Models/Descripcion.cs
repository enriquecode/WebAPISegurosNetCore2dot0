using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebAPISegurosNetCore2dot0.Models
{
    public partial class Descripcion
    {
        public string DescripcionId { get; set; }
        public int ModeloId { get; set; }
        public string DescripcionDetallada { get; set; }

        public virtual Modelo Modelo { get; set; }
    }
}
