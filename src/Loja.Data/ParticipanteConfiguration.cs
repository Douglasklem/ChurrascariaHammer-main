using Churrascaria.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Churrascaria.Data.Configuration
{
    public class ParticipanteConfiguration : IEntityTypeConfiguration<Participante>
    {
        public void Configure(EntityTypeBuilder<Participante> builder)
        {
            builder.ToTable("Participantes");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasColumnName("VARCHAR(80)").IsRequired();
        }
    }
}
