using Microsoft.AspNetCore.Mvc;

namespace UniSystem_BackEnd.webAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuario_Service _usuarioService;
        public UsuarioController()
        {
            _usuarioService = usuarioService;
        }
        [HttpGet]
        public IActionResult GetAllUsuario([FromServices] UniSystem_BackEnd.IServices.IUsuario_Service usuarioService)
        {
            try
            {
                var usuarios = usuarioService.GetAllUsuario();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost] 
        public IActionResult CreateUsuario([FromBody] UniSystem_BackEnd.Domain.Usuario_Domain usuario, [FromServices] UniSystem_BackEnd.IServices.IUsuario_Service usuarioService)
        {
            try
            {
                usuarioService.CreateUsuario(usuario);
                return CreatedAtAction(nameof(GetAllUsuario), new { id = usuario.Login }, usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public IActionResult AlterUsuario([FromBody] UniSystem_BackEnd.Domain.Usuario_Domain usuario, [FromServices] UniSystem_BackEnd.IServices.IUsuario_Service usuarioService)
        {
            try
            {
                usuarioService.AlterUsuario(usuario);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{login}")]
        public IActionResult DeleteUsuario(string login, [FromServices] UniSystem_BackEnd.IServices.IUsuario_Service usuarioService)
        {
            try
            {
                usuarioService.DeleteUsuario(login);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
