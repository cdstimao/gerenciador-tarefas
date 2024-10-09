using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorTarefasAPI.Models
{
    public class UsuarioModel
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public int PerfilId { get; set; }
        [ValidateNever]
        public PerfilModel Perfil { get; set; }
    }
}
