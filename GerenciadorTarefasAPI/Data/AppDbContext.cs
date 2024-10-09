using GerenciadorTarefasAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorTarefasAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ProjetoModel> Projetos { get; set; }
        public DbSet<TarefaModel> Tarefas { get; set; }
        public DbSet<PerfilModel> Perfis { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<PrioridadeModel> Prioridades { get; set; }
        public DbSet<StatusModel> Statuses { get; set; }
        public DbSet<HistoricoModel> Historicos { get; set; }
        public DbSet<ComentarioTarefaModel> Comentarios { get; set; }




    }
}
