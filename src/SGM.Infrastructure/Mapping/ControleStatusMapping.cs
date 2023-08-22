using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGM.Domain.Entities;

namespace SGM.Infrastructure.Mapping
{
    public class ControleStatusMapping : IEntityTypeConfiguration<ControleStatus>
    {
        public void Configure(EntityTypeBuilder<ControleStatus> builder)
        {
            builder.ToTable("ControleStatus");
            builder.HasKey(x => x.StatusId);
            builder.Property(x => x.StatusId).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.TipoStatus);
            builder.Property(x => x.Descricao);
            builder.Property(x => x.DataCadastro);
            builder.Property(x => x.DataAlteracao);
        }
    }
}