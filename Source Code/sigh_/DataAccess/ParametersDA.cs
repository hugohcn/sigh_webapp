using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace DataAccess
{
    public class ParametersDA
    {
        /// <summary>
        /// Retorna o parâmetro
        /// </summary>
        /// <param name="key">Nome da chave</param>
        /// <returns>Objeto parâmetro</returns>
        public ParametersEN RetornaParametro(string key)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["sigh"].ConnectionString);

            try
            {
                string sql = @" 
                                select id_parametro, key_parametro, value_parametro from tblparametrossistema
                                where key_parametro = ?key
                                ";

                //Command
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add(new MySqlParameter("?key",key));
                
                //Abre conexão
                con.Open();

                //Efetua leitura
                MySqlDataReader dr = cmd.ExecuteReader();

                ParametersEN parametro = new ParametersEN();
                
                while (dr.Read())
                {
                    parametro.Id = Convert.ToInt32(dr["id_parametro"].ToString());
                    parametro.Key = dr["key_parametro"].ToString();
                    parametro.Value = dr["value_parametro"].ToString();
                }
                
                return parametro;
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
        /// Método que retorna todos os parâmetros cadastrados...
        /// </summary>
        /// <returns>DataTable contendo todos os parâmetros</returns>
        public DataTable RetornaTodosParametros()
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["sigh"].ConnectionString);

            try
            {
                string sql = @" 
                                select id_parametro, key_parametro, value_parametro from tblparametrossistema
                                ";

                //Command
                MySqlCommand cmd = new MySqlCommand(sql, con);

                //Abre conexão
                con.Open();

                //Efetua leitura
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataTable dtParametros = new DataTable();
                
                adp.Fill(dtParametros);
                
                return dtParametros;
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
        /// Método que insere um parâmetro no sistema
        /// </summary>
        /// <param name="parametro">Objeto parâmetro</param>
        public void InserirParametro(ParametersEN parametro)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["sigh"].ConnectionString);

            try
            {
                string sql = @" 
                                insert into tblparametrossistema 
	                            (
		                            id_parametro, 
		                            key_parametro, 
		                            value_parametro
	                            )
	                            values
	                            (
		                            ?id_parametro, 
		                            ?key_parametro, 
		                            ?value_parametro
	                            )
                                ";

                //Command
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add(new MySqlParameter("?id_parametro", 0));
                cmd.Parameters.Add(new MySqlParameter("?key_parametro", parametro.Key));
                cmd.Parameters.Add(new MySqlParameter("?value_parametro", parametro.Value));
                

                //Abre conexão
                con.Open();

                cmd.ExecuteNonQuery();
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
        /// Método que atualiza um parâmetro no sistema
        /// </summary>
        /// <param name="parametro">Objeto parâmetro</param>
        public void AtualizarParametro(ParametersEN parametro)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["sigh"].ConnectionString);

            try
            {
                string sql = @" 
                                update tblparametrossistema 
                                set 
	                            key_parametro = ?key_parametro, 
	                            value_parametro = ?value_parametro
	                            where id_parametro = ?id_parametro 
                                ";

                //Command
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add(new MySqlParameter("?id_parametro", parametro.Id));
                cmd.Parameters.Add(new MySqlParameter("?key_parametro", parametro.Key));
                cmd.Parameters.Add(new MySqlParameter("?value_parametro", parametro.Value));


                //Abre conexão
                con.Open();

                cmd.ExecuteNonQuery();
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
       /// Método que efetua deleção de parâmetro do banco de dados...
       /// </summary>
       /// <param name="idParametro">Identificador (inteiro) do parâmetro</param>
        public void DeletarParametro(int idParametro)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["sigh"].ConnectionString);

            try
            {
                string sql = @" 
                                delete from tblparametrossistema 
	                            where id_parametro = ?id_parametro 
                                ";

                //Command
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add(new MySqlParameter("?id_parametro", idParametro));

                //Abre conexão
                con.Open();

                cmd.ExecuteNonQuery();
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
