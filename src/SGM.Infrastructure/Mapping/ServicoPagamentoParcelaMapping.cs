using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGM.Domain.Entities;

namespace SGM.Infrastructure.Mapping
{
    public class ServicoPagamentoParcelaMapping : IEntityTypeConfiguration<ServicoPagamentoParcela>
    {
        public void Configure(EntityTypeBuilder<ServicoPagamentoParcela> builder)
        {
            builder.ToTable("ServicoPagamentoParcela");
            builder.HasKey(x => x.ServicoPagamentoParcelaId);
            builder.Property(x => x.ServicoPagamentoParcelaId).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.ServicoPagamentoId);
            builder.Property(x => x.Parcela);
            builder.Property(x => x.ValorOriginalParcela);
            builder.Property(x => x.DataPagamento);
            builder.Property(x => x.Descricao);
            builder.Property(x => x.ParcelaGeradaAutomaticamente);
            builder.Property(x => x.DataCadastro);
            builder.Property(x => x.DataAlteracao);
        }
    }
}