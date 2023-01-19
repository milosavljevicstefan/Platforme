using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Services
{
    interface IAdresaService
    {
        void SacuvajAdrese(Object obj);

        void ProcitajAdrese();

        void IzbrisiAdresu(string id);
        void IzmeniAdresu(Object obj);
    }
}
