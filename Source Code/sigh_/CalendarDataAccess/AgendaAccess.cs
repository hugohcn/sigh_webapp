using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;
using CalendarEntity;

namespace CalendarDataAccess
{
    public class AgendaAccess
    {
        /// <summary>
        /// Método que insere os dados de uma consulta na tabela de agendamentos
        /// </summary>
        /// <param name="agenda">Objeto agenda que permite receber os parametros e propriedades do mesmo.</param>
        public void InserirConsultaByDiaByMedicoByHoraAgendada(string date, Agenda agenda, string horaAgendada)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["sigh_integracao"].ConnectionString);

            try
            {
                string sql = @"
                                insert into agenda
                                (   CD_MEDICOR, 
                                    DT_AGENDA, 
                                    HR_AGENDA, 
                                    CD_SERVICO, 
                                    CD_PACIENTE, 
                                    CD_CATEGORIA, 
                                    CD_CONVENIO, 
                                    DS_OBS, 
                                    DS_SITUACAO, 
                                    VL_SERVICO, 
                                    LG_REVISAO, 
                                    DS_USUARIO, 
                                    LG_PEQPROCED, 
                                    LG_CHAMOU, 
                                    DT_CHAMOU, 
                                    LG_ATENDEU, 
	                                DT_ATENDEU, 
	                                NM_ANDAR, 
	                                CD_LANCAMENTO, 
	                                LG_PRIMEIRA_VEZ, 
	                                LG_EXCLUIDO, 
	                                DS_MOTIVO, 
	                                CD_CID, 
	                                LG_ENCAIXE, 
	                                LG_MARCACAO_WEB,
	                                CD_INSTITUICAO
	                            )
                                values
                                (
                                    ?codMedicor,
                                    ?dtAgenda,
                                    ?hrAgenda,
                                    ?codServico,
                                    ?codPaciente,
                                    ?codCategoria,
                                    ?codConvenio,
                                    ?dsObs,
                                    ?ds_situacao,
                                    ?vlServico,
                                    ?lgRevisao,
                                    ?ds_usuario,
                                    ?lgPeqProced,
                                    ?lgChamou,
                                    ?dtChamou,
                                    ?lgAtendeu,
                                    ?dtAtendeu,
                                    ?nmAndar,
                                    ?cdLancamento,
                                    ?lgPrimeiraVez,
                                    ?lgExcluido,
                                    ?dsMotivo,
                                    ?cdCid,
                                    ?lgEncaixe,
                                    ?lgMarcacaoWeb,
                                    ?cdInstituicao
                                )                                 
                             ";

                //Abre conexão
                con.Open();

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add(new MySqlParameter("?codMedicor", agenda.CodigoMedicor));
                cmd.Parameters.Add(new MySqlParameter("?dtAgenda", date));
                cmd.Parameters.Add(new MySqlParameter("?hrAgenda", horaAgendada));
                cmd.Parameters.Add(new MySqlParameter("?codServico", agenda.CodigoServico));
                cmd.Parameters.Add(new MySqlParameter("?codPaciente", agenda.CodigoPaciente));
                cmd.Parameters.Add(new MySqlParameter("?codCategoria", agenda.CodigoCategoria));
                cmd.Parameters.Add(new MySqlParameter("?codConvenio", agenda.CodigoConvenio));
                cmd.Parameters.Add(new MySqlParameter("?dsObs", agenda.Observacao));
                cmd.Parameters.Add(new MySqlParameter("?ds_situacao", agenda.Situacao));
                cmd.Parameters.Add(new MySqlParameter("?vlServico", agenda.ValorServico));
                cmd.Parameters.Add(new MySqlParameter("?lgRevisao", agenda.LogRevisao));
                cmd.Parameters.Add(new MySqlParameter("?ds_usuario", agenda.DescricaoUsuario));
                cmd.Parameters.Add(new MySqlParameter("?lgPeqProced", agenda.LogPeqProcedencia));
                cmd.Parameters.Add(new MySqlParameter("?lgChamou", agenda.LogChamou));
                cmd.Parameters.Add(new MySqlParameter("?dtChamou", agenda.DataChamou));
                cmd.Parameters.Add(new MySqlParameter("?lgAtendeu", 1));
                cmd.Parameters.Add(new MySqlParameter("?dtAtendeu", DBNull.Value));
                cmd.Parameters.Add(new MySqlParameter("?nmAndar", agenda.NmAndar));
                cmd.Parameters.Add(new MySqlParameter("?cdLancamento", DBNull.Value));
                cmd.Parameters.Add(new MySqlParameter("?lgPrimeiraVez", agenda.LogPrimeiraVez));
                cmd.Parameters.Add(new MySqlParameter("?lgExcluido", agenda.LogExcluido));
                cmd.Parameters.Add(new MySqlParameter("?dsMotivo", agenda.DescricaoMotivo));
                cmd.Parameters.Add(new MySqlParameter("?cdCid", agenda.CodigoCid));
                cmd.Parameters.Add(new MySqlParameter("?lgEncaixe", agenda.LogEncaixe));
                cmd.Parameters.Add(new MySqlParameter("?lgMarcacaoWeb", agenda.LogMarcacaoWeb));
                cmd.Parameters.Add(new MySqlParameter("?cdInstituicao", agenda.CodigoInstituicao));

                int count = cmd.ExecuteNonQuery();

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
        /// Método que atualiza uma consulta
        /// </summary>
        /// <param name="date">Data da consulta</param>
        /// <param name="codMedico">Código do médico</param>
        /// <param name="horaAgendada">Hora agendada para a consulta</param>
        public void AtualizarConsultaByDiaByMedicoByHoraAgendada(string date, Agenda agenda, string horaAgendada)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["sigh_integracao"].ConnectionString);

            try
            {
                string sql = @"
                                update
                                agenda
                                set
                                cd_medicor = ?codMedicor,
                                dt_agenda = ?dtAgenda,
                                hr_agenda = ?hrAgenda,
                                cd_servico = ?codServico,
                                cd_paciente = ?codPaciente,
                                cd_categoria = ?codCategoria,
                                cd_convenio = ?codConvenio,
                                ds_obs = ?dsObs,
                                ds_situacao = ?ds_situacao,
                                vl_servico = ?vlServico,
                                lg_revisao = ?lgRevisao,
                                ds_usuario = ?ds_usuario,
                                lg_peqproced = ?lgPeqProced,
                                lg_chamou = ?lgChamou,
                                dt_chamou = ?dtChamou,
                                lg_atendeu = ?lgAtendeu,
                                dt_atendeu = ?dtAtendeu,
                                nm_andar = ?nmAndar,
                                cd_lancamento = ?cdLancamento,
                                lg_primeira_vez = ?lgPrimeiraVez,
                                lg_excluido = ?lgExcluido,
                                ds_motivo = ?dsMotivo,
                                cd_cid = ?cdCid,
                                lg_encaixe = ?lgEncaixe,
                                lg_marcacao_web = ?lgMarcacaoWeb,
                                cd_instituicao = ?cdInstituicao
                                where agenda.DT_AGENDA = ?dtAgenda
                                and agenda.CD_MEDICOR = ?codMedicor
                                and agenda.HR_AGENDA = ?hrAgenda                                  
                             ";

                //Abre conexão
                con.Open();
                
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add(new MySqlParameter("?codMedicor",agenda.CodigoMedicor));
                cmd.Parameters.Add(new MySqlParameter("?dtAgenda", date));
                cmd.Parameters.Add(new MySqlParameter("?hrAgenda", horaAgendada));
                cmd.Parameters.Add(new MySqlParameter("?codServico", agenda.CodigoServico));
                cmd.Parameters.Add(new MySqlParameter("?codPaciente", agenda.CodigoPaciente));
                cmd.Parameters.Add(new MySqlParameter("?codCategoria", agenda.CodigoCategoria));
                cmd.Parameters.Add(new MySqlParameter("?codConvenio", agenda.CodigoConvenio));
                cmd.Parameters.Add(new MySqlParameter("?dsObs", agenda.Observacao));
                cmd.Parameters.Add(new MySqlParameter("?ds_situacao", agenda.Situacao));
                cmd.Parameters.Add(new MySqlParameter("?vlServico", agenda.ValorServico));
                cmd.Parameters.Add(new MySqlParameter("?lgRevisao", agenda.LogRevisao));
                cmd.Parameters.Add(new MySqlParameter("?ds_usuario", agenda.DescricaoUsuario));
                cmd.Parameters.Add(new MySqlParameter("?lgPeqProced", agenda.LogPeqProcedencia));
                cmd.Parameters.Add(new MySqlParameter("?lgChamou", agenda.LogChamou));
                cmd.Parameters.Add(new MySqlParameter("?dtChamou", agenda.DataChamou));
                cmd.Parameters.Add(new MySqlParameter("?lgAtendeu", 1));
                cmd.Parameters.Add(new MySqlParameter("?dtAtendeu", DBNull.Value));
                cmd.Parameters.Add(new MySqlParameter("?nmAndar", agenda.NmAndar));
                cmd.Parameters.Add(new MySqlParameter("?cdLancamento", DBNull.Value));
                cmd.Parameters.Add(new MySqlParameter("?lgPrimeiraVez", agenda.LogPrimeiraVez));
                cmd.Parameters.Add(new MySqlParameter("?lgExcluido", agenda.LogExcluido));
                cmd.Parameters.Add(new MySqlParameter("?dsMotivo", agenda.DescricaoMotivo));
                cmd.Parameters.Add(new MySqlParameter("?cdCid", agenda.CodigoCid));
                cmd.Parameters.Add(new MySqlParameter("?lgEncaixe", agenda.LogEncaixe));
                cmd.Parameters.Add(new MySqlParameter("?lgMarcacaoWeb", agenda.LogMarcacaoWeb));
                cmd.Parameters.Add(new MySqlParameter("?cdInstituicao", agenda.CodigoInstituicao));
                
                
                int count = cmd.ExecuteNonQuery();
                
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
        /// Método que efetua deleção de consulta na agenda
        /// </summary>
        /// <param name="date">Data da consulta</param>
        /// <param name="agenda">Objeto agenda para população de parâmetros</param>
        /// <param name="horaAgendada">Hora agendada</param>
        public void DeletarConsultaByDiaByMedicoByHoraAgendada(string date, int codMedicor, string horaAgendada)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["sigh_integracao"].ConnectionString);

            try
            {
                string sql = @"
                                update agenda set
                                lg_excluido = 1,
                                ds_situacao = ‘Excluído’
                                where 
                                cd_medicor = ?cdMedicor
                                and dt_agenda = ?dtAgenda
                                and hr_agenda = ?hrAgenda                                   
                             ";

                //Abre conexão
                con.Open();

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add(new MySqlParameter("?cdMedicor", codMedicor));
                cmd.Parameters.Add(new MySqlParameter("?dtAgenda", date));
                cmd.Parameters.Add(new MySqlParameter("?hrAgenda", horaAgendada));

                int count = cmd.ExecuteNonQuery();

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
        /// Retorna as consultas marcadas para o médico na data informada.
        /// </summary>
        /// <param name="date">Data da agenda</param>
        /// <param name="codMedico">Código do médico</param>
        /// <returns>DataTable contendo os dados das consultas do dia do médico</returns>
        public DataTable RetornaAgendaByDiaByMedico(string date, int codMedico)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["sigh_integracao"].ConnectionString);

            try
            {
                string sql = @" SELECT agenda.DT_AGENDA, 
                                agenda.ds_situacao, 
                                agenda.HR_AGENDA, 
                                pacientes.DS_NOME AS nome, 
                                pacientes.DS_TELEFONE1 AS telefone, 
                                convenios.DS_NOME AS convenio, 
                                servicos.DS_NOME AS servico, 
                                agenda.DS_OBS AS observacao,
                                agenda.cd_instituicao
                                FROM agenda, pacientes, convenios, servicos
                                WHERE agenda.CD_PACIENTE = pacientes.CD_PACIENTE
                                AND agenda.CD_CONVENIO = convenios.CD_CONVENIO
                                AND agenda.CD_SERVICO = servicos.CD_SERVICO
                                AND agenda.DT_AGENDA = " + date + @"
                                AND agenda.CD_MEDICOR = " + codMedico.ToString() + @"
                                AND agenda.ds_situacao <> 'Cancelado' AND ds_situacao <> 'Faltou' AND ds_situacao <> 'Excluído'
                                ORDER BY agenda.HR_AGENDA ASC
                             ";

                MySqlCommand cmd = new MySqlCommand(sql, con);

                //Abre conexão
                con.Open();

                //Datatable que terá os dados do médico
                DataTable dtConsultas = new DataTable();

                //Popula o datatable
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                adp.Fill(dtConsultas);

                return dtConsultas;
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
        /// Retorna a consulta em determinada hora, feita por determinado médico.
        /// </summary>
        /// <param name="date">Data da consulta na agenda</param>
        /// <param name="codMedico">Código do médico no qual fará o serviço</param>
        /// <param name="horaAgendada">Hora agendada para o paciente</param>
        /// <returns></returns>
        public DataTable RetornaConsultaByDiaByMedicoByHoraAgendada(string date, int codMedico, string horaAgendada)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["sigh_integracao"].ConnectionString);

            try
            {
                string sql = @" 
                                SELECT agenda.DT_AGENDA, 
                                agenda.HR_AGENDA,
                                agenda.CD_SERVICO,  
                                agenda.CD_CATEGORIA,  
                                agenda.CD_CONVENIO,
                                agenda.CD_PACIENTE,
                                agenda.ds_situacao, 
                                agenda.HR_AGENDA,
                                agenda.VL_SERVICO as valor,
                                agenda.cd_instituicao, 
                                pacientes.DS_NOME AS nome, 
                                pacientes.DS_TELEFONE1 AS telefone, 
                                convenios.DS_NOME AS convenio, 
                                servicos.DS_NOME AS servico, 
                                agenda.DS_OBS AS observacao,
                                categorias.DS_NOME as categoria
                                FROM agenda, pacientes, convenios, servicos, categorias 
                                WHERE agenda.CD_PACIENTE = pacientes.CD_PACIENTE
                                AND agenda.CD_CONVENIO = convenios.CD_CONVENIO
                                AND agenda.CD_SERVICO = servicos.CD_SERVICO
                                AND agenda.CD_CATEGORIA = categorias.CD_CATEGORIA
                                AND agenda.DT_AGENDA = " + date + @" 
                                AND agenda.CD_MEDICOR = " + codMedico.ToString() + @"
                                AND agenda.HR_AGENDA = " + horaAgendada +@"
                                AND agenda.ds_situacao <> 'Cancelado' AND ds_situacao <> 'Faltou' AND ds_situacao <> 'Excluído'
                                ORDER BY agenda.HR_AGENDA ASC
                             ";

                MySqlCommand cmd = new MySqlCommand(sql, con);

                //Abre conexão
                con.Open();

                //Datatable que terá os dados do médico
                DataTable dtConsultas = new DataTable();

                //Popula o datatable
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                adp.Fill(dtConsultas);

                return dtConsultas;
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
        /// Retorna as consultas marcadas para o médico na data informada.
        /// </summary>
        /// <param name="date">Data da agenda</param>
        /// <param name="codMedico">Código do médico</param>
        /// <returns>DataTable contendo os dados das consultas do dia do médico</returns>
        public DataTable RetornaObservacaoByDate(string date)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["sigh_integracao"].ConnectionString);

            try
            {
                string sql = @" 
                                select agenda.DS_OBS from agenda
                                where agenda.HR_AGENDA = 1030
                             ";

                MySqlCommand cmd = new MySqlCommand(sql, con);

                //cmd.Parameters.AddWithValue("@dtAgenda", date);
                //cmd.Parameters.AddWithValue("@codMedico", codMedico);

                //Abre conexão
                con.Open();

                //Datatable que terá os dados do médico
                DataTable dtConsultas = new DataTable();

                //Popula o datatable
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                adp.Fill(dtConsultas);

                return dtConsultas;
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
