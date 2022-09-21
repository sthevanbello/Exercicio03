using Exercicio02.Interfaces;
using Exercicio02.Models;
using Exercicio02.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Exercicio02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TbEventosController : ControllerBase
    {
        private readonly ITbEventoRepository _eventoRepository;

        public TbEventosController(ITbEventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }
        /// <summary>
        /// Inserir um evento no banco
        /// </summary>
        /// <param name="evento"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult InsertEvento(TbEvento evento)
        {
            try
            {
                var eventoInserido = _eventoRepository.Inserir(evento);
                return Ok(eventoInserido);
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao inserir um evento no banco",
                    ex.Message
                });
            }
        }
        /// <summary>
        /// Exibir todos os eventos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllEventos()
        {
            try
            {
                var eventos = _eventoRepository.ListarTodos();
                return Ok(eventos); 
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao listar os eventos",
                    ex.Message
                });
            }
        }

        /// <summary>
        /// Exibir um evento a partir do Id fornecido
        /// </summary>
        /// <param name="id">Id da evento</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetByIdEvento(int id)
        {
            try
            {
                var evento = _eventoRepository.BuscarPorId(id);
                if (evento is null)
                {
                    return NotFound(new { msg = "Evento não foi encontrado. Verifique se o Id está correto" });
                }
                return Ok(evento);
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao exibir o evento",
                    ex.Message
                });
            }
        }

        /// <summary>
        /// Atualizar parte das informações do evento
        /// </summary>
        /// <param name="id">Id do evento</param>
        /// <param name="patchEvento">informações a serem alteradas</param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public IActionResult PatchEvento(int id, [FromBody] JsonPatchDocument patchEvento)
        {
            try
            {
                if (patchEvento is null)
                {
                    return BadRequest(new { msg = "Insira os dados novos" });
                }

                var evento = _eventoRepository.BuscarPorId(id);
                if (evento is null)
                {
                    return NotFound(new { msg = "Evento não encontrado. Conferir o Id informado" });
                }

                _eventoRepository.AlterarParcialmente(patchEvento, evento);

                return Ok(new { msg = "Evento alterado", evento });
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao alterar o evento",
                    ex.Message
                });
            }
        }
        /// <summary>
        /// Alterar um evento a partir do Id fornecido
        /// </summary>
        /// <param name="id">Id da evento</param>
        /// <param name="evento">Dados atualizados</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult PutEvento(int id, TbEvento evento)
        {
            try
            {
                if (id != evento.Id)
                {
                    return BadRequest(new { msg = "Os ids não são correspondentes" });
                }
                var eventoRetorno = _eventoRepository.BuscarPorId(id);

                if (eventoRetorno is null)
                {
                    return NotFound(new { msg = "Usuário não encontrado. Conferir o Id informado" });
                }

                _eventoRepository.Alterar(evento);

                return Ok(new { msg = "Usuário alterado", evento });
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao alterar o evento",
                    ex.Message
                });
            }
        }
    }
}
