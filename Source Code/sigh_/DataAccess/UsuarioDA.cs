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
    public class UsuarioDA
    {

        /// <summary>
        /// Método para atualização dos tipos de usuário.
        /// </summary>
        /// <param name="tipoUsuario">Objeto Tipo usuário</param>
        public void AtualizarTipoUsuario(TipoUsuario tpUsuario)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["sigh"].ConnectionString);

            try
            {
                string sql = @" update tbltipousuario
                                set ds_tipo_usuario = ?dsTipoUsuario where id_tipo_usuario = ?idTipoUsuario";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add(new MySqlParameter("?dsTipoUsuario", tpUsuario.DescricaoTipoUsuario));
                cmd.Parameters.Add(new MySqlParameter("?idTipoUsuario", tpUsuario.IdTipoUsuario));
                
                //Abre conexão
                con.Open();

                //Efetua leitura
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
        /// Método para deleção de tipos de usuário.
        /// </summary>
        /// <param name="tipoUsuario">Objeto Tipo usuário</param>
        public void ExcluirTipoUsuario(TipoUsuario tpUsuario)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["sigh"].ConnectionString);

            try
            {
                string sql = @" delete from tbltipousuario
                                where id_tipo_usuario = ?idTipoUsuario";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add(new MySqlParameter("?idTipoUsuario", tpUsuario.IdTipoUsuario));
                
                //Abre conexão
                con.Open();

                //Efetua leitura
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
        /// Método para inserção de tipos de usuário.
        /// </summary>
        /// <param name="tipoUsuario">Objeto Tipo usuário</param>
        public void InserirTipoUsuario(TipoUsuario tpUsuario)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["sigh"].ConnectionString);

            try
            {
                string sql = @" insert into tbltipousuario 
                                (
                                    id_tipo_usuario ,
                                    ds_tipo_usuario
                                )
                                values 
                                (
                                    0,
                                    ?dsTipoUsuario
                                 )
                                 ";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add(new MySqlParameter("?dsTipoUsuario", tpUsuario.DescricaoTipoUsuario));

                //Abre conexão
                con.Open();

                //Efetua leitura
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
        /// Método que efetua deleção de usuário no banco de dados.
        /// </summary>
        /// <param name="cpf">cpf do usuário</param>
        public void ExcluirUsuarioBycpf(string cpf)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["sigh"].ConnectionString);

            try
            {
                string sql = @" delete from tblusuario where cpf = ?cpf";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add(new MySqlParameter("?cpf", cpf));
                
                //Abre conexão
                con.Open();

                //Efetua leitura
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
        /// Método que retorna um usuário pelo seu cpf
        /// </summary>
        /// <returns>Objeto usuário</returns>
        public Usuario RetornaUsuarioBycpf(string cpf)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["sigh"].ConnectionString);

            try
            {
                string sql = @" select 
                                tblusuario.cpf, 
                                tblusuario.id_tipo_usuario, 
                                tblusuario.nome as 'nomeUsuario', 
                                tblusuario.telefone1, 
                                tblusuario.telefone2, 
                                tblusuario.email 'emailUsuario', 
                                tblusuario.is_ativo, 
                                tblusuario.login, 
                                tblusuario.senha, 
                                tblusuario.dt_ultimo_acesso, 
                                tblusuario.is_medico,
                                tbltipousuario.ds_tipo_usuario,
                                tblinstituicao.*
                                from tblusuario, tbltipousuario, tblinstituicao
                                where tblusuario.cpf = ?cpf
                                and tblusuario.id_instituicao = tblinstituicao.id_instituicao
				                and tblusuario.id_tipo_usuario = tbltipousuario.id_tipo_usuario";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add(new MySqlParameter("?cpf", cpf));

                //Abre conexão
                con.Open();

                //Efetua leitura
                MySqlDataReader rd = cmd.ExecuteReader();

                Usuario userObj = new Usuario();

                //Popula objeto retornado do banco de dados
                while (rd.Read())
                {
                    userObj.Cpf = rd["cpf"].ToString();
                    
                    //Iniciando tipo de usuario
                    userObj.Nome = rd["nomeUsuario"].ToString();
                    userObj.Telefone1 = rd["telefone1"].ToString();
                    userObj.Telefone2 = rd["telefone2"].ToString();
                    userObj.Email = rd["email"].ToString();
                    userObj.IsAtivo = bool.Parse(rd["is_ativo"].ToString());
                    userObj.Login = rd["login"].ToString();
                    userObj.Senha = rd["senha"].ToString();
                    userObj.DtUltimoAcesso = Convert.ToDateTime(rd["dt_ultimo_acesso"].ToString());
                    userObj.IsMedico = bool.Parse(rd["is_medico"].ToString());

                    //Inicializa o tipo de usuário
                    userObj.TipoUsuario = new TipoUsuario();
                    userObj.TipoUsuario.IdTipoUsuario = Convert.ToInt32(rd["id_tipo_usuario"].ToString());
                    userObj.TipoUsuario.DescricaoTipoUsuario = rd["ds_tipo_usuario"].ToString();

                    //Inicializa a instituição do mesmo
                    userObj.Instituicao = new InstituicaoEN();
                    userObj.Instituicao.IdInstituicao = Convert.ToInt32(rd["id_instituicao"].ToString());
                    userObj.Instituicao.Nome = rd["nome"].ToString();
                    userObj.Instituicao.Endereco = rd["endereco"].ToString();
                    userObj.Instituicao.Numero = Convert.ToInt32(rd["numero"].ToString());
                    userObj.Instituicao.Bairro = rd["bairro"].ToString();
                    userObj.Instituicao.Cidade = rd["cidade"].ToString();
                    userObj.Instituicao.Estado = rd["estado"].ToString();
                    userObj.Instituicao.Cep = rd["cep"].ToString();
                    userObj.Instituicao.DtRegistro = Convert.ToDateTime(rd["dt_registro"].ToString());
                    userObj.Instituicao.NomeResponsavel = rd["nome_responsavel"].ToString();
                    userObj.Instituicao.Funcao = rd["funcao"].ToString();
                    userObj.Instituicao.Email = rd["email"].ToString();
                    userObj.Instituicao.Telefone = rd["telefone"].ToString();
                    userObj.Instituicao.CnpjInstituicao = rd["cnpj_instituicao"].ToString();
                }

                //Retorna objeto
                return userObj;
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
        /// Método que retorna todos os usuários registrados no sistema.
        /// </summary>
        /// <returns>Dataset com resultados das querys.</returns>
        public DataSet RetornaUsuariosSistema()
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["sigh"].ConnectionString);

            try
            {
                string sql = @" select 
                                tblusuario.cpf, 
                                tblusuario.id_instituicao,
                                tblusuario.id_tipo_usuario, 
                                tblusuario.nome as 'nomeUsuario', 
                                tblusuario.telefone1, 
                                tblusuario.telefone2, 
                                tblusuario.email as 'emailUsuario', 
                                tblusuario.is_ativo, 
                                tblusuario.login, 
                                tblusuario.senha, 
                                tblusuario.dt_ultimo_acesso,
                                tblusuario.is_medico, 
                                tbltipousuario.ds_tipo_usuario,
                                tblinstituicao.*
                                from tblusuario, tbltipousuario, tblinstituicao
                                where tblusuario.id_tipo_usuario = tbltipousuario.id_tipo_usuario
                                and tblinstituicao.id_instituicao = tblusuario.id_instituicao";

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
        /// Método de login no sistema.
        /// </summary>
        /// <param name="login">Objeto de login.</param>
        /// <returns>Objeto Membro.</returns>
        public Usuario Efetuarlogin(string login, string pass)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["sigh"].ConnectionString);

            try
            {
//                string sql = @" select 
//                                tblusuario.cpf, 
//                                tblusuario.id_tipo_usuario, 
//                                tblusuario.nome as 'nomeUsuario', 
//                                tblusuario.telefone1, 
//                                tblusuario.telefone2, 
//                                tblusuario.email 'emailUsuario', 
//                                tblusuario.is_ativo, 
//                                tblusuario.login, 
//                                tblusuario.senha, 
//                                tblusuario.dt_ultimo_acesso, 
//                                tbltipousuario.ds_tipo_usuario,
//                                tblinstituicao.*
//                                from tblusuario, tbltipousuario, tblinstituicao
//                                where tblusuario.login = '" + login + @"'
//                                and tblusuario.senha = '" + pass + @"'
//                                and tblusuario.id_tipo_usuario = tbltipousuario.id_tipo_usuario
//                                and tblinstituicao.id_instituicao = tblusuario.id_instituicao";

                string sql = @" select 
                                tblusuario.cpf, 
                                tblusuario.id_tipo_usuario, 
                                tblusuario.nome as 'nomeUsuario', 
                                tblusuario.telefone1, 
                                tblusuario.telefone2, 
                                tblusuario.email 'emailUsuario', 
                                tblusuario.is_ativo, 
                                tblusuario.login, 
                                tblusuario.senha, 
                                tblusuario.dt_ultimo_acesso,
                                tblusuario.is_medico, 
                                tbltipousuario.ds_tipo_usuario,
                                tblinstituicao.*
                                from tblusuario, tbltipousuario, tblinstituicao
                                where tblusuario.login = ?login
                                and tblusuario.senha = ?pass
                                and tblusuario.id_tipo_usuario = tbltipousuario.id_tipo_usuario
                                and tblinstituicao.id_instituicao = tblusuario.id_instituicao";

                //Abre conexão
                con.Open();

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add(new MySqlParameter("?login", login));
                cmd.Parameters.Add(new MySqlParameter("?pass", pass));
                
                //Efetua leitura
                MySqlDataReader rd = cmd.ExecuteReader();

                Usuario userObj = null;

                while (rd.Read())
                {
                    //Inicializa usuário
                    userObj = new Usuario();
                    
                    userObj.Cpf = rd["cpf"].ToString();
                    userObj.Nome = rd["nomeUsuario"].ToString();
                    userObj.Telefone1 = rd["telefone1"].ToString();
                    userObj.Telefone2 = rd["telefone2"].ToString();
                    userObj.Email = rd["emailUsuario"].ToString();
                    userObj.IsAtivo = bool.Parse(rd["is_ativo"].ToString());
                    userObj.Login = rd["login"].ToString();
                    userObj.Senha = rd["senha"].ToString();
                    userObj.DtUltimoAcesso = Convert.ToDateTime(rd["dt_ultimo_acesso"].ToString());
                    userObj.IsMedico = bool.Parse(rd["is_medico"].ToString());
                    
                    //Inicializa o tipo de usuário
                    userObj.TipoUsuario = new TipoUsuario();
                    userObj.TipoUsuario.IdTipoUsuario = Convert.ToInt32(rd["id_tipo_usuario"].ToString());
                    userObj.TipoUsuario.DescricaoTipoUsuario = rd["ds_tipo_usuario"].ToString();
                    
                    //Inicializa a instituição do mesmo
                    userObj.Instituicao = new InstituicaoEN();
                    userObj.Instituicao.IdInstituicao = Convert.ToInt32(rd["id_instituicao"].ToString());
                    userObj.Instituicao.Nome = rd["nome"].ToString();
                    userObj.Instituicao.Endereco = rd["endereco"].ToString();
                    userObj.Instituicao.Numero = Convert.ToInt32(rd["numero"].ToString());
                    userObj.Instituicao.Bairro = rd["bairro"].ToString();
                    userObj.Instituicao.Cidade = rd["cidade"].ToString();
                    userObj.Instituicao.Estado = rd["estado"].ToString();
                    userObj.Instituicao.Cep = rd["cep"].ToString();
                    userObj.Instituicao.DtRegistro = Convert.ToDateTime(rd["dt_registro"].ToString());
                    userObj.Instituicao.NomeResponsavel = rd["nome_responsavel"].ToString();
                    userObj.Instituicao.Funcao = rd["funcao"].ToString();
                    userObj.Instituicao.Email = rd["email"].ToString();
                    userObj.Instituicao.Telefone = rd["telefone"].ToString();
                    userObj.Instituicao.CnpjInstituicao = rd["cnpj_instituicao"].ToString();
                }

                con.Close();

                con.Open();
                //Caso exista o objeto...ele altera o valor da última visita.
                if (userObj != null)
                {
                    //Verifica se o usuário está ativo.
                    if (userObj.IsAtivo)
                    {
                        string sqlInsertUltimaDataAcesso = @"update tblusuario set dt_ultimo_acesso = '" + DateTime.Now.ToString("yyyy:MM:dd HH:mm:ss") + "' where cpf = '" + userObj.Cpf + "'";

                        MySqlCommand cmdInsert = new MySqlCommand(sqlInsertUltimaDataAcesso, con);

                        //Atualiza valor de último acesso do usuário.
                        cmdInsert.ExecuteNonQuery();
                    }
                }

                //Retorna objeto de login.
                return userObj;
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
        /// Método que retorna um usuário através do seu login e cpf.
        /// </summary>
        /// <param name="login">login do usuário</param>
        /// <param name="cpf">cpf do usuário</param>
        /// <returns>booleano indicando a existência do mesmo ou não</returns>
        public Usuario RecuperaUsuarioByloginAndcpf(string login, string cpf)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["sigh"].ConnectionString);

            try
            {
                string sql = @" select 
                                tblusuario.cpf, 
                                tblusuario.id_tipo_usuario, 
                                tblusuario.nome as 'nomeUsuario', 
                                tblusuario.telefone1, 
                                tblusuario.telefone2, 
                                tblusuario.email as 'emailUsuario', 
                                tblusuario.is_ativo, 
                                tblusuario.login, 
                                tblusuario.senha, 
                                tblusuario.dt_ultimo_acesso,
                                tblusuario.is_medico, 
                                tbltipousuario.ds_tipo_usuario,
                                tblinstituicao.*
                                from tblusuario, tbltipousuario, tblinstituicao
                                where login = ?login and cpf = ?cpf";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add(new MySqlParameter("?login", login));
                cmd.Parameters.Add(new MySqlParameter("?cpf", cpf));
                
                //Abre conexão
                con.Open();

                //Efetua leitura
                MySqlDataReader rd = cmd.ExecuteReader();

                Usuario userObj = null;

                //Efetua leitura dos dados retornados do banco.
                while (rd.Read())
                {
                    //Inicializa o usuário
                    userObj = new Usuario();

                    userObj.Cpf = rd["cpf"].ToString();
                    userObj.Nome = rd["nomeUsuario"].ToString();
                    userObj.Telefone1 = rd["telefone1"].ToString();
                    userObj.Telefone2 = rd["telefone2"].ToString();
                    userObj.Email = rd["emailUsuario"].ToString();
                    userObj.IsAtivo = bool.Parse(rd["is_ativo"].ToString());
                    userObj.Login = rd["login"].ToString();
                    userObj.Senha = rd["senha"].ToString();
                    userObj.DtUltimoAcesso = Convert.ToDateTime(rd["dt_ultimo_acesso"].ToString());
                    userObj.IsMedico = bool.Parse(rd["is_medico"].ToString());
                    
                    //Inicializa o tipo de usuário
                    userObj.TipoUsuario = new TipoUsuario();
                    userObj.TipoUsuario.IdTipoUsuario = Convert.ToInt32(rd["id_tipo_usuario"].ToString());
                    userObj.TipoUsuario.DescricaoTipoUsuario = rd["ds_tipo_usuario"].ToString();

                    //Inicializa a instituição do mesmo
                    userObj.Instituicao = new InstituicaoEN();
                    userObj.Instituicao.IdInstituicao = Convert.ToInt32(rd["id_instituicao"].ToString());
                    userObj.Instituicao.Nome = rd["nome"].ToString();
                    userObj.Instituicao.Endereco = rd["endereco"].ToString();
                    userObj.Instituicao.Numero = Convert.ToInt32(rd["numero"].ToString());
                    userObj.Instituicao.Bairro = rd["bairro"].ToString();
                    userObj.Instituicao.Cidade = rd["cidade"].ToString();
                    userObj.Instituicao.Estado = rd["estado"].ToString();
                    userObj.Instituicao.Cep = rd["cep"].ToString();
                    userObj.Instituicao.DtRegistro = Convert.ToDateTime(rd["dt_registro"].ToString());
                    userObj.Instituicao.NomeResponsavel = rd["nome_responsavel"].ToString();
                    userObj.Instituicao.Funcao = rd["funcao"].ToString();
                    userObj.Instituicao.Email = rd["email"].ToString();
                    userObj.Instituicao.Telefone = rd["telefone"].ToString();
                    userObj.Instituicao.CnpjInstituicao = rd["cnpj_instituicao"].ToString();
                }

                return userObj;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// Método que altera um usuário
        /// </summary>
        /// <param name="user">Objeto usuário com os dados atualizados.</param>
        public void InserirUsuario(Usuario user)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["sigh"].ConnectionString);

            try
            {
                string sql = @" insert into tblusuario 
                                (
                                    cpf,
                                    id_tipo_usuario,
                                    id_instituicao,
                                    nome,
                                    telefone1,
                                    telefone2,
                                    email,
                                    is_ativo,
                                    login,
                                    senha,
                                    dt_ultimo_acesso,
                                    is_medico
                                )
                                values 
                                ( 
                                  ?cpf, 
                                  ?idTipoUsuario,
                                  ?idInstituicao,
                                  ?nome,
                                  ?telefone1,
                                  ?telefone2,
                                  ?email,
                                  ?isAtivo,
                                  ?login,
                                  ?senha,
                                  ?dt_ultimo_acesso,
                                  ?isMedico
                                )";
                                  
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add(new MySqlParameter("?cpf", user.Cpf));
                cmd.Parameters.Add(new MySqlParameter("?idTipoUsuario", user.TipoUsuario.IdTipoUsuario));
                cmd.Parameters.Add(new MySqlParameter("?idInstituicao", user.Instituicao.IdInstituicao));
                cmd.Parameters.Add(new MySqlParameter("?nome", user.Nome));
                cmd.Parameters.Add(new MySqlParameter("?telefone1", user.Telefone1));
                cmd.Parameters.Add(new MySqlParameter("?telefone2", user.Telefone2));
                cmd.Parameters.Add(new MySqlParameter("?email", user.Email));
                cmd.Parameters.Add(new MySqlParameter("?isAtivo", user.IsAtivo));
                cmd.Parameters.Add(new MySqlParameter("?login", user.Login));
                cmd.Parameters.Add(new MySqlParameter("?senha", user.Senha));
                cmd.Parameters.Add(new MySqlParameter("?dt_ultimo_acesso", DateTime.Now));
                cmd.Parameters.Add(new MySqlParameter("?isMedico", user.IsMedico));
                
                //Abre conexão com o banco de dados
                con.Open();

                //Executa a query de comando.
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                con.Close();
            }
        }



        /// <summary>
        /// Método que altera um usuário
        /// </summary>
        /// <param name="user">Objeto usuário com os dados atualizados.</param>
        public void AtualizarUsuario(Usuario user, string cpf, string login)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["sigh"].ConnectionString);

            try
            {
                string sql = @" update tblusuario set 
                                cpf = ?cpf,
                                id_tipo_usuario = ?idTipoUsuario,
                                id_instituicao = ?idInstituicao,
                                nome = ?nome,
                                telefone1 = ?telefone1,
                                telefone2 = ?telefone2,
                                email = ?email,
                                is_ativo = ?isAtivo,
                                login = ?login, 
                                senha = ?senha,
                                is_medico = ?isMedico                                
                                WHERE cpf = ?cpf
                                and login = ?login";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add(new MySqlParameter("?cpf", user.Cpf));
                cmd.Parameters.Add(new MySqlParameter("?idTipoUsuario", user.TipoUsuario.IdTipoUsuario));
                cmd.Parameters.Add(new MySqlParameter("?idInstituicao", user.Instituicao.IdInstituicao));
                cmd.Parameters.Add(new MySqlParameter("?nome", user.Nome));
                cmd.Parameters.Add(new MySqlParameter("?telefone1", user.Telefone1));
                cmd.Parameters.Add(new MySqlParameter("?telefone2", user.Telefone2));
                cmd.Parameters.Add(new MySqlParameter("?email", user.Email));
                cmd.Parameters.Add(new MySqlParameter("?isAtivo", user.IsAtivo));
                cmd.Parameters.Add(new MySqlParameter("?login", user.Login));
                cmd.Parameters.Add(new MySqlParameter("?senha", user.Senha));
                cmd.Parameters.Add(new MySqlParameter("?dt_ultimo_acesso", DateTime.Now));
                cmd.Parameters.Add(new MySqlParameter("?isMedico", user.IsMedico));
                
                //Abre conexão com o banco de dados
                con.Open();

                //Executa a query de comando.
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// Método que retorna todos os tipos de usuários.
        /// </summary>
        /// <returns></returns>
        public DataTable RetornaTodosTiposUsuarios()
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["sigh"].ConnectionString);

            try
            {
                string sql = @" select id_tipo_usuario, ds_tipo_usuario from tbltipousuario";

                DataTable dt = new DataTable();

                MySqlCommand cmd = new MySqlCommand(sql, con);

                con.Open();

                //Efetua leitura
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                
                adp.Fill(dt);
                
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// Método que retorna o grupo de usuário pelo seu nome
        /// </summary>
        /// <returns></returns>
        public TipoUsuario RetornaTipoUsuarioBynome(string nomeGrupo)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["sigh"].ConnectionString);

            try
            {
                string sql = @" select id_tipo_usuario, ds_tipo_usuario from tbltipousuario
                                where ds_tipo_usuario = ?nomeGrupo";

                DataTable dt = new DataTable();

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add(new MySqlParameter("?nomeGrupo", nomeGrupo));
                
                con.Open();

                MySqlDataReader dr = cmd.ExecuteReader();

                TipoUsuario tpUsuario = new TipoUsuario();

                while (dr.Read())
                {
                    tpUsuario.IdTipoUsuario = Convert.ToInt32(dr["id_tipo_usuario"].ToString());
                    tpUsuario.DescricaoTipoUsuario = dr["ds_tipo_usuario"].ToString();
                }
                
                return tpUsuario;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
