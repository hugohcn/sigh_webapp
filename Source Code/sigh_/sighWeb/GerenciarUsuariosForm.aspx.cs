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

namespace sighWeb
{
    public partial class UsuariosForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gdvUsuarios_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            try
            {
                e.Cancel = true;

                string cpf = e.NewValues["cpf"].ToString();

                Usuario user = new Usuario();

                user.Cpf = cpf;
                user.Nome = e.NewValues["nomeUsuario"].ToString();
                user.Email = e.NewValues["emailUsuario"].ToString();

                if (e.NewValues["telefone1"] != null)
                {
                    if (e.NewValues["telefone1"].ToString().Equals("(  )     -    "))
                    {
                        user.Telefone1 = string.Empty;
                    }
                    else
                    {
                        user.Telefone1 = e.NewValues["telefone1"].ToString();
                    }
                }
                else
                {
                    user.Telefone1 = string.Empty;
                }

                if (e.NewValues["telefone2"] != null)
                    if (e.NewValues["telefone2"].ToString().Equals("(  )     -    "))
                    {
                        user.Telefone2 = string.Empty;
                    }
                    else
                    {
                        user.Telefone2 = e.NewValues["telefone2"].ToString();
                    }
                else
                {
                    user.Telefone2 = string.Empty;
                }

                user.Login = e.NewValues["login"].ToString();
                user.Senha = e.NewValues["senha"].ToString();
                user.DtUltimoAcesso = DateTime.Now;

                if (e.NewValues["is_ativo"] != null)
                {
                    user.IsAtivo = bool.Parse(e.NewValues["is_ativo"].ToString());
                }
                else
                {
                    user.IsAtivo = false;
                }

                if (e.NewValues["is_medico"] != null)
                {
                    user.IsMedico = bool.Parse(e.NewValues["is_medico"].ToString());
                }
                else
                {
                    user.IsMedico = false;
                }

                //inicializa instituição
                user.Instituicao = new InstituicaoEN();
                user.Instituicao.IdInstituicao = Convert.ToInt32(e.NewValues["id_instituicao"].ToString());

                //inicializa tipo de usuario
                user.TipoUsuario = new TipoUsuario();
                user.TipoUsuario.IdTipoUsuario = Convert.ToInt32(e.NewValues["id_tipo_usuario"].ToString());

                //Efetua atualização do usuário
                new UsuarioBU().AtualizarUsuario(user, user.Cpf, user.Login);

                //Fecha a janela de edição do grid
                this.gdvUsuarios.CancelEdit();
            }
            catch (Exception eX)
            {
                throw eX;
            }
        }

        protected void gdvUsuarios_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            try
            {
                e.Cancel = true;


                string cpf = e.NewValues["cpf"].ToString();

                Usuario user = new Usuario();

                user.Cpf = cpf;
                user.Nome = e.NewValues["nomeUsuario"].ToString();
                user.Email = e.NewValues["emailUsuario"].ToString();

                if (e.NewValues["telefone1"] != null)
                {
                    if (e.NewValues["telefone1"].ToString().Equals("(  )     -    "))
                    {
                        user.Telefone1 = string.Empty;
                    }
                    else
                    {
                        user.Telefone1 = e.NewValues["telefone1"].ToString();
                    }
                }
                else
                {
                    user.Telefone1 = string.Empty;
                }

                if (e.NewValues["telefone2"] != null)
                    if (e.NewValues["telefone2"].ToString().Equals("(  )     -    "))
                    {
                        user.Telefone2 = string.Empty;
                    }
                    else
                    {
                        user.Telefone2 = e.NewValues["telefone2"].ToString();
                    }
                else
                {
                    user.Telefone2 = string.Empty;
                }

                user.Login = e.NewValues["login"].ToString();
                user.Senha = e.NewValues["senha"].ToString();
                user.DtUltimoAcesso = DateTime.Now;

                if (e.NewValues["is_ativo"] != null)
                {
                    user.IsAtivo = bool.Parse(e.NewValues["is_ativo"].ToString());
                }
                else
                {
                    user.IsAtivo = false;
                }
                
                if(e.NewValues["is_medico"] != null)
                {
                    user.IsMedico = bool.Parse(e.NewValues["is_medico"].ToString());
                }
                else
                {
                    user.IsMedico = false;
                }

                //inicializa instituição
                user.Instituicao = new InstituicaoEN();
                user.Instituicao.IdInstituicao = Convert.ToInt32(e.NewValues["id_instituicao"].ToString());

                //inicializa tipo de usuario
                user.TipoUsuario = new TipoUsuario();
                user.TipoUsuario.IdTipoUsuario = Convert.ToInt32(e.NewValues["id_tipo_usuario"].ToString());

                //Efetua a inserção do usuário
                new UsuarioBU().InserirUsuario(user);

                //Fecha a janela de edição do grid
                this.gdvUsuarios.CancelEdit();
            }
            catch (Exception eX)
            {
                throw eX;
            }
        }

        protected void gdvUsuarios_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            try
            {
                e.Cancel = true;

                string cpf = e.Keys["cpf"].ToString();

                //Efetua a inserção do usuário
                new UsuarioBU().ExcluirUsuarioByCpf(cpf);
            }
            catch (Exception eX)
            {
                throw eX;
            }
        }

        protected void gdvUsuarios_HtmlDataCellPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableDataCellEventArgs e)
        {

            if (e.DataColumn.FieldName == "is_medico")
            {
                if (bool.Parse(e.CellValue.ToString()))
                {
                    Label lbl = (Label)this.gdvUsuarios.FindRowCellTemplateControl(e.VisibleIndex, (DevExpress.Web.ASPxGridView.GridViewDataColumn)gdvUsuarios.Columns["is_medico"], "lblIsmedico");

                    if (lbl != null)
                    {
                        lbl.Text = "Sim";
                    }
                }
                else
                {
                    Label lbl = (Label)this.gdvUsuarios.FindRowCellTemplateControl(e.VisibleIndex, (DevExpress.Web.ASPxGridView.GridViewDataColumn)gdvUsuarios.Columns["is_medico"], "lblIsmedico");

                    if (lbl != null)
                    {
                        lbl.Text = "Não";
                    }
                }
            }

            if (e.DataColumn.Caption == "Situação")
            {
                if (bool.Parse(e.CellValue.ToString()))
                {
                    Image img = (Image)this.gdvUsuarios.FindRowCellTemplateControl(e.VisibleIndex, (DevExpress.Web.ASPxGridView.GridViewDataColumn)gdvUsuarios.Columns["Situacao"], "imgStatus");

                    if (img != null)
                    {
                        //Usuário Ativo
                        img.AlternateText = "Usuário ativo";
                        img.Attributes["title"] = "Usuário ativo";
                        img.ImageUrl = "images/ativo.png";
                    }
                }
                else
                {
                    Image img = (Image)this.gdvUsuarios.FindRowCellTemplateControl(e.VisibleIndex, (DevExpress.Web.ASPxGridView.GridViewDataColumn)gdvUsuarios.Columns["Situacao"], "imgStatus");

                    if (img != null)
                    {
                        //Usuário Desativado
                        img.AlternateText = "Usuário desativado";
                        img.Attributes["title"] = "Usuário desativado";
                        img.ImageUrl = "images/desativado.png";
                    }
                }
            }
        }
    }
}
