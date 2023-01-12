using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Services
{
    interface IAdresaService
    {
        void SacuvajAdrese(string filename);

        void ProcitajAdrese(string filename);

        void IzbrisiAdresu(string id);
    }
}
