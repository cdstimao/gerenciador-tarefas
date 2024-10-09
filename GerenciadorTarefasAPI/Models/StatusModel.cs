using System.ComponentModel.DataAnnotations;

namespace GerenciadorTarefasAPI.Models
{
    public class StatusModel
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
    }
}
