using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Suportify.Domain.Entities.Cadastros;
using Suportify.Domain.Enums;

namespace Suportify.Infra.Data.EFCore.Mapping.Cadastro
{
    internal class TicketMap : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.ToTable("Ticket");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasMaxLength(64);
            builder.Property(x => x.ClienteId).HasMaxLength(64);
            builder.Property(x => x.ResponsavelId).HasMaxLength(64);
            builder.Property(x => x.Protocolo).HasMaxLength(15);
            builder.Property(x => x.Titulo).HasMaxLength(30);
            builder.Property(x => x.SlaHoras);
            builder.Property(x => x.DataCriacao).HasColumnType("datetime2");
            builder.Property(x => x.DataFechamento).HasColumnType("datetime2");

            builder.Property(x => x.Status)
                .HasConversion(
                    v => v.ToString(),
                    v => (eTicketStatus)Enum.Parse(typeof(eTicketStatus), v))
                .HasMaxLength(20);

            builder.HasOne(x => x.Cliente)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Responsavel)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Comentarios)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
