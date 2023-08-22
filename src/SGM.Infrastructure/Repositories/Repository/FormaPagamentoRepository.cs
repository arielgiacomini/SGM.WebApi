using Microsoft.EntityFrameworkCore;
using SGM.Domain.Entities;
using SGM.Infrastructure.Context;
using SGM.Infrastructure.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SGM.Infrastructure.Repositories.Repository
{
    public class FormaPagamentoRepository : IFormaPagamentoRepository
    {
        private readonly SGMContext _sGMContext;

        public FormaPagamentoRepository(SGMContext sGMContext)
        {
            _sGMContext = sGMContext;
        }

        public IEnumerable<FormaPagamento> GetFormaPagamentoByAll()
        {
            var formaPagamento = _sGMContext.FormaPagamento.AsNoTracking().ToList();

            foreach (var forma in formaPagamento)
            {
                forma.ParcelaDisponivel = _sGMContext.FormaPagamentoParcela.AsNoTracking().Where(parcela => parcela.FormaPagamentoId == forma.FormaPagamentoId).ToList();
            }

            return formaPagamento;
        }

        public FormaPagamento GetFormaPagamentoById(int formaPagamentoId)
        {
            var formaPagamento = _sGMContext.FormaPagamento.AsNoTracking().Where(forma => forma.FormaPagamentoId == formaPagamentoId).FirstOrDefault();

            if (formaPagamento.FormaPagamentoId > 0)
            {
                var formaPagamentoParcela = _sGMContext.FormaPagamentoParcela.AsNoTracking().Where(parcela => parcela.FormaPagamentoId == formaPagamento.FormaPagamentoId).ToList();

                formaPagamento.ParcelaDisponivel = formaPagamentoParcela;
            }

            return formaPagamento;
        }
    }
}