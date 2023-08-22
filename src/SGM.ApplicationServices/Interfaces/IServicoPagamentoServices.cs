using SGM.ApplicationServices.ViewModels;
using SGM.Domain.Utils;
using System.Collections.Generic;

namespace SGM.ApplicationServices.Interfaces
{
    public interface IServicoPagamentoServices
    {
        void AtualizarServicoPagamento(ServicoPagamentoViewModel model);
        void DeletarServicoPagamentoParcelaByServicoIdAndParcela(int servicoId, int? parcela);
        IEnumerable<ServicoPagamentoViewModel> GetServicoPagamentoByAll();
        ServicoPagamentoViewModel GetServicoPagamentoById(int servicoPagamentoId);
        IList<ServicoPagamentoViewModel> GetServicoPagamentoByServicoId(int servicoId);
        Count GetServicoPagamentoCount();
        IList<ServicoPagamentoViewModel> GetUltimosServicoPagamento(int quantidade);
        int SalvarServicoPagamento(ServicoPagamentoViewModel model);
        void SalvarServicoPagamentoParcelas(IList<ServicoPagamentoParcelaViewModel> servicoPagamentoParcelaViewModels);
    }
}