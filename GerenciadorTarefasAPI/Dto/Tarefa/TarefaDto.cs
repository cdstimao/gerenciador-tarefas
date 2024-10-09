namespace GerenciadorTarefasAPI.Dto.Tarefa
{

    public class TarefaDto
    {
        public int Id { get; set; }
        public string NomeTarefa { get; set; }
        public string Descricao { get; set; }
        public DateTime DtCriacao { get; set; }
        public DateTime DtVencimento { get; set; }
        public string Prioridade { get; set; }
        public string Status { get; set; }
        public string Projeto { get; set; }
        public string Usuario { get; set; }

    }
}