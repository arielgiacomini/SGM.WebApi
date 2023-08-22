using AutoMapper;
using SGM.ApplicationServices.Interfaces;
using SGM.ApplicationServices.ViewModels;
using SGM.Infrastructure.Repositories.Interfaces;
using System.Collections.Generic;

namespace SGM.ApplicationServices.Services
{
    public class FormaPagamentoServices : IFormaPagamentoServices
    {
        private readonly IFormaPagamentoRepository _formaPagamentoRepository;
        private readonly IMapper _mapper;

        public FormaPagamentoServices(IFormaPagamentoRepository formaPagamentoRepository, IMapper mapper)
        {
            _formaPagamentoRepository = formaPagamentoRepository;
            _mapper = mapper;
        }

        public IList<FormaPagamentoViewModel> GetFormaPagamentoByAll()
        {
            return _mapper.Map<IList<FormaPagamentoViewModel>>(_formaPagamentoRepository.GetFormaPagamentoByAll());
        }

        public FormaPagamentoViewModel GetFormaPagamentoById(int formaPagamentoId)
        {
            return _mapper.Map<FormaPagamentoViewModel>(_formaPagamentoRepository.GetFormaPagamentoById(formaPagamentoId));
        }
    }
}