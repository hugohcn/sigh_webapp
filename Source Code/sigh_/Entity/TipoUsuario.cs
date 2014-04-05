using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    [Serializable]
    public class TipoUsuario
    {
        private int _idTipoUsuario;
        /// <summary>
        /// Identificador do tipo de usuário;
        /// </summary>
        public int IdTipoUsuario
        {
            get { return _idTipoUsuario; }
            set { _idTipoUsuario = value; }
        }
        private string _descricaoTipoUsuario;
        /// <summary>
        /// Descrição do tipo de usuário;
        /// </summary>
        public string DescricaoTipoUsuario
        {
            get { return _descricaoTipoUsuario; }
            set { _descricaoTipoUsuario = value; }
        }
    }
}
