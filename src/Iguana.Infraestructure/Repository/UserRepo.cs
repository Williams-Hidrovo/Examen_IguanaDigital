using AutoMapper;
using Iguana.Api.Models;
using Iguana.Application.Contracts;
using Iguana.Domain.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Iguana.Infraestructure.Repository
{
    public class UserRepo : IUser
    {

        private readonly PruebasContext _context;
        private readonly IMapper _mapper;

        public UserRepo(PruebasContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> deleteUser(int userID)
        {
            try
            {
                var response = await _context.Users.FirstOrDefaultAsync(x => x.Id == userID);
                if(response == null)
                {
                    return false;
                }
                else
                {
                    _context.Users.Remove(response);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new NotFiniteNumberException(ex.Message);
            }
        }

        public async Task<ICollection<UserDTO>> GetUsers()
        {
            try
            {
                ICollection<UserDTO> usersList = new List<UserDTO>();
                var response = await _context.Users.ToListAsync();
                foreach (var user in response)
                {
                    var mapp = _mapper.Map<UserDTO>(user);
                    usersList.Add(mapp);
                }
                return usersList;
            }
            catch (Exception ex)
            {
                throw new NotFiniteNumberException(ex.Message);
            }
        }

        public async Task<bool> postUser(UserDTO userDTO)
        {
            try
            {
                var response = await _context.Users.FirstOrDefaultAsync(c => c.Usuario == userDTO.Usuario);
                if(response == null)
                {
                    var mapp = _mapper.Map<User>(userDTO);

                    var random = new Random();

                    mapp.Id = random.Next(0, 1000000);

                    _context.Users.Add(mapp);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new NotFiniteNumberException(ex.Message);
            }
        }

        public async Task<bool> putUser(UserDTO userDTO, int userID)
        {
            try
            {
                var response = await _context.Users.FirstOrDefaultAsync(c => c.Id == userID);
                if (response != null)
                {
                    var mapp = _mapper.Map(userDTO, response);

                    _context.Users.Update(response);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new NotFiniteNumberException(ex.Message);
            }
        }
    }
}
