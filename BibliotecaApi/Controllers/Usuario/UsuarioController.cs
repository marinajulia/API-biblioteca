using Biblioteca.Domain.Common.Token;
using Biblioteca.Domain.Services.Entidades;
using Biblioteca.Domain.Services.Usuario;
using Biblioteca.Domain.Services.Usuario.Dto;
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

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            var usuario = _usuarioService.Get();
            if (usuario == null)
                return BadRequest(_notification.GetErrors());

            return Ok(usuario);
        }

        [HttpGet]
        [Route("getbyid")]
        [AllowAnonymous]
        public IActionResult GetById(int id)
        {
            var usuario = _usuarioService.GetById(id);
            if (usuario == null)
                return BadRequest(_notification.GetErrors());

            return Ok(usuario);
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
        public IActionResult PostCadastro(UsuarioEntity usuario)
        {
            var response = _usuarioService.PostCadastro(usuario);
            if (!response)
                return BadRequest(_notification.GetErrors());

            return Ok(_notification.GetErrors());
        }

        [HttpPost("alterarsenha")]
        [AllowAnonymous]
        public IActionResult PostAlterarSenha(UsuarioEntity usuario)
        {
            var response = _usuarioService.PostAlterarSenha(usuario);
            if (!response)
                return BadRequest(_notification.GetErrors());

            return Ok(_notification.GetErrors());
        }

        [HttpPost("bloqueio")]
        [Authorize]
        public IActionResult PostBloqueio(UsuarioDto usuario)
        {
            var response = _usuarioService.PostBloqueio(usuario);
            if (!response)
                return BadRequest(_notification.GetErrors());

            return Ok(_notification.GetErrors());
        }

        [HttpPost("desbloqueio")]
        public IActionResult PostDesbloqueio(UsuarioDto usuario)
        {
            var response = _usuarioService.PostDesbloqueio(usuario);
            if (!response)
                return BadRequest(_notification.GetErrors());

            return Ok(_notification.GetErrors());
        }

        [HttpGet]
        [Route("getnome")]
        [AllowAnonymous]
        public IActionResult GetNome(UsuarioDto usuario)
        {
            var response = _usuarioService.GetNome(usuario);
            if (response == null)
                return BadRequest(_notification.GetErrors());

            return Ok(response);
        }
    }
}
