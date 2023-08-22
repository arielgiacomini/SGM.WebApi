using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGM.Domain.Entities;

namespace SGM.Infrastructure.Mapping
{
    public class FormaPagamentoMapping : IEntityTypeConfiguration<FormaPagamento>
    {
        public void Configure(EntityTypeBuilder<FormaPagamento> builder)
        {
            builder.ToTable("FormaPagamento");
            builder.HasKey(x => x.FormaPagamentoId);
            builder.Property(x => x.FormaPagamentoId).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Descricao);
            builder.Property(x => x.TemTaxaAdicional);
            builder.Property(x => x.PercentualTaxaAdicional);
            builder.Property(x => x.FormaPagamentoAtiva);
            builder.Property(x => x.DataCadastro);
            builder.Property(x => x.DataAlteracao);
        }
    }
}