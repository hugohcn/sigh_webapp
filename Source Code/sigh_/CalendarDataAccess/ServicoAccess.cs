using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace CalendarDataAccess
{
    public class ServicoAccess
    {
        /// <summary>
        /// Método qque busca todos os médicos do legado
        /// </summary>
        public DataTable ObterServicosSistema()
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["sigh_integracao"].ConnectionString);

            try
            {
                string sql = @" select 	
                                CD_SERVICO, 
                                CD_CATEGORIA, 
                                DS_NOME, 
                                VL_PARTICULAR, 
                                CD_AMB, 
                                CD_GRUPO, 
                                DS_PREPARO, 
                                LG_DELETADO, 
                                LG_PRIMEIRA_VEZ, 
                                DS_TIPO 
                                from servicos";

                MySqlCommand cmd = new MySqlCommand(sql, con);

                //Abre conexão
                con.Open();

                //Datatable que terá os dados do médico
                DataTable dtServico = new DataTable();

                //Popula o datatable
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                adp.Fill(dtServico);

                return dtServico;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// Método de busca de todos os serviços de acordo com a categoria informada
        /// </summary>
        public DataTable ObterServicosByCategoria(int categoria)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["sigh_integracao"].ConnectionString);

            try
            {
                string sql = @" 
                                select 	
                                cd_servico, 
                                ds_nome,  
                                ds_preparo
                                from servicos
                                where cd_categoria = ?cdCategoria
                                ";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add(new MySqlParameter("?cdCategoria",categoria));

                //Abre conexão
                con.Open();

                //Datatable que terá os dados do médico
                DataTable dtServico = new DataTable();

                //Popula o datatable
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                adp.Fill(dtServico);

                return dtServico;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
