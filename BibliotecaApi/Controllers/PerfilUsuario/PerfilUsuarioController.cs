﻿using Biblioteca.Domain.Services.PerfilUsuario;
using Biblioteca.Domain.Services.PerfilUsuario.Dto;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Domain.Notification;

namespace BibliotecaApi.Controllers.PerfilUsuario
{
    [ApiController]
    [Route("v1/perfilusuario")]
    public class PerfilUsuarioController : ControllerBase
    {
        private readonly IPerfilUsuarioService _perfilUsuarioService;
        private readonly INotification _notification;

        public PerfilUsuarioController (INotification notification, IPerfilUsuarioService perfilUsuarioService)
        {
            _notification = notification;
            _perfilUsuarioService = perfilUsuarioService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var perfilUsuarios = _perfilUsuarioService.Get();

            return Ok(perfilUsuarios);
        }

        [HttpGet("findbyid")]
        public IActionResult GetById(int id)
        {
            var response = _perfilUsuarioService.GetById(id);
            if (response == null)
                return BadRequest(_notification.GetErrors());

            return Ok(response);
        }

        [HttpPost]
        public IActionResult Post(PerfilUsuarioDto perfil)
        {
            var response = _perfilUsuarioService.Post(perfil);

            if (response == null)
                return BadRequest(_notification.GetErrors());

            return Ok(response);
        }
    }
}
