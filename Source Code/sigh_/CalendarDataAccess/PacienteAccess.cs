using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using CalendarEntity;
using MySql.Data.MySqlClient;

namespace CalendarDataAccess
{
    public class PacienteAccess
    {
        /// <summary>
        /// Método que faz uma inserção básica de um paciente para que seja efetuado o agendamento.
        /// </summary>
        /// <param name="paciente">Objeto Paciente</param>
        
        public void InserirPacienteAgendamentoBasico(Paciente paciente)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["sigh_integracao"].ConnectionString);

            try
            {
                string sql = @" insert into pacientes 
	                            (
	                                ds_nome, 
	                                ds_cpf, 
	                                ds_telefone1,
	                                ds_email,
	                                dt_inclusao
	                            )
	                            values
	                            (
	                                ?ds_nome,  
	                                ?ds_cpf, 
	                                ?ds_telefone1, 
	                                ?ds_email,
	                                ?dtInclusao
	                            )
                                ";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                
                cmd.CommandText = cmd.CommandText.ToLower();
                cmd.Parameters.Add(new MySqlParameter("?ds_nome", paciente.DescricaoNome));
                cmd.Parameters.Add(new MySqlParameter("?ds_cpf", paciente.Cpf));
                cmd.Parameters.Add(new MySqlParameter("?ds_telefone1", paciente.Telefone1));
                cmd.Parameters.Add(new MySqlParameter("?ds_email", paciente.Email));
                cmd.Parameters.Add(new MySqlParameter("?dtInclusao", paciente.DataInclusao.Date));

                //Abre conexão
                con.Open();

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
        /// Retorna todos os pacientes
        /// </summary>
        /// <returns>Datatable contendo todos os pacientes do sistema</returns>
        public DataTable RetornaPacientes()
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["sigh_integracao"].ConnectionString);

            try
            {
                string sql = @" 
                               SELECT 
                                CD_PACIENTE,
                                CD_CONVENIO,
                                DS_NOME,
                                DS_RG,
                                DS_CPF,
                                DS_ENDERECO,
                                DS_COMPL,
                                DS_BAIRRO,
                                DS_CIDADE,
                                DS_ESTADO,
                                DS_CEP,
                                DS_TELEFONE1,
                                DS_TELEFONE2,
                                DT_NASCIMENTO,
                                DS_EMAIL,
                                DS_SEXO,
                                DS_EST_CIVIL,
                                DS_SANGUE,
                                DS_MATRICULA,
                                DS_DEPENDENTE,
                                CD_BAIRRO,
                                CD_CIDADE,
                                CD_RUA,
                                DS_COD_PRONTUARIO,
                                DS_OBS,
                                LG_PRONTUARIO,
                                CD_PROFISSAO,
                                NM_ALTURA,
                                NM_PESO,
                                DT_ULTIMO_ATEND,
                                DT_INCLUSAO,
                                BL_IMAGEM, 
                                LG_AMPLIADO, 
                                DS_PROFISSAO, 
                                NM_SITUACAO, 
                                DT_OBITO, 
                                LG_AUX, 
                                CD_IBGE_CIDADE, 
                                DT_VAL_MATRICULA, 
                                CD_AUX
                                from pacientes
                                ";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.CommandText = cmd.CommandText.ToLower();
                
                //Abre conexão
                con.Open();

                //Criação do adpater
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                
                DataTable dtPacientes = new DataTable();
                adp.Fill(dtPacientes);
                
                return dtPacientes;

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
        /// Retorna paciente de acordo com o id apresentado
        /// </summary>
        /// <param name="codPaciente">Código do paciente</param>
        /// <returns>Objeto paciente</returns>
        public Paciente RetornaPacienteByID(int codPaciente)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["sigh_integracao"].ConnectionString);

            try
            {
                string sql = @" 
                               SELECT 
                                CD_PACIENTE,
                                CD_CONVENIO,
                                DS_NOME,
                                DS_RG,
                                DS_CPF,
                                DS_ENDERECO,
                                DS_COMPL,
                                DS_BAIRRO,
                                DS_CIDADE,
                                DS_ESTADO,
                                DS_CEP,
                                DS_TELEFONE1,
                                DS_TELEFONE2,
                                DT_NASCIMENTO,
                                DS_EMAIL,
                                DS_SEXO,
                                DS_EST_CIVIL,
                                DS_SANGUE,
                                DS_MATRICULA,
                                DS_DEPENDENTE,
                                CD_BAIRRO,
                                CD_CIDADE,
                                CD_RUA,
                                DS_COD_PRONTUARIO,
                                DS_OBS,
                                LG_PRONTUARIO,
                                CD_PROFISSAO,
                                NM_ALTURA,
                                NM_PESO,
                                DT_ULTIMO_ATEND,
                                DT_INCLUSAO,
                                BL_IMAGEM, 
                                LG_AMPLIADO, 
                                DS_PROFISSAO, 
                                NM_SITUACAO, 
                                DT_OBITO, 
                                LG_AUX, 
                                CD_IBGE_CIDADE, 
                                DT_VAL_MATRICULA, 
                                CD_AUX
                                FROM pacientes
                                WHERE CD_PACIENTE = " + codPaciente.ToString(); 

                MySqlCommand cmd = new MySqlCommand(sql, con);

                cmd.CommandText = cmd.CommandText.ToLower();

                //Abre conexão
                con.Open();

                Paciente newPaciente = new Paciente();
                
                MySqlDataReader rd = cmd.ExecuteReader();

                while(rd.Read())
                {
                    newPaciente.CodigoPaciente = Convert.ToInt32(rd["CD_PACIENTE"].ToString());
                    newPaciente.CodigoConvenio = Convert.ToInt32(rd["CD_CONVENIO"].ToString());
                    newPaciente.DescricaoNome = rd["DS_NOME"].ToString();
                    newPaciente.Rg = rd["DS_RG"].ToString();
                    //newPaciente.Cpf = rd["DS_CPF"].ToString();
                    newPaciente.Endereco = rd["DS_ENDERECO"].ToString();
                    newPaciente.Complemento = rd["DS_COMPL"].ToString();
                    newPaciente.Complemento = rd["DS_COMPL"].ToString();
                    newPaciente.Bairro = rd["DS_BAIRRO"].ToString();
                    newPaciente.Cidade = rd["DS_CIDADE"].ToString();
                    newPaciente.Estado = rd["DS_ESTADO"].ToString();
                    newPaciente.Cep = rd["DS_CEP"].ToString();
                    newPaciente.Telefone1 = rd["DS_TELEFONE1"].ToString();
                    newPaciente.Telefone2 = rd["DS_TELEFONE2"].ToString();
                    newPaciente.DataAniversario = Convert.ToInt32(rd["DT_NASCIMENTO"].ToString());
                    newPaciente.Email = rd["DS_EMAIL"].ToString();
                    newPaciente.Sexo = rd["DS_SEXO"].ToString();
                    newPaciente.DescricaoEstadoCivil = rd["DS_EST_CIVIL"].ToString();
                    newPaciente.Sangue = rd["DS_SANGUE"].ToString();
                    newPaciente.Matricula = rd["DS_MATRICULA"].ToString();
                    newPaciente.Dependente = rd["DS_DEPENDENTE"].ToString();
                    newPaciente.CodigoBairro = Convert.ToInt32(rd["CD_BAIRRO"].ToString());
                    newPaciente.CodigoCidade = Convert.ToInt32(rd["CD_CIDADE"].ToString());
                    newPaciente.CodigoRua = Convert.ToInt32(rd["CD_RUA"].ToString());
                    newPaciente.DescricaoCodigoProntuario = rd["DS_COD_PRONTUARIO"].ToString();
                    newPaciente.Observacao = rd["DS_OBS"].ToString();
                    newPaciente.LogProntuario = Convert.ToInt32(rd["LG_PRONTUARIO"].ToString());
                    newPaciente.CodigoProfissao = Convert.ToInt32(rd["CD_PROFISSAO"].ToString());
                    newPaciente.NmAltura = Convert.ToInt32(rd["NM_ALTURA"].ToString());
                    newPaciente.NmPeso = Convert.ToInt32(rd["NM_PESO"].ToString());
                    newPaciente.DataUltimoAtendimento = Convert.ToDateTime(rd["DT_ULTIMO_ATEND"].ToString());
                    newPaciente.DataInclusao = Convert.ToDateTime(rd["DT_INCLUSAO"].ToString());
                    
                    
                }

                return newPaciente;
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
        /// Retorna paciente de acordo com o id apresentado
        /// </summary>
        /// <param name="codPaciente">Código do paciente</param>
        /// <returns>Objeto paciente</returns>
        public Paciente RetornaPacienteByCpf(string cpfPaciente)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["sigh_integracao"].ConnectionString);

            try
            {
                string sql = @" 
                               SELECT 
                                CD_PACIENTE,
                                CD_CONVENIO,
                                DS_NOME,
                                DS_RG,
                                DS_CPF,
                                DS_ENDERECO,
                                DS_COMPL,
                                DS_BAIRRO,
                                DS_CIDADE,
                                DS_ESTADO,
                                DS_CEP,
                                DS_TELEFONE1,
                                DS_TELEFONE2,
                                DT_NASCIMENTO,
                                DS_EMAIL,
                                DS_SEXO,
                                DS_EST_CIVIL,
                                DS_SANGUE,
                                DS_MATRICULA,
                                DS_DEPENDENTE,
                                CD_BAIRRO,
                                CD_CIDADE,
                                CD_RUA,
                                DS_COD_PRONTUARIO,
                                DS_OBS,
                                LG_PRONTUARIO,
                                CD_PROFISSAO,
                                NM_ALTURA,
                                NM_PESO,
                                DT_ULTIMO_ATEND,
                                DT_INCLUSAO,
                                BL_IMAGEM, 
                                LG_AMPLIADO, 
                                DS_PROFISSAO, 
                                NM_SITUACAO, 
                                DT_OBITO, 
                                LG_AUX, 
                                CD_IBGE_CIDADE, 
                                DT_VAL_MATRICULA, 
                                CD_AUX
                                FROM pacientes
                                WHERE DS_CPF = '" + cpfPaciente.ToString() + "'";

                MySqlCommand cmd = new MySqlCommand(sql, con);

                cmd.CommandText = cmd.CommandText.ToLower();

                //Abre conexão
                con.Open();

                Paciente newPaciente = new Paciente();
                
                MySqlDataReader rd = cmd.ExecuteReader();

                while(rd.Read())
                {
                    newPaciente.CodigoPaciente = Convert.ToInt32(rd["CD_PACIENTE"].ToString());
                    newPaciente.CodigoConvenio = Convert.ToInt32(rd["CD_CONVENIO"].ToString());
                    newPaciente.DescricaoNome = rd["DS_NOME"].ToString();
                    newPaciente.Rg = rd["DS_RG"].ToString();
                    //newPaciente.Cpf = rd["DS_CPF"].ToString();
                    newPaciente.Endereco = rd["DS_ENDERECO"].ToString();
                    newPaciente.Complemento = rd["DS_COMPL"].ToString();
                    newPaciente.Complemento = rd["DS_COMPL"].ToString();
                    newPaciente.Bairro = rd["DS_BAIRRO"].ToString();
                    newPaciente.Cidade = rd["DS_CIDADE"].ToString();
                    newPaciente.Estado = rd["DS_ESTADO"].ToString();
                    newPaciente.Cep = rd["DS_CEP"].ToString();
                    newPaciente.Telefone1 = rd["DS_TELEFONE1"].ToString();
                    newPaciente.Telefone2 = rd["DS_TELEFONE2"].ToString();
                    newPaciente.DataAniversario = Convert.ToInt32(rd["DT_NASCIMENTO"].ToString());
                    newPaciente.Email = rd["DS_EMAIL"].ToString();
                    newPaciente.Sexo = rd["DS_SEXO"].ToString();
                    newPaciente.DescricaoEstadoCivil = rd["DS_EST_CIVIL"].ToString();
                    newPaciente.Sangue = rd["DS_SANGUE"].ToString();
                    newPaciente.Matricula = rd["DS_MATRICULA"].ToString();
                    newPaciente.Dependente = rd["DS_DEPENDENTE"].ToString();
                    newPaciente.CodigoBairro = Convert.ToInt32(rd["CD_BAIRRO"].ToString());
                    newPaciente.CodigoCidade = Convert.ToInt32(rd["CD_CIDADE"].ToString());
                    newPaciente.CodigoRua = Convert.ToInt32(rd["CD_RUA"].ToString());
                    newPaciente.DescricaoCodigoProntuario = rd["DS_COD_PRONTUARIO"].ToString();
                    newPaciente.Observacao = rd["DS_OBS"].ToString();
                    newPaciente.LogProntuario = Convert.ToInt32(rd["LG_PRONTUARIO"].ToString());
                    newPaciente.CodigoProfissao = Convert.ToInt32(rd["CD_PROFISSAO"].ToString());
                    newPaciente.NmAltura = Convert.ToInt32(rd["NM_ALTURA"].ToString());
                    newPaciente.NmPeso = Convert.ToInt32(rd["NM_PESO"].ToString());
                    newPaciente.DataUltimoAtendimento = Convert.ToDateTime(rd["DT_ULTIMO_ATEND"].ToString());
                    newPaciente.DataInclusao = Convert.ToDateTime(rd["DT_INCLUSAO"].ToString());
                    
                    
                }

                return newPaciente;
                
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
        /// Retorna paciente de acordo com o id apresentado
        /// </summary>
        /// <param name="codPaciente">Código do paciente</param>
        /// <returns>Objeto paciente</returns>
        public DataTable RetornaPacienteByCpfDataTable(string cpf, string nome)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["sigh_integracao"].ConnectionString);
            
            string sql = string.Empty;
            
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, con);
                
                sql  = @" 
                            SELECT 
                            CD_PACIENTE,
                            DS_NOME,
                            DS_CPF,
                            DS_TELEFONE1,
                            DS_EMAIL
                            FROM pacientes
                            WHERE 1=1 ";

               if (!string.IsNullOrEmpty(cpf))
               {
                    sql += @"and ds_cpf = ?cpf ";
                    cmd.Parameters.Add(new MySqlParameter("?cpf", cpf));
               }

               if (!string.IsNullOrEmpty(nome))
               {
                    sql += @"and ds_nome like '" + nome + @"%'";   
               }
               cmd.CommandText = sql;
               cmd.CommandText = cmd.CommandText.ToLower();
                
                //Abre conexão
               con.Open();
               MySqlDataAdapter da = new MySqlDataAdapter(cmd);

               DataTable dtPaciente = new DataTable();
               da.Fill(dtPaciente);
               return dtPaciente;

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
