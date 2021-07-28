using Biblioteca.Domain.Common.Token;
using Biblioteca.Domain.Services.Entidades;
using Biblioteca.Domain.Services.Usuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Domain.Notification;

namespace Biblioteca.Api.Controllers.Usuario
{
    [ApiController]
    [Route("v1/usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly INotification _notification;
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService, INotification notification)
        {
            _usuarioService = usuarioService;
            _notification = notification;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public IActionResult PostLogin(UsuarioEntity model)
        {
            var usuario = _usuarioService.PostLogin(model);
            if (usuario == null)
                return BadRequest(_notification.GetErrors());

            var token = TokenService.GenerateToken(usuario);

            return Ok(token);
        }

        [HttpPost("cadastro")]
        [AllowAnonymous]
        public ActionResult PostCadastro(UsuarioEntity usuario)
        {
            var response = _usuarioService.PostCadastro(usuario);
            if (response == null)
                return BadRequest(_notification.GetErrors());

            return Ok(response);

        }

        [HttpPost("bloquear")]
        [Authorize]
        public ActionResult PostBloqueio(int id)
        {
            var response = _usuarioService.PostBloqueio(id);
            if (response == null)
                return BadRequest(_notification.GetErrors());

            return Ok(response);

        }

    }
}
