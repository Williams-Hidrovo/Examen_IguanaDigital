using AutoMapper;
using Iguana.Api.Models;
using Iguana.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iguana.Infraestructure.Mapper
{
    public class MapperServices : Profile
    {
        public MapperServices() 
        {
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();

            CreateMap<CargoDTO, Cargo>();
            CreateMap<Cargo, CargoDTO>();

            CreateMap<DepartamentoDTO, Departamento>();
            CreateMap<Departamento, DepartamentoDTO>();
        }
    }
}
