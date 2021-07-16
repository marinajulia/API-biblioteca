using Biblioteca.Domain.Services.Livro;
using Biblioteca.Domain.Services.Livro.Dto;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Domain.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Api.Controllers.Livro
{
    [ApiController]
    [Route("v1/livro")]
    public class LivroController : ControllerBase
    {
        private readonly INotification _notification;
        private readonly ILivroService _livroService;

        public LivroController(ILivroService livroService, INotification notification)
        {
            _livroService = livroService;
            _notification = notification;
        }

        [HttpGet]
        // [Authorize]
        public IActionResult Get()
        {
            var livros = _livroService.Get();

            return Ok(livros);
        }

        [HttpGet("findbyid")]
        //[Authorize]
        public IActionResult GetById(int id)
        {
            var response = _livroService.GetById(id);
            if (response == null)
                return BadRequest(_notification.GetErrors());

            return Ok(response);
        }
        [HttpPost]
        public IActionResult Post(LivroDto livro)
        {
            var response = _livroService.Post(livro);

            if (response == null)
                return BadRequest(_notification.GetErrors());

            return Ok(response);
        }
    }
}
