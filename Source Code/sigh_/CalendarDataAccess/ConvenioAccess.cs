using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace CalendarDataAccess
{
    public class ConvenioAccess
    {
        /// <summary>
        /// Método que retorna os convênios registrados no banco de dados
        /// </summary>
        /// <returns></returns>
        public DataTable RetornaConvenios()
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["sigh_integracao"].ConnectionString);

            try
            {
                //Query que roda no mysql 4.1
                string sql = @" select cd_convenio, ds_nome, ds_letra, ds_cnpj, ds_registro_ans, ds_razao_social
                                from convenios
                                where ds_nome <> 'CORTESIA'";

                MySqlCommand cmd = new MySqlCommand(sql, con);

                //Abre conexão
                con.Open();

                //Datatable que terá os dados do médico
                DataTable dtConvenios = new DataTable();

                //Popula o datatable
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                adp.Fill(dtConvenios);

                return dtConvenios;
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
        /// Método que retorna os convênios registrados no banco de dados
        /// </summary>
        /// <returns></returns>
        public DataTable RetornaConveniosByMedico(int cdMedico)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["sigh_integracao"].ConnectionString);

            try
            {
                //Query que roda no mysql 4.1
                string sql = @" select convenios.ds_nome, convenios.cd_convenio
                                from convenios, convxmedi
                                where convenios.cd_convenio = convxmedi.cd_convenio
                                and ds_nome <> 'CORTESIA'
                                and convxmedi.cd_medicor = ?cdMedicor
                                order by convenios.ds_nome
                                ";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add(new MySqlParameter("?cdMedicor",cdMedico));

                //Abre conexão
                con.Open();

                //Datatable que terá os dados do médico
                DataTable dtConvenios = new DataTable();

                //Popula o datatable
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                adp.Fill(dtConvenios);

                return dtConvenios;
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
