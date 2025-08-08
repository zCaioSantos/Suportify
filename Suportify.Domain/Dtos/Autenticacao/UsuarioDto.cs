using Suportify.Domain.Entities.Autenticacao;

namespace Suportify.Domain.Dtos.Autenticacao
{
    public record UsuarioDto
    {
        public string? Id { get; set; }
        public required string Email { get; set; }
        public required string Nome { get; set; }
        public string? Senha { get; set; }
        public required PerfilUsuario Perfil { get; set; }
        public string? Foto { get; set; }
        public string? Token { get; set; }
        public DateTime? ExpiracaoToken { get; set; }
        public string? RefreshToken { get; set; }
        public string? CodigoRecuperacaoSenha { get; set; }
        public DateTime? DataExpiracaoCodigo { get; set; }
        public bool Ativo { get; set; }


        public static UsuarioDto FromModel(Usuario entity)
        {
            return new UsuarioDto
            {
                Id = entity.Id,
                Email = entity.Email,
                Nome = entity.Nome,
                Senha = entity.Senha,
                Perfil = entity.Perfil,
                Foto = entity.Foto,
                Token = entity.Token,
                ExpiracaoToken = entity.ExpiracaoToken,
                RefreshToken = entity.RefreshToken,
                CodigoRecuperacaoSenha = entity.CodigoRecuperacaoSenha,
                DataExpiracaoCodigo = entity.DataExpiracaoCodigo,
                Ativo = entity.Ativo
            };
        }

    }
}
