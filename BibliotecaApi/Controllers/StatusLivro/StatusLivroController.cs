using Biblioteca.Domain.Services.StatusLivro;
using Biblioteca.Domain.Services.StatusLivro.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Domain.Notification;

namespace BibliotecaApi.Controllers.StatusLivro
{
    [ApiController]
    [Route("v1/statuslivro")]
    public class StatusLivroController : ControllerBase
    {
        private readonly INotification _notification;
        private readonly IStatusLivroService _statusLivroService;

        public StatusLivroController(IStatusLivroService statusLivroService, INotification notification)
        {
            _statusLivroService = statusLivroService;
            _notification = notification;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            var statusLivros = _statusLivroService.Get();

            return Ok(statusLivros);
        }

        [HttpGet("findbyid")]
        [Authorize]
        public IActionResult GetById(int id)
        {
            var response = _statusLivroService.GetById(id);
            if (response == null)
                return BadRequest(_notification.GetErrors());

            return Ok(response);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Post(StatusLivroDto statusLivro)
        {
            var response = _statusLivroService.Post(statusLivro);

            if (response == null)
                return BadRequest(_notification.GetErrors());

            return Ok(response);
        }

        [HttpGet("getnome")]
        [Authorize]
        public IActionResult GetNome(string nome)
        {
            var response = _statusLivroService.GetNome(nome);
            if (response == null)
                return BadRequest(_notification.GetErrors());

            return Ok(response);
        }
    }
}
