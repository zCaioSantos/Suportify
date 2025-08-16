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
        public string Descricao { get; private set; }  
        public int SlaHoras { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime? DataFechamento { get; private set; }
        public eTicketStatus Status { get; private set; }


        public virtual Usuario Cliente { get; private set; }
        public virtual Usuario Resposanvel { get; private set; }



        public Ticket() { }


        public Ticket(string? id, string clienteId, string protocolo, string titulo, string descricao, int slaHoras)
        {
            Id = string.IsNullOrWhiteSpace(id) ? Guid.NewGuid().ToString() : id;
            ClienteId = clienteId;
            Protocolo = protocolo;
            SlaHoras = slaHoras;
            DataCriacao = DateTime.Now;
            Status = eTicketStatus.Pendente;


            Alterar(titulo, descricao);
        }


        
        public void Alterar(string titulo, string descricao)
        {
            Titulo = titulo.Trim();
            Descricao = descricao.Trim();
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
