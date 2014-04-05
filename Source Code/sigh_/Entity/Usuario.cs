using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    [Serializable]
    public class Usuario
    {
        private string _cpf;
        /// <summary>
        /// Cpf do usuário;
        /// </summary>
        public string Cpf
        {
            get { return _cpf; }
            set { _cpf = value; }
        }
        
        private TipoUsuario _tipoUsuario;
        /// <summary>
        /// Tipo de usuário
        /// </summary>
        public TipoUsuario TipoUsuario
        {
            get { return _tipoUsuario; }
            set { _tipoUsuario = value; }
        }
        
        private string _nome;
        /// <summary>
        /// Nome do usuário;
        /// </summary>
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
        private string _telefone1;
        /// <summary>
        /// Telefone 1 do usuário;
        /// </summary>
        public string Telefone1
        {
            get { return _telefone1; }
            set { _telefone1 = value; }
        }
        private string _telefone2;
        /// <summary>
        /// Telefone 2 do usuário;
        /// </summary>
        public string Telefone2
        {
            get { return _telefone2; }
            set { _telefone2 = value; }
        }
        private string _email;
        /// <summary>
        /// E-mail do usuário;
        /// </summary>
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        private bool _isAtivo;
        /// <summary>
        /// Identificador de atividade válida para o usuário;
        /// </summary>
        public bool IsAtivo
        {
            get { return _isAtivo; }
            set { _isAtivo = value; }
        }
        private string _login;
        /// <summary>
        /// Login do usuário;
        /// </summary>
        public string Login
        {
            get { return _login; }
            set { _login = value; }
        }
        private string _senha;
        /// <summary>
        /// Senha do usuário;
        /// </summary>
        public string Senha
        {
            get { return _senha; }
            set { _senha = value; }
        }
        private DateTime _dtUltimoAcesso;
        /// <summary>
        /// Data do último acesso do usuário.
        /// </summary>
        public DateTime DtUltimoAcesso
        {
            get { return _dtUltimoAcesso; }
            set { _dtUltimoAcesso = value; }
        }

        private InstituicaoEN _instituicao;
        /// <summary>
        /// Entidade instituição que o usuário representa
        /// </summary>
        public InstituicaoEN Instituicao
        {
            get { return _instituicao; }
            set { _instituicao = value; }
        }

        private bool _isMedico;
        /// <summary>
        /// Verifica se o usuário é médico da clínica
        /// </summary>
        public bool IsMedico
        {
            get { return _isMedico; }
            set { _isMedico = value; }
        }
    }
}
