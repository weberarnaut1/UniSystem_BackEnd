using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniSystem_BackEnd.Domain;
using UniSystem_BackEnd.IRepository;
using UniSystem_BackEnd.IServices;
using UniSystem_BackEnd.Repository;

namespace UniSystem_BackEnd.Services
{
    public class Usuario_Service : IUsuario_Service
    {
        private readonly IUsuario_Repository _usuarioRepository;
        public Usuario_Service() {
            _usuarioRepository = new Usuario_Repository();
        }
        public IEnumerable<Usuario_Domain> GetAllUsuario()
        {
            try
            {
                return _usuarioRepository.GetAllUsuario();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UR001"))
                {
                    throw new Exception(ex.Message, ex);
                }
                else
                {
                    throw new Exception("US001 - Erro ao buscar lista de usuários. ", ex);
                }
            }
        }
        public void CreateUsuario(Usuario_Domain Usuario)
        {
            try
            {
                _usuarioRepository.CreateUsuario(Usuario);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UR002"))
                {
                    throw new Exception("", ex);
                }
                else
                {
                    throw new Exception("US002 - Erro ao inserir usuário. ", ex);
                }
            }
        }
        public void AlterUsuario(Usuario_Domain Usuario)
        {
            try
            {
                _usuarioRepository.AlterUsuario(Usuario);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UR003"))
                {
                    throw new Exception("", ex);
                }
                else
                {
                    throw new Exception("US003 - Erro ao alterar usuário. ", ex);
                }
            }
        }
        public void DeleteUsuario(long Id)
        {
            try
            {
                _usuarioRepository.DeleteUsuario(Id);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UR004"))
                {
                    throw new Exception("", ex);
                }
                else
                {
                    throw new Exception("US004 - Erro ao excluir usuário. ", ex);
                }
            }
        }
    }
}
