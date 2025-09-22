using Suportify.Domain.Entities.Autenticacao;

namespace Suportify.Domain.Entities;

public class Organizacao
{
    public string Id { get; private set; }
    public List<string> UsuariosId { get; private set; }
    public string Nome { get; private set; }
    public string Cnpj { get; private set; }
    public string Endereco { get; private set; }
    public string Telefone { get; private set; }
    public string EmailContato { get; private set; }
    public bool Ativo { get; private set; }
    public DateTime DataCriacao { get; private set; }
    
    public required virtual List<Usuario> Usuarios { get; set; } = new List<Usuario>();
    
    
    
    
    public Organizacao(){}
    
    
    public Organizacao(string? id, string nome, string cnpj, string endereco, string telefone, string email)
    {
        Id = id;
        Cnpj = cnpj;
        Ativo = true;
        DataCriacao = DateTime.Now;
        Alterar(nome, endereco, telefone, email);

    }

    
    public void Alterar(string nome, string endereco, string telefone, string email)
    {
        Nome = nome;
        Endereco = endereco;
        Telefone = telefone;
        EmailContato = email;
        Formatar();
        Validar();
    }

    
    public void Ativar()
    {
        Ativo = true;
    }

    
    public void Desativar()
    {
        Ativo = false;
    }

    
    public void Validar()
    {
        if (string.IsNullOrEmpty(Nome)) throw new Exception("Nome da organização é obrigatório");
        if (string.IsNullOrEmpty(Endereco)) throw new Exception("Endereço da organização é obrigatório");
        if (string.IsNullOrEmpty(EmailContato)) throw new Exception("Email de contato da organização é obrigatório");
        if (string.IsNullOrEmpty(Telefone)) throw new Exception("Telefone da organização é obrigatório");
    }

    
    public void Formatar()
    {
        Nome = Nome.Trim();
        Endereco = Endereco.Trim();
        Telefone = Telefone.Trim();
        EmailContato = EmailContato.Trim();
    }
    
    
}