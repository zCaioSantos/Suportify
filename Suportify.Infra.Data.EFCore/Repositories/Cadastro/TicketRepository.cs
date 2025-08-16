using Suportify.Domain.Entities.Cadastros;
using Suportify.Domain.Interfaces.Repositories.Cadastros;
using Suportify.Infra.Data.EFCore.Context;

namespace Suportify.Infra.Data.EFCore.Repositories.Cadastro
{
    internal class TicketRepository : BaseRepository<Ticket>, ITicketRepository
    {
        public TicketRepository(EFContext context) : base(context)
        {
        }
    }
}
