﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Services
{
    public interface ICasoviService
    {
        void SacuvajCas(string filename);
        void ProcitajCasove(string filename);
        void IzbrisiCas(string id);
    }
}
