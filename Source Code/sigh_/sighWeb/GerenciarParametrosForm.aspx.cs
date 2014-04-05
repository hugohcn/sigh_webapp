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
    public partial class GerenciarParametrosForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gdvParametros_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            try
            {
                e.Cancel = true;

                ParametersEN parameter = new ParametersEN();

                parameter.Id = 0;
                parameter.Key = e.NewValues["key_parametro"].ToString();
                parameter.Value = e.NewValues["value_parametro"].ToString();

                new ParametersBU().InserirParametro(parameter);

                this.gdvParametros.CancelEdit();
            }
            catch (Exception eX)
            {
                throw eX;
            }
        }

        protected void gdvParametros_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            try
            {
                e.Cancel = true;

                ParametersEN parameter = new ParametersEN();

                parameter.Id = Convert.ToInt32(e.Keys["id_parametro"].ToString());
                parameter.Key = e.NewValues["key_parametro"].ToString();
                parameter.Value = e.NewValues["value_parametro"].ToString();

                new ParametersBU().AtualizarParametro(parameter);

                this.gdvParametros.CancelEdit();
            }
            catch (Exception eX)
            {
                throw eX;
            }
        }

        protected void gdvParametros_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            try
            {
                e.Cancel = true;
                                                    
                new ParametersBU().DeletarParametro(Convert.ToInt32(e.Keys["id_parametro"].ToString()));
            }
            catch (Exception eX)
            {
                throw eX;
            }
        }
    }
}
