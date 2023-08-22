using SGM.ApplicationServices.ViewModels;
using System.Collections.Generic;

namespace SGM.ApplicationServices.Interfaces
{
    public interface IFormaPagamentoServices
    {
        IList<FormaPagamentoViewModel> GetFormaPagamentoByAll();
        FormaPagamentoViewModel GetFormaPagamentoById(int formaPagamentoId);
    }
}