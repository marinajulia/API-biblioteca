using Biblioteca.Domain.Services;
using Biblioteca.Domain.Services.Autor;
using Biblioteca.Domain.Services.Autor.Dto;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Domain.Notification;

namespace BibliotecaApi.Controllers.Autor
{
    [ApiController]
    [Route("v1/autor")]
    public class AutorController : ControllerBase
    {
        private readonly IAutorRepository _autorRepository;
        private readonly IAutorService _autorService;
        private readonly INotification _notification;

        public AutorController(IAutorRepository autorRepository, IAutorService autorService, INotification notification)
        {
            _autorRepository = autorRepository;
            _autorService = autorService;
            _notification = notification;
        }

        [HttpGet]
        // [Authorize]
        public IActionResult Get()
        {
            var autor = _autorRepository.Get();

            return Ok(autor);
        }

        [HttpGet("findbyid")]
        //[Authorize]
        public IActionResult GetById(int id)
        {
            var autor = _autorRepository.GetById(id);
            if (autor == null)
                return BadRequest("A categoria não pode ser encontrada");

            return Ok(autor);
        }

        [HttpPost]
        public IActionResult Post(AutorDto autor)
        {
            var response = _autorService.Post(autor);

            if (response == null)
                return BadRequest(_notification.GetErrors());

            return Ok(response);
        }
    }
}
