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
using sighWeb.Base;
using Entity;
using Business;

namespace sighWeb.reports
{
    public partial class RelatorioTrabalhoMedicoForm : SecurityLayerPage
    {
        Usuario user;

        public override void Page_Init(object sender, EventArgs e)
        {
            base.Page_Init(sender, e);
        }
        public override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);

            //Recupera usuário e valida se  o mesmo é médico e pode ver esta página
            user = Session["usuarioLogado"] as Usuario;

            if (user != null)
            {
                if (user.TipoUsuario.DescricaoTipoUsuario.Equals("Administrador"))
                {      
                    //Habilita o usuário para ver o combobox.
                    cmbMedicos.Visible = true;
                    lblMedico.Visible = true;

                    //Efetua o bind no ComboBox
                    DataTable dtMedicos = new MedicorBU().RetornaMedicos();
                    cmbMedicos.DataSource = dtMedicos;
                    cmbMedicos.ValueField = "CD_MEDICOR";
                    cmbMedicos.TextField = "DS_NOME";

                    //Bind do combo de médicos
                    cmbMedicos.DataBind();
                }
                else
                {
                    tdMedicos1.Visible = false;
                    tdMedicos2.Visible = false;
                }

                //Valida o usuário
                if (user.TipoUsuario.DescricaoTipoUsuario != "Administrador" && !user.IsMedico)
                {
                    Response.Redirect("../AcessoNegado.htm", true);
                }
            }
            else
            {
                //Desloga e manda para a página de login
                this.DeslogaUsuario();
            }

        }

        private void DeslogaUsuario()
        {
            //Destroi todos os tickets existentes
            FormsAuthentication.SignOut();

            //Limpa as sessões existentes
            Session.Clear();

            //Redireciona para a página principal
            FormsAuthentication.RedirectToLoginPage();
        }

        protected void btnGerarRelatório_Click(object sender, EventArgs e)
        {
            int cdMedico = -1;

            if (user.IsMedico)
            {
                cdMedico = new MedicorBU().RetornaMedicoByCpf(user.Cpf);
            }
            else if (user.TipoUsuario.DescricaoTipoUsuario.Equals("Administrador"))
            {
                cdMedico = Convert.ToInt32(cmbMedicos.SelectedItem.Value);
            }

            if (!cdMedico.Equals(-1))
            {
                odsTrabalhoMedico.SelectParameters[0].DefaultValue = dteDataInicio.Date.ToString();
                odsTrabalhoMedico.SelectParameters[1].DefaultValue = dteDataFim.Date.ToString();
                odsTrabalhoMedico.SelectParameters[2].DefaultValue = cdMedico.ToString();

                this.gdvResultado.DataBind();

                btnExportarXls.ClientVisible = true;
                btnExportarPDF.ClientVisible = true;
            }
        }

        protected void btnExportarXls_Click(object sender, EventArgs e)
        {
            this.gdvResultadoExporter.WriteXlsToResponse(true);
        }

        protected void btnExportarPDF_Click(object sender, EventArgs e)
        {
            this.gdvResultadoExporter.WritePdfToResponse(true);
        }
    }
}
