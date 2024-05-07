using Iguana.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iguana.Domain.DTO
{
    public class CargoDTO
    {
        public int Id { get; set; }

        public string? Codigo { get; set; }

        public string? Nombre { get; set; }

        public bool? Activo { get; set; }

        public int? IdUsuarioCreacion { get; set; }

        public virtual User? IdUsuarioCreacionNavigation { get; set; }
    }
}
