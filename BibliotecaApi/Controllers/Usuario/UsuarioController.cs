//using Biblioteca.Domain.Services.Usuario;
//using Biblioteca.Domain.Services.Usuario.Dto;
//using Microsoft.AspNetCore.Mvc;
//using SharedKernel.Domain.Notification;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Biblioteca.Api.Controllers.Usuario
//{
//    [ApiController]
//    [Route("v1/usuario")]
//    public class UsuarioController : ControllerBase
//    {
//        private readonly INotification _notification;
//        private readonly IUsuarioService _usuarioService;

//        public UsuarioController(IUsuarioService usuarioService, INotification notification)
//        {
//            _usuarioService = usuarioService;
//            _notification = notification;
//        }

//        [HttpGet]
//        // [Authorize]
//        public IActionResult Get()
//        {
//            var usuarios = _usuarioService.Get();

//            return Ok(usuarios);
//        }

//        [HttpGet("findbyid")]
//        //[Authorize]
//        public IActionResult GetById(int id)
//        {
//            var response = _usuarioService.GetById(id);
//            if (response == null)
//                return BadRequest(_notification.GetErrors());

//            return Ok(response);
//        }

//        [HttpPost]
//        public IActionResult Post(UsuarioDto usuario)
//        {
//            var response = _usuarioService.Post(usuario);

//            if (response == null)
//                return BadRequest(_notification.GetErrors());

//            return Ok(response);
//        }
//    }
//}
