using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Services
{
    interface ISkolaService
    {
        void SacuvajSkolu(string filename);
        void ProcitajSkolu(string filename);
        void IzbrisiAdresu(int id);
    }
}
