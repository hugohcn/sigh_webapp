using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalendarEntity
{
    public class Escala
    {
        private int _codigoEscala;
        
        /// <summary>
        /// Código da escala
        /// </summary>
        public int CodigoEscala
        {
            get { return _codigoEscala; }
            set { _codigoEscala = value; }
        }
        private int _codigoMedicor;

        /// <summary>
        /// Código do médico
        /// </summary>
        public int CodigoMedicor
        {
            get { return _codigoMedicor; }
            set { _codigoMedicor = value; }
        }
        private string _diaSemana;
        /// <summary>
        /// Dia da Semana
        /// </summary>
        public string DiaSemana
        {
            get { return _diaSemana; }
            set { _diaSemana = value; }
        }
        private Jornada _jornada1;
        /// <summary>
        /// Jornada 1 da escala do médico
        /// </summary>
        public Jornada Jornada1
        {
            get { return _jornada1; }
            set { _jornada1 = value; }
        }
        private Jornada _jornada2;
        /// <summary>
        /// Jornada 2 da escala do médico
        /// </summary>
        public Jornada Jornada2
        {
            get { return _jornada2; }
            set { _jornada2 = value; }
        }
        private Jornada _jornada3;
        /// <summary>
        /// Jornada 3 da escala do médico
        /// </summary>
        public Jornada Jornada3
        {
            get { return _jornada3; }
            set { _jornada3 = value; }
        }
        private int _logHabilitado;
        /// <summary>
        /// Log de habilitação da escala
        /// </summary>
        public int LogHabilitado
        {
            get { return _logHabilitado; }
            set { _logHabilitado = value; }
        }
        private DateTime _dataEscala;
        /// <summary>
        /// Data da escala
        /// </summary>
        public DateTime DataEscala
        {
            get { return _dataEscala; }
            set { _dataEscala = value; }
        }
        private string _observacao;
        /// <summary>
        /// Observação da escala
        /// </summary>
        public string Observacao
        {
            get { return _observacao; }
            set { _observacao = value; }
        }
        private int _nmEncaixesLivres;
        /// <summary>
        /// Números de encaixes livres
        /// </summary>
        public int NmEncaixesLivres
        {
            get { return _nmEncaixesLivres; }
            set { _nmEncaixesLivres = value; }
        }
        private int _nmEncaixesSenhas;
        /// <summary>
        /// Números de encaixes com senhas
        /// </summary>
        public int NmEncaixesSenhas
        {
            get { return _nmEncaixesSenhas; }
            set { _nmEncaixesSenhas = value; }
        }
    }
    
    public class Jornada
    {
        private int _horaInicio;

        /// <summary>
        /// Hora de início da jornada
        /// </summary>
        public int HoraInicio
        {
            get { return _horaInicio; }
            set { _horaInicio = value; }
        }
        private int _horaFim;

        /// <summary>
        /// Hora de fim da jornada
        /// </summary>
        public int HoraFim
        {
            get { return _horaFim; }
            set { _horaFim = value; }
        }
        private int _nmDuracao;

        /// <summary>
        /// Duração das consultas em cada jornada
        /// </summary>
        public int NmDuracao
        {
            get { return _nmDuracao; }
            set { _nmDuracao = value; }
        }   
    }
}
