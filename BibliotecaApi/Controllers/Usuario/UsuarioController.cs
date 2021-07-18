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
        //private readonly INotification _notification;
        //private readonly IUsuarioService _usuarioService;

        //public UsuarioController(IUsuarioService usuarioService, INotification notification)
        //{
        //    _usuarioService = usuarioService;
        //    _notification = notification;
        //}

        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]

        public IActionResult Post(UsuarioEntity model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var usuario = _usuarioRepository.GetUser(model.NomeUsuario, model.Senha);

                if (usuario == null)
                    return NotFound("Usuario e senha não encontrados");

                var token = TokenService.GenerateToken(usuario);

                return Ok(new
                {
                    usuario,
                    token
                });

            }
            catch (Exception)
            {
                return BadRequest("Usuario ou senha inválidos");

            }
        }

        [HttpPost]
        [Route("cadastro")]
        [AllowAnonymous]


        public ActionResult PostCadastro(UsuarioEntity usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var usuarios = _usuarioRepository.PostCadastro(usuario);

                    return Ok(usuario);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception e)
            {
              // return BadRequest(e);

                return BadRequest("Já existe um cadastro com esse nome de usuário");
            }


        }




    }
}
