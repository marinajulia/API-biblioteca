using Biblioteca.Domain.Services.UsuarioLivros;
using Biblioteca.Domain.Services.UsuarioLivros.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Domain.Notification;

namespace Biblioteca.Api.Controllers.UsuarioLivro
{
    [ApiController]
    [Route("v1/usuariolivros")]
    public class UsuarioLivroController : ControllerBase
    {
        private readonly INotification _notification;
        private readonly IUsuarioLivrosService _usuarioLivrosService;

        public UsuarioLivroController(IUsuarioLivrosService usuarioLivrosService, INotification notification)
        {
            _usuarioLivrosService = usuarioLivrosService;
            _notification = notification;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            var usuarioLivros = _usuarioLivrosService.Get();
            return Ok(usuarioLivros);
        }

        [HttpGet("findbyid")]
        [Authorize]
        public IActionResult GetById(int id)
        {
            var response = _usuarioLivrosService.GetById(id);
            if (response == null)
                return BadRequest(_notification.GetErrors());

            return Ok(response);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Post(UsuarioLivrosDto usuarioLivros)
        {
            var response = _usuarioLivrosService.Post(usuarioLivros);

            if (response == null)
                return BadRequest(_notification.GetErrors());

            return Ok(response);
        }


        [HttpPost("devolucao")]
        [Authorize]
        public IActionResult PostDevolucao(UsuarioLivrosDto usuarioLivros)
        {
            var response = _usuarioLivrosService.PostDevolucao(usuarioLivros);

           if (!response)
                return BadRequest(_notification.GetErrors());

            return Ok(_notification.GetErrors());
        }

        [HttpGet("livrosUsuario")]
        [Authorize]
        public IActionResult GetUser(UsuarioLivrosDto usuarioLivros)
        {
            var response = _usuarioLivrosService.GetUser(usuarioLivros.UsuarioId);

            if (response == null)
                return BadRequest(_notification.GetErrors());

            return Ok(response);
        }
    }
}
