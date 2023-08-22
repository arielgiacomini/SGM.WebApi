﻿using AutoMapper;
using SGM.ApplicationServices.Interfaces;
using SGM.ApplicationServices.ViewModels;
using SGM.Domain.Entities;
using SGM.Domain.Utils;
using SGM.Infrastructure.Repositories.Interfaces;
using System.Collections.Generic;

namespace SGM.ApplicationServices.Services
{
    public class OrcamentoServices : IOrcamentoServices
    {
        private readonly IOrcamentoRepository _orcamentoRepository;
        private readonly IMapper _mapper;

        public OrcamentoServices(IOrcamentoRepository orcamentoRepository, IMapper mapper)
        {
            _orcamentoRepository = orcamentoRepository;
            _mapper = mapper;
        }

        public IEnumerable<OrcamentoViewModel> GetOrcamentoByAll()
        {
            return _mapper.Map<IEnumerable<OrcamentoViewModel>>(_orcamentoRepository.GetOrcamentoByAll());
        }

        public IList<OrcamentoViewModel> GetUltimosOrcamentos(int quantidade)
        {
            return _mapper.Map<IList<OrcamentoViewModel>>(_orcamentoRepository.GetUltimosOrcamento(quantidade));
        }

        public Count GetOrcamentoCount()
        {
            return _mapper.Map<Count>(_orcamentoRepository.GetOrcamentoCount());
        }

        public OrcamentoViewModel GetOrcamentoById(int orcamentoId)
        {
            return _mapper.Map<OrcamentoViewModel>(_orcamentoRepository.GetOrcamentoById(orcamentoId));
        }

        public IList<OrcamentoViewModel> GetOrcamentoByClienteVeiculoId(int clienteVeiculoId)
        {
            return _mapper.Map<IList<OrcamentoViewModel>>(_orcamentoRepository.GetOrcamentoByClienteVeiculoId(clienteVeiculoId));
        }

        public int AtualizarOrSalvarOrcamento(OrcamentoViewModel model)
        {
            var orcamento = _orcamentoRepository.GetOrcamentoById(model.OrcamentoId);

            if (orcamento == null)
            {
                return _orcamentoRepository.SalvarOrcamento(new Orcamento()
                {
                    ClienteVeiculoId = model.ClienteVeiculoId,
                    ColaboradorId = model.ColaboradorId,
                    Descricao = model.Descricao,
                    ValorMaodeObra = model.ValorMaodeObra,
                    ValorPeca = model.ValorPeca,
                    ValorAdicional = model.ValorAdicional,
                    PercentualDesconto = model.PercentualDesconto,
                    ValorDesconto = model.ValorDesconto,
                    ValorTotal = model.ValorTotal,
                    Status = model.Status,
                    Ativo = model.Ativo,
                    DataCadastro = model.DataCadastro,
                    DataAlteracao = model.DataAlteracao
                });
            }
            else
            {
                _orcamentoRepository.AtualizarOrcamento(new Orcamento()
                {
                    OrcamentoId = model.OrcamentoId,
                    ClienteVeiculoId = model.ClienteVeiculoId,
                    ColaboradorId = model.ColaboradorId,
                    Descricao = model.Descricao,
                    ValorMaodeObra = model.ValorMaodeObra,
                    ValorPeca = model.ValorPeca,
                    ValorAdicional = model.ValorAdicional,
                    PercentualDesconto = model.PercentualDesconto,
                    ValorDesconto = model.ValorDesconto,
                    ValorTotal = model.ValorTotal,
                    Status = model.Status,
                    Ativo = model.Ativo,
                    DataCadastro = model.DataCadastro,
                    DataAlteracao = model.DataAlteracao
                });

                return 0;
            }
        }

        public int SalvarOrcamentoMaodeObra(OrcamentoMaodeObraViewModel orcamentoMaodeObraViewModel)
        {
            return _orcamentoRepository.SalvarOrcamentoMaodeObra(_mapper.Map<OrcamentoMaodeObra>(orcamentoMaodeObraViewModel));
        }

        public int SalvarOrcamentoPeca(OrcamentoPecaViewModel orcamentoPecaViewModel)
        {
            return _orcamentoRepository.SalvarOrcamentoPeca(_mapper.Map<OrcamentoPeca>(orcamentoPecaViewModel));
        }

        public void DeletarOrcamentoMaodeObra(OrcamentoMaodeObraViewModel orcamentoMaodeObraViewModel)
        {
            _orcamentoRepository.DeletarOrcamentoMaodeObra(_mapper.Map<OrcamentoMaodeObra>(orcamentoMaodeObraViewModel));
        }

        public void DeletarOrcamentoPeca(OrcamentoPecaViewModel orcamentoPecaViewModel)
        {
            _orcamentoRepository.DeletarOrcamentoPeca(_mapper.Map<OrcamentoPeca>(orcamentoPecaViewModel));
        }

        public IList<OrcamentoMaodeObraViewModel> GetOrcamentoMaodeObraByOrcamentoId(int orcamentoId)
        {
            return _mapper.Map<IList<OrcamentoMaodeObraViewModel>>(_orcamentoRepository.GetOrcamentoMaodeObraByOrcamentoId(orcamentoId));
        }

        public IList<OrcamentoPecaViewModel> GetOrcamentoPecaByOrcamentoId(int orcamentoId)
        {
            return _mapper.Map<IList<OrcamentoPecaViewModel>>(_orcamentoRepository.GetOrcamentoPecaByOrcamentoId(orcamentoId));
        }
    }
}