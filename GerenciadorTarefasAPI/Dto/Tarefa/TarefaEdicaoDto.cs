using GerenciadorTarefasAPI.Dto.Vinculo;
using GerenciadorTarefasAPI.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace GerenciadorTarefasAPI.Dto.Tarefa
{
    public class TarefaEdicaoDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int StatusId { get; set; }
        public int UsuarioId { get; set; }
        public ProjetoVinculoDto Projeto { get; set; }

    }
}
