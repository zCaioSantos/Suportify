using Suportify.Domain.Enums;

namespace Suportify.Domain.Entities.Autenticacao
{
    public class Usuario
    {
        public string Id { get; private set; }
        public string Email { get; private set; }
        public string Nome { get; private set; }
        public string Senha { get; private set; }
        public ePerfilUsuario Perfil { get; private set; }
        public string? Foto { get; private set; }
        public string? Token { get; private set; }
        public DateTime? ExpiracaoToken { get; private set; }
        public string? RefreshToken { get; private set; }
        public string? CodigoRecuperacaoSenha { get; private set; }
        public DateTime? DataExpiracaoCodigo { get; private set; }
        public bool Ativo { get; private set; }
        
        
        
        public virtual Organizacao Organizacao { get; set; }



        #region Construtores
        public Usuario()
        {
        }

        public Usuario(string? id, string email, string nome, string? foto, ePerfilUsuario perfil)
        {
            Id = string.IsNullOrWhiteSpace(id) ? Guid.NewGuid().ToString() : id;

            Alterar(email, nome, foto, perfil, true);
            GerarCodigoRecuperacaoSenha();
        }
        #endregion



        #region Metodos Publicos
        public void Alterar(string email, string nome, string? foto, ePerfilUsuario perfil, bool ativo)
        {
            Email = email.Trim();
            Nome = nome.Trim();
            Foto = foto;
            Perfil = perfil;
            Ativo = ativo;

            Validar();
        }

        public void DefinirSenha(string senha)
        {
            if (string.IsNullOrWhiteSpace(senha))
                throw new ArgumentException("Senha não pode ser vazia.");

            Senha = senha;
        }


        public void CriarAcesso(string? token, DateTime? expiracaoToken, string? refreshToken)
        {
            Token = token;
            ExpiracaoToken = expiracaoToken;
            RefreshToken = refreshToken;
        }


        public void GerarCodigoRecuperacaoSenha()
        {
            CodigoRecuperacaoSenha = new Random().Next(100000, 999999).ToString();
            DataExpiracaoCodigo = DateTime.Now.AddHours(1);
        }
        #endregion



        #region Metodos Privados
        private void Validar()
        {
            if (Email.IndexOf('@') <= 0)
                throw new ArgumentException("E-mail invalido.");
        } 
        #endregion

    }
}
