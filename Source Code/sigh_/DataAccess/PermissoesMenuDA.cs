using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using Entity;

namespace DataAccess
{
    public class PermissoesMenuDA
    {

        /// <summary>
        /// Método que atualiza o menu do sistema
        /// </summary>
        public void AtualizarMenuSistema(MenuEN menu)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["sigh"].ConnectionString);

            try
            {
                //Seleciona todos os menus pai do sistema
                string sql = @" 
                                update tblMenu
                                set
                                ds_nome_menu = @nomeMenu,
                                is_ativo = @isAtivo,
                                path = @path
                                where id_menu = @idMenu
                                and id_menu_pai = @idMenuPai
                                ";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add(new MySqlParameter("@nomeMenu",menu.NomeMenu));
                cmd.Parameters.Add(new MySqlParameter("@isAtivo", menu.IsAtivo));
                cmd.Parameters.Add(new MySqlParameter("@path", menu.Path));
                cmd.Parameters.Add(new MySqlParameter("@id_menu", menu.IdMenu));
                cmd.Parameters.Add(new MySqlParameter("@id_menu_pai", menu.IdMenuPai));

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
        /// Método que obtem os dados de permissão de níveis de um grupo de usuários
        /// </summary>
        public DataTable ObterMenuPaisPorGrupoUsuario(int idGrupoUsuario)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["sigh"].ConnectionString);

            try
            {
                //Seleciona todos os menus pai do sistema
                string sql = @" 
                                select  distinct tblmenu.id_menu, tblmenu.ds_nome_menu, tblmenu.id_menu_pai, tblmenu.path, tblmenu.id_ordem from tblmenu, tblniveispermissaomenu
                                where tblmenu.id_menu  in (
                                select distinct  tblmenu.id_menu_pai from tblmenu, tblniveispermissaomenu
                                where tblniveispermissaomenu.leitura = 1
                                and tblniveispermissaomenu.id_tipo_usuario = ?idTipoUsuario
                                and tblniveispermissaomenu.id_menu = tblmenu.id_menu
                                ) order by id_ordem";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add(new MySqlParameter("?idTipoUsuario", idGrupoUsuario));

                //Abre conexão
                con.Open();


                //Efetua leitura
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                //Retorna resultado
                return dt;
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
        /// Método que obtem os dados de permissão de níveis de um grupo de usuários
        /// </summary>
        public DataTable ObterPermissoesPorGrupoUsuario(int idGrupoUsuario)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["sigh"].ConnectionString);

            try
            {
                //Seleciona todos os menus pai do sistema
                string sql = @" 
                                select distinct tblmenu.ds_nome_menu from tblmenu, tblniveispermissaomenu
                                where tblniveispermissaomenu.leitura = 1
                                or tblmenu.id_menu_pai = 0
                                and tblniveispermissaomenu.id_tipo_usuario = " +idGrupoUsuario.ToString()+ @"
                                and tblniveispermissaomenu.id_menu = tblmenu.id_menu
                                ";

                MySqlCommand cmd = new MySqlCommand(sql, con);

                //Abre conexão
                con.Open();


                //Efetua leitura
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                //Retorna resultado
                return dt;
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
        /// Método que obtem os dados de permissão de níveis de um grupo de usuários
        /// </summary>
        public NiveisPermissao ObterPermissoesGrupoUsuarioByIdGrupoAndIdMenu(int idGrupoUsuario, int idMenu)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["sigh"].ConnectionString);

            try
            {
                //Seleciona todos os menus pai do sistema
                string sql = @" select tblniveispermissaomenu.id_niveis_permissao, tblmenu.id_menu as 'id_menu',tblmenu.ds_nome_menu as 'funcionalidade', tblniveispermissaomenu.leitura as 'situacao',
                                tblniveispermissaomenu.atualizacao as 'atualizacao', tblniveispermissaomenu.atualizacao as 'atualizacao' ,
                                tblniveispermissaomenu.remocao as 'remocao'
                                from tblmenu, tblniveispermissaomenu
                                where tblmenu.id_menu_pai <> 0
                                and tblmenu.id_menu = tblniveispermissaomenu.id_menu
                                and tblniveispermissaomenu.id_tipo_usuario = " +idGrupoUsuario.ToString()+ @"
                                and tblniveispermissaomenu.id_menu = " + idMenu.ToString();

                MySqlCommand cmd = new MySqlCommand(sql, con); ;

                //Abre conexão
                con.Open();

                //Efetua leitura
                MySqlDataReader rd = cmd.ExecuteReader();

                NiveisPermissao nPermissao = new NiveisPermissao();

                //Popula objeto retornado do banco de dados
                while (rd.Read())
                {
                    nPermissao.IdNivelPermissao = Convert.ToInt32(rd["id_niveis_permissao"].ToString());
                    nPermissao.IdMenu = Convert.ToInt32(rd["id_menu"].ToString());
                }

                //Retorna objeto
                return nPermissao;
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
        /// Método que obtem os dados de permissão de níveis de um grupo de usuários
        /// </summary>
        public void RemoverPermissaoVisualizacaoByIdGrupoUsuarioAndIdMenu(int idGrupoUsuario, int idMenu)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["sigh"].ConnectionString);

            try
            {
                //Seleciona todos os menus pai do sistema
                string sql = @" 
                                delete from tblniveispermissaomenu
                                where tblniveispermissaomenu.id_menu = " + idMenu.ToString() + @"
                                and tblniveispermissaomenu.id_tipo_usuario = " + idGrupoUsuario.ToString();

                MySqlCommand cmd = new MySqlCommand(sql, con); ;

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
        /// Método que obtem os dados de permissão de níveis de um grupo de usuários
        /// </summary>
        public DataTable ObterPermissoesGrupoUsuarioByPermissoesAtivas(int idGrupoUsuario)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["sigh"].ConnectionString);

            try
            {
                //Seleciona todos os menus pai do sistema
                string sql = @" select tblniveispermissaomenu.id_niveis_permissao, tblmenu.path, tblmenu.id_menu   as 'id_menu', tblmenu.id_menu_pai as 'id_menu_pai', tblmenu.ds_nome_menu as 'funcionalidade', tblniveispermissaomenu.leitura as 'situacao',
                                tblniveispermissaomenu.atualizacao as 'atualizacao', tblniveispermissaomenu.atualizacao as 'atualizacao' ,
                                tblniveispermissaomenu.remocao as 'remocao'
                                from tblmenu, tblniveispermissaomenu
                                where tblmenu.id_menu_pai <> 0
                                and tblmenu.id_menu = tblniveispermissaomenu.id_menu
                                and tblniveispermissaomenu.id_tipo_usuario = " + idGrupoUsuario.ToString() + @"
                                and tblniveispermissaomenu.leitura <> 0
                                ";

                MySqlCommand cmd = new MySqlCommand(sql, con); ;
                //Abre conexão
                con.Open();

                //Efetua leitura
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                //Retorna resultado
                return dt;
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
        /// Método que obtem os dados de permissão de níveis de um grupo de usuários
        /// </summary>
        public DataTable ObterPermissoesGrupoUsuario(int idGrupoUsuario)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["sigh"].ConnectionString);

            try
            {
                //Seleciona todos os menus pai do sistema
                string sql = @" select tblniveispermissaomenu.id_niveis_permissao, tblmenu.path, tblmenu.id_menu   as 'id_menu', tblmenu.id_menu_pai as 'id_menu_pai', tblmenu.ds_nome_menu as 'funcionalidade', tblniveispermissaomenu.leitura as 'situacao',
                                tblniveispermissaomenu.criacao as 'criacao', tblniveispermissaomenu.atualizacao as 'atualizacao' ,
                                tblniveispermissaomenu.remocao as 'remocao'
                                from tblmenu, tblniveispermissaomenu
                                where tblmenu.id_menu_pai <> 0
                                and tblmenu.id_menu = tblniveispermissaomenu.id_menu
                                and tblniveispermissaomenu.id_tipo_usuario = " + idGrupoUsuario.ToString();

                MySqlCommand cmd = new MySqlCommand(sql, con); ;

                //Abre conexão
                con.Open();

                //Efetua leitura
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                //Retorna resultado
                return dt;
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
        /// Método que insere menu no banco de dados
        /// <param name="menu">Objeto menu</param>
        /// </summary>
        public void InserirMenuSistema(MenuEN menu)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["sigh"].ConnectionString);

            try
            {
                //Seleciona todos os menus pai do sistema
                string sql = @" insert into tblmenu (id_menu, ds_nome_menu, is_ativo, id_menu_pai, path) 
                                values (0, '" + menu.NomeMenu + "', " + menu.IsAtivo.ToString() + ", " + menu.IdMenuPai.ToString() + ", '" + menu.Path  + "')";

                MySqlCommand cmd = new MySqlCommand(sql, con);

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
        /// Método que obtém os menus pai
        /// </summary>
        /// <returns>DataTable com alguns menus de status pai do sistema</returns>
        public DataTable ObterMenuSistema()
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["sigh"].ConnectionString);

            try
            {
                //Seleciona todos os menus pai do sistema
                string sql = @" select id_menu, ds_nome_menu, is_ativo, id_menu_pai, path from tblmenu";

                MySqlCommand cmd = new MySqlCommand(sql, con); ;

                //Abre conexão
                con.Open();

                //Efetua leitura
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                //Retorna resultado
                return dt;
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
        /// Método que obtém os menus pai
        /// </summary>
        /// <returns>DataTable com alguns menus de status pai do sistema</returns>
        public DataTable ObterMenusPaisSistema()
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["sigh"].ConnectionString);

            try
            {
                //Seleciona todos os menus pai do sistema
                string sql = @" select id_menu, ds_nome_menu, is_ativo, id_menu_pai, path from tblmenu where id_menu_pai = 0";

                MySqlCommand cmd = new MySqlCommand(sql, con);;

                //Abre conexão
                con.Open();

                //Efetua leitura
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                //Retorna resultado
                return dt;
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
        /// Método que obtém os menus pai
        /// </summary>
        /// <returns>DataTable com alguns menus de status pai do sistema</returns>
        public DataTable ObterSubMenusPaisSistema(int idMenuPai)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["sigh"].ConnectionString);

            try
            {
                //Seleciona todos os menus pai do sistema
                string sql = @" select id_menu, ds_nome_menu, is_ativo, id_menu_pai, path from tblmenu where id_menu_pai = " + idMenuPai.ToString();

                MySqlCommand cmd = new MySqlCommand(sql, con);

                //Abre conexão
                con.Open();

                //Efetua leitura
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                //Retorna resultado
                return dt;
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
        /// Método que obtém os menus pai
        /// </summary>
        /// <returns>DataTable com alguns menus de status pai do sistema</returns>
        public DataTable ObterSubMenusSistema()
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["sigh"].ConnectionString);

            try
            {
                //Seleciona todos os menus pai do sistema
                string sql = @" select id_menu, ds_nome_menu, is_ativo, id_menu_pai, path from tblmenu where id_menu_pai <> 0";

                MySqlCommand cmd = new MySqlCommand(sql, con);

                //Abre conexão
                con.Open();

                //Efetua leitura
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                //Retorna resultado
                return dt;
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
        /// Método que obtém os menus pai
        /// </summary>
        /// <returns>DataTable com alguns menus de status pai do sistema</returns>
        public void RemoverSubMenuSistema(int idMenu, int idMenuPai, bool isMenuPai)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["sigh"].ConnectionString);
            
            int erros = -1;
                            
            try
            {
                string sqlNiveisPermissao = string.Empty;

                if (isMenuPai)
                {
                    //deleta todos o niveis de permissao para este menu
                    sqlNiveisPermissao = @" delete from tblniveispermissaomenu
                                            where tblniveispermissaomenu.id_menu in 
                                            (
                                                select id_menu from tblmenu where id_menu_pai = " + idMenu.ToString() + @"
                                            )";
                }
                else
                {
                    //deleta todos o niveis de permissao para este menu
                    sqlNiveisPermissao = @"  delete from tblniveispermissaomenu
                                                where tblniveispermissaomenu.id_menu = " + idMenu.ToString();
                }

                MySqlCommand cmd = new MySqlCommand(sqlNiveisPermissao, con);
                
                //Abre conexão
                con.Open();
                
                erros = cmd.ExecuteNonQuery();

                if (erros > -1)
                {
                    //Fecha a conexão para abri-la novamente.
                    con.Close();

                    string sqlMenus = string.Empty;

                    //command de acesso o objeto de dados
                    MySqlCommand cmdMenu = new MySqlCommand();
                    
                    //deleta o menu
                    if (isMenuPai)
                    {
                        sqlMenus = @"delete from tblmenu where id_menu = ?idMenu or id_menu_pai = ?idMenuPai";
                        cmdMenu.Parameters.Add(new MySqlParameter("?idMenu", idMenu.ToString()));
                        cmdMenu.Parameters.Add(new MySqlParameter("?idMenuPai", idMenu.ToString()));
                    }
                    else
                    {
                        sqlMenus = @"delete from tblmenu where id_menu = ?idMenu and id_menu_pai = ?idMenuPai";
                        cmdMenu.Parameters.Add(new MySqlParameter("?idMenu", idMenu.ToString()));
                        cmdMenu.Parameters.Add(new MySqlParameter("?idMenuPai", idMenuPai.ToString()));
                    }

                    cmdMenu.Connection = con;
                    cmdMenu.CommandText = sqlMenus;
                    
                    //Abre conexão
                    con.Open();
                    
                    //executa query
                    cmdMenu.ExecuteNonQuery();
                }
                
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
        /// Método que obtem as permissões de menu de acordo com o tipo de usuário
        /// </summary>
        /// <param name="tipoUsuario">Parâmetro de definição do tipo de usuário</param>
        /// <returns>DataTable com os resultados</returns>
        public DataTable obterPermissoesMenu(string tipoUsuario)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["sigh"].ConnectionString);

            try
            {
                string sql = @" select tblniveispermissaomenu.ds_nivel, tblniveispermissaomenu.flag from tblniveispermissaomenu, tblTipoUsuario 
                                where tblTipoUsuario.id_tipo_usuario = tblniveispermissaomenu.id_tipo_usuario 
                                and tblTipoUsuario.ds_tipo_usuario = " + tipoUsuario ;

                MySqlCommand cmd = new MySqlCommand(sql, con);

                //Abre conexão
                con.Open();

                //Efetua leitura
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                //Retorna resultado
                return dt;
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
        /// Retorna todos os níveis de permissão por tipo de usuário
        /// </summary>
        /// <param name="idTipoUsuario">Identificador do tipo de usuário</param>
        /// <returns>Datatable contendo os niveis</returns>
        public DataTable RetornaNiveisPermissaoByTipoUsuario(int idTipoUsuario)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["sigh"].ConnectionString);

            try
            {
                string sql = @"select id_niveis_permissao, ds_nivel, flag from tblniveispermissaomenu where id_tipo_usuario = " + idTipoUsuario.ToString();

                MySqlCommand cmd = new MySqlCommand(sql, con);

                //Abre conexão
                con.Open();

                //Efetua leitura
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                //Retorna resultado
                return dt;
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
        /// Método de atualização do nível de informação do sistema
        /// </summary>
        /// <param name="idTipoUsuario">Identificador do tipo de usuário</param>
        /// <returns>Datatable contendo os niveis</returns>
        public void AtualizaNivelPermissao(NiveisPermissao nivel)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["sigh"].ConnectionString);

            try
            {
                string sql = @"
                                update tblniveispermissaomenu
                                set leitura = " + nivel.PermissaoLeitura.ToString() + @",
                                criacao = " + nivel.PermissaoCriacao.ToString() + @",
                                atualizacao = " + nivel.PermissaoAtualizacao.ToString() + @",
                                remocao = " + nivel.PermissaoRemocao + @"
                                where id_niveis_permissao = " + nivel.IdNivelPermissao.ToString();
                
                con.Open();

                MySqlCommand cmd = new MySqlCommand(sql, con);

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
        /// Retorna todos os níveis de permissão por tipo de usuário
        /// </summary>
        /// <param name="idTipoUsuario">Identificador do tipo de usuário</param>
        /// <returns>Datatable contendo os niveis</returns>
        public void InserirNivelPermissao(NiveisPermissao nivel)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["sigh"].ConnectionString);

            try
            {
                string sql = @" insert into tblniveispermissaomenu
                                (id_niveis_permissao, id_tipo_usuario, id_menu, leitura, criacao, atualizacao, remocao)
                                value (0, " + nivel.TipoUsuario.IdTipoUsuario.ToString() + ", " + nivel.IdMenu.ToString() + ", " + nivel.PermissaoLeitura.ToString() + ", " + nivel.PermissaoCriacao.ToString() + ", " + nivel.PermissaoAtualizacao.ToString() + ", " + nivel.PermissaoRemocao.ToString() + ")";

                MySqlCommand cmd = new MySqlCommand(sql, con);

                //Abre conexão
                con.Open();
                
                //Executa query
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
