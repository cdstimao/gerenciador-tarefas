using System.ComponentModel.DataAnnotations;

namespace GerenciadorTarefasAPI.Models
{
    public class PerfilModel
    {
        [Key]
        public int Id { get; set; }
        public string NomePerfil { get; set; }
    }
}
