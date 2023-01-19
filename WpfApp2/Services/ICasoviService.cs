using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Services
{
    public interface ICasoviService
    {
        void SacuvajCas(Object obj);
        void ProcitajCasove();
        void IzbrisiCas(string id);
        void IzmeniCas(Object obj);
    }
}
