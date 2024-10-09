using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorTarefasAPI.Models
{
    public class HistoricoModel
    {
        [Key]
        public int Id { get; set; }
        public DateTime DtAlteracao { get; set; }
        public string Detalhes { get; set; }
        public int TarefaId { get; set; }
        [ValidateNever]
        public TarefaModel Tarefa { get; set; }
    }
}

