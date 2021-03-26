using Churrascaria.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Churrascaria.Data
{
    public class ConvidadoConfiguration : IEntityTypeConfiguration<Convidado>
    {
        public void Configure(EntityTypeBuilder<Convidado> builder)
        {
            builder.ToTable("Convidados");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(x => x.Idade);
            builder.Property(x => x.Telefone).HasColumnType("CHAR(11)");
            builder.Property(x => x.ValorConvidado).IsRequired();
        }
    }
}
