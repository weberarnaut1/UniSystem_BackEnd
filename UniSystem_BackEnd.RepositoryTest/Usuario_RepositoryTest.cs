using System;
using UniSystem_BackEnd.IRepository;
using UniSystem_BackEnd.Libs;
using UniSystem_BackEnd.Repository;
using UniSystem_BackEnd.RepositoryTest.Lib;

namespace UniSystem_BackEnd.RepositoryTest
{
    public class Usuario_RepositoryTest
    {
        private readonly IUsuario_Repository _usuarioRepository;
        private BogusGenerator _bogusGenerator;
        private Usuario_Lib _usuario_Lib;
        public Usuario_RepositoryTest()
        {
            _usuario_Lib = new Usuario_Lib();
            _bogusGenerator = new BogusGenerator();
            _usuarioRepository = new Usuario_Repository();
        }
        [Fact]
        public void GetAllUsuarioTest()
        {
            var exception = Record.Exception(() => _usuarioRepository.GetAllUsuario());
            Assert.Null(exception);
            Assert.IsType<List<Domain.Usuario_Domain>>(_usuarioRepository.GetAllUsuario());
            Assert.NotNull(_usuarioRepository.GetAllUsuario());
            Assert.NotEmpty(_usuarioRepository.GetAllUsuario());
            Assert.True(_usuarioRepository.GetAllUsuario().Any());
            Assert.All(_usuarioRepository.GetAllUsuario(), item => Assert.IsType<Domain.Usuario_Domain>(item));
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

            var exception = Record.Exception(() => _usuarioRepository.CreateUsuario(usuario));
            Assert.Null(exception);

            IEnumerable<Domain.Usuario_Domain> usuarios = _usuarioRepository.GetAllUsuario();
            bool usuariocriado = usuarios.Any(n => n.Login == usuario.Login);

            Assert.True(usuariocriado);
        }

        [Fact]
        public void AlterUsuarioTest()
        {
            IEnumerable<Domain.Usuario_Domain> usuarios = _usuarioRepository.GetAllUsuario();

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
            var exception = Record.Exception(() => _usuarioRepository.AlterUsuario(usuarioAtualizado));
            Assert.Null(exception);
            IEnumerable<Domain.Usuario_Domain> usuariosAtualizados = _usuarioRepository.GetAllUsuario();
            bool usuarioAlterado = usuariosAtualizados.Any(n => n.Id == usuarioAtualizado.Id && n.Nome == usuarioAtualizado.Nome);
            Assert.True(usuarioAlterado);
        }

        [Fact]
        public void DeleteUsuarioTest()
        {
            IEnumerable<Domain.Usuario_Domain> usuarios = _usuarioRepository.GetAllUsuario();
            Random random = new Random();
            Domain.Usuario_Domain usuario = _usuario_Lib.GetUsuarioAleatorio(usuarios, random);
            var exception = Record.Exception(() => _usuarioRepository.DeleteUsuario(usuario.Id));
            Assert.Null(exception);
            IEnumerable<Domain.Usuario_Domain> usuariosAtualizados = _usuarioRepository.GetAllUsuario();
            bool usuarioDeletado = usuariosAtualizados.Any(n => n.Id == usuario.Id);
            Assert.False(usuarioDeletado);
        }        
    }
}
