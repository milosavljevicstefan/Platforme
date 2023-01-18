using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Services
{
    interface ISkolaService
    {
        void SacuvajSkolu(Object obj);
        void ProcitajSkolu();
        void IzbrisiAdresu(int id);
    }
}
