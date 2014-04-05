using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalendarEntity
{
    [Serializable]
    public class Agenda
    {
        #region Atributos

            private int _codigoMedicor;
            private int _dataAgenda;
            private int _horaAgenda;
            private int _codigoServico;
            private int _codigoPaciente;
            private int _codigoCategoria;
            private int _codigoConvenio;
            private string _observacao;
            private string _situacao;
            private double _valorServico;
            private int _logRevisao;
            private string _descricaoUsuario;
            private int _logPeqProcedencia;
            private int _logChamou;
            private DateTime _dataChamou;
            private int _nmAndar;
            private int _codigoLancamento;
            private int _logPrimeiraVez;
            private int _logExcluido;
            private string _descricaoMotivo;
            private int _codigoCid;
            private int _logEncaixe;
            private int _codigoInstituicao;
            
            //Atributo criado para controlar consulta marcada pela internet
            private int _logMarcacaoWeb;
            
        #endregion
        
        #region Propriedades
            
            /// <summary>
            /// Código do médico
            /// </summary>
            public int CodigoMedicor
            {
                get { return _codigoMedicor; }
                set { _codigoMedicor = value; }
            }

            /// <summary>
            /// Data da agenda
            /// </summary>
            public int DataAgenda
            {
                get { return _dataAgenda; }
                set { _dataAgenda = value; }
            }

            /// <summary>
            /// Hora do agendamento
            /// </summary>
            public int HoraAgenda
            {
                get { return _horaAgenda; }
                set { _horaAgenda = value; }
            }

            /// <summary>
            /// Código do serviço
            /// </summary>
            public int CodigoServico
            {
                get { return _codigoServico; }
                set { _codigoServico = value; }
            }

            /// <summary>
            /// Código do paciente
            /// </summary>
            public int CodigoPaciente
            {
                get { return _codigoPaciente; }
                set { _codigoPaciente = value; }
            }

            /// <summary>
            /// Código da categoria
            /// </summary>
            public int CodigoCategoria
            {
                get { return _codigoCategoria; }
                set { _codigoCategoria = value; }
            }

            /// <summary>
            /// Código do convênio
            /// </summary>
            public int CodigoConvenio
            {
                get { return _codigoConvenio; }
                set { _codigoConvenio = value; }
            }

            /// <summary>
            /// Observação da marcação do horário
            /// </summary>
            public string Observacao
            {
                get { return _observacao; }
                set { _observacao = value; }
            }

            /// <summary>
            /// Situação da consulta marcada
            /// </summary>
            public string Situacao
            {
                get { return _situacao; }
                set { _situacao = value; }
            }

            /// <summary>
            /// Valor do serviço agendado
            /// </summary>
            public double ValorServico
            {
                get { return _valorServico; }
                set { _valorServico = value; }
            }

            /// <summary>
            /// Log de revisão
            /// </summary>
            public int LogRevisao
            {
                get { return _logRevisao; }
                set { _logRevisao = value; }
            }

            /// <summary>
            /// Descrição do usuário
            /// </summary>
            public string DescricaoUsuario
            {
                get { return _descricaoUsuario; }
                set { _descricaoUsuario = value; }
            }

            /// <summary>
            /// Log de Procedência
            /// </summary>
            public int LogPeqProcedencia
            {
                get { return _logPeqProcedencia; }
                set { _logPeqProcedencia = value; }
            }

            /// <summary>
            /// Log de chamada
            /// </summary>
            public int LogChamou
            {
                get { return _logChamou; }
                set { _logChamou = value; }
            }

            /// <summary>
            /// Data de chamada
            /// </summary>
            public DateTime DataChamou
            {
                get { return _dataChamou; }
                set { _dataChamou = value; }
            }

            /// <summary>
            /// NMAndar
            /// </summary>
            public int NmAndar
            {
                get { return _nmAndar; }
                set { _nmAndar = value; }
            }

            /// <summary>
            /// Código de lançamento
            /// </summary>
            public int CodigoLancamento
            {
                get { return _codigoLancamento; }
                set { _codigoLancamento = value; }
            }

            /// <summary>
            /// Log de primeira consulta
            /// </summary>
            public int LogPrimeiraVez
            {
                get { return _logPrimeiraVez; }
                set { _logPrimeiraVez = value; }
            }

            /// <summary>
            /// Log de consulta excluída
            /// </summary>
            public int LogExcluido
            {
                get { return _logExcluido; }
                set { _logExcluido = value; }
            }

            /// <summary>
            /// Descrição da exclusão da consulta
            /// </summary>
            public string DescricaoMotivo
            {
                get { return _descricaoMotivo; }
                set { _descricaoMotivo = value; }
            }

            /// <summary>
            /// Código CID
            /// </summary>
            public int CodigoCid
            {
                get { return _codigoCid; }
                set { _codigoCid = value; }
            }

            /// <summary>
            /// Log identificador de encaixe
            /// </summary>
            public int LogEncaixe
            {
                get { return _logEncaixe; }
                set { _logEncaixe = value; }
            }

            /// <summary>
            /// Log de marcação de consulta pela web
            /// </summary>
            public int LogMarcacaoWeb
            {
                get { return _logMarcacaoWeb; }
                set { _logMarcacaoWeb = value; }
            }

            /// <summary>
            /// Código da instituição ao qual pertence o funcionário que registrou o agendamento.
            /// </summary>
            public int CodigoInstituicao
            {
                get { return _codigoInstituicao; }
                set { _codigoInstituicao = value; }
            }
            
        #endregion
        
        #region Construtores
        
            public Agenda()
            {
            
            }
        
        #endregion
    }
}
