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

namespace sighWeb
{
    public partial class VisualizarEscalasMedicos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["exame"] != null && Request.QueryString["tipoExame"] != null)
            {
                lblTitulo.InnerHtml = "Exame: " + Request.QueryString["exame"] + "<br/>Tipo de Exame: " + Request.QueryString["tipoExame"];
            }
        }
    }
}
