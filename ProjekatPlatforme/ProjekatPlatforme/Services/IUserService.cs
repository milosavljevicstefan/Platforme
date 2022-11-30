using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatPlatforme.Services
{
    interface IUserService
    {
        void SaveUsers(string filename);

        void ReadUsers(string filename);

        void DeleteUser(string email);
    }
}
