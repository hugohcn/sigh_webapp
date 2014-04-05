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

namespace sighWeb
{
    public partial class ContatoAdministradorForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["nome"] != null)
            {
                //Desabilita o box de nome
                txtNome.Text = Request.QueryString["nome"].ToString();
                txtNome.Enabled = false;
            }

            if (Request.QueryString["email"] != null)
            {
                //Desabilita o box de nome
                txtEmail.Text = Request.QueryString["email"].ToString();
                txtEmail.Enabled = false;
            }
            
            if (Request.QueryString["telefone"] != null)
            {
                //Desabilita o box de nome
                txtTelefone.Text = Request.QueryString["telefone"].ToString();
            }

            if (Request.QueryString["celular"] != null)
            {
                //Desabilita o box de nome
                txtCelular.Text = Request.QueryString["celular"].ToString();
            }
        }

        protected void cbSaveData_Callback(object source, DevExpress.Web.ASPxCallback.CallbackEventArgs e)
        {
            try
            {
                //Efetuar contato administrativo
                new UsuarioBU().EfetuarContatoAdministrativo(txtNome.Text, txtEmail.Text, cmbTipoContato.SelectedItem.Text, txtTelefone.Text, txtCelular.Text, txtMensagem.Text);
            }
            catch (Exception eX)
            {
                throw eX;
            }
        }
    }
}
