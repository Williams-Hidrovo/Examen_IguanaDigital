using Iguana.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iguana.Application.Contracts
{
    public interface IUser
    {
        Task<ICollection<UserDTO>> GetUsers();
        Task<bool> postUser(UserDTO userDTO);
        Task<bool> putUser(UserDTO userDTO, int userID);
        Task<bool> deleteUser(int userID);
    }
}
