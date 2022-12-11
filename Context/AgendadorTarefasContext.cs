using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_agendador_tarefas.Model;
using Microsoft.EntityFrameworkCore;

namespace api_agendador_tarefas.Context
{
    public class AgendadorTarefasContext : DbContext
    {
        public AgendadorTarefasContext(DbContextOptions<AgendadorTarefasContext> options) : base(options)
        {
            
        }

        //entidade (Model)
        public DbSet<Tarefa> Tarefas { get; set; }

    }
}