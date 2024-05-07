using Iguana.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Iguana.Domain.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string? Usuario { get; set; }

        public string? PrimerNombre { get; set; }

        public string? SegundoNombre { get; set; }

        public string? PrimerApellido { get; set; }

        public string? SegundoApellido { get; set; }

        public int? IdDepartamento { get; set; }

        public int? IdCargo { get; set; }
    }
}
