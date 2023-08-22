namespace SGM.Domain.DataSources
{
    public class PesquisaMaodeObraOrcamentoDataSource
    {
        public int MaodeObraId { get; set; }
        public string MaodeObra { get; set; }
        public decimal Valor { get; set; }
        public int OrcamentoMaodeObraId { get; set; }
    }
}