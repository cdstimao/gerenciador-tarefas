using GerenciadorTarefasAPI.Dto.Projeto;
using GerenciadorTarefasAPI.Models;
using GerenciadorTarefasAPI.Services.Projetos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;

namespace GerenciadorTarefasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetoController : ControllerBase
    {
        private readonly IProjetoInterface _projetoInterface;
        public ProjetoController(IProjetoInterface projetoInterface)
        {
            _projetoInterface = projetoInterface;
        }

        [HttpGet("ListarProjetos/")]
        public async Task<ActionResult<ResponseModel<List<ProjetoModel>>>> ListarProjetos()
        {
            var projetos = await _projetoInterface.ListarProjetos();
            return Ok(projetos);
        }
        
        [HttpPost("CriarProjeto/")]
        public async Task<ActionResult<ResponseModel<ProjetoModel>>> CriarProjeto(ProjetoCriacaoDto projetoCriacaoDto)
        {
            var projetos = await _projetoInterface.CriarProjeto(projetoCriacaoDto);
            return Ok(projetos);
        }
    }
}
