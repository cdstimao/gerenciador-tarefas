using GerenciadorTarefasAPI.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Swashbuckle.AspNetCore.Annotations;

namespace GerenciadorTarefasAPI.Dto.Tarefa
{
    public class TarefaCriacaoDto
    {
        public string NomeTarefa { get; set; }
        public string Descricao { get; set; }
        public DateTime DtCriacao { get; set; }
        public DateTime DtVencimento { get; set; }

        [SwaggerSchema("Prioridade: 1-Baixa, 2-Média, 3-Alta")]
        public int PrioridadeId { get; set; }

        public int UsuarioId { get; set; }

        // Use apenas o ProjetoId, sem passar o objeto Projeto inteiro
        public int ProjetoId { get; set; }
    }
}
