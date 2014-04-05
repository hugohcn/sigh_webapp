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
using Common;

namespace sighWeb
{
    public partial class Default : System.Web.UI.Page
    {
        public Usuario user;
        public SecurityCommon security = new SecurityCommon();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //Recupera o usuário
             user = (Usuario)Session["usuarioLogado"];

            if (user != null)
            {
                //Carrega os dados do usuário
                lblUsuario.InnerHtml = user.Nome;
                lblLogin.InnerHtml = user.Login;
                lblUltimoAcesso.InnerHtml = user.DtUltimoAcesso.ToString();
                lblTipoUsuario.InnerHtml = user.TipoUsuario.DescricaoTipoUsuario;
            }
        }
    }
}
