using Biblioteca.Domain.Services;
using Biblioteca.Domain.Services.Autor.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Domain.Notification;

namespace BibliotecaApi.Controllers.Autor
{
    [ApiController]
    [Route("v1/autor")]
    public class AutorController : ControllerBase
    {
        private readonly IAutorService _autorService;
        private readonly INotification _notification;

        public AutorController(IAutorService autorService, INotification notification)
        {
            _autorService = autorService;
            _notification = notification;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            var autor = _autorService.Get();

            return Ok(autor);
        }

        [HttpGet("findbyid")]
        [Authorize]

        public IActionResult GetById(int id)
        {
            var autor = _autorService.GetById(id);
            if (autor == null)
                return BadRequest(_notification.GetErrors());

            return Ok(autor);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Post(AutorDto autor)
        {
            var response = _autorService.Post(autor);

            if (response == null)
                return BadRequest(_notification.GetErrors());

            return Ok(response);
        }

        [HttpDelete("delete")]
        [Authorize]
        public IActionResult Delete(AutorDto autor)
        {
            var response = _autorService.Delete(autor);

            if (!response)
                return BadRequest(_notification.GetErrors());

            return Ok(_notification.GetErrors());
        }

        [HttpGet("getnome")]
        [Authorize]
        public IActionResult GetNome(AutorDto autor)
        {
            var response = _autorService.GetNome(autor);

            if (response == null)
                return BadRequest(_notification.GetErrors());

            return Ok(response);
        }
    }
}
