using Biblioteca.Domain.Services.Entidades;
using Biblioteca.Domain.Services.UsuarioLivros;
using Biblioteca.Domain.Services.UsuarioLivros.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Domain.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public IActionResult Get()
        {
            var usuarioLivros = _usuarioLivrosService.Get();
            return Ok(usuarioLivros);
        }

        [HttpGet("findbyid")]
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
    }
}
