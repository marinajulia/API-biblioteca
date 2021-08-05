using Biblioteca.Domain.Services.Entidades;
using Biblioteca.Domain.Services.Usuario.Dto;
using Biblioteca.SharedKernel;
using SharedKernel.Domain;
using SharedKernel.Domain.Notification;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca.Domain.Services.Usuario
{
    public class UsuarioService : IUsuarioService
    {
        private readonly INotification _notification;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly UserLoggedData _userLoggedData;

        public UsuarioService(
            IUsuarioRepository usuarioRepository,
            INotification notification,
            UserLoggedData userLoggedData)
        {
            _usuarioRepository = usuarioRepository;
            _notification = notification;
            _userLoggedData = userLoggedData;
        }

        public bool Allow(int idUser)
        {
            var usuarioData = _usuarioRepository.GetById(idUser);
            if (usuarioData == null)
                return _notification.AddWithReturn<bool>("Usuário ou senha incorretos");

            _userLoggedData.Add(usuarioData.UsuarioId, usuarioData.PerfilUsuarioId);

            return true;
        }

        public IEnumerable<UsuarioDto> Get()
        {
            var usuarios = _usuarioRepository.Get();

            return usuarios.Select(x => new UsuarioDto
            {
                UsuarioId = x.UsuarioId,
                NomeUsuario = x.NomeUsuario,
                StatusUsuarioId = x.StatusUsuarioId,
                StatusUsuario = x.StatusUsuario,
                Email = x.Email,
                PerfilUsuarioId = x.PerfilUsuarioId,
                PerfilUsuario = x.PerfilUsuario

            }).ToList();
        }

        public UsuarioDto GetById(int id)
        {
            var usuario = _usuarioRepository.GetById(id);

            if (usuario == null)
                return _notification.AddWithReturn<UsuarioDto>
                    ("O usuario não pode ser encontrado");

            return new UsuarioDto
            {
                UsuarioId = usuario.UsuarioId,
                NomeUsuario = usuario.NomeUsuario,
                StatusUsuarioId = usuario.StatusUsuarioId,
                StatusUsuario = usuario.StatusUsuario,
                Email = usuario.Email,
                PerfilUsuarioId = usuario.PerfilUsuarioId,
                PerfilUsuario = usuario.PerfilUsuario
            };
        }

        public bool PostBloqueio(UsuarioDto usuarioDto)
        {
            var usuario = _usuarioRepository.GetById(usuarioDto.UsuarioId);
            if (usuario == null)
                return _notification.AddWithReturn<bool>("O usuário informado não existe!");

            var statusUsuario = _usuarioRepository.GetByStatus(usuario.UsuarioId);
            if (statusUsuario != null)
                return _notification.AddWithReturn<bool>
                    ("Ops.. parece que esse usuário já está bloqueado!");

            _usuarioRepository.UpdateStatus(usuario.UsuarioId, 5);

            _notification.Add("O usuário foi bloqueado com sucesso!");

            return true;

        }

        public bool PostDesbloqueio(UsuarioDto usuarioDto)
        {
            var usuario = _usuarioRepository.GetById(usuarioDto.UsuarioId);
            if (usuario == null)
                return _notification.AddWithReturn<bool>("O usuário informado não existe!");

            var statusUsuario = _usuarioRepository.GetByStatus(usuario.UsuarioId);
            if (statusUsuario == null)
                return _notification.AddWithReturn<bool>("Ops.. parece que esse usuário já está desbloqueado!");

            _usuarioRepository.UpdateStatus(usuario.UsuarioId, 6);

            _notification.Add("O usuário foi desbloqueado com sucesso!");

            return true;
        }

        public bool PostCadastro(UsuarioEntity usuario)
        {
            var comparacaoNome = _usuarioRepository.GetByName(usuario.NomeUsuario);
            if (comparacaoNome != null)
                return _notification.AddWithReturn<bool>("Ops.. parece que o usuário informado já existe");

            var verificaSeCpfJaExiste = _usuarioRepository.GetByCpf(usuario.CPF);
            if (verificaSeCpfJaExiste != null)
                return _notification.AddWithReturn<bool>("Ops.. parece que o CPF inserido já existe");

            var verificaSeEmailJaExiste = _usuarioRepository.GetByEmail(usuario.Email);
            if (verificaSeEmailJaExiste != null)
                return _notification.AddWithReturn<bool>("Ops.. parece que o email inserido já existe");

            if (usuario.CPF == "" || usuario.Email == "" || usuario.NomeUsuario == "" || usuario.Senha == "")
                return _notification.AddWithReturn<bool>("Ops.. você não pode inserir um campo vazio");

            if (!usuario.Email.IsValidMail())
                return _notification.AddWithReturn<bool>("Ops.. O email inserido é inválido");

            var validaCpf = _usuarioRepository.ValidaCpf(usuario.CPF);
            if (validaCpf == false)
                return _notification.AddWithReturn<bool>("O CPF é inválido");


            _usuarioRepository.PostCadastro(new UsuarioEntity
            {
                NomeUsuario = usuario.NomeUsuario,
                CPF = usuario.CPF,
                Senha = usuario.Senha,
                StatusUsuarioId = 6,
                Email = usuario.Email,
                PerfilUsuarioId = 1
            });
            _notification.Add("Usuário cadastrado com sucesso");

            return true;
        }

        public UsuarioDto PostLogin(UsuarioEntity usuario)
        {

            if (usuario.NomeUsuario == "" || usuario.Senha == "")
                return _notification.AddWithReturn<UsuarioDto>
                    ("Existem campos vazios no login!");

            var usuarioData = _usuarioRepository.GetUser(usuario.NomeUsuario, usuario.Senha);
            if (usuarioData == null)
                return _notification.AddWithReturn<UsuarioDto>
                    ("Usuário ou senha incorretos");

            return new UsuarioDto
            {
                UsuarioId = usuarioData.UsuarioId,
                NomeUsuario = usuarioData.NomeUsuario,
                StatusUsuarioId = usuarioData.StatusUsuarioId,
                Email = usuarioData.Email,
                PerfilUsuarioId = usuarioData.PerfilUsuarioId
            };
        }

        public bool PutAlterarDados(UsuarioDto usuario)
        {
            if (usuario.NomeUsuario == "")
                return _notification.AddWithReturn<bool>("Existem campos vazios!");

            var user = _usuarioRepository.GetById(usuario.UsuarioId);
            if (user == null)
                return _notification.AddWithReturn<bool>("Ops.. parece que este usuário não existe");

            if (!usuario.Email.IsValidMail())
                return _notification.AddWithReturn<bool>("Ops.. O email inserido é inválido");

            var verificaSeEmailJaExiste = _usuarioRepository.GetByEmail(usuario.Email);
            if (verificaSeEmailJaExiste != null)
                return _notification.AddWithReturn<bool>("Ops.. parece que o email inserido já existe");

            _usuarioRepository.PutAlterarSenha(user);

            user.Email = usuario.Email;
            _usuarioRepository.PutAlteraremail(user);

            _notification.Add("Seus dados foram alterados com sucesso!");

            return true;
        }

        public IEnumerable<UsuarioDto> GetNome(string nome)
        {
            var dadosUsuarioLogado = _userLoggedData.GetData();

            if (dadosUsuarioLogado.Id_PerfilUsuario == 1)
                return _notification.AddWithReturn<IEnumerable<UsuarioDto>>
                    ("Ops.. parece que você não tem permissão para listar os usuários");

            var usuarios = _usuarioRepository.Get(nome);

            if (usuarios == null)
                return _notification.AddWithReturn<IEnumerable<UsuarioDto>>("Este nome não existe!");

            return usuarios.Select(x => new UsuarioDto
            {
                UsuarioId = x.UsuarioId,
                NomeUsuario = x.NomeUsuario,
                StatusUsuarioId = x.StatusUsuarioId,
                StatusUsuario = x.StatusUsuario,
                Email = x.Email,
                PerfilUsuarioId = x.PerfilUsuarioId,
                PerfilUsuario = x.PerfilUsuario

            }).ToList();
        }
    }
}
