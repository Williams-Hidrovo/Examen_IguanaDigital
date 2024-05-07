﻿using Iguana.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iguana.Application.Contracts
{
    public interface ICargo
    {
        Task<ICollection<CargoDTO>> GetCargos();
    }
}
