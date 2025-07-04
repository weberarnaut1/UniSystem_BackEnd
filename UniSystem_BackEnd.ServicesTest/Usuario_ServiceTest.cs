using UniSystem_BackEnd.IServices;
using UniSystem_BackEnd.Libs;
using UniSystem_BackEnd.RepositoryTest.Lib;
using UniSystem_BackEnd.Services;

namespace UniSystem_BackEnd.ServicesTest
{
    public class Usuario_ServiceTest
    {
        private readonly IUsuario_Service _usuarioService;
        private BogusGenerator _bogusGenerator;
        private Usuario_Lib _usuario_Lib;
        public Usuario_ServiceTest()
        {
            _usuario_Lib = new Usuario_Lib();
            _bogusGenerator = new BogusGenerator();
            _usuarioService = new Usuario_Service();
        }
        [Fact]
        public void GetAllUsuarioTest()
        {
            var exception = Record.Exception(() => _usuarioService.GetAllUsuario());
            Assert.Null(exception);
            Assert.IsType<List<Domain.Usuario_Domain>>(_usuarioService.GetAllUsuario());
            Assert.NotNull(_usuarioService.GetAllUsuario());
            Assert.NotEmpty(_usuarioService.GetAllUsuario());
            Assert.True(_usuarioService.GetAllUsuario().Any());
            Assert.All(_usuarioService.GetAllUsuario(), item => Assert.IsType<Domain.Usuario_Domain>(item));
        }

        [Fact]
        public void CreateUsuarioTest()
        {
            var usuario = new Domain.Usuario_Domain
            {
                Nome = _bogusGenerator.GerarNomeCompleto(),
                Email = _bogusGenerator.GerarEmail(),
                Dt_Nascimento = new DateTime(1990, 1, 1),
                Login = _bogusGenerator.GerarLogin()
            };

            var exception = Record.Exception(() => _usuarioService.CreateUsuario(usuario));
            Assert.Null(exception);

            IEnumerable<Domain.Usuario_Domain> usuarios = _usuarioService.GetAllUsuario();
            bool usuariocriado = usuarios.Any(n => n.Login == usuario.Login);

            Assert.True(usuariocriado);
        }

        [Fact]
        public void AlterUsuarioTest()
        {
            IEnumerable<Domain.Usuario_Domain> usuarios = _usuarioService.GetAllUsuario();

            Random random = new Random();

            Domain.Usuario_Domain usuario = _usuario_Lib.GetUsuarioAleatorio(usuarios, random);

            Domain.Usuario_Domain usuarioAtualizado = new Domain.Usuario_Domain
            {
                Id = usuario.Id,
                Nome = _bogusGenerator.GerarNomeCompleto(),
                Email = _bogusGenerator.GerarEmail(),
                Dt_Nascimento = usuario.Dt_Nascimento,
                Login = usuario.Login
            };
            var exception = Record.Exception(() => _usuarioService.AlterUsuario(usuarioAtualizado));
            Assert.Null(exception);
            IEnumerable<Domain.Usuario_Domain> usuariosAtualizados = _usuarioService.GetAllUsuario();
            bool usuarioAlterado = usuariosAtualizados.Any(n => n.Id == usuarioAtualizado.Id && n.Nome == usuarioAtualizado.Nome);
            Assert.True(usuarioAlterado);
        }

        [Fact]
        public void DeleteUsuarioTest()
        {
            IEnumerable<Domain.Usuario_Domain> usuarios = _usuarioService.GetAllUsuario();
            Random random = new Random();
            Domain.Usuario_Domain usuario = _usuario_Lib.GetUsuarioAleatorio(usuarios, random);
            var exception = Record.Exception(() => _usuarioService.DeleteUsuario(usuario.Id));
            Assert.Null(exception);
            IEnumerable<Domain.Usuario_Domain> usuariosAtualizados = _usuarioService.GetAllUsuario();
            bool usuarioDeletado = usuariosAtualizados.Any(n => n.Id == usuario.Id);
            Assert.False(usuarioDeletado);
        }
    }
}