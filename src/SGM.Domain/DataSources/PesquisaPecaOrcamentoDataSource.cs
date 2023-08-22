namespace SGM.Domain.DataSources
{
    public class PesquisaPecaOrcamentoDataSource
    {
        public int PecaId { get; set; }
        public string Peca { get; set; }
        public decimal Valor { get; set; }
        public int OrcamentoPecaId { get; set; }
    }
}