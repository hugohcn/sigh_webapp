using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Entity;
using Business;
using System.Collections.Generic;
using sighWeb.Base;

namespace sighWeb
{
    public partial class Principal : SecurityLayer
    {
        Usuario user;
        DataTable dtMenuItenRoot;
        DataView dvMenuItenRoot;

        DataTable dtMenuItensSon;
        DataView dvMenuItensSon;

        public override void Page_Init(object sender, EventArgs e)
        {
            base.Page_Init(sender, e);

            //recupera o usuário da sessão
            user = (Usuario)Session["usuarioLogado"];

            if (user != null)
            {
                //inicializa os elementos
                dtMenuItenRoot = new PermissaoMenuBU().ObterMenuPaisPorGrupoUsuario(user.TipoUsuario.IdTipoUsuario);
                dvMenuItenRoot = dtMenuItenRoot.DefaultView;

                dtMenuItensSon = new PermissaoMenuBU().ObterPermissoesGrupoUsuarioByPermissoesAtivas(user.TipoUsuario.IdTipoUsuario);
                dvMenuItensSon = dtMenuItensSon.DefaultView;

                Session["funcionalidades"] = dtMenuItensSon;
            }
            else
            {
                //Destroi todos os tickets existentes
                FormsAuthentication.SignOut();

                //Limpa as sessões existentes
                Session.Clear();
                
                //Redireciona para a página principal
                //FormsAuthentication.RedirectToLoginPage();
                Server.Transfer("principal.aspx", false);
            }
        }

        public override void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                base.Page_Load(sender, e);

                //verifica a existência do mesmo
                if (user != null)
                {
                    lblUserInfo.InnerText = user.Nome + " | " + DateTime.Now.ToLongDateString();

                    Session["FuncionalidadesPermitidas"] = dtMenuItensSon;

                    // Build Menu Items
                    Dictionary<string, DevExpress.Web.ASPxMenu.MenuItem> menuItems =
                        new Dictionary<string, DevExpress.Web.ASPxMenu.MenuItem>();

                    for (int i = 0; i < dvMenuItenRoot.Count; i++)
                    {
                        DataRow row = dvMenuItenRoot[i].Row;

                        DevExpress.Web.ASPxMenu.MenuItem item = CreateMenuItem(row, true);
                        string itemID = row["id_menu"].ToString();
                        string parentID = row["id_menu_pai"].ToString();

                        //Adiciona o menu principal (ROOT)
                        if (menuItems.ContainsKey(parentID))
                            menuItems[parentID].Items.Add(item);
                        else
                        {
                            if (parentID == "0") // It's Root Item
                                menuSistema.Items.Add(item);
                        }

                        menuItems.Add(itemID, item);

                        //Filter para pegar apenas os filhos do menu pai
                        //dvMenuItensSon.RowFilter = "id_menu_pai = " + itemID;
                        //dvMenuItensSon.RowStateFilter = DataViewRowState.ModifiedCurrent;

                        for (int j = 0; j < dvMenuItensSon.Count; j++)
                        {
                            if (dvMenuItensSon[j].Row["id_menu_pai"].ToString().Equals(itemID))
                            {
                                DataRow rowSon = dvMenuItensSon[j].Row;

                                DevExpress.Web.ASPxMenu.MenuItem itemSon = CreateMenuItem(rowSon, false);
                                string itemIDSon = rowSon["id_menu"].ToString();
                                string parentIDSon = rowSon["id_menu_pai"].ToString();

                                //Adiciona os menus itens do pai
                                if (menuItems.ContainsKey(parentIDSon))
                                    menuItems[parentIDSon].Items.Add(itemSon);
                                else
                                {
                                    if (parentIDSon == "0") // It's Root Item
                                        menuSistema.Items.Add(itemSon);
                                }
                                menuItems.Add(itemIDSon, itemSon);
                            }
                        }
                    }

                    //Cria o menu o item de menu SAIR
                    DevExpress.Web.ASPxMenu.MenuItem btnSair = new DevExpress.Web.ASPxMenu.MenuItem();
                    btnSair.Text = "Sair";
                    btnSair.Name = "btnSair";

                    //Adiciona botao ao menu
                    menuSistema.Items.Add(btnSair);
                }
                else
                {
                    //Destroi todos os tickets existentes
                    FormsAuthentication.SignOut();

                    //Limpa as sessões existentes
                    Session.Clear();

                    //Redireciona para a página principal
                    FormsAuthentication.RedirectToLoginPage();
                }
            }
        }

        private DevExpress.Web.ASPxMenu.MenuItem CreateMenuItem(DataRow row, bool menuPai)
        {
            if (menuPai)
            {
                DevExpress.Web.ASPxMenu.MenuItem ret = new DevExpress.Web.ASPxMenu.MenuItem();
                ret.Text = row["ds_nome_menu"].ToString();
                ret.NavigateUrl = row["path"].ToString();
                return ret;
            }
            else
            {
                DevExpress.Web.ASPxMenu.MenuItem ret = new DevExpress.Web.ASPxMenu.MenuItem();
                ret.Text = row["funcionalidade"].ToString();
                ret.NavigateUrl = row["path"].ToString();
                return ret;
            }
        }

        protected void menuSistema_ItemClick(object source, DevExpress.Web.ASPxMenu.MenuItemEventArgs e)
        {
            try
            {
                if (e.Item.Name.Equals("btnSair"))
                {
                    //Destroi todos os tickets existentes
                    FormsAuthentication.SignOut();

                    //Limpa as sessões existentes
                    Session.Clear();

                    //Redireciona para a página principal
                    FormsAuthentication.RedirectToLoginPage();
                }
            }
            catch (Exception eX)
            {
                throw eX;
            }
        }
    }
}
