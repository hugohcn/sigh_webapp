using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace CalendarDataAccess
{
    public class ReportAccess
    {
        /// <summary>
        /// Método que recupera os dados do relatório de um médico
        /// </summary>
        /// <param name="dtInicio">Data de início do relatório</param>
        /// <param name="dtFim">Data de fim do relatório</param>
        /// <param name="idMedico">Código do médico</param>
        /// <returns>DataTable contendo os dados do relatório corrente.</returns>
        public DataSet GetRelatorioTrabalhoMedico(string dtInicio, string dtFim, int idMedico)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["sigh_integracao"].ConnectionString);

            try
            {
                string sql = @"
                                SELECT S.DS_NOME AS SERVICO, COUNT(S.CD_SERVICO) AS QTD
                                FROM LANCAMENTOS L, SERVXLANC SL, SERVICOS S
                                WHERE SL.CD_SERVICO = S.CD_SERVICO
                                AND SL.CD_MEDICOR = ?cdMedico
                                AND L.CD_LANCAMENTO = SL.CD_LANCAMENTO
                                AND L.DT_COMPETENCIA >= ?dtInicio
                                AND L.DT_COMPETENCIA <= ?dtFim
                                GROUP BY S.CD_SERVICO
                                ORDER BY QTD DESC, SERVICO
                                ";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.CommandText = cmd.CommandText.ToLower();
                
                //Adiciona os parametros para execução do select
                cmd.Parameters.Add(new MySqlParameter("?cdMedico", idMedico));
                cmd.Parameters.Add(new MySqlParameter("?dtInicio", dtInicio));
                cmd.Parameters.Add(new MySqlParameter("?dtFim", dtFim));

                //Abre conexão
                con.Open();

                //Datatable que terá os dados do médico
                DataSet dsDiasServico = new DataSet();

                //Popula o datatable
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                adp.Fill(dsDiasServico);

                return dsDiasServico;                             
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
