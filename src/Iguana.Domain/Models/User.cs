﻿using System;
using System.Collections.Generic;

namespace Iguana.Api.Models;

public partial class User
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
