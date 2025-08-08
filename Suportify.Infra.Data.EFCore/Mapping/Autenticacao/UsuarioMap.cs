using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Suportify.Domain.Entities.Autenticacao;

namespace Suportify.Infra.Data.EFCore.Mapping.Autenticacao
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasMaxLength(64);
            builder.Property(x => x.Email).HasMaxLength(300).IsRequired();
            builder.Property(x => x.Nome).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Senha).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Perfil).IsRequired();
            builder.Property(x => x.Foto).HasMaxLength(300);
            builder.Property(x => x.Token).HasMaxLength(800);
            builder.Property(x => x.ExpiracaoToken).HasColumnType("datetime2");
            builder.Property(x => x.RefreshToken).HasMaxLength(500);
            builder.Property(x => x.CodigoRecuperacaoSenha).HasMaxLength(6);
            builder.Property(x => x.DataExpiracaoCodigo).HasColumnType("datetime2");
            builder.Property(x => x.Ativo).IsRequired();
        }
    }
}
