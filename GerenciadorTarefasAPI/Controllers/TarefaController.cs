using GerenciadorTarefasAPI.Dto.Projeto;
using GerenciadorTarefasAPI.Dto.Tarefa;
using GerenciadorTarefasAPI.Models;
using GerenciadorTarefasAPI.Services.Projetos;
using GerenciadorTarefasAPI.Services.Tarefas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorTarefasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaInterface _tarefaInterface;
        public TarefaController(ITarefaInterface tarefaInterface) 
        {
            _tarefaInterface = tarefaInterface;
        }
        [HttpGet("BuscarTarefasPorIdProjeto/{idProjeto}")]
        public async Task<ActionResult<ResponseModel<List<TarefaDto>>>> BuscarTarefasPorIdProjeto(int idProjeto)
        {
            var tarefas = await _tarefaInterface.BuscarTarefasPorIdProjeto(idProjeto);
            return Ok(tarefas);
        }

        [HttpPost("CriarTarefa")]
        public async Task<ActionResult<ResponseModel<TarefaModel>>> CriarTarefa(TarefaCriacaoDto tarefaCriacaoDto)
        {
            var tarefa = await _tarefaInterface.CriarTarefa(tarefaCriacaoDto);
            return Ok(tarefa);
        }

        [HttpPut("EditarTarefa")]
        public async Task<ActionResult<ResponseModel<List<TarefaModel>>>> EditarTarefa(TarefaEdicaoDto tarefaEdicaoDto)
        {
            var tarefas = await _tarefaInterface.EditarTarefa(tarefaEdicaoDto);
            return Ok(tarefas);
        }

        [HttpDelete("ExcluirTarefa")]
        public async Task<ActionResult<ResponseModel<List<TarefaModel>>>> ExcluirTarefa(int idTarefa)
        {
            var tarefa = await _tarefaInterface.ExcluirTarefa(idTarefa);
            return Ok(tarefa);
        }

        [HttpPost("InserirComentario")]
        public async Task<ActionResult<ResponseModel<ComentarioTarefaModel>>> InserirComentario(ComentarioTarefaDto comentarioTarefaDto)
        {
            var comentarioTarefa = await _tarefaInterface.InserirComentario(comentarioTarefaDto);
            return Ok(comentarioTarefa);
        }
    }
}
