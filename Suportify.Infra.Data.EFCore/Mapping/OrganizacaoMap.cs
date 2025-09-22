using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Suportify.Domain.Entities;

namespace Suportify.Infra.Data.EFCore.Mapping;

internal class OrganizacaoMap : IEntityTypeConfiguration<Organizacao>
{
    public void Configure(EntityTypeBuilder<Organizacao> builder)
    {
        builder.ToTable("Organizacao");

        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id).HasMaxLength(64);
        builder.Property(x => x.Nome).HasMaxLength(255);
        builder.Property(x => x.Cnpj).HasMaxLength(18);
        builder.Property(x => x.Endereco).HasMaxLength(500);
        builder.Property(x => x.Telefone).HasMaxLength(20);
        builder.Property(x => x.EmailContato).HasMaxLength(255);
        builder.Property(x => x.Ativo).HasDefaultValue(true);
        builder.Property(x => x.DataCriacao).HasColumnType("datetime").HasDefaultValue(DateTime.Now);
        
        builder.HasMany(x => x.Usuarios)
            .WithOne()
            .OnDelete(DeleteBehavior.Restrict);
    }
}