using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorTarefasAPI.Models
{
    public class PrioridadeModel
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
    }
}
