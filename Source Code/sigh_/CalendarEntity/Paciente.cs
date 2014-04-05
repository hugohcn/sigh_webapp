using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalendarEntity
{
    public class Paciente
    {
        private int _codigoPaciente;

        public int CodigoPaciente
        {
            get { return _codigoPaciente; }
            set { _codigoPaciente = value; }
        }
        private int _codigoConvenio;

        public int CodigoConvenio
        {
            get { return _codigoConvenio; }
            set { _codigoConvenio = value; }
        }
        private string _descricaoNome;

        public string DescricaoNome
        {
            get { return _descricaoNome; }
            set { _descricaoNome = value; }
        }
        private string _rg;

        public string Rg
        {
            get { return _rg; }
            set { _rg = value; }
        }
        private string _cpf;

        public string Cpf
        {
            get { return _cpf; }
            set { _cpf = value; }
        }
        private string _endereco;

        public string Endereco
        {
            get { return _endereco; }
            set { _endereco = value; }
        }
        private string _complemento;

        public string Complemento
        {
            get { return _complemento; }
            set { _complemento = value; }
        }
        private string _bairro;

        public string Bairro
        {
            get { return _bairro; }
            set { _bairro = value; }
        }
        private string _cidade;

        public string Cidade
        {
            get { return _cidade; }
            set { _cidade = value; }
        }
        private string _estado;

        public string Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
        private string _cep;

        public string Cep
        {
            get { return _cep; }
            set { _cep = value; }
        }
        private string _telefone1;

        public string Telefone1
        {
            get { return _telefone1; }
            set { _telefone1 = value; }
        }
        private string _telefone2;

        public string Telefone2
        {
            get { return _telefone2; }
            set { _telefone2 = value; }
        }
        private int _dataAniversario;

        public int DataAniversario
        {
            get { return _dataAniversario; }
            set { _dataAniversario = value; }
        }
        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        private string _sexo;

        public string Sexo
        {
            get { return _sexo; }
            set { _sexo = value; }
        }
        private string _descricaoEstadoCivil;

        public string DescricaoEstadoCivil
        {
            get { return _descricaoEstadoCivil; }
            set { _descricaoEstadoCivil = value; }
        }
        private string _sangue;

        public string Sangue
        {
            get { return _sangue; }
            set { _sangue = value; }
        }
        private string _matricula;

        public string Matricula
        {
            get { return _matricula; }
            set { _matricula = value; }
        }
        private string _dependente;

        public string Dependente
        {
            get { return _dependente; }
            set { _dependente = value; }
        }
        private int _codigoBairro;

        public int CodigoBairro
        {
            get { return _codigoBairro; }
            set { _codigoBairro = value; }
        }
        private int _codigoCidade;

        public int CodigoCidade
        {
            get { return _codigoCidade; }
            set { _codigoCidade = value; }
        }
        private int _codigoRua;

        public int CodigoRua
        {
            get { return _codigoRua; }
            set { _codigoRua = value; }
        }
        private string _descricaoCodigoProntuario;

        public string DescricaoCodigoProntuario
        {
            get { return _descricaoCodigoProntuario; }
            set { _descricaoCodigoProntuario = value; }
        }
        private string _observacao;

        public string Observacao
        {
            get { return _observacao; }
            set { _observacao = value; }
        }
        private int _logProntuario;

        public int LogProntuario
        {
            get { return _logProntuario; }
            set { _logProntuario = value; }
        }
        private int _codigoProfissao;

        public int CodigoProfissao
        {
            get { return _codigoProfissao; }
            set { _codigoProfissao = value; }
        }
        private double _nmAltura;

        public double NmAltura
        {
            get { return _nmAltura; }
            set { _nmAltura = value; }
        }
        private double _nmPeso;

        public double NmPeso
        {
            get { return _nmPeso; }
            set { _nmPeso = value; }
        }
        private DateTime _dataUltimoAtendimento;

        public DateTime DataUltimoAtendimento
        {
            get { return _dataUltimoAtendimento; }
            set { _dataUltimoAtendimento = value; }
        }
        private DateTime _dataInclusao;

        public DateTime DataInclusao
        {
            get { return _dataInclusao; }
            set { _dataInclusao = value; }
        }
        private byte[] _imagemPaciente;

        public byte[] ImagemPaciente
        {
            get { return _imagemPaciente; }
            set { _imagemPaciente = value; }
        }
        private int _logAmpliado;

        public int LogAmpliado
        {
            get { return _logAmpliado; }
            set { _logAmpliado = value; }
        }
        private string _descricaoProfissao;

        public string DescricaoProfissao
        {
            get { return _descricaoProfissao; }
            set { _descricaoProfissao = value; }
        }
        private int _nmSituacao;

        public int NmSituacao
        {
            get { return _nmSituacao; }
            set { _nmSituacao = value; }
        }
        private DateTime _dataObito;

        public DateTime DataObito
        {
            get { return _dataObito; }
            set { _dataObito = value; }
        }
        private int _logAuxiliar;

        public int LogAuxiliar
        {
            get { return _logAuxiliar; }
            set { _logAuxiliar = value; }
        }
        private int _codigoIbgeCidade;

        public int CodigoIbgeCidade
        {
            get { return _codigoIbgeCidade; }
            set { _codigoIbgeCidade = value; }
        }
        private DateTime _dataValidadeMatricula;

        public DateTime DataValidadeMatricula
        {
            get { return _dataValidadeMatricula; }
            set { _dataValidadeMatricula = value; }
        }
        private int _codigoAuxiliar;

        public int CodigoAuxiliar
        {
            get { return _codigoAuxiliar; }
            set { _codigoAuxiliar = value; }
        }
    }
}
