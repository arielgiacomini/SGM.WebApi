using Microsoft.EntityFrameworkCore;
using SGM.Domain.Entities;
using SGM.Domain.Utils;
using SGM.Infrastructure.Context;
using SGM.Infrastructure.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SGM.Infrastructure.Repositories.Repository
{
    public class OrcamentoRepository : IOrcamentoRepository
    {
        private readonly SGMContext _SGMContext;

        public OrcamentoRepository(SGMContext sgmContext)
        {
            _SGMContext = sgmContext;
        }

        public IEnumerable<Orcamento> GetOrcamentoByAll()
        {
            var orcamentos = _SGMContext.Orcamento.AsNoTracking().ToList();

            if (orcamentos != null)
            {
                foreach (var orcamento in orcamentos)
                {
                    orcamento.OrcamentoMaodeObra = GetOrcamentoMaodeObraByOrcamentoId(orcamento.OrcamentoId);
                    orcamento.OrcamentoPeca = GetOrcamentoPecaByOrcamentoId(orcamento.OrcamentoId);
                }
            }

            return orcamentos;
        }

        public IList<Orcamento> GetUltimosOrcamento(int quantidade)
        {
            return GetOrcamentoByAll().OrderByDescending(x => x.DataCadastro).Take(quantidade).ToList();
        }

        public Count GetOrcamentoCount()
        {
            var contagem = GetOrcamentoByAll().Count();

            Count cont = new Count();
            {
                cont.Contagem = contagem;
            }

            return cont;
        }

        public Orcamento GetOrcamentoById(int orcamentoId)
        {
            var orcamento = _SGMContext.Orcamento.AsNoTracking().Where(x => x.OrcamentoId == orcamentoId).FirstOrDefault();

            if (orcamento != null)
            {
                orcamento.OrcamentoMaodeObra = GetOrcamentoMaodeObraByOrcamentoId(orcamentoId);
                orcamento.OrcamentoPeca = GetOrcamentoPecaByOrcamentoId(orcamentoId);
            }

            return orcamento;
        }

        public IList<Orcamento> GetOrcamentoByClienteVeiculoId(int clienteVeiculoId)
        {
            var orcamentos = _SGMContext.Orcamento.AsNoTracking().Where(orcamento => orcamento.ClienteVeiculoId == clienteVeiculoId).ToList();

            if (orcamentos != null)
            {
                foreach (var orcamento in orcamentos)
                {
                    orcamento.OrcamentoMaodeObra = GetOrcamentoMaodeObraByOrcamentoId(orcamento.OrcamentoId);
                    orcamento.OrcamentoPeca = GetOrcamentoPecaByOrcamentoId(orcamento.OrcamentoId);
                }
            }

            return orcamentos;
        }

        public int SalvarOrcamento(Orcamento orcamento)
        {
            _SGMContext.Orcamento.Add(orcamento);
            _SGMContext.SaveChanges();

            return orcamento.OrcamentoId;
        }

        public void AtualizarOrcamento(Orcamento orcamento)
        {
            _SGMContext.Orcamento.Update(orcamento);
            _SGMContext.SaveChanges();
        }

        public int SalvarOrcamentoMaodeObra(OrcamentoMaodeObra orcamentoMaodeObra)
        {
            _SGMContext.OrcamentoMaodeObra.Add(orcamentoMaodeObra);
            _SGMContext.SaveChanges();

            return orcamentoMaodeObra.Id;
        }

        public int SalvarOrcamentoPeca(OrcamentoPeca orcamentoPeca)
        {
            _SGMContext.OrcamentoPeca.Add(orcamentoPeca);
            _SGMContext.SaveChanges();

            return orcamentoPeca.Id;
        }

        public void DeletarOrcamentoMaodeObra(OrcamentoMaodeObra orcamentoMaodeObra)
        {
            _SGMContext.OrcamentoMaodeObra.Remove(orcamentoMaodeObra);
            _SGMContext.SaveChanges();
        }

        public void DeletarOrcamentoPeca(OrcamentoPeca orcamentoPeca)
        {
            _SGMContext.OrcamentoPeca.Remove(orcamentoPeca);
            _SGMContext.SaveChanges();
        }

        public IList<OrcamentoMaodeObra> GetOrcamentoMaodeObraByOrcamentoId(int orcamentoId)
        {
            var orcamentoMaodeObra = _SGMContext.OrcamentoMaodeObra.AsNoTracking().Where(orcamento => orcamento.OrcamentoId == orcamentoId).ToList();

            return orcamentoMaodeObra;
        }

        public IList<OrcamentoPeca> GetOrcamentoPecaByOrcamentoId(int orcamentoId)
        {
            var orcamentoPeca = _SGMContext.OrcamentoPeca.AsNoTracking().Where(orcamento => orcamento.OrcamentoId == orcamentoId).ToList();

            return orcamentoPeca;
        }
    }
}