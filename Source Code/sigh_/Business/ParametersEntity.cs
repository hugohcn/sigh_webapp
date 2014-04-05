using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Business;
using Entity;

namespace Business
{
    public class ParametersEntity
    {
        /// <summary>
        /// Método de recuperação de parâmetro
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string RecuperarParametro(string key)
        {
            //Recupera chave no web.config
            string keyValue = ConfigurationManager.AppSettings[key].ToString();

            //Se não encontrar no web.config, tenta recuperar no banco de dados...
            if (string.IsNullOrEmpty(keyValue))
            {
                //Recupera no banco de dados...
                ParametersEN parameter = new ParametersBU().RetornaParametro(key);
                
                return parameter.Value;
            }
            else
            {
                return keyValue;
            }
        }
    }
}
