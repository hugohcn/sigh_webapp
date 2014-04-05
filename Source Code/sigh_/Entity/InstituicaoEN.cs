using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    [Serializable]
    public class InstituicaoEN
    {
        private int _idInstituicao;
        /// <summary>
        /// Identificador da Instituição
        /// </summary>
        public int IdInstituicao
        {
            get { return _idInstituicao; }
            set { _idInstituicao = value; }
        }
        private string _nome;
        /// <summary>
        /// Nome da instituição
        /// </summary>
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
        private string _endereco;
        /// <summary>
        /// Endereço da instituição
        /// </summary>
        public string Endereco
        {
            get { return _endereco; }
            set { _endereco = value; }
        }
        private int _numero;
        /// <summary>
        /// Numero do endereço
        /// </summary>
        public int Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }
        private string _bairro;
        /// <summary>
        /// Bairro da instituição
        /// </summary>
        public string Bairro
        {
            get { return _bairro; }
            set { _bairro = value; }
        }
        private string _cidade;
        /// <summary>
        /// Cidade da instituição
        /// </summary>
        public string Cidade
        {
            get { return _cidade; }
            set { _cidade = value; }
        }
        private string _estado;
        /// <summary>
        /// Estado da instituição (UF)
        /// </summary>
        public string Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
        private string _cep;
        /// <summary>
        /// Cep da instituição
        /// </summary>
        public string Cep
        {
            get { return _cep; }
            set { _cep = value; }
        }
        private DateTime _dtRegistro;
        /// <summary>
        /// Data de registro da instituição no sistema
        /// </summary>
        public DateTime DtRegistro
        {
            get { return _dtRegistro; }
            set { _dtRegistro = value; }
        }
        private string _nomeResponsavel;
        /// <summary>
        /// Nome do responsável pela instituição
        /// </summary>
        public string NomeResponsavel
        {
            get { return _nomeResponsavel; }
            set { _nomeResponsavel = value; }
        }
        private string _funcao;
        /// <summary>
        /// Função do responspavel na instituição
        /// </summary>
        public string Funcao
        {
            get { return _funcao; }
            set { _funcao = value; }
        }
        private string _email;
        /// <summary>
        /// E-mail do funcionário responsável
        /// </summary>
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        private string _telefone;
        /// <summary>
        /// Telefone de contato da empresa
        /// </summary>
        public string Telefone
        {
            get { return _telefone; }
            set { _telefone = value; }
        }
        private string _cnpjInstituicao;
        /// <summary>
        /// Cnpj da instituição
        /// </summary>
        public string CnpjInstituicao
        {
            get { return _cnpjInstituicao; }
            set { _cnpjInstituicao = value; }
        }        
    }
}
