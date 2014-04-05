using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class ParametersEN
    {
        private int _id;
        /// <summary>
        /// Identificador único do parâmetro
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _key;
        /// <summary>
        /// Nome do parâmetro
        /// </summary>
        public string Key
        {
            get { return _key; }
            set { _key = value; }
        }
        private string _value;
        /// <summary>
        /// valor do parâmetro
        /// </summary>
        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }
        
    }
}
