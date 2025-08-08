using Suportify.Domain.Dtos.Autenticacao;
using Suportify.Domain.Entities.Autenticacao;
using Suportify.Domain.Interfaces.Repositories.Autenticacao;

namespace Suportify.Service.Domain.Autenticacao
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _repository;


        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }


        public async Task<UsuarioDto> Create(UsuarioDto obj)
        {
            Usuario usuario = new Usuario(
                null,
                obj.Email,
                obj.Nome,
                obj.Foto,
                obj.Perfil
            );

            if (!string.IsNullOrWhiteSpace(obj.Senha))
                usuario.DefinirSenha(obj.Senha);

            await _repository.Create(usuario);

            return UsuarioDto.FromModel(usuario);
        }


        public async Task Delete(string id)
        {
            Usuario? usuario = await _repository.Get<Usuario, bool>(where: u => u.Id == id);
            
            if (usuario == null)
                throw new Exception("Usuário não encontrado");

            await _repository.Delete(usuario);
        }


        public async Task<UsuarioDto> Get(string id)
        {
            Usuario usuario = await _repository.Get<Usuario, bool>(where: u => u.Id == id);

            if (usuario == null)
                throw new Exception("Usuário não encontrado");

            return UsuarioDto.FromModel(usuario);
        }


        public async Task<List<UsuarioDto>?> GetAll()
        {
            List<Usuario>? usuarios = await _repository.GetAll<Usuario, bool>();
            
            if (usuarios == null || usuarios.Count == 0)
                return null;
            
            return usuarios.Select(u => UsuarioDto.FromModel(u)).ToList();
        }


        public async Task<UsuarioDto?> Update(UsuarioDto dto)
        {
            Usuario? usuario = await _repository.Get<Usuario, bool>(where: u => u.Id == dto.Id);
            
            if (usuario == null)
                throw new Exception("Usuário não encontrado");

            usuario.Alterar(dto.Email, dto.Nome, dto.Foto, dto.Perfil, dto.Ativo);

            await _repository.Update(usuario);
            return UsuarioDto.FromModel(usuario);
        }
    }
}