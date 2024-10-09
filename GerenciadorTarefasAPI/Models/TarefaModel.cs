using GerenciadorTarefasAPI.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorTarefasAPI.Models
{
    public class TarefaModel
    {
        public int Id { get; set; }
        public string NomeTarefa { get; set; }
        public string Descricao { get; set; }
        public DateTime DtCriacao { get; set; }
        public DateTime DtVencimento { get; set; }
        public int PrioridadeId { get; set; }
        public int StatusId { get; set; }

        // Propriedade para armazenar o ID do projeto
        public int ProjetoId { get; set; }

        // Propriedade de navegação (não obrigatória no DTO)
        public ProjetoModel Projeto { get; set; }

        public int UsuarioId { get; set; }
        [ValidateNever]
        [SwaggerSchema("Prioridade: 1-Baixa, 2-Média, 3-Alta")]
        public PrioridadeModel Prioridade { get; set; }
        [ValidateNever]
        public StatusModel Status { get; set; }
        [ValidateNever]
        public UsuarioModel Usuario { get; set; }
    }

}
