using Microsoft.AspNetCore.Mvc;
using UniSystem_BackEnd.IServices;

namespace UniSystem_BackEnd.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuario_Service _usuarioService;
        public UsuarioController() 
        { 
            _usuarioService = new UniSystem_BackEnd.Services.Usuario_Service(); 
        }        
        
        [HttpGet]
        public IActionResult GetAllUsuario()
        {
            try
            {
                var usuarios = _usuarioService.GetAllUsuario();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult CreateUsuario([FromBody] Domain.Usuario_Domain usuario)
        {
            try
            {
                _usuarioService.CreateUsuario(usuario);
                return CreatedAtAction(nameof(GetAllUsuario), new { id = usuario.Login }, usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public IActionResult AlterUsuario([FromBody] Domain.Usuario_Domain usuario)
        {
            try
            {
                _usuarioService.AlterUsuario(usuario);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteUsuario(int id)
        {
            try
            {
                _usuarioService.DeleteUsuario(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
