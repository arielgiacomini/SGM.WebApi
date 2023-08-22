using SGM.Domain.Entities;
using System.Collections.Generic;

namespace SGM.Infrastructure.Repositories.Interfaces
{
    public interface IFormaPagamentoRepository
    {
        IEnumerable<FormaPagamento> GetFormaPagamentoByAll();
        FormaPagamento GetFormaPagamentoById(int formaPagamentoId);
    }
}