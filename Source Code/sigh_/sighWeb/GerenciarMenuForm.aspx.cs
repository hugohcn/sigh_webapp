using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using Entity;
using Business;
using DevExpress.Web.ASPxGridView;

namespace sighWeb
{
    public partial class GerenciarMenuForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gdvMenuSistema_HtmlDataCellPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableDataCellEventArgs e)
        {
            if (e.DataColumn.Caption == "Situação")
            {
                if (bool.Parse(e.CellValue.ToString()))
                {
                    Image img = (Image)this.gdvMenuSistema.FindRowCellTemplateControl(e.VisibleIndex, (DevExpress.Web.ASPxGridView.GridViewDataColumn)gdvMenuSistema.Columns["Situacao"], "imgStatus");

                    if (img != null)
                    {
                        //Usuário Ativo
                        img.AlternateText = "Menu ativo";
                        img.Attributes["title"] = "Menu ativo";
                        img.ImageUrl = "images/ativo.png";
                    }
                }
                else
                {
                    Image img = (Image)this.gdvMenuSistema.FindRowCellTemplateControl(e.VisibleIndex, (DevExpress.Web.ASPxGridView.GridViewDataColumn)gdvMenuSistema.Columns["Situacao"], "imgStatus");

                    if (img != null)
                    {
                        //Usuário Desativado
                        img.AlternateText = "Menu desativado";
                        img.Attributes["title"] = "Menu desativado";
                        img.ImageUrl = "images/desativado.png";
                    }
                }
            }
        }

        protected void gdvMenuSistema_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            try
            {
                //Cancela o insert normal padrão do grid.
                e.Cancel = true;

                MenuEN menu = new MenuEN();

                //Monta objeto com estrutura de menu pai
                menu.IdMenu = 0;
                menu.IdMenuPai = 0;
                menu.NomeMenu = e.NewValues["ds_nome_menu"].ToString();
                menu.IsAtivo = bool.Parse(e.NewValues["is_ativo"].ToString());

                //Correção para não gerar excessão com valor nulo
                if (e.NewValues["path"] != null)
                {
                    menu.Path = e.NewValues["path"].ToString();
                }
                else
                {
                    menu.Path = string.Empty;
                }


                //Insere menu no sistema
                new PermissaoMenuBU().InserirMenuSistema(menu);

                //Cancela a edição para atualização
                (sender as ASPxGridView).CancelEdit();
            }
            catch (Exception eX)
            {
                throw eX;
            }
        }

        protected void gdvSubMenuSistema_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            try
            {
                //Cancela o insert normal padrão do grid.
                e.Cancel = true;

                MenuEN menu = new MenuEN();

                //Monta objeto com estrutura de menu pai
                menu.IdMenu = 0;
                menu.IdMenuPai = Convert.ToInt32((sender as ASPxGridView).GetMasterRowKeyValue());
                menu.NomeMenu = e.NewValues["ds_nome_menu"].ToString();
                menu.IsAtivo = bool.Parse(e.NewValues["is_ativo"].ToString());

                //Correção para não gerar excessão com valor nulo
                if (e.NewValues["path"] != null)
                {
                    menu.Path = e.NewValues["path"].ToString();
                }
                else
                {
                    menu.Path = string.Empty;
                }


                //Insere menu no sistema
                new PermissaoMenuBU().InserirMenuSistema(menu);

                //Cancela a edição para atualização
                (sender as ASPxGridView).CancelEdit();
            }
            catch (Exception eX)
            {
                throw eX;
            }
        }

        protected void gdvSubMenuSistema_BeforePerformDataSelect(object sender, EventArgs e)
        {
            Session["CategoryID"] = (sender as ASPxGridView).GetMasterRowKeyValue();
        }

        protected void gdvSubMenuSistema_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            try
            {
                //Cancela o insert normal padrão do grid.
                e.Cancel = true;

                //Insere menu no sistema
                new PermissaoMenuBU().RemoverSubMenuSistema(Convert.ToInt32(e.Keys["id_menu"].ToString()), Convert.ToInt32((sender as ASPxGridView).GetMasterRowKeyValue()), false);

                //Cancela a edição para atualização
                (sender as ASPxGridView).CancelEdit();
                (sender as ASPxGridView).DataBind();
            }
            catch (Exception eX)
            {
                throw eX;
            }
        }

        protected void gdvMenuSistema_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            try
            {
                //Cancela o insert normal padrão do grid.
                e.Cancel = true;

                //Insere menu no sistema
                new PermissaoMenuBU().RemoverSubMenuSistema(Convert.ToInt32(e.Keys["id_menu"].ToString()), 0, true);

                //Cancela a edição para atualização
                (sender as ASPxGridView).CancelEdit();
                (sender as ASPxGridView).DataBind();
            }
            catch (Exception eX)
            {
                throw eX;
            }
        }

        protected void gdvMenuSistema_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            try
            {
                //Cancela o insert normal padrão do grid.
                e.Cancel = true;

                MenuEN menu = new MenuEN();

                //Monta objeto com estrutura de menu pai
                menu.IdMenu = 0;
                menu.IdMenuPai = 0;
                menu.NomeMenu = e.NewValues["ds_nome_menu"].ToString();
                menu.IsAtivo = bool.Parse(e.NewValues["is_ativo"].ToString());

                //Correção para não gerar excessão com valor nulo
                if (e.NewValues["path"] != null)
                {
                    menu.Path = e.NewValues["path"].ToString();
                }
                else
                {
                    menu.Path = string.Empty;
                }


                //Insere menu no sistema
                new PermissaoMenuBU().InserirMenuSistema(menu);

                //Cancela a edição para atualização
                (sender as ASPxGridView).CancelEdit();
            }
            catch (Exception eX)
            {
                throw eX;
            }
        }

        protected void gdvSubMenuSistema_HtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e)
        {
            if (e.DataColumn.Caption == "Situação")
            {
                ASPxGridView gdv = (ASPxGridView)sender;
                
                if (bool.Parse(e.CellValue.ToString()))
                {
                    Image img = (Image)gdv.FindRowCellTemplateControl(e.VisibleIndex, (DevExpress.Web.ASPxGridView.GridViewDataColumn)gdv.Columns["Situacao"], "imgSubMenuStatus");

                    if (img != null)
                    {
                        //Usuário Ativo
                        img.AlternateText = "Menu ativo";
                        img.Attributes["title"] = "Menu ativo";
                        img.ImageUrl = "images/ativo.png";
                    }
                }
                else
                {
                    Image img = (Image)gdv.FindRowCellTemplateControl(e.VisibleIndex, (DevExpress.Web.ASPxGridView.GridViewDataColumn)gdv.Columns["Situacao"], "imgSubMenuStatus");

                    if (img != null)
                    {
                        //Usuário Desativado
                        img.AlternateText = "Menu desativado";
                        img.Attributes["title"] = "Menu desativado";
                        img.ImageUrl = "images/desativado.png";
                    }
                }
            }
        }

        protected void gdvSubMenuSistema_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            try
            {
                //Cancela o insert normal padrão do grid.
                e.Cancel = true;

                MenuEN menu = new MenuEN();

                menu.IdMenu = Convert.ToInt32(e.Keys["id_menu"].ToString());
                menu.IdMenuPai = Convert.ToInt32(Session["CategoryID"].ToString());
                menu.NomeMenu = e.NewValues["ds_nome_menu"].ToString();


                //Tratamento do checkbox
                if (e.NewValues["is_ativo"] != null)
                {
                    menu.IsAtivo = bool.Parse(e.NewValues["is_ativo"].ToString());
                }
                else
                {
                    menu.IsAtivo = false;
                }

                //Correção para não gerar excessão com valor nulo
                if (e.NewValues["path"] != null)
                {
                    menu.Path = e.NewValues["path"].ToString();
                }
                else
                {
                    menu.Path = string.Empty;
                }


                //Insere menu no sistema
                new PermissaoMenuBU().AtualizarMenuSistema(menu);

                //Cancela a edição para atualização
                (sender as ASPxGridView).CancelEdit();
            }
            catch (Exception eX)
            {
                throw eX;
            }
        }
    }
}
