using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGM.Domain.Entities;

namespace SGM.Infrastructure.Mapping
{
    public class ServicoPagamentoMapping : IEntityTypeConfiguration<ServicoPagamento>
    {
        public void Configure(EntityTypeBuilder<ServicoPagamento> builder)
        {
            builder.ToTable("ServicoPagamento");
            builder.HasKey(x => x.ServicoPagamentoId);
            builder.Property(x => x.ServicoPagamentoId).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.ServicoId);
            builder.Property(x => x.FormaPagamentoId);
            builder.Property(x => x.ValorTotalOriginal);
            builder.Property(x => x.ValorTotalPago);
            builder.Property(x => x.SaldoDevedorTotal);
            builder.Property(x => x.DataPagamento);
            builder.Property(x => x.EhPagamentoParcelado);
            builder.Property(x => x.EhPagamentoEmDuasFormaPagamento);
            builder.Property(x => x.ValorPagoNaSegundaFormaPagamento);
            builder.Property(x => x.ColaboradorCadastroId);
            builder.Property(x => x.DataCadastro);
            builder.Property(x => x.ColaboradorAlteracaoId);
            builder.Property(x => x.DataAlteracao);
        }
    }
}