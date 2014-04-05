using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class MenuEN
    {
        private int _idMenu;
        /// <summary>
        /// Identificador do menu
        /// </summary>
        public int IdMenu
        {
            get { return _idMenu; }
            set { _idMenu = value; }
        }
        private string _nomeMenu;
        /// <summary>
        /// Nome do menu
        /// </summary>
        public string NomeMenu
        {
            get { return _nomeMenu; }
            set { _nomeMenu = value; }
        }
        private bool _isAtivo;
        /// <summary>
        /// Indicador booleano de situação do menu
        /// </summary>
        public bool IsAtivo
        {
            get { return _isAtivo; }
            set { _isAtivo = value; }
        }
        private int _idMenuPai;
        /// <summary>
        /// Identificador do menu pai
        /// </summary>
        public int IdMenuPai
        {
            get { return _idMenuPai; }
            set { _idMenuPai = value; }
        }
        private string _path;
        /// <summary>
        /// Endereço da página a ser linkada
        /// </summary>
        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }
        
    }
}
