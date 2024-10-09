using GerenciadorTarefasAPI.Dto.Projeto;
using GerenciadorTarefasAPI.Models;

namespace GerenciadorTarefasAPI.Services.Projetos
{
    public interface IProjetoInterface
    {
        Task<ResponseModel<List<ProjetoModel>>> ListarProjetos();
        Task<ResponseModel<List<ProjetoModel>>> CriarProjeto(ProjetoCriacaoDto projetoCriacaoDto);

    }
}
