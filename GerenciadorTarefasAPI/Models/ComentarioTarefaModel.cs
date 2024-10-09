using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorTarefasAPI.Models
{
    public class ComentarioTarefaModel
    {
        [Key]
        public int Id { get; set; }
        public string Comentario { get; set; }
        public int TarefaId { get; set; }
        [ValidateNever]
        public TarefaModel Tarefa { get; set; }
    }
}
