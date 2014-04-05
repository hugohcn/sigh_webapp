using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace CalendarDataAccess
{
    public class CategoriaAccess
    {
        /// <summary>
        /// Método que retorna as categorias de serviços prestados de acordo com cada médico
        /// </summary>
        /// <param name="codMedico">Código de identificação do médico</param>
        /// <returns></returns>
        public DataTable RetornaCategoriaByMedico(int codMedico)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["sigh_integracao"].ConnectionString);

            try
            {
                //Query que roda no mysql 4.1
                string sql = @" select categorias.cd_categoria, categorias.ds_nome
                                from servicos, categorias, servxmedi
                                where servicos.cd_servico = servxmedi.cd_servico 
                                and servicos.cd_categoria = categorias.cd_categoria 
                                and servxmedi.cd_medicor = " +codMedico.ToString()+ @"
                                group by categorias.cd_categoria
                                order by categorias.ds_nome";

                MySqlCommand cmd = new MySqlCommand(sql, con);

                //Abre conexão
                con.Open();

                //Datatable que terá os dados do médico
                DataTable dtCategorias = new DataTable();

                //Popula o datatable
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                adp.Fill(dtCategorias);

                return dtCategorias;
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
        /// Método que retorna todas as categorias de serviços do banco de dados
        /// </summary>
        /// <returns>Retorna um datatable contendo os resultados obtidos (Categorias de Serviços)</returns>
        public DataTable RetornaCategorias()
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["sigh_integracao"].ConnectionString);

            try
            {
                //Query que roda no mysql 4.1
                string sql = @" select categorias.cd_categoria, categorias.ds_nome
                                from categorias";

                MySqlCommand cmd = new MySqlCommand(sql, con);

                //Abre conexão
                con.Open();

                //Datatable que terá os dados do médico
                DataTable dtCategorias = new DataTable();

                //Popula o datatable
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                adp.Fill(dtCategorias);

                return dtCategorias;
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
