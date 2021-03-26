using Churrascaria.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Churrascaria.Data
{
    public class FuncionarioConfiguration : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.ToTable("Funcionarios");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasColumnType("VARCHAR(80)").IsRequired();
            builder.Property(x => x.Idade);
            builder.Property(x => x.Telefone).HasColumnType("CHAR(11)");
            builder.Property(x => x.ValorFuncionario).IsRequired();
            builder.Property(x => x.ConvidadoId);

            builder.HasOne(x => x.Convidado)
                    .WithOne(x => x.Funcionario);
        }
    }
}
