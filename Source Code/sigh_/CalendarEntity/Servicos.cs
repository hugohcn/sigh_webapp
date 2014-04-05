using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalendarEntity
{
    public class Servicos
    {
        private int _codigoServico;
        /// <summary>
        /// Código do serviço
        /// </summary>
        public int CodigoServico
        {
            get { return _codigoServico; }
            set { _codigoServico = value; }
        }
        private Categoria _categoria;
        /// <summary>
        /// Categoria do serviço
        /// </summary>
        public Categoria Categoria
        {
            get { return _categoria; }
            set { _categoria = value; }
        }
        private string _nome;
        /// <summary>
        /// Nome do serviço
        /// </summary>
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
        private double _valorParticular;
        /// <summary>
        /// Valor do serviço particular
        /// </summary>
        public double ValorParticular
        {
            get { return _valorParticular; }
            set { _valorParticular = value; }
        }
        private int _codigoAmb;
        /// <summary>
        /// Código de ambulatorio
        /// </summary>
        public int CodigoAmb
        {
            get { return _codigoAmb; }
            set { _codigoAmb = value; }
        }
        private int _codigoGrupo;
        /// <summary>
        /// Código do grupo
        /// </summary>
        public int CodigoGrupo
        {
            get { return _codigoGrupo; }
            set { _codigoGrupo = value; }
        }
        private byte[] _preparo;
        /// <summary>
        /// Arquivo contendo os dados necessários para o serviço
        /// </summary>
        public byte[] Preparo
        {
            get { return _preparo; }
            set { _preparo = value; }
        }
        private int _logDeletado;
        /// <summary>
        /// Valor indicativo de deleção
        /// </summary>
        public int LogDeletado
        {
            get { return _logDeletado; }
            set { _logDeletado = value; }
        }
        private int _logPrimeiraVez;
        /// <summary>
        /// Valor indicador sobre primeira vez
        /// </summary>
        public int LogPrimeiraVez
        {
            get { return _logPrimeiraVez; }
            set { _logPrimeiraVez = value; }
        }
        private string _descricaoTipo;
        /// <summary>
        /// Descrição do tipo
        /// </summary>
        public string DescricaoTipo
        {
            get { return _descricaoTipo; }
            set { _descricaoTipo = value; }
        }
    }
}
