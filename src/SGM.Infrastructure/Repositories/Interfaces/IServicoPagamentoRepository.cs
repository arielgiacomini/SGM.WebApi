using SGM.Domain.Entities;
using SGM.Domain.Utils;
using System.Collections.Generic;

namespace SGM.Infrastructure.Repositories.Interfaces
{
    public interface IServicoPagamentoRepository
    {
        void AtualizarServicoPagamento(ServicoPagamento servicoPagamento);
        void DeletarServicoPagamentoParcelas(int servicoId, int? parcela);
        IEnumerable<ServicoPagamento> GetServicoPagamentoByAll();
        ServicoPagamento GetServicoPagamentoById(int servicoPagamentoId);
        IList<ServicoPagamento> GetServicoPagamentoByServicoId(int servicoId);
        Count GetServicoPagamentoCount();
        IList<ServicoPagamento> GetUltimosServicoPagamento(int quantidade);
        int SalvarServicoPagamento(ServicoPagamento servicoPagamento);
        void SalvarServicoPagamentoParcelas(IList<ServicoPagamentoParcela> servicoPagamentoParcelas);
    }
}