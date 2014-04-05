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
using Common;

namespace sighWeb
{
    public partial class ManterPerfilForm : System.Web.UI.Page
    {
        public Usuario user;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string cpf = Request.QueryString["idUsuario"].ToString();

                    //Verificação da querystring obtida
                    if (!string.IsNullOrEmpty(cpf))
                    {
                        //desencripta a query string
                        cpf = new SecurityCommon().DesencriptarObjeto(cpf);

                        //Recupera o usuário passado pela querystring            
                        user = new UsuarioBU().RetornaUsuarioByCpf(cpf);

                        if (user != null)
                        {
                            txtCpf.Text = user.Cpf;
                            txtTipoUsuario.Text = user.TipoUsuario.DescricaoTipoUsuario;
                            txtNome.Text = user.Nome;
                            txtEmail.Text = user.Email;
                            txtTelefone.Text = user.Telefone1;
                            txtCelular.Text = user.Telefone2;
                            txtInstituicao.Text = user.Instituicao.Nome;
                            txtNome.Focus();
                            txtLogin.Text = user.Login;
                            txtSenha.Text = user.Senha;
                        }
                    }

                }
                catch (Exception eX)
                {
                    throw eX;
                }
            }
        }

        protected void cbSave_Callback(object source, DevExpress.Web.ASPxCallback.CallbackEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtEmail.Text) && !string.IsNullOrEmpty(txtNome.Text))
                {
                    Usuario user = new Usuario();

                    string cpf = Request.QueryString["idUsuario"].ToString();

                    //desencripta a query string
                    cpf = new SecurityCommon().DesencriptarObjeto(cpf);

                    //Recupera o usuário passado pela querystring            
                    user = new UsuarioBU().RetornaUsuarioByCpf(cpf);
                    if (user != null)
                    {
                        user.Nome = txtNome.Text;
                        user.Email = txtEmail.Text;

                        if (txtTelefone.Text.Equals("(  )     -    ") && string.IsNullOrEmpty(user.Telefone1))
                        {
                            user.Telefone1 = string.Empty;
                        }
                        else
                        {
                            user.Telefone1 = txtTelefone.Text;
                        }


                        if (txtCelular.Text.Equals("(  )     -    ") && string.IsNullOrEmpty(user.Telefone2))
                        {
                            user.Telefone2 = string.Empty;
                        }
                        else
                        {
                            user.Telefone2 = txtCelular.Text;
                        }

                        user.Senha = txtSenha.Text;

                        new UsuarioBU().AtualizarUsuario(user, user.Cpf, user.Login);
                    }
                }
            }
            catch (Exception eX)
            {
                throw eX;
            }
        }
    }
}
