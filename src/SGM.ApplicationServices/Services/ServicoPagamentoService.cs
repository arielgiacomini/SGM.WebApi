using AutoMapper;
using SGM.ApplicationServices.Interfaces;
using SGM.ApplicationServices.ViewModels;
using SGM.Domain.Entities;
using SGM.Domain.Utils;
using SGM.Infrastructure.Repositories.Interfaces;
using System.Collections.Generic;

namespace SGM.ApplicationServices.Services
{
    public class ServicoPagamentoService : IServicoPagamentoServices
    {
        private readonly IServicoPagamentoRepository _servicoPagamentoRepository;
        private readonly IMapper _mapper;

        public ServicoPagamentoService(IServicoPagamentoRepository servicoPagamentoRepository, IMapper mapper)
        {
            _servicoPagamentoRepository = servicoPagamentoRepository;
            _mapper = mapper;
        }

        public IEnumerable<ServicoPagamentoViewModel> GetServicoPagamentoByAll()
        {
            return _mapper.Map<IList<ServicoPagamentoViewModel>>(_servicoPagamentoRepository.GetServicoPagamentoByAll());
        }

        public IList<ServicoPagamentoViewModel> GetUltimosServicoPagamento(int quantidade)
        {
            return _mapper.Map<IList<ServicoPagamentoViewModel>>(_servicoPagamentoRepository.GetUltimosServicoPagamento(quantidade));
        }

        public Count GetServicoPagamentoCount()
        {
            return _mapper.Map<Count>(_servicoPagamentoRepository.GetServicoPagamentoCount());
        }

        public ServicoPagamentoViewModel GetServicoPagamentoById(int servicoPagamentoId)
        {
            return _mapper.Map<ServicoPagamentoViewModel>(_servicoPagamentoRepository.GetServicoPagamentoById(servicoPagamentoId));
        }

        public IList<ServicoPagamentoViewModel> GetServicoPagamentoByServicoId(int servicoId)
        {
            return _mapper.Map<IList<ServicoPagamentoViewModel>>(_servicoPagamentoRepository.GetServicoPagamentoByServicoId(servicoId));
        }

        public int SalvarServicoPagamento(ServicoPagamentoViewModel model)
        {
            return _servicoPagamentoRepository.SalvarServicoPagamento(_mapper.Map<ServicoPagamento>(model));
        }

        public void AtualizarServicoPagamento(ServicoPagamentoViewModel model)
        {
            _servicoPagamentoRepository.AtualizarServicoPagamento(_mapper.Map<ServicoPagamento>(model));
        }

        public void SalvarServicoPagamentoParcelas(IList<ServicoPagamentoParcelaViewModel> servicoPagamentoParcelaViewModels)
        {
            _servicoPagamentoRepository.SalvarServicoPagamentoParcelas(_mapper.Map<IList<ServicoPagamentoParcela>>(servicoPagamentoParcelaViewModels));
        }

        public void DeletarServicoPagamentoParcelaByServicoIdAndParcela(int servicoId, int? parcela)
        {
            _servicoPagamentoRepository.DeletarServicoPagamentoParcelas(servicoId, parcela);
        }
    }
}