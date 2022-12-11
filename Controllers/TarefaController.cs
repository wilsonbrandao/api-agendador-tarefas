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

        [HttpPost("/tarefa")]
        public IActionResult CriarTarefa(Tarefa tarefa)
        {
            _context.Add(tarefa);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPost("/tarefa/ObterTodos")]
        public IActionResult ObterTodos()
        {
            var tarefas = _context.Tarefas;
            

            return Ok(tarefas);
        }




    }
}