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
        public int IdModelo { get; set; }
        public string Descripcion1 { get; set; }

        public virtual Modelo IdModeloNavigation { get; set; }
    }
}
