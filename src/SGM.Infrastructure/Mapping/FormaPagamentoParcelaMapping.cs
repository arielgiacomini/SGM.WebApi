using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGM.Domain.Entities;

namespace SGM.Infrastructure.Mapping
{
    public class FormaPagamentoParcelaMapping : IEntityTypeConfiguration<FormaPagamentoParcela>
    {
        public void Configure(EntityTypeBuilder<FormaPagamentoParcela> builder)
        {
            builder.ToTable("FormaPagamentoParcela");
            builder.HasKey(x => x.FormaPagamentoParcelaId);
            builder.Property(x => x.FormaPagamentoParcelaId).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.FormaPagamentoId);
            builder.Property(x => x.NumeroParcela);
            builder.Property(x => x.TextoParcela);
            builder.Property(x => x.DataCadastro);
            builder.Property(x => x.ColaboradorCadastroId);
            builder.Property(x => x.DataAlteracao);
            builder.Property(x => x.ColaboradorAlteracaoId);
        }
    }
}