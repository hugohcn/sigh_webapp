using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.Common;
using CalendarEntity;
using MySql.Data.MySqlClient;

namespace CalendarDataAccess
{
    public class MedicorAccess
    {
        /// <summary>
        /// Método que retorna o código do médico pelo cpf
        /// </summary>
        /// <param name="cpf">Cpf do médico</param>
        /// <returns>Inteiro resolvido como código do médico</returns>
        public int RetornaMedicoByCpf(string cpf)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["sigh_integracao"].ConnectionString);

            try
            {
                string sql = @"                             
                                select cd_medicor
	                            from medicor 
	                            where ds_cpf = ?cpf
                                ";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add(new MySqlParameter("?cpf", cpf));

                //Abre conexão
                con.Open();

                MySqlDataReader rd = cmd.ExecuteReader();
                
                int codMedico = -1;
                
                while (rd.Read())
                {
                    codMedico = Convert.ToInt32(rd["cd_medicor"].ToString());
                }

                return codMedico;

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
        /// Método que retorna os médicos que trabalham em um determinado com um determinado serviço
        /// </summary>
        /// <param name="diaServico">Dia do serviço</param>
        /// <param name="codServico">Código do Serviço</param>
        /// <returns></returns>
        public DataTable RetornaMedicoByDiaServicoByIdServico(string diaServico, int codServico)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["sigh_integracao"].ConnectionString);

            try
            {
                string sql = @" 
                                select medicor.cd_medicor, medicor.ds_nome from medicor, escalas, servxmedi
                                where escalas.cd_medicor = medicor.cd_medicor 
                                and escalas.ds_dia = ?diaServico
                                and servxmedi.CD_MEDICOR = medicor.cd_medicor 
                                and servxmedi.CD_SERVICO = ?codServico

                ";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add(new MySqlParameter("?diaServico",diaServico));
                cmd.Parameters.Add(new MySqlParameter("?codServico", codServico));

                //Abre conexão
                con.Open();

                //Datatable que terá os dados do médico
                DataTable dtMedicos = new DataTable();

                //Popula o datatable
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                adp.Fill(dtMedicos);

                return dtMedicos;

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
        /// Método qque busca todos os médicos do legado
        /// </summary>
        public DataTable RetornaMedicosByServico(int idServico)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["sigh_integracao"].ConnectionString);

            try
            {
                /*
                 * Query antiga que serve para versões > 4.1 do MySql
                string sql = @" select medicor.CD_MEDICOR, medicor.DS_NOME from medicor 
                 *              where cd_medicor in 
                                (   select servxmedi.CD_MEDICOR from servxmedi
	                                where cd_servico = @idServico
	                            )";
	            */

                string sql = @" select medicor.* from medicor
                                left join servxmedi on servxmedi.CD_MEDICOR = medicor.CD_MEDICOR
                                where cd_servico = " + idServico.ToString();

                MySqlCommand cmd = new MySqlCommand(sql, con);
                //cmd.Parameters.AddWithValue("@idServico", idServico);

                //Abre conexão
                con.Open();

                //Datatable que terá os dados do médico
                DataTable dtMedicos = new DataTable();

                //Popula o datatable
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                adp.Fill(dtMedicos);

                return dtMedicos;

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
        /// Método de retorna da escala de um médico
        /// </summary>
        /// <param name="idMedico">Identificador do médico</param>
        /// <param name="diaSemana">Dia da semana</param>
        /// <returns>DataTable com a escala e possíveis escalas no dia</returns>
        public Escala RetornaEscalaMedico(int idMedico, string diaSemana)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["sigh_integracao"].ConnectionString);

            try
            {
                string sql = @" SELECT 
                                CD_ESCALA,
                                CD_MEDICOR,
                                DS_DIA,
                                HR_INI1,
                                HR_FIM1,
                                NM_DURACAO1,
                                LG_HABILITADO,
                                DT_ESCALA,
                                HR_INI2,
                                HR_FIM2,
                                NM_DURACAO2,
                                HR_INI3,
                                HR_FIM3,
                                NM_DURACAO3,
                                DS_OBS,
                                NM_ENCAIXES_LIVRE,
                                NM_ENCAIXES_SENHA
                                FROM escalas WHERE CD_MEDICOR = ?idMedico
                                and DS_DIA = ?diaSemana";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add(new MySqlParameter("?idMedico", idMedico));
                cmd.Parameters.Add(new MySqlParameter("?diaSemana", diaSemana));                
                
                //Abre conexão
                con.Open();
                
                cmd.CommandText = cmd.CommandText.ToLower();

                MySqlDataReader dr = cmd.ExecuteReader();

                //Monta o novo objeto de escala
                Escala newEscala = new Escala();

                while (dr.Read())
                {
                    //Inicia a população do objeto de escala
                    newEscala.CodigoEscala = Convert.ToInt32(dr["CD_ESCALA"].ToString());
                    newEscala.CodigoMedicor = Convert.ToInt32(dr["CD_MEDICOR"].ToString());
                    newEscala.DiaSemana = dr["DS_DIA"].ToString();
                    
                    //Verifica a primeira jornada
                    if(!dr["HR_INI1"].Equals(DBNull.Value))
	                {
	                    newEscala.Jornada1 = new Jornada();
	                    
                        newEscala.Jornada1.HoraInicio = Convert.ToInt32(dr["HR_INI1"].ToString());
                        newEscala.Jornada1.HoraFim = Convert.ToInt32(dr["HR_FIM1"].ToString());
                        newEscala.Jornada1.NmDuracao = Convert.ToInt32(dr["NM_DURACAO1"].ToString());	                         
	                }
                    else
                    {
                        newEscala.Jornada1 = null;
                    }
	                
	                newEscala.LogHabilitado = Convert.ToInt32(dr["LG_HABILITADO"].ToString());

                    //Trata a existência de alguns valores inadequados para o datetime.
                    if (!dr["DT_ESCALA"].Equals(DBNull.Value))
                    {
                        newEscala.DataEscala = Convert.ToDateTime(dr["DT_ESCALA"].ToString());
                    }
                    else
                    {
                        newEscala.DataEscala = DateTime.MinValue;
                    }
	                

                    //Verifica a segunda jornada
                    if (!dr["HR_INI2"].Equals(DBNull.Value))
                    {
                        newEscala.Jornada2 = new Jornada();
                        
                        newEscala.Jornada2.HoraInicio = Convert.ToInt32(dr["HR_INI2"].ToString());
                        newEscala.Jornada2.HoraFim = Convert.ToInt32(dr["HR_FIM2"].ToString());
                        newEscala.Jornada2.NmDuracao = Convert.ToInt32(dr["NM_DURACAO2"].ToString());
                    }
                    else
                    {
                        newEscala.Jornada2 = null;
                    }

                    //Verifica a terceira jornada
                    if (!dr["HR_INI3"].Equals(DBNull.Value))
                    {
                        newEscala.Jornada3 = new Jornada();
                    
                        newEscala.Jornada3.HoraInicio = Convert.ToInt32(dr["HR_INI3"].ToString());
                        newEscala.Jornada3.HoraFim = Convert.ToInt32(dr["HR_FIM3"].ToString());
                        newEscala.Jornada3.NmDuracao = Convert.ToInt32(dr["NM_DURACAO3"].ToString());
                    }
                    else
                    {
                        newEscala.Jornada3 = null;
                    }
                    
                    //Verificação de dados null
                    if (!dr["DS_OBS"].Equals(DBNull.Value))
                    {
                        newEscala.Observacao = dr["DS_OBS"].ToString();
                    }
                    else
                    {
                        newEscala.Observacao = string.Empty;
                    }

                    //Verificação de dados null
                    if (!dr["NM_ENCAIXES_LIVRE"].Equals(DBNull.Value))
                    {
                        newEscala.NmEncaixesLivres = Convert.ToInt32(dr["NM_ENCAIXES_LIVRE"].ToString());
                    }
                    else
                    {
                        newEscala.NmEncaixesLivres = 0;
                    }

                    //Verificação de dados null
                    if (!dr["NM_ENCAIXES_SENHA"].Equals(DBNull.Value))
                    {
                        newEscala.NmEncaixesSenhas = Convert.ToInt32(dr["NM_ENCAIXES_SENHA"].ToString());
                    }
                    else
                    {
                        newEscala.NmEncaixesSenhas = 0;
                    }
                }                
                
                return newEscala;
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
        /// Método qque busca todos os médicos do legado
        /// </summary>
        public DataTable RetornaMedicos()
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["sigh_integracao"].ConnectionString);

            try
            {
                string sql = @"
                                SELECT 
                                CD_MEDICOR,
                                DS_NOME,
                                LG_SOCIO,
                                DS_RG,
                                DS_CPF,
                                DS_ENDERECO,
                                DS_BAIRRO,
                                DS_CIDADE,
                                DS_ESTADO,
                                NM_PERCENTUAL,
                                DS_CEP,
                                DS_TELEFONE1,
                                DS_TELEFONE2,
                                DS_EMAIL,
                                DT_NASCIMENTO,
                                DS_CRM,
                                DS_UF,
                                DS_ESPECIALIDADE,
                                DS_FUNCAO,
                                LG_REVISAO,
                                DS_BANCO,
                                DS_AGENCIA,
                                DS_CONTA,
                                DS_OBS_AGENDA,
                                CD_MEDICOS,
                                LG_PERMITE_ENCAIXE,
                                LG_RECEBE_EMAIL,
                                CD_CBOS,
                                DS_LOGIN_TOMMASI,
                                DS_SENHA_TOMMASI,
                                CD_CONSELHO,
                                CD_MEDICOR_AUX,
                                NM_ACESSOS_TOMMASI,
                                LG_VISUALIZA_CANCELADOS,
                                CD_CBOS2,
                                LG_PADRAO
                                FROM medicor";

                MySqlCommand cmd = new MySqlCommand(sql, con);

                //Abre conexão
                con.Open();

                //Datatable que terá os dados do médico
                DataTable dtMedicos = new DataTable();

                //Popula o datatable
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                adp.Fill(dtMedicos);

                return dtMedicos;

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
