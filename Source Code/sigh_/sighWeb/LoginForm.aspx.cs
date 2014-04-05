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

namespace sighWeb
{
    public partial class LoginForm : System.Web.UI.Page
    {
        //Cria contador de acesso.
        int contAcesso = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            txtLogin.Focus();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                //Busca o usuário no banco de dados
                Usuario user = new UsuarioBU().EfetuarLogin(txtLogin.Text, txtSenha.Text);

                if (user != null)
                {
                    //Verifica se o usuário está ativo para login
                    if (user.IsAtivo)
                    {
                        /*Cria registro do relatorio de acesso*/
                        Session.Add("usuarioLogado", user);

                        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(user.Login, true, 10);

                        Response.Cookies["sighSecurity"].Value = System.Web.Security.FormsAuthentication.Encrypt(ticket);
                        Response.Cookies["sighSecurity"].Expires = DateTime.Now.AddMinutes(10);
                        FormsAuthentication.RedirectFromLoginPage(user.Login, false);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "xInativo", "alert('Atenção: Este usuário está inativo. Entre em contato com o administrador do sistema!');txtLogin.SetText(''); txtSenha.SetText('');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "x", "alert('Erro: Usuário e/ou Senha incorreto(s).'); txtLogin.SetText(''); txtSenha.SetText('');", true);
                }

            }
            catch (Exception eX)
            {

                throw eX;
            }
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                int flag = new UsuarioBU().RecuperarSenhaLogin(txtNome_Recuperar_Senha.Text, txtCpf.Text);
                if (flag.Equals(1))
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alertRecuperacaoSenha", "alert('Atenção: Sua senha foi recuperada com sucesso! Verifique seu e-mail!'); txtNome_Recuperar_Senha.SetText(''); txtEmail.SetText(''); txtCpf.SetText('');", true);
                }
                else if(flag.Equals(-1))
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alertRecuperacaoSenhaNegada", "alert('Atenção: Este usuário está inativo. Contate o administrador do sistema!'); txtNome_Recuperar_Senha.SetText(''); txtEmail.SetText(''); txtCpf.SetText('');", true);
                }
            }
            catch (Exception eX)
            {
                throw eX;
            }
        }
    }
}
