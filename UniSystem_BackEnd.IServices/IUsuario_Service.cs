using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniSystem_BackEnd.Domain;

namespace UniSystem_BackEnd.IServices
{
    public  interface IUsuario_Service
    {
        IEnumerable<Usuario_Domain> GetAllUsuario();
        void CreateUsuario(Usuario_Domain Usuario);
        void AlterUsuario(Usuario_Domain Usuario);
        void DeleteUsuario(long Id);
    }
}
