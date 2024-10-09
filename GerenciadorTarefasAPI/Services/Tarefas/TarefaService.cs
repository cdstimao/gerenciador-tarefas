using GerenciadorTarefasAPI.Data;
using GerenciadorTarefasAPI.Dto.Projeto;
using GerenciadorTarefasAPI.Dto.Tarefa;
using GerenciadorTarefasAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorTarefasAPI.Services.Tarefas
{
    public class TarefaService : ITarefaInterface
    {
        private readonly AppDbContext _context;
        public TarefaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<TarefaDto>>> BuscarTarefasPorIdProjeto(int idProjeto)
        {
            ResponseModel<List<TarefaDto>> resposta = new ResponseModel<List<TarefaDto>>();
            try
            {
                var tarefas = await _context.Tarefas
                                            .Where(t => t.ProjetoId == idProjeto)
                                            .Include(t => t.Prioridade)
                                            .Include(t => t.Status)    
                                            .Include(t => t.Projeto)   
                                            .Include(t => t.Usuario)   
                                            .ToListAsync();

                if (tarefas == null || tarefas.Count == 0)
                {
                    resposta.Dados = null;
                    resposta.Mensagem = "Nenhum registro localizado!";
                    resposta.Status = true;
                    return resposta;
                }

                resposta.Dados = tarefas.Select(t => new TarefaDto
                {
                    Id = t.Id,
                    NomeTarefa = t.NomeTarefa,
                    Descricao = t.Descricao,
                    DtCriacao = t.DtCriacao,
                    DtVencimento = t.DtVencimento,
                    Prioridade = t.Prioridade.Descricao ?? "Desconhecida",
                    Status = t.Status.Descricao ?? "Desconhecido",
                    Projeto = t.Projeto.NomeProjeto ?? "Desconhecido",
                    Usuario = t.Usuario.Nome ?? "Desconhecido"
                }).ToList();

                resposta.Mensagem = "Tarefas localizadas neste projeto!";
                resposta.Status = true;
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<TarefaModel>>> CriarTarefa(TarefaCriacaoDto tarefaCriacaoDto)
        {
            ResponseModel<List<TarefaModel>> resposta = new ResponseModel<List<TarefaModel>>();

            try
            {
                var projeto = await _context.Projetos
                    .FirstOrDefaultAsync(projetoBanco => projetoBanco.Id == tarefaCriacaoDto.ProjetoId);

                if (projeto == null)
                {
                    resposta.Mensagem = "Nenhum registro de projeto localizado";
                    return resposta;
                }

                var totalTarefas = await _context.Tarefas
                    .CountAsync(t => t.ProjetoId == projeto.Id);

                if (totalTarefas >= 20)
                {
                    resposta.Mensagem = "Limite de 20 tarefas por projeto alcançado. Não é possível adicionar mais tarefas.";
                    return resposta;
                }

                var tarefa = new TarefaModel()
                {
                    NomeTarefa = tarefaCriacaoDto.NomeTarefa,
                    Descricao = tarefaCriacaoDto.Descricao,
                    DtCriacao = tarefaCriacaoDto.DtCriacao,
                    DtVencimento = tarefaCriacaoDto.DtVencimento,
                    PrioridadeId = tarefaCriacaoDto.PrioridadeId,
                    StatusId = 1,
                    ProjetoId = tarefaCriacaoDto.ProjetoId,
                    UsuarioId = tarefaCriacaoDto.UsuarioId
                };

                _context.Add(tarefa);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Tarefas
                    .Include(t => t.Projeto).Where(a => a.ProjetoId == projeto.Id) 
                    .ToListAsync();
                resposta.Mensagem = "Tarefa criada com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<TarefaModel>>> EditarTarefa(TarefaEdicaoDto tarefaEdicaoDto)
        {
            ResponseModel<List<TarefaModel>> resposta = new ResponseModel<List<TarefaModel>>();
            try
            {
                var tarefa = await _context.Tarefas.Include(a => a.Projeto)
                    .FirstOrDefaultAsync(tarefaBanco => tarefaBanco.Id == tarefaEdicaoDto.Id);

                var projeto = await _context.Projetos
                    .FirstOrDefaultAsync(projetoBanco => projetoBanco.Id == tarefaEdicaoDto.Projeto.Id);
                if (tarefa == null)
                {
                    resposta.Mensagem = "Nenhum registro de tarefa localizado";
                }

                if (projeto == null)
                {
                    resposta.Mensagem = "Nenhum registro de projeto localizado";
                }

                var detalhesAlteracao = $"Status alterado para: {tarefaEdicaoDto.StatusId}, " +
                                         $"Descrição alterada para: {tarefaEdicaoDto.Descricao}, " +
                                         $"Usuário que alterou: {tarefaEdicaoDto.UsuarioId}";

                var historico = new HistoricoModel
                {
                    DtAlteracao = DateTime.Now,
                    Detalhes = detalhesAlteracao,
                    TarefaId = tarefa.Id
                };

                _context.Historicos.Add(historico);

                tarefa.Descricao = tarefaEdicaoDto.Descricao;
                tarefa.StatusId = tarefaEdicaoDto.StatusId;
                tarefa.UsuarioId = tarefaEdicaoDto.UsuarioId;
                _context.Update(tarefa);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Tarefas.ToListAsync();
                return resposta;
            }
            catch (Exception ex)
            {

                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<TarefaModel>>> ExcluirTarefa(int idTarefa)
        {
            ResponseModel<List<TarefaModel>> resposta = new ResponseModel<List<TarefaModel>>();
            try
            {
                var tarefa = await _context.Tarefas.FirstOrDefaultAsync(tarefaBanco => tarefaBanco.Id == idTarefa);

                if (tarefa == null)
                {
                    resposta.Mensagem = "Nenhuma tarefa localizada!";
                    return resposta;
                }

                _context.Remove(tarefa);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Tarefas.ToListAsync();
                resposta.Mensagem = "Tarefa removida com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {

                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<ComentarioTarefaModel>> InserirComentario(ComentarioTarefaDto comentarioDto)
        {
            ResponseModel<ComentarioTarefaModel> resposta = new ResponseModel<ComentarioTarefaModel>();

            try
            {
                var tarefa = await _context.Tarefas
                    .FirstOrDefaultAsync(t => t.Id == comentarioDto.TarefaId);

                if (tarefa == null)
                {
                    resposta.Mensagem = "Nenhum registro de tarefa localizado";
                    resposta.Status = false;
                    return resposta;
                }

                var detalhesAlteracao =  $"Comentário inserido pelo usuário: {comentarioDto.Comentario}, " +
                                         $"Tarefa: {comentarioDto.TarefaId}";

                var historico = new HistoricoModel
                {
                    DtAlteracao = DateTime.Now,
                    Detalhes = detalhesAlteracao,
                    TarefaId = comentarioDto.TarefaId
                };

                _context.Historicos.Add(historico);


               var comentario = new ComentarioTarefaModel()
                {
                    Comentario = comentarioDto.Comentario,
                    TarefaId = comentarioDto.TarefaId
                };

                _context.Comentarios.Add(comentario);
                await _context.SaveChangesAsync();

                resposta.Dados = comentario;
                resposta.Mensagem = "Comentário inserido com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}


