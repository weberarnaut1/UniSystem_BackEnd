using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniSystem_BackEnd.Domain;

namespace UniSystem_BackEnd.Libs
{
    public class Usuario_Lib
    {
        public Usuario_Lib()
        {
        }

        public Domain.Usuario_Domain GetUsuarioAleatorio(IEnumerable<Domain.Usuario_Domain> usuarios, Random random)
        {
            List<Domain.Usuario_Domain> listaUsuarios = usuarios.ToList();

            int indiceAleatorio = random.Next(listaUsuarios.Count);

            return listaUsuarios[indiceAleatorio];

        }
    }
}
