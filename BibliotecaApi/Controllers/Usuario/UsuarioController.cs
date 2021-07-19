using Biblioteca.Domain.Common.Token;
using Biblioteca.Domain.Services.Entidades;
using Biblioteca.Domain.Services.Usuario;
using Biblioteca.Domain.Services.Usuario.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Domain.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            return Ok(usuario);
        }

        //[HttpPost]
        //[Route("cadastro")]
        //[AllowAnonymous]


        //public ActionResult PostCadastro(UsuarioEntity usuario)
        //{

        //}

    }
}
