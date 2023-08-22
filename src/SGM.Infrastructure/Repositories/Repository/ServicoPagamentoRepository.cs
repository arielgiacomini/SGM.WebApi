using Microsoft.EntityFrameworkCore;
using SGM.Domain.Entities;
using SGM.Domain.Utils;
using SGM.Infrastructure.Context;
using SGM.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SGM.Infrastructure.Repositories.Repository
{
    public class ServicoPagamentoRepository : IServicoPagamentoRepository
    {
        private readonly SGMContext _sGMContext;
        private readonly IServicoRepository _servicoRepository;
        private readonly IFormaPagamentoRepository _formaPagamentoRepository;

        public ServicoPagamentoRepository(SGMContext sGMContext, IServicoRepository servicoRepository, IFormaPagamentoRepository formaPagamentoRepository)
        {
            _sGMContext = sGMContext;
            _servicoRepository = servicoRepository;
            _formaPagamentoRepository = formaPagamentoRepository;
        }

        public IEnumerable<ServicoPagamento> GetServicoPagamentoByAll()
        {
            var servicosPagamento = _sGMContext.ServicoPagamento.AsNoTracking().ToList();

            if (servicosPagamento != null)
            {
                foreach (var servicoPagamento in servicosPagamento)
                {
                    servicoPagamento.ServicoPagamentoParcela = GetServicoPagamentoParcelaByServicoPagamentoId(servicoPagamento.ServicoPagamentoId);

                    servicoPagamento.FormaPagamento = _formaPagamentoRepository.GetFormaPagamentoById(servicoPagamento.FormaPagamentoId);
                }
            }

            return servicosPagamento;
        }

        public IList<ServicoPagamento> GetUltimosServicoPagamento(int quantidade)
        {
            var ultimosServicosPagamento = GetServicoPagamentoByAll().OrderByDescending(x => x.DataCadastro).Take(quantidade).ToList();

            if (ultimosServicosPagamento != null)
            {
                foreach (var ultimoServicoPagamento in ultimosServicosPagamento)
                {
                    ultimoServicoPagamento.ServicoPagamentoParcela = GetServicoPagamentoParcelaByServicoPagamentoId(ultimoServicoPagamento.ServicoPagamentoId);

                    ultimoServicoPagamento.FormaPagamento = _formaPagamentoRepository.GetFormaPagamentoById(ultimoServicoPagamento.FormaPagamentoId);
                }
            }

            return ultimosServicosPagamento;
        }

        public Count GetServicoPagamentoCount()
        {
            var contagem = GetServicoPagamentoByAll().Count();

            Count cont = new Count();
            {
                cont.Contagem = contagem;
            }

            return cont;
        }

        public ServicoPagamento GetServicoPagamentoById(int servicoPagamentoId)
        {
            var servicoPagamento = _sGMContext.ServicoPagamento.AsNoTracking().Where(pagamento => pagamento.ServicoPagamentoId == servicoPagamentoId).FirstOrDefault();

            if (servicoPagamento != null)
            {
                servicoPagamento.ServicoPagamentoParcela = GetServicoPagamentoParcelaByServicoPagamentoId(servicoPagamento.ServicoPagamentoId);

                servicoPagamento.FormaPagamento = _formaPagamentoRepository.GetFormaPagamentoById(servicoPagamento.FormaPagamentoId);
            }

            return servicoPagamento;
        }

        public int SalvarServicoPagamento(ServicoPagamento servicoPagamento)
        {
            _sGMContext.ServicoPagamento.Add(servicoPagamento);
            _sGMContext.SaveChanges();

            return servicoPagamento.ServicoPagamentoId;
        }

        public void AtualizarServicoPagamento(ServicoPagamento servicoPagamento)
        {
            _sGMContext.ServicoPagamento.Update(servicoPagamento);
            _sGMContext.SaveChanges();
        }

        public IList<ServicoPagamento> GetServicoPagamentoByServicoId(int servicoId)
        {
            var servicoPagamentos = _sGMContext.ServicoPagamento.AsNoTracking().Where(pagamento => pagamento.ServicoId == servicoId).ToList();

            if (servicoPagamentos != null)
            {
                foreach (var servicoPagamento in servicoPagamentos)
                {
                    if (servicoPagamento.EhPagamentoParcelado)
                    {
                        servicoPagamento.ServicoPagamentoParcela = GetServicoPagamentoParcelaByServicoPagamentoId(servicoPagamento.ServicoPagamentoId);
                    }

                    servicoPagamento.FormaPagamento = _formaPagamentoRepository.GetFormaPagamentoById(servicoPagamento.FormaPagamentoId);
                }
            }

            return servicoPagamentos;
        }

        private IList<ServicoPagamentoParcela> GetServicoPagamentoParcelaByServicoPagamentoId(int servicoPagamentoId)
        {
            var servicoPagamentoParcela = _sGMContext.ServicoPagamentoParcela.AsNoTracking().Where(parcela => parcela.ServicoPagamentoId == servicoPagamentoId).ToList();

            return servicoPagamentoParcela;
        }

        public void SalvarServicoPagamentoParcelas(IList<ServicoPagamentoParcela> servicoPagamentoParcelas)
        {
            foreach (var parcela in servicoPagamentoParcelas)
            {
                _sGMContext.ServicoPagamentoParcela.Add(parcela);
                _sGMContext.SaveChanges();
            }
        }

        public void DeletarServicoPagamentoParcelas(int servicoId, int? parcelaInformada)
        {
            var servicoPagamento = GetServicoPagamentoByServicoId(servicoId).FirstOrDefault();
            var quantidadeParcelasTotais = servicoPagamento?.ServicoPagamentoParcela?.Count();

            if (parcelaInformada != null && servicoPagamento != null)
            {
                var remover = servicoPagamento.ServicoPagamentoParcela.FirstOrDefault(x => x.Parcela == parcelaInformada);

                _sGMContext.ServicoPagamentoParcela.Remove(remover);

                _sGMContext.SaveChanges();
            }
            else if (parcelaInformada == null && quantidadeParcelasTotais > 0)
            {
                var parcelas = servicoPagamento.ServicoPagamentoParcela;

                foreach (var remover in parcelas)
                {
                    _sGMContext.ServicoPagamentoParcela.Remove(remover);

                    _sGMContext.SaveChanges();
                }
            }
        }

        private ServicoPagamentoParcela GetServicoPagamentoParcelaByServicoIdAndParcela(int servicoId, int parcela)
        {
            var servicoPagamentoParcela = new ServicoPagamentoParcela();

            try
            {
                var servico = _servicoRepository.GetServicoById(servicoId);

                if (servico != null)
                {
                    var servicoPagamento = GetServicoPagamentoById(servico.ServicoId);

                    if (servicoPagamento != null)
                    {
                        servicoPagamentoParcela = _sGMContext.ServicoPagamentoParcela.AsNoTracking().Where(parc => parc.ServicoPagamentoId == servicoPagamento.ServicoPagamentoId && parc.Parcela == parcela).FirstOrDefault();

                        if (servicoPagamentoParcela == null)
                        {
                            servicoPagamentoParcela = new ServicoPagamentoParcela();
                        }

                        servicoPagamento.FormaPagamento = _formaPagamentoRepository.GetFormaPagamentoById(servicoPagamento.FormaPagamentoId);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return servicoPagamentoParcela;
        }

        private ServicoPagamentoParcela GetServicoPagamentoParcelaById(int servicoPagamentoParcelaId)
        {
            var servicoPagamentoParcela = _sGMContext.ServicoPagamentoParcela.AsNoTracking().Where(parcela => parcela.ServicoPagamentoParcelaId == servicoPagamentoParcelaId).FirstOrDefault();

            return servicoPagamentoParcela;
        }
    }
}