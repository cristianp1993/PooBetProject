using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BetProject.Models
{
    public class persona
    {

        public string per_documento { get; set; }
        public string per_nombre { get; set; }
        public DateTime per_fecha_nac { get; set; }

        public string per_correo { get; set; }
        public string per_genero { get; set; }
        public string per_contrasena { get; set; }

        public IEnumerable<SelectListItem> LsApostadores { get; set; }
    }
}