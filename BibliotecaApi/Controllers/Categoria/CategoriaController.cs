using Biblioteca.Domain.Services.Categoria;
using Biblioteca.Domain.Services.Entidades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaApi.Controllers.Categoria
{
    [ApiController]
    [Route("v1/categoria")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        [HttpGet]
        // [Authorize]
        public IActionResult Get()
        {
            var categorias = _categoriaRepository.Get();

            return Ok(categorias);
        }

        [HttpGet("findbyid")]
        //[Authorize]
        public IActionResult GetById(int id)
        {
            var categoria = _categoriaRepository.GetById(id);
            if (categoria == null)
                return BadRequest("A categoria não pode ser encontrada");

            return Ok(categoria);
        }
        [HttpPost]
        public IActionResult Post(CategoriaEntity categoria)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                else
                {
                    var nomeCategoria = _categoriaRepository.GetByName(categoria.NomeCategoria);
                    if (nomeCategoria != null)
                        return BadRequest("Essa categoria já existe");

                    var categorias = _categoriaRepository.Post(categoria);

                    return Ok(categorias);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
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
