using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalendarEntity
{
    public class Categoria
    {
        private int _codCategoria;
        /// <summary>
        /// Código da categoria
        /// </summary>
        public int CodCategoria
        {
            get { return _codCategoria; }
            set { _codCategoria = value; }
        }
        private string _nome;
        /// <summary>
        /// Nome da categoria
        /// </summary>
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
        private int _logDeletado;
        /// <summary>
        /// Valor que identifica se a categoria foi ou não deletada
        /// </summary>
        public int LogDeletado
        {
            get { return _logDeletado; }
            set { _logDeletado = value; }
        }
    }
}
