using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GerenciadorTarefasAPI.Models
{
    public class ProjetoModel
    {
        [Key]
        public int Id { get; set; }
        public string NomeProjeto { get; set; }
        [JsonIgnore]
        public ICollection<TarefaModel> Tarefas { get; set; }

    }
}
