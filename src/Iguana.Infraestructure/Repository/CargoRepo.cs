using AutoMapper;
using Azure;
using Iguana.Api.Models;
using Iguana.Application.Contracts;
using Iguana.Domain.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iguana.Infraestructure.Repository
{
    public class CargoRepo : ICargo
    {
        private readonly PruebasContext _context;
        private readonly IMapper _mapper;

        public CargoRepo(PruebasContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ICollection<CargoDTO>> GetCargos()
        {
            try
            {
                ICollection<CargoDTO> cargos = new List<CargoDTO>();
                var response = await _context.Cargos.ToListAsync();
                foreach (var cargo in response)
                {
                    var mapp = _mapper.Map<CargoDTO>(cargo);
                    cargos.Add(mapp);
                }
                return cargos;
            }
            catch (Exception ex)
            {
                throw new NotFiniteNumberException(ex.Message);
            }
        }
    }
}
