using GerenciadorTarefasAPI.Data;
using GerenciadorTarefasAPI.Dto.Projeto;
using GerenciadorTarefasAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorTarefasAPI.Services.Projetos
{
    public class ProjetoService : IProjetoInterface
    {
        private readonly AppDbContext _context;
        public ProjetoService(AppDbContext context) 
        {
            _context = context;
        }
       public async Task<ResponseModel<List<ProjetoModel>>> CriarProjeto(ProjetoCriacaoDto projetoCriacaoDto)
        {
            ResponseModel<List<ProjetoModel>> resposta = new ResponseModel<List<ProjetoModel>>();

            try
            {
                var projeto = new ProjetoModel() 
                {
                    NomeProjeto = projetoCriacaoDto.NomeProjeto
                };

                _context.Add(projeto);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Projetos.ToListAsync();
                resposta.Mensagem = "Projeto criado com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {

                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<ProjetoModel>>> ListarProjetos()
        {
            ResponseModel<List<ProjetoModel>> resposta = new ResponseModel<List<ProjetoModel>>();
            try
            {
                var projetos = await _context.Projetos.ToListAsync();
                resposta.Dados = projetos;
                resposta.Mensagem = "Todos os Projetos foram coletados!";
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
