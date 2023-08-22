namespace SGM.Domain.DataSources
{
    public class PesquisaPecaServicoDataSource
    {
        public int PecaId { get; set; }
        public string Peca { get; set; }
        public decimal Valor { get; set; }
        public int ServicoPecaId { get; set; }
    }
}