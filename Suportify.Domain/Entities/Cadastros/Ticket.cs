using Suportify.Domain.Entities.Autenticacao;
using Suportify.Domain.Enums;

namespace Suportify.Domain.Entities.Cadastros
{
    public class Ticket
    {
        public string Id { get; private set; }
        public string ClienteId { get; private set; }
        public string? ResponsavelId { get; private set; }
        public string Protocolo { get; private set; }
        public string Titulo { get; private set; }
        public int SlaHoras { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime? DataFechamento { get; private set; }
        public eTicketStatus Status { get; private set; }
        
        public List<Comentario> Comentarios  { get; set; } = new List<Comentario>();

        public virtual Usuario Cliente { get; set; }
        public virtual Usuario Responsavel { get; set; }



        public Ticket() { }


        public Ticket(string? id, string clienteId, string protocolo, string titulo, int slaHoras)
        {
            Id = string.IsNullOrWhiteSpace(id) ? Guid.NewGuid().ToString() : id;
            ClienteId = clienteId;
            Protocolo = protocolo;
            SlaHoras = slaHoras;
            Titulo = titulo;
            DataCriacao = DateTime.Now;
            Status = eTicketStatus.Pendente;
            
        }


        

        public void AtribuirResponsavel(string responsavelId)
        {
            ResponsavelId = responsavelId.Trim();
        }


        public void Fechar()
        {
            Status = eTicketStatus.Concluido;   
            DataFechamento = DateTime.Now;
        }
    }
}
