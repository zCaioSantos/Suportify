using Microsoft.AspNetCore.Mvc;
using Suportify.Domain.Dtos;
using Suportify.Domain.Dtos.Autenticacao;
using Suportify.Service.Domain.Autenticacao;

namespace Suportify.Api.Controllers.ControleUsuario
{
    [Route("usuarios")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }


        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                var usuario = await _usuarioService.Get(id);

                return Ok(usuario);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var usuarios = await _usuarioService.GetAll();

                return Ok(usuarios);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("create")]
        public async Task<IActionResult> Create(UsuarioDto dto)
        {
            try
            {
                var usuario = await _usuarioService.Create(dto);

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("delete")]
        public async Task<IActionResult> Delete(ObjetoPadraoDto dto)
        {
            try
            {
                await _usuarioService.Delete(dto.Id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("update")]
        public async Task<IActionResult> Update(UsuarioDto dto)
        {
            try
            {
                var  usuario = await _usuarioService.Update(dto);

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
