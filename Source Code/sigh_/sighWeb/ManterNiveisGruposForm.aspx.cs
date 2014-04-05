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
using Business;
using Entity;
using DevExpress.Web.ASPxGridView;
using sighWeb.Base;

namespace sighWeb
{
    public partial class ManterNiveisGruposForm : SecurityLayerPage
    {
        public override void Page_Init(object sender, EventArgs e)
        {
            base.Page_Init(sender, e);
        }
        
        public override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
        }

        protected void gdvNiveis_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            try
            {
                e.Cancel = true;

                NiveisPermissao nPermissao = new NiveisPermissao();
                
                nPermissao.IdNivelPermissao = Convert.ToInt32(e.Keys["id_niveis_permissao"].ToString());
                nPermissao.IdMenu = Convert.ToInt32(e.OldValues["id_menu"].ToString());
                nPermissao.TipoUsuario = new TipoUsuario();
                nPermissao.TipoUsuario.IdTipoUsuario =  Convert.ToInt32(Request.QueryString["idGrupoUsuario"].ToString());

                //Verifica se o combo de Atualização está marcado
                if (e.NewValues["atualizacao"].ToString().Equals("1"))
                {
                    nPermissao.PermissaoAtualizacao = 1;
                }
                else
                {
                    nPermissao.PermissaoAtualizacao = 0;
                }

                //Verifica se o combo de Criação está marcado
                if (e.NewValues["criacao"].ToString().Equals("1"))
                {

                    nPermissao.PermissaoCriacao = 1;
                }
                else
                {
                    nPermissao.PermissaoCriacao = 0;
                }

                //Verifica se o combo de Remoção está marcado
                if (e.NewValues["remocao"].ToString().Equals("1"))
                {

                    nPermissao.PermissaoRemocao = 1;
                }
                else
                {
                    nPermissao.PermissaoRemocao = 0;
                }

                //Verifica se o combo de Visualização está marcado
                if (e.NewValues["situacao"].ToString().Equals("1"))
                {
                    nPermissao.PermissaoLeitura = 1;
                }
                else
                {
                    nPermissao.PermissaoLeitura = 0;
                }

                //Efetua atualização
                new PermissaoMenuBU().AtualizaNivelPermissao(nPermissao);
                
                ((ASPxGridView)sender).CancelEdit();
                
                ((ASPxGridView)sender).DataBind();
                
            }
            catch (Exception eX)
            {
                throw eX;
            }
        }

        protected void gdvNiveis_HtmlDataCellPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableDataCellEventArgs e)
        {
            if (e.DataColumn.Caption == "Situação")
            {
                if (e.CellValue.ToString().Equals("1"))
                {
                    Image img = (Image)this.gdvNiveis.FindRowCellTemplateControl(e.VisibleIndex, (DevExpress.Web.ASPxGridView.GridViewDataColumn)gdvNiveis.Columns["Situacao"], "imgStatus");

                    if (img != null)
                    {
                        //Usuário Ativo
                        img.AlternateText = "Ativo";
                        img.Attributes["title"] = "Ativo";
                        img.ImageUrl = "images/ativo.png";
                    }
                }
                else
                {
                    Image img = (Image)this.gdvNiveis.FindRowCellTemplateControl(e.VisibleIndex, (DevExpress.Web.ASPxGridView.GridViewDataColumn)gdvNiveis.Columns["Situacao"], "imgStatus");

                    if (img != null)
                    {
                        //Usuário Desativado
                        img.AlternateText = "Desativado";
                        img.Attributes["title"] = "Desativado";
                        img.ImageUrl = "images/desativado.png";
                    }
                }
            }
            else if (e.DataColumn.Caption == "Permissão de Criação")
            {
                if (e.CellValue.ToString().Equals("1"))
                {
                    Image img = (Image)this.gdvNiveis.FindRowCellTemplateControl(e.VisibleIndex, (DevExpress.Web.ASPxGridView.GridViewDataColumn)gdvNiveis.Columns["Situacao"], "imgCriacao");

                    if (img != null)
                    {
                        //Usuário Ativo
                        img.AlternateText = "Ativo";
                        img.Attributes["title"] = "Ativo";
                        img.ImageUrl = "images/ativo.png";
                    }
                }
                else
                {
                    Image img = (Image)this.gdvNiveis.FindRowCellTemplateControl(e.VisibleIndex, (DevExpress.Web.ASPxGridView.GridViewDataColumn)gdvNiveis.Columns["Situacao"], "imgCriacao");

                    if (img != null)
                    {
                        //Usuário Desativado
                        img.AlternateText = "Desativado";
                        img.Attributes["title"] = "Desativado";
                        img.ImageUrl = "images/desativado.png";
                    }
                }
            }
            else if (e.DataColumn.Caption == "Permissão de Atualização")
            {
                if (e.CellValue.ToString().Equals("1"))
                {
                    Image img = (Image)this.gdvNiveis.FindRowCellTemplateControl(e.VisibleIndex, (DevExpress.Web.ASPxGridView.GridViewDataColumn)gdvNiveis.Columns["Situacao"], "imgAtualizacao");

                    if (img != null)
                    {
                        //Usuário Ativo
                        img.AlternateText = "Ativo";
                        img.Attributes["title"] = "Ativo";
                        img.ImageUrl = "images/ativo.png";
                    }
                }
                else
                {
                    Image img = (Image)this.gdvNiveis.FindRowCellTemplateControl(e.VisibleIndex, (DevExpress.Web.ASPxGridView.GridViewDataColumn)gdvNiveis.Columns["Situacao"], "imgAtualizacao");

                    if (img != null)
                    {
                        //Usuário Desativado
                        img.AlternateText = "Desativado";
                        img.Attributes["title"] = "Desativado";
                        img.ImageUrl = "images/desativado.png";
                    }
                }
            }
            else if (e.DataColumn.Caption == "Permissão de Remoção")
            {
                if (e.CellValue.ToString().Equals("1"))
                {
                    Image img = (Image)this.gdvNiveis.FindRowCellTemplateControl(e.VisibleIndex, (DevExpress.Web.ASPxGridView.GridViewDataColumn)gdvNiveis.Columns["Situacao"], "imgRemocao");

                    if (img != null)
                    {
                        //Usuário Ativo
                        img.AlternateText = "Ativo";
                        img.Attributes["title"] = "Ativo";
                        img.ImageUrl = "images/ativo.png";
                    }
                }
                else
                {
                    Image img = (Image)this.gdvNiveis.FindRowCellTemplateControl(e.VisibleIndex, (DevExpress.Web.ASPxGridView.GridViewDataColumn)gdvNiveis.Columns["Situacao"], "imgRemocao");

                    if (img != null)
                    {
                        //Usuário Desativado
                        img.AlternateText = "Desativado";
                        img.Attributes["title"] = "Desativado";
                        img.ImageUrl = "images/desativado.png";
                    }
                }
            }
        }

        protected void gdvNiveis_CustomCallback(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewCustomCallbackEventArgs e)
        {
            //Inseri os dados de níveis de visualização.
            NiveisPermissao nPermissao = new NiveisPermissao();
            
            nPermissao.TipoUsuario = new TipoUsuario();
            
            nPermissao.TipoUsuario.IdTipoUsuario = Convert.ToInt32(Request.QueryString["idGrupoUsuario"].ToString());
            nPermissao.IdMenu = Convert.ToInt32(cmbFuncionalidade.SelectedItem.Value);
            nPermissao.IdNivelPermissao = 0;
            
            //Verifica se o combo de Atualização está marcado
            if (chkPermissaoAtualizacao.Checked)
            {
                nPermissao.PermissaoAtualizacao = 1;
            }
            else
            {
                nPermissao.PermissaoAtualizacao = 0;                                                        
            }

            //Verifica se o combo de Criação está marcado
            if (chkPermissaoCriacao.Checked)
            {
                
                nPermissao.PermissaoCriacao = 1;
            }
            else
            {
                nPermissao.PermissaoCriacao = 0;
            }

            //Verifica se o combo de Remoção está marcado
            if (chkPermissaoRemocao.Checked)
            {
                
                nPermissao.PermissaoRemocao = 1;
            }
            else
            {
                nPermissao.PermissaoRemocao = 0;
            }

            //Verifica se o combo de Visualização está marcado
            if (chkPermissaoVisualizacao.Checked)
            { 
                nPermissao.PermissaoLeitura = 1;
            }
            else
            {
                nPermissao.PermissaoLeitura = 0;
            }
           
            //Verifica a existência deste nível para inserção
            NiveisPermissao nPermissaoVerify = new PermissaoMenuBU().ObterPermissoesGrupoUsuarioByIdGrupoAndIdMenu(nPermissao.TipoUsuario.IdTipoUsuario, nPermissao.IdMenu);

            if (!nPermissao.IdMenu.Equals(nPermissaoVerify.IdMenu))
            {
                //Faz a inserção dos dados no banco
                new PermissaoMenuBU().InserirNivelPermissao(nPermissao);
                
                ((ASPxGridView)sender).DataBind();
            }
            else
            {
                throw new Exception("Duplicate");
            }
        }

        protected void gdvNiveis_CustomErrorText(object sender, ASPxGridViewCustomErrorTextEventArgs e)
        {
            if (e.Exception.Message.Contains("Duplicate"))
            {
                e.ErrorText = "Esta funcionalidade já foi configurada para este grupo.";
            }
        }

        protected void gdvNiveis_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            try
            {
                e.Cancel = true;
                
                //Efetua exclusao do objeto
                new PermissaoMenuBU().RemoverPermissaoVisualizacaoByIdGrupoUsuarioAndIdMenu(Convert.ToInt32(Request.QueryString["idGrupoUsuario"].ToString()), Convert.ToInt32(e.Values["id_menu"].ToString()));
            }
            catch (Exception eX)
            {
                throw eX;
            }
        }
    }
}
