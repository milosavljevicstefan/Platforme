using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatPlatforme.Models;

namespace ProjekatPlatforme.Services
{
    interface IProfessorService
    {
        List<RegistrovaniKorisnik> ListAllStudents();
    }
}
