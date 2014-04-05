using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace CalendarDataAccess
{
    public class EscalaAccess
    {
        /// <summary>
        /// Método de retorna da escala de um médico
        /// </summary>
        /// <param name="idMedico">Identificador do médico</param>
        /// <param name="diaSemana">Dia da semana</param>
        /// <returns>DataTable com a escala e possíveis escalas no dia</returns>
        public DataTable RetornaEscalasByServico(int idServico, bool isVisualizacaoDiasServico)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["sigh_integracao"].ConnectionString);
            string sql = string.Empty;

            try
            {
                /*
                 * Query que é executada em bancos de dados MySql com versão > 4.1
                string sql = @" SELECT distinct
                                DS_DIA FROM escalas 
                                WHERE CD_MEDICOR in (select servxmedi.CD_MEDICOR from servxmedi where cd_servico = @idServico)";
                
                */

                if (!isVisualizacaoDiasServico)
                {
                    sql = @" SELECT distinct
                                DS_DIA FROM escalas
                                left join servxmedi on servxmedi.CD_MEDICOR = escalas.CD_MEDICOR 
                                where cd_servico = ?cdServico";
                
                }
                else
                {
                    sql = @" SELECT distinct
                                escalas.ds_dia, medicor.ds_nome FROM escalas
                                left join servxmedi on servxmedi.cd_medicor = escalas.cd_medicor 
                                left join medicor on medicor.cd_medicor = escalas.cd_medicor 
                                where cd_servico = ?cdServico";
                
                }                
                MySqlCommand cmd = new MySqlCommand(sql, con);
                
                //Adiciona os parametros para execução do select
                cmd.Parameters.Add(new MySqlParameter("?cdServico", idServico));

                //Abre conexão
                con.Open();

                //Datatable que terá os dados do médico
                DataTable dtDiasServico = new DataTable();

                //Popula o datatable
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                adp.Fill(dtDiasServico);

                return dtDiasServico;
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
