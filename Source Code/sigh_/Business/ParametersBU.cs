using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using DataAccess;
using System.Data;

namespace Business
{
    public class ParametersBU
    {
        /// <summary>
        /// Retorna o parâmetro
        /// </summary>
        /// <param name="key">Nome da chave</param>
        /// <returns>Objeto parâmetro</returns>
        public ParametersEN RetornaParametro(string key)
        {
            try
            {
                return new ParametersDA().RetornaParametro(key);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Método que retorna todos os parâmetros cadastrados...
        /// </summary>
        /// <returns>DataTable contendo todos os parâmetros</returns>
        public DataTable RetornaTodosParametros()
        {
            try
            {
                return new ParametersDA().RetornaTodosParametros();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        /// <summary>
        /// Método que insere um parâmetro no sistema
        /// </summary>
        /// <param name="parametro">Objeto parâmetro</param>
        public void InserirParametro(ParametersEN parametro)
        {
            try
            {
                new ParametersDA().InserirParametro(parametro);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        /// <summary>
        /// Método que atualiza um parâmetro no sistema
        /// </summary>
        /// <param name="parametro">Objeto parâmetro</param>
        public void AtualizarParametro(ParametersEN parametro)
        {
            try
            {
                new ParametersDA().AtualizarParametro(parametro);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        /// <summary>
       /// Método que efetua deleção de parâmetro do banco de dados...
       /// </summary>
       /// <param name="idParametro">Identificador (inteiro) do parâmetro</param>
        public void DeletarParametro(int idParametro)
        {
            try
            {
                new ParametersDA().DeletarParametro(idParametro);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
