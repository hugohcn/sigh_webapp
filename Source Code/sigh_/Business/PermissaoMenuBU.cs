using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using System.Data;
using Entity;

namespace Business
{
    public class PermissaoMenuBU
    {
        /// <summary>
        /// Método que atualiza o menu do sistema
        /// </summary>
        public void AtualizarMenuSistema(MenuEN menu)
        {
            try
            {
                new PermissoesMenuDA().AtualizarMenuSistema(menu);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        /// <summary>
        /// Método que obtém os menus pai
        /// </summary>
        /// <returns>DataTable com alguns menus de status pai do sistema</returns>
        public void RemoverSubMenuSistema(int idMenu, int idMenuPai, bool isMenuPai)
        {
            try
            {
                new PermissoesMenuDA().RemoverSubMenuSistema(idMenu, idMenuPai, isMenuPai);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    
        /// <summary>
        /// Método que obtem os dados de permissão de níveis de um grupo de usuários
        /// </summary>
        public DataTable ObterMenuPaisPorGrupoUsuario(int idGrupoUsuario)
        {
            try
            {
                return new PermissoesMenuDA().ObterMenuPaisPorGrupoUsuario(idGrupoUsuario);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    
        /// <summary>
        /// Método que obtem os dados de permissão de níveis de um grupo de usuários
        /// </summary>
        public DataTable ObterPermissoesPorGrupoUsuario(int idGrupoUsuario)
        {
            try
            {
                return new PermissoesMenuDA().ObterPermissoesGrupoUsuario(idGrupoUsuario);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    
        /// <summary>
        /// Retorna todos os níveis de permissão por tipo de usuário
        /// </summary>
        /// <param name="idTipoUsuario">Identificador do tipo de usuário</param>
        /// <returns>Datatable contendo os niveis</returns>
        public void InserirNivelPermissao(NiveisPermissao nivel)
        {
            try
            {
                new PermissoesMenuDA().InserirNivelPermissao(nivel);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    
        /// <summary>
        /// Método de atualização do nível de informação do sistema
        /// </summary>
        /// <param name="idTipoUsuario">Identificador do tipo de usuário</param>
        /// <returns>Datatable contendo os niveis</returns>
        public void AtualizaNivelPermissao(NiveisPermissao nivel)
        {
            try
            {
                new PermissoesMenuDA().AtualizaNivelPermissao(nivel);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        /// <summary>
        /// Método que obtem os dados de permissão de níveis de um grupo de usuários
        /// </summary>
        public void RemoverPermissaoVisualizacaoByIdGrupoUsuarioAndIdMenu(int idGrupoUsuario, int idMenu)
        {
            try
            {
                new PermissoesMenuDA().RemoverPermissaoVisualizacaoByIdGrupoUsuarioAndIdMenu(idGrupoUsuario, idMenu);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    
        /// <summary>
        /// Método que obtem os dados de permissão de níveis de um grupo de usuários
        /// </summary>
        public NiveisPermissao ObterPermissoesGrupoUsuarioByIdGrupoAndIdMenu(int idGrupoUsuario, int idMenu)
        {
            try
            {
                return new PermissoesMenuDA().ObterPermissoesGrupoUsuarioByIdGrupoAndIdMenu(idGrupoUsuario, idMenu);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        /// <summary>
        /// Método que obtem os dados de permissão de níveis de um grupo de usuários
        /// </summary>
        public DataTable ObterPermissoesGrupoUsuarioByPermissoesAtivas(int idGrupoUsuario)
        {
            try
            {
                return new PermissoesMenuDA().ObterPermissoesGrupoUsuarioByPermissoesAtivas(idGrupoUsuario);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        /// <summary>
        /// Método que obtem os dados de permissão de níveis de um grupo de usuários
        /// </summary>
        public DataTable ObterPermissoesGrupoUsuario(int idGrupoUsuario)
        {
            try
            {
                return new PermissoesMenuDA().ObterPermissoesGrupoUsuario(idGrupoUsuario);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    
        /// <summary>
        /// Método que obtém os menus pai
        /// </summary>
        /// <returns>DataTable com alguns menus de status pai do sistema</returns>
        public DataTable ObterSubMenusSistema()
        {
            try
            {
                return new PermissoesMenuDA().ObterSubMenusSistema();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    
        /// <summary>
        /// Método que insere menu no banco de dados
        /// <param name="menu">Objeto menu</param>
        /// </summary>
        public void InserirMenuSistema(MenuEN menu)
        {
            try
            {
                new PermissoesMenuDA().InserirMenuSistema(menu);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    
        /// <summary>
        /// Método que obtém os menus pai
        /// </summary>
        /// <returns>DataTable com alguns menus de status pai do sistema</returns>
        public DataTable ObterMenusPaisSistema()
        {
            try
            {
                return new PermissoesMenuDA().ObterMenusPaisSistema();
            }
            catch (Exception eX)
            {
                throw eX;
            }
        }
        
         /// <summary>
        /// Método que obtém os menus pai
        /// </summary>
        /// <returns>DataTable com alguns menus de status pai do sistema</returns>
        public DataTable ObterSubMenusPaisSistema(int idMenuPai)
        {
            try
            {
                return new PermissoesMenuDA().ObterSubMenusPaisSistema(idMenuPai);
            }
            catch (Exception eX)
            {
                throw eX;
            } 
        }
        
        /// <summary>
        /// Método que obtem as permissões de menu de acordo com o tipo de usuário
        /// </summary>
        /// <param name="tipoUsuario">Parâmetro de definição do tipo de usuário</param>
        /// <returns>DataTable com os resultados</returns>
        public DataTable obterPermissoesMenu(string tipoUsuario)
        {
            try
            {
                //chamada ao evento de acesso aos dados
                return new PermissoesMenuDA().obterPermissoesMenu(tipoUsuario);
            }
            catch (Exception e)
            {
                
                throw e;
            } 
        }
        
        /// <summary>
        /// Método que obtém os menus pai
        /// </summary>
        /// <returns>DataTable com alguns menus de status pai do sistema</returns>
        public DataTable ObterMenuSistema()
        {
            try
            {
                //chamada ao evento de acesso aos dados
                return new PermissoesMenuDA().ObterMenuSistema();
            }
            catch (Exception e)
            {

                throw e;
            } 
        }
    }
}
