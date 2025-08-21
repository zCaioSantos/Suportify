using Suportify.Domain.Entities.Autenticacao;

namespace Suportify.Domain.Entities.Cadastros;

public class Comentario
{
    public string Id { get; set; }
    
    public string TicketId { get; set; }
    public string UsuarioId { get; set; }
    public string Descricao { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime DataAlteracao { get; set; }
    
    public virtual Usuario Usuario { get; set; }
    public virtual Ticket Ticket { get; set; }
    
    
    
    
    public Comentario(){}

    
    public Comentario(string id, string usuarioId, string descricao, string ticketId)
    {
        Id = id;
        UsuarioId = usuarioId;
        TicketId = ticketId;
        
        Alterar(descricao);
    }

    public void Alterar(string descricao)
    {
        Descricao = descricao;
        DataAlteracao = DateTime.Now;
        
        Validar();
        Formatar();
    }

    private void Validar()
    {
        if (string.IsNullOrEmpty(UsuarioId))
            throw new Exception("UsuarioId é obrigatório");
        
    }


    private void Formatar()
    { 
        Descricao.Trim();
    }
    
}
