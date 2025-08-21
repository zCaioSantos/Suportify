using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Suportify.Domain.Entities.Cadastros;

namespace Suportify.Infra.Data.EFCore.Mapping.Cadastro;

internal class ComentarioMap : IEntityTypeConfiguration<Comentario>
{
    public void Configure(EntityTypeBuilder<Comentario> builder)
    {
        builder.ToTable("Comentario");

        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id).HasMaxLength(64);
        builder.Property(x => x.UsuarioId).HasMaxLength(64);
        builder.Property(x => x.Descricao).HasMaxLength(1024);
        builder.Property(x => x.DataCriacao).HasColumnType("datetime");
        builder.Property(x => x.DataAlteracao).HasColumnType("datetime");
        
        builder.HasOne(x => x.Usuario)
            .WithOne()
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(x => x.Ticket)
            .WithOne()
            .OnDelete(DeleteBehavior.Restrict);

    }
}