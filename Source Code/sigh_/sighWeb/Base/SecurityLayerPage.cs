using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Entity;

namespace sighWeb.Base
{
    public class SecurityLayerPage : System.Web.UI.Page
    {
        public virtual void Page_Init(object sender, EventArgs e)
        {
            //revisa as sessões existentes
            if (Session.Count == 0)
            {
                //Destroi todos os tickets existentes
                FormsAuthentication.SignOut();

                //Limpa as sessões existentes
                Session.Clear();

                //Redireciona para a página principal
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        public virtual void Page_Load(object sender, EventArgs e)
        {
            //Executado em requisições normais (posts) de uma página (primeira requisição)
            if (!IsPostBack)
            {
                if (Session["usuarioLogado"] != null)
                {
                    //Recupera o usuario
                    Usuario user = (Usuario)Session["usuarioLogado"];

                    //Verifica se o mesmo é administrador
                    if (user.TipoUsuario.DescricaoTipoUsuario != "Administrador")
                    {
                        string path = string.Empty;
                        
                        if (Session["funcionalidades"] != null)
                        {
                            DataTable menus = (DataTable)Session["funcionalidades"];

                            int flag = 0;

                            if (!Request.Url.ToString().Contains("Default.aspx"))
                            {
                                foreach (DataRow x in menus.Rows)
                                {
                                    //Verifica a existência desta página como funcionalidade
                                    path = x["path"].ToString();
                                    path = path.Substring(2, path.Length - 2);

                                    int permissao = Convert.ToInt32(x["situacao"].ToString());


                                    if (Request.Url.ToString().Contains(path) && permissao != 0)
                                    {
                                        flag++;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                //Anula o redirecionamento
                                flag = 1;
                            }

                            if (flag == 0)
                            {
                                if (Request.Url.ToString().Contains("reports"))
                                {
                                    Server.Transfer("../AcessoNegado.htm");
                                }
                                else
                                {
                                    Server.Transfer("~/AcessoNegado.htm");
                                }
                            }
                        }
                    }
                }
            }
        } 
    }
}
