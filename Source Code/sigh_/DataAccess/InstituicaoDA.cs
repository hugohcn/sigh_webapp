using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using Entity;
using MySql.Data.MySqlClient;

namespace DataAccess
{
    public class InstituicaoDA
    {
        /// <summary>
        /// Método que retorna todas as instituições do sistema.
        /// </summary>
        /// <returns>Dataset com resultados das querys.</returns>
        public DataSet RetornaInstituicoes()
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["sigh"].ConnectionString);

            try
            {
                string sql = @" select 	
                                id_instituicao, 
                                nome, 
                                endereco, 
                                numero, 
                                bairro, 
                                cidade, 
                                estado, 
                                cep, 
                                dt_registro, 
                                nome_responsavel, 
                                funcao, 
                                email, 
                                telefone, 
                                cnpj_instituicao 
                                from 
                                tblinstituicao";

                MySqlCommand cmd = new MySqlCommand(sql, con);

                //Abre conexão
                con.Open();

                //Efetua leitura
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                //Cria objeto DataSet que armazenará os resultados retornados do banco
                DataSet dsResult = new DataSet();

                da.Fill(dsResult);

                //Retorna objeto de login.
                return dsResult;
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
        /// Método que insere instituição no sistema.
        /// </summary>
        /// <returns>Sem retorno</returns>
        public void InserirInstituicao(InstituicaoEN instituicao)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["sigh"].ConnectionString);

            try
            {
                string sql = @" insert into tblinstituicao 
                                (
	                                id_instituicao, 
	                                nome, 
	                                endereco, 
	                                numero, 
	                                bairro, 
	                                cidade, 
	                                estado, 
	                                cep, 
	                                dt_registro, 
	                                nome_responsavel, 
	                                funcao, 
	                                email, 
	                                telefone, 
	                                cnpj_instituicao
                                )
                                values
                                (
	                                ?id_instituicao, 
	                                ?nome, 
	                                ?endereco, 
	                                ?numero, 
	                                ?bairro, 
	                                ?cidade, 
	                                ?estado, 
	                                ?cep, 
	                                ?dt_registro, 
	                                ?nome_responsavel, 
	                                ?funcao, 
	                                ?email, 
	                                ?telefone, 
	                                ?cnpj_instituicao
                                )
                                ";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add(new MySqlParameter("?id_instituicao",instituicao.IdInstituicao));
                cmd.Parameters.Add(new MySqlParameter("?nome", instituicao.Nome));
                cmd.Parameters.Add(new MySqlParameter("?endereco", instituicao.Endereco));
                cmd.Parameters.Add(new MySqlParameter("?numero", instituicao.Numero));
                cmd.Parameters.Add(new MySqlParameter("?bairro", instituicao.Bairro));
                cmd.Parameters.Add(new MySqlParameter("?cidade", instituicao.Cidade));
                cmd.Parameters.Add(new MySqlParameter("?estado", instituicao.Estado));
                cmd.Parameters.Add(new MySqlParameter("?cep", instituicao.Cep));
                cmd.Parameters.Add(new MySqlParameter("?dt_registro", instituicao.DtRegistro.Date));
                cmd.Parameters.Add(new MySqlParameter("?nome_responsavel", instituicao.NomeResponsavel));
                cmd.Parameters.Add(new MySqlParameter("?funcao", instituicao.Funcao));
                cmd.Parameters.Add(new MySqlParameter("?email", instituicao.Email));
                cmd.Parameters.Add(new MySqlParameter("?telefone", instituicao.Telefone));
                cmd.Parameters.Add(new MySqlParameter("?cnpj_instituicao", instituicao.CnpjInstituicao));
                
                //Abre conexão
                con.Open();

                //executa a query
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
        /// Método que insere instituição no sistema.
        /// </summary>
        /// <returns>Sem retorno</returns>
        public void AtualizarInstituicao(InstituicaoEN instituicao)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["sigh"].ConnectionString);

            try
            {
                string sql = @" update tblinstituicao 
                                set  
                                nome = ?nome, 
                                endereco = ?endereco, 
                                numero = ?numero, 
                                bairro = ?bairro, 
                                cidade = ?cidade, 
                                estado = ?estado, 
                                cep = ?cep, 
                                dt_registro = ?dt_registro, 
                                nome_responsavel = ?nome_responsavel, 
                                funcao = ?funcao, 
                                email = ?email,
                                telefone = ?telefone, 
                                cnpj_instituicao = ?cnpj_instituicao
                                where id_instituicao = ?id_instituicao
                                ";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add(new MySqlParameter("?id_instituicao", instituicao.IdInstituicao));
                cmd.Parameters.Add(new MySqlParameter("?nome", instituicao.Nome));
                cmd.Parameters.Add(new MySqlParameter("?endereco", instituicao.Endereco));
                cmd.Parameters.Add(new MySqlParameter("?numero", instituicao.Numero));
                cmd.Parameters.Add(new MySqlParameter("?bairro", instituicao.Bairro));
                cmd.Parameters.Add(new MySqlParameter("?cidade", instituicao.Cidade));
                cmd.Parameters.Add(new MySqlParameter("?estado", instituicao.Estado));
                cmd.Parameters.Add(new MySqlParameter("?cep", instituicao.Cep));
                cmd.Parameters.Add(new MySqlParameter("?dt_registro", instituicao.DtRegistro.Date));
                cmd.Parameters.Add(new MySqlParameter("?nome_responsavel", instituicao.NomeResponsavel));
                cmd.Parameters.Add(new MySqlParameter("?funcao", instituicao.Funcao));
                cmd.Parameters.Add(new MySqlParameter("?email", instituicao.Email));
                cmd.Parameters.Add(new MySqlParameter("?telefone", instituicao.Telefone));
                cmd.Parameters.Add(new MySqlParameter("?cnpj_instituicao", instituicao.CnpjInstituicao));

                //Abre conexão
                con.Open();

                //executa a query
                int a = cmd.ExecuteNonQuery();
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
        /// Método que remove instituição no sistema.
        /// </summary>
        /// <returns>Sem retorno</returns>
        public void RemoverInstituicao(int idInstituicao)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["sigh"].ConnectionString);

            try
            {
                string sql = @" delete from tblinstituicao
                                where id_instituicao = ?id_instituicao
                                ";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add(new MySqlParameter("?id_instituicao", idInstituicao));

                //Abre conexão
                con.Open();

                //executa a query
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
