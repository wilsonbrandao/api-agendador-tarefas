using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using api_agendador_tarefas.Context;
using api_agendador_tarefas.Model;
using Microsoft.AspNetCore.Mvc;

namespace api_agendador_tarefas.Controllers
{
    [ApiController]
    [Route("controller")]
    public class TarefaController : ControllerBase
    {
        private readonly AgendadorTarefasContext _context;

        public TarefaController(AgendadorTarefasContext context)
        {
            _context = context;
        }

        [HttpGet("/tarefa/{id}")]
        public IActionResult ObterPorId(int id)
        {
            var tarefa = _context.Tarefas.Find(id);

            if (tarefa == null) return NotFound();

            return Ok(tarefa);
        }

        [HttpGet("/tarefa/ObterPorTitulo")]
        public IActionResult ObterPorTitulo(string titulo)
        {
            var tarefas = _context.Tarefas.Where(x => x.Titulo.Contains(titulo));

            if (tarefas == null) return NotFound();

            return Ok(tarefas);
        }

        [HttpGet("/tarefa/ObterPorData")]
        public IActionResult ObterPorData(DateTime data)
        {
            var tarefas = _context.Tarefas.Where(x => x.Data == data);

            if (tarefas == null) return NotFound();

            return Ok(tarefas);
        }

        [HttpGet("/tarefa/ObterStatus")]
        public IActionResult ObterPorStatus (EnumStatusTarefa status)
        {
            var tarefas = _context.Tarefas.Where(x => x.Status == status);

            if (tarefas == null) return NotFound();

            return Ok(tarefas);
        }


        [HttpPost("/tarefa")]
        public IActionResult CriarTarefa(Tarefa tarefa)
        {
            _context.Add(tarefa);
            _context.SaveChanges();

            return Ok();
        }

        [HttpGet("/tarefa/ObterTodos")]
        public IActionResult ObterTodos()
        {
            var tarefas = _context.Tarefas;

            return Ok(tarefas);
        }



        [HttpPut("/tarefa/{id}")]
        public IActionResult AtualizarTarega(int id, Tarefa tarefa)
        {
            var tarefaBanco = _context.Tarefas.Find(id);

            if (tarefaBanco == null) return NotFound();

            if (tarefa.Data == DateTime.MinValue) return BadRequest(new { Erro = "A data não pode estar vazia" });

            tarefaBanco.Titulo = tarefa.Titulo;
            tarefaBanco.Descricao = tarefa.Descricao;
            tarefaBanco.Data = tarefa.Data;
            tarefaBanco.Status = tarefa.Status;

            _context.Tarefas.Update(tarefaBanco);
            _context.SaveChanges();

            return Ok(tarefaBanco);
        }


        [HttpDelete("/tarefa/{id}")]
        public IActionResult Delete(int id)
        {
            var tarefaBanco = _context.Tarefas.Find(id);

            if (tarefaBanco == null) return NotFound();

            _context.Tarefas.Remove(tarefaBanco);
            _context.SaveChanges();

            return NoContent();
        }




    }
}