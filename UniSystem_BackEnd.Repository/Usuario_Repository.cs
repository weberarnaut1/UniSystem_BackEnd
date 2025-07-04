using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniSystem_BackEnd.Domain;
using UniSystem_BackEnd.IRepository;
using UniSystem_BackEnd.Repository.Lib;

namespace UniSystem_BackEnd.Repository
{
    public class Usuario_Repository : IUsuario_Repository
    {
        DatabaseConnection _dbConnect;
        public Usuario_Repository() {
            _dbConnect = new DatabaseConnection();
        }
        public IEnumerable<Usuario_Domain> GetAllUsuario()
        {
            try
            {
                string Query = "SELECT * FROM public.usuarios";

                var result = _dbConnect.Query<Usuario_Domain>(Query);
                return result;
            }
            catch(Exception ex)
            {
                // Log the exception or handle it as needed
                throw new Exception("UR001 - Erro ao buscar lista de usuários. ", ex);
            }
        }

        public void CreateUsuario(Usuario_Domain Usuario)
        {
            try
            {
                string Query = "INSERT INTO public.usuarios (nome, email, login, dt_nascimento) VALUES (@Nome, @Email, @Login, @Dt_Nascimento)";

                _dbConnect.ExecuteQuery(Query, Usuario);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new Exception("UR002 - Erro ao inserir usuário. ", ex);
            }
        }

        public void AlterUsuario(Usuario_Domain Usuario)
        {
            try
            {
                string Query = "UPDATE public.usuarios SET nome = @Nome, email = @Email, login = @Login, dt_nascimento = @Dt_Nascimento WHERE id = @Id";

                _dbConnect.ExecuteQuery(Query, Usuario);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new Exception("UR003 - Erro ao alterar usuário. ", ex);
            }
        }

        public void DeleteUsuario(long Id)
        {
            try
            {
                string Query = "DELETE FROM public.usuarios WHERE id = @Id";

                _dbConnect.ExecuteQuery(Query, Id);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new Exception("UR004 - Erro ao excluir usuário. ", ex);
            }
        }
    }
}
