using Biblioteca.Domain.Services.Categoria;
using Biblioteca.Domain.Services.Categoria.Dto;
using Biblioteca.Domain.Services.CategoriaService;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Domain.Notification;

namespace BibliotecaApi.Controllers.Categoria
{
    [ApiController]
    [Route("v1/categoria")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly ICategoriaService _categoriaService;
        private readonly INotification _notification;

        public CategoriaController(ICategoriaRepository categoriaRepository, ICategoriaService categoriaService, INotification notification)
        {
            _categoriaRepository = categoriaRepository;
            _categoriaService = categoriaService;
            _notification = notification;
        }

        [HttpGet]
        // [Authorize]
        public IActionResult Get()
        {
            var categorias = _categoriaService.Get();

            return Ok(categorias);
        }

        [HttpGet("findbyid")]
        //[Authorize]
        public IActionResult GetById(int id)
        {
            var response = _categoriaService.GetById(id);
            if (response == null)
                return BadRequest(_notification.GetErrors());

            return Ok(response);
        }
        [HttpPost]
        public IActionResult Post(CategoriaDto categoria)
        {
            var response = _categoriaService.Post(categoria);

            if (response == null)
                return BadRequest(_notification.GetErrors());

            return Ok(response);
        }

        //[HttpGet("findbyname")]
        ////[Authorize]
        //public ActionResult GetByName(string nome)
        //{
        //    try
        //    {
        //        var categoria = _categoriaRepository.GetByName(nome);
        //        if (categoria == null)
        //            return BadRequest("A categoria não pode ser encontrada");

        //        return Ok(categoria);

        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.Message);
        //    }

        //}

    }
}
