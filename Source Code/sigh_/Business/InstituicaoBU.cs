using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess;
using Entity;

namespace Business
{
    public class InstituicaoBU
    {
        /// <summary>
        /// Método que remove instituição no sistema.
        /// </summary>
        /// <returns>Sem retorno</returns>
        public void RemoverInstituicao(int idInstituicao)
        {
            try
            {
                new InstituicaoDA().RemoverInstituicao(idInstituicao);
            }
            catch (Exception e)
            {
                throw e;
            } 
        }
    
         /// <summary>
        /// Método que retorna todas as instituições do sistema.
        /// </summary>
        /// <returns>Dataset com resultados das querys.</returns>
        public DataSet RetornaInstituicoes()
        {
            try
            {
                return new InstituicaoDA().RetornaInstituicoes();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        /// <summary>
        /// Método que insere instituição no sistema.
        /// </summary>
        /// <returns>Dataset com resultados das querys.</returns>
        public void InserirInstituicao(InstituicaoEN instituicao)
        {
            try
            {
                new InstituicaoDA().InserirInstituicao(instituicao);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        /// <summary>
        /// Método que insere instituição no sistema.
        /// </summary>
        /// <returns>Sem retorno</returns>
        public void AtualizarInstituicao(InstituicaoEN instituicao)
        {
            try
            {
                new InstituicaoDA().AtualizarInstituicao(instituicao);
            }
            catch (Exception eX)
            {
                throw eX;
            }
        }
    }
}
