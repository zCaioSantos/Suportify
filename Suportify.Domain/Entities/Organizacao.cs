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
    public Boolean Ativo { get; private set; }
    public DateTime DataCriacao { get; private set; }
    
    public required virtual List<Usuario> Usuarios { get; set; } = new List<Usuario>();
    
    
    
    
    public Organizacao(){}
    
    
    public Organizacao(string? id, string nome, string cnpj, string endereco, string telefone, string email, Boolean ativo, DateTime dataCriacao)
    {
        Id = id;
        Nome = nome;
        Cnpj = cnpj;
        Endereco = endereco;
        Telefone = telefone;
        EmailContato = email;
        Ativo = true;
        DataCriacao = DateTime.Now;
        Alterar(nome, endereco, telefone, email, ativo);
    }

    
    public void Alterar(string nome, string endereco, string telefone, string email, Boolean ativo)
    {
        Nome = nome;
        Endereco = endereco;
        Telefone = telefone;
        EmailContato = email;
        Ativo = ativo;
        Validar(nome, endereco, telefone, email);
        Formatar(nome, endereco, telefone, email);
    }

    
    public void Ativar()
    {
        Ativo = true;
    }

    
    public void Desativar()
    {
        Ativo = false;
    }

    
    public void Validar(string nome, string endereco, string telefone, string email)
    {
        if (!string.IsNullOrEmpty(nome)) throw new Exception("Nome da organização é obrigatório");
        if (!string.IsNullOrEmpty(endereco)) throw new Exception("Endereço da organização é obrigatório");
        if (!string.IsNullOrEmpty(email)) throw new Exception("Email de contato da organização é obrigatório");
        if (!string.IsNullOrEmpty(telefone)) throw new Exception("Telefone da organização é obrigatório");
    }

    
    public void Formatar(string nome, string endereco, string telefone, string email)
    {
        nome.Trim();
        endereco.Trim();
        telefone.Trim();
        email.Trim();
    }
    
    
}