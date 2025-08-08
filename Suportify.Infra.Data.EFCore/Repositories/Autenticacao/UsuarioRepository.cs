using Suportify.Domain.Entities.Autenticacao;
using Suportify.Domain.Interfaces.Repositories.Autenticacao;
using Suportify.Infra.Data.EFCore.Context;

namespace Suportify.Infra.Data.EFCore.Repositories.Autenticacao
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(EFContext context) : base(context)
        {
        }
    }
}
