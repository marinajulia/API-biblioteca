using Biblioteca.Domain.Services.Entidades;
using Biblioteca.Domain.Services.UsuarioLivros;
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
        public IActionResult Post(UsuarioLivrosEntity usuarioLivros)
        {
            var response = _usuarioLivrosService.Post(usuarioLivros);

            if (response == null)
                return BadRequest(_notification.GetErrors());

            return Ok(response);
        }


        [HttpPost("devolucao")]
        [Authorize]
        public IActionResult PostDevolucao(UsuarioLivrosEntity usuarioLivros)
        {
            var response = _usuarioLivrosService.PostDevolucao(usuarioLivros);

           if (response == null)
                return Ok(_notification.GetErrors());

            return Ok(response);
        }
    }
}
