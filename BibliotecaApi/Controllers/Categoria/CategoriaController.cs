﻿using Biblioteca.Domain.Services.Categoria.Dto;
using Biblioteca.Domain.Services.CategoriaService;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Domain.Notification;

namespace BibliotecaApi.Controllers.Categoria
{
    [ApiController]
    [Route("v1/categoria")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;
        private readonly INotification _notification;

        public CategoriaController(ICategoriaService categoriaService, INotification notification)
        {
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
    }
}
