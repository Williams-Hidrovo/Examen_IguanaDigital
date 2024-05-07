using AutoMapper;
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
    public class DepartamentoRepo : IDepartamento
    {
        private readonly PruebasContext _context;
        private readonly IMapper _mapper;

        public DepartamentoRepo(PruebasContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ICollection<DepartamentoDTO>> GetDepartamentos()
        {
            try
            {
                ICollection<DepartamentoDTO> departamentos = new List<DepartamentoDTO>();
                var response = await _context.Departamentos.ToListAsync();
                foreach (var depa in response)
                {
                    var mapper = _mapper.Map<DepartamentoDTO>(depa);
                    departamentos.Add(mapper);
                }
                return departamentos;
            }
            catch (Exception ex) 
            {
                throw new NotFiniteNumberException(ex.Message);
            }
        }
    }
}
