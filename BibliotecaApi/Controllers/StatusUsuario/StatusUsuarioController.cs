using Biblioteca.Domain.Services.StatusUsuario;
using Biblioteca.Domain.Services.StatusUsuario.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Domain.Notification;

namespace Biblioteca.Api.Controllers.StatusUsuario
{
    [ApiController]
    [Route("v1/statususuario")]
    public class StatusUsuarioController : ControllerBase
    {
        private readonly INotification _notification;
        private readonly IStatusUsuarioService _statusUsuario;

        public StatusUsuarioController(IStatusUsuarioService statusUsuario, INotification notification)
        {
            _statusUsuario = statusUsuario;
            _notification = notification;
        }

        [HttpGet]
        // [Authorize]
        public IActionResult Get()
        {
            var statusUsuarios = _statusUsuario.Get();

            return Ok(statusUsuarios);
        }

        [HttpGet("findbyid")]
        //[Authorize]
        public IActionResult GetById(int id)
        {
            var response = _statusUsuario.GetById(id);
            if (response == null)
                return BadRequest(_notification.GetErrors());

            return Ok(response);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Post(StatusUsuarioDto statusUsuario)
        {
            var response = _statusUsuario.Post(statusUsuario);

            if (response == null)
                return BadRequest(_notification.GetErrors());

            return Ok(response);
        }


    }
}
