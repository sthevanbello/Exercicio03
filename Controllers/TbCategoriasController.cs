using Exercicio02.Interfaces;
using Exercicio02.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Exercicio02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TbCategoriasController : ControllerBase
    {
        private readonly ITbCategoriaRepository _categoriaRepository;

        public TbCategoriasController(ITbCategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }
        /// <summary>
        /// Inserir uma categoria no banco
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult InsertCategoria(TbCategoria categoria)
        {
            try
            {
                var categoriaInserida = _categoriaRepository.Inserir(categoria);
                return Ok(categoria);
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao listar os clientes",
                    ex.Message
                });
            }
        }
        /// <summary>
        /// Exibir todas as categorias
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllCategorias()
        {
            try
            {
                var categorias = _categoriaRepository.ListarTodos();
                return Ok(categorias);
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao listar os clientes",
                    ex.Message
                });
            }
        }
        /// <summary>
        /// Exibir uma categoria a partir do Id fornecido
        /// </summary>
        /// <param name="id">Id da categoria</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetByIdCategoria(int id)
        {
            try
            {
                var categoria = _categoriaRepository.BuscarPorId(id);
                if (categoria is null)
                {
                    return NotFound(new { msg = "Categoria não foi encontrada. Verifique se o Id está correto" });
                }
                return Ok(categoria);
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao listar os clientes",
                    ex.Message
                });
            }
        }

        /// <summary>
        /// Atualizar parte das informações da categoria
        /// </summary>
        /// <param name="id">Id do categoria</param>
        /// <param name="patchCategoria">informações a serem alteradas</param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public IActionResult PatchCategoria(int id, [FromBody] JsonPatchDocument patchCategoria)
        {
            try
            {
                if (patchCategoria is null)
                {
                    return BadRequest(new { msg = "Insira os dados novos" });
                }

                var categoria = _categoriaRepository.BuscarPorId(id);
                if (categoria is null)
                {
                    return NotFound(new { msg = "Categoria não encontrada. Conferir o Id informado" });
                }

                _categoriaRepository.AlterarParcialmente(patchCategoria, categoria);

                return Ok(new { msg = "Categoria alterada", categoria });
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao alterar o cliente",
                    ex.Message
                });
            }
        }
        /// <summary>
        /// Alterar uma categoria a partir do Id fornecido
        /// </summary>
        /// <param name="id">Id da categoria</param>
        /// <param name="categoria">Dados atualizados</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult PutCategoria(int id, TbCategoria categoria)
        {
            try
            {
                if (id != categoria.Id)
                {
                    return BadRequest(new { msg = "Os ids não são correspondentes" });
                }
                var categoriaRetorno = _categoriaRepository.BuscarPorId(id);

                if (categoriaRetorno is null)
                {
                    return NotFound(new { msg = "Categoria não encontrada. Conferir o Id informado" });
                }

                _categoriaRepository.Alterar(categoria);

                return Ok(new { msg = "Categoria alterada", categoria });
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao alterar a categoria",
                    ex.Message
                });
            }
        }
    }
}
