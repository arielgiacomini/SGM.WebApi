namespace SGM.Domain.DataSources
{
    public class PesquisaMaodeObraServicoDataSource
    {
        public int MaodeObraId { get; set; }
        public string MaodeObra { get; set; }
        public decimal Valor { get; set; }
        public int ServicoMaodeObraId { get; set; }
    }
}