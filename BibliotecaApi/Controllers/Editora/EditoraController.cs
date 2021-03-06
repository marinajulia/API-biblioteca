using Biblioteca.Domain.Services.Editora;
using Biblioteca.Domain.Services.Editora.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Domain.Notification;

namespace BibliotecaApi.Controllers.Editora
{
    [ApiController]
    [Route("v1/editora")]
    public class EditoraController : ControllerBase
    {
        private readonly IEditoraService _editoraService;
        private readonly INotification _notification;

        public EditoraController(IEditoraService editoraService, INotification notification)
        {
            _editoraService = editoraService;
            _notification = notification;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            var editoras = _editoraService.Get();

            return Ok(editoras);
        }

        [HttpGet("findbyid")]
        [Authorize]
        public IActionResult GetById(int id)
        {
            var response = _editoraService.GetById(id);
            if (response == null)
                return BadRequest(_notification.GetErrors());

            return Ok(response);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Post(EditoraDto editora)
        {
            var response = _editoraService.Post(editora);

            if (response == null)
                return BadRequest(_notification.GetErrors());

            return Ok(response);
        }

        [HttpDelete("delete")]
        [Authorize]
        public IActionResult Delete(int editora)
        {
            var response = _editoraService.Delete(editora);

            if (!response)
                return BadRequest(_notification.GetErrors());

            return Ok(_notification.GetErrors());
        }

        [HttpGet("getnome")]
        [Authorize]
        public IActionResult GetNome(string editora)
        {
            var response = _editoraService.GetNome(editora);

            if (response == null)
                return BadRequest(_notification.GetErrors());

            return Ok(response);
        }
    }
}
