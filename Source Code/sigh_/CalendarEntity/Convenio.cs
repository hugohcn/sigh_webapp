using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalendarEntity
{
    public class Convenio
    {
        private int _codigoConvenio;

        public int CodigoConvenio
        {
            get { return _codigoConvenio; }
            set { _codigoConvenio = value; }
        }
        private string _dsNome;

        public string DsNome
        {
            get { return _dsNome; }
            set { _dsNome = value; }
        }
        private string _dsLetra;

        public string DsLetra
        {
            get { return _dsLetra; }
            set { _dsLetra = value; }
        }
        private string _dsCnpj;

        public string DsCnpj
        {
            get { return _dsCnpj; }
            set { _dsCnpj = value; }
        }
        private string _dsRegistroAns;

        public string DsRegistroAns
        {
            get { return _dsRegistroAns; }
            set { _dsRegistroAns = value; }
        }
        private string _dsRazaoSocial;

        public string DsRazaoSocial
        {
            get { return _dsRazaoSocial; }
            set { _dsRazaoSocial = value; }
        }   
    }
}
