using GerenciadorTarefasAPI.Dto.Projeto;
using GerenciadorTarefasAPI.Dto.Tarefa;
using GerenciadorTarefasAPI.Models;

namespace GerenciadorTarefasAPI.Services.Tarefas
{
    public interface ITarefaInterface
    {
        Task<ResponseModel<List<TarefaDto>>> BuscarTarefasPorIdProjeto(int idProjeto);
        Task<ResponseModel<List<TarefaModel>>> CriarTarefa(TarefaCriacaoDto tarefaCriacaoDto);
        Task<ResponseModel<List<TarefaModel>>> EditarTarefa(TarefaEdicaoDto tarefaEdicaoDto);
        Task<ResponseModel<List<TarefaModel>>> ExcluirTarefa(int idTarefa);
        Task<ResponseModel<ComentarioTarefaModel>> InserirComentario(ComentarioTarefaDto comentarioDto);
    }
}
