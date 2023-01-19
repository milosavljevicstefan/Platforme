using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Services
{
    interface IUserService
    {
        void SaveUsers(Object obj);

        void ReadUsers();

        void DeleteUser(string email);

        void UpdateUser(object obj);
    }
}
