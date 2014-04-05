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
using CalendarEntity;
using Business;
using DevExpress.Web.ASPxEditors;
using Entity;
using sighWeb.Base;

namespace sighWeb
{
    public partial class ManterConsultaAgenda : System.Web.UI.Page
    {
        public DataTable dtConsulta = new DataTable();
        Usuario user;
        string cpf = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            user = (Usuario)Session["usuarioLogado"];

            if (!IsPostBack)
            {
                //Verifica se é uma edição de dados
                if (Request.QueryString["exists"] != null && Request.QueryString["exists"] != string.Empty)
                {
                    //Seta o título da página
                    this.Page.Title = "Sistema Integrado de Gerenciamento Hospitalar | Editar Consulta";

                    //Desabilita a busca de pacientes
                    lblPaciente.ClientVisible = true;
                    lblTelefone.ClientVisible = true;
                    hlInserirPaciente.ClientVisible = false;

                    if (Request.QueryString["dtConsulta"] != null && Request.QueryString["idMedico"] != null)
                    {
                        //Busca os dados do agendamento no banco
                        dtConsulta = new AgendaBU().RetornaConsultaByDiaByMedicoByHoraAgendada(Convert.ToDateTime(Request.QueryString["dtConsulta"].ToString()), Convert.ToInt32(Request.QueryString["idMedico"].ToString()), Request.QueryString["hora"].ToString());

                        if (dtConsulta.Rows.Count > 0)
                        {
                            hfIdMedico.Value = Request.QueryString["idMedico"].ToString();
                            lblDataConsulta.Text = Request.QueryString["dtConsulta"].ToString();
                            lblHora.Text = "Hora da Consulta: " + Request.QueryString["hora"].ToString();
                            lblPacienteNome.Text = dtConsulta.Rows[0]["nome"].ToString();
                            lblTelefonePaciente.Text = dtConsulta.Rows[0]["telefone"].ToString();

                            if (cmbSituacao.SelectedItem != null)
                                cmbSituacao.SelectedItem.Value = dtConsulta.Rows[0]["ds_situacao"].ToString();
                            else
                                cmbSituacao.Text = dtConsulta.Rows[0]["ds_situacao"].ToString();
                            txtObservacao.Text = dtConsulta.Rows[0]["observacao"].ToString();
                            txtValor.Text = dtConsulta.Rows[0]["valor"].ToString();
                            idPaciente.Value = dtConsulta.Rows[0]["CD_PACIENTE"].ToString();
                        }
                    }
                }
                else
                {
                    //Seta o título da página
                    this.Page.Title = "Sistema Integrado de Gerenciamento Hospitalar | Nova Consulta";

                    //Desabilita a busca de pacientes
                    //hlAdicionarPaciente.Visible = true;

                    //Populando os dados
                    lblHora.Text = "Hora da Consulta: " + Request.QueryString["hora"].ToString();
                    hfIdMedico.Value = Request.QueryString["idMedico"].ToString();
                    lblDataConsulta.Text = Request.QueryString["dtConsulta"].ToString();

                    //Por padrão habilita o combo de situação no item selecionado como marcado
                    cmbSituacao.Text = "Marcado";
                }
            }
        }

        protected void cbpBuscaPaciente_Callback(object sender, DevExpress.Web.ASPxClasses.CallbackEventArgsBase e)
        {

        }

        protected void cbSalvarConsulta_Callback(object source, DevExpress.Web.ASPxCallback.CallbackEventArgs e)
        {
            //objeto de consulta
            Agenda agenda = new Agenda();

            //Inseri ou Atualiza uma consulta
            if (Request.QueryString["exists"] != null)
            {
                //É uma atualização
                //tratamento realizado no hora
                string hora = Request.QueryString["hora"].ToString().Replace(":", "");

                //tratamento da data de consulta
                DateTime dtConsulta = Convert.ToDateTime(Request.QueryString["dtConsulta"].ToString());

                string dia = string.Empty, mes = string.Empty, ano = string.Empty;
                dia = dtConsulta.Day.ToString();
                mes = dtConsulta.Month.ToString();
                ano = dtConsulta.Year.ToString();

                //começo da população de dados
                agenda.CodigoMedicor = Convert.ToInt32(Request.QueryString["idMedico"].ToString());
                agenda.DataAgenda = Convert.ToInt32(ano + mes + dia);
                agenda.HoraAgenda = Convert.ToInt32(hora);
                agenda.CodigoServico = Convert.ToInt32(Request.QueryString["idServico"].ToString());
                agenda.CodigoPaciente = Convert.ToInt32(idPaciente.Value);
                agenda.CodigoCategoria = Convert.ToInt32(Request.QueryString["idCategoria"].ToString());
                agenda.CodigoConvenio = Convert.ToInt32(Request.QueryString["idConvenio"].ToString());

                if (!string.IsNullOrEmpty(txtObservacao.Text))
                {
                    //efetua o tratamento com a frase escrita no memo de observação
                    string obs = txtObservacao.Text;
                    obs = obs.Replace("'", "");
                    obs = obs.Replace("´", "");
                    obs = obs.Replace("`", "");
                    obs = obs.Replace("~", "");
                    obs = obs.Replace("¨", "");

                    agenda.Observacao = obs;
                }
                else
                    agenda.Observacao = string.Empty;

                //tratamento em cima da situação da agenda
                agenda.Situacao = RetornaSituacaoConsulta(this.cmbSituacao);

                if (!string.IsNullOrEmpty(txtValor.Text))
                    agenda.ValorServico = double.Parse(txtValor.Text);
                else
                    agenda.ValorServico = 0;

                agenda.LogRevisao = 0;
                agenda.DescricaoUsuario = lblPacienteNome.Text;
                agenda.LogPeqProcedencia = 0;
                agenda.LogChamou = 1;
                agenda.DataChamou = DateTime.Now;
                agenda.NmAndar = 1;
                agenda.LogPrimeiraVez = 0;
                agenda.LogExcluido = 0;
                agenda.DescricaoMotivo = string.Empty;
                agenda.CodigoCid = 0;
                agenda.LogEncaixe = 0;
                agenda.LogMarcacaoWeb = 1;
                agenda.CodigoInstituicao = user.Instituicao.IdInstituicao;

                new AgendaBU().AtualizarConsultaByDiaByMedicoByHoraAgendada(Convert.ToDateTime(Request.QueryString["dtConsulta"].ToString()), agenda, hora);
            }
            else
            {
                //É uma inserção
                //tratamento realizado no hora
                string hora = Request.QueryString["hora"].ToString().Replace(":", "");

                //tratamento da data de consulta
                DateTime dtConsulta = Convert.ToDateTime(Request.QueryString["dtConsulta"].ToString());

                string dia = string.Empty, mes = string.Empty, ano = string.Empty;
                dia = dtConsulta.Day.ToString();
                mes = dtConsulta.Month.ToString();
                ano = dtConsulta.Year.ToString();

                //começo da população de dados
                agenda.CodigoMedicor = Convert.ToInt32(Request.QueryString["idMedico"].ToString());
                agenda.DataAgenda = Convert.ToInt32(ano + mes + dia);
                agenda.HoraAgenda = Convert.ToInt32(hora);
                agenda.CodigoServico = Convert.ToInt32(Request.QueryString["idServico"].ToString());
                agenda.CodigoPaciente = Convert.ToInt32(idPaciente.Value);
                agenda.CodigoCategoria = Convert.ToInt32(Request.QueryString["idCategoria"].ToString());
                agenda.CodigoConvenio = Convert.ToInt32(Request.QueryString["idConvenio"].ToString());

                if (!string.IsNullOrEmpty(txtObservacao.Text))
                {
                    //efetua o tratamento com a frase escrita no memo de observação
                    string obs = txtObservacao.Text;
                    obs = obs.Replace("'", "");
                    obs = obs.Replace("´", "");
                    obs = obs.Replace("`", "");
                    obs = obs.Replace("~", "");
                    obs = obs.Replace("¨", "");

                    agenda.Observacao = obs;
                }
                else
                    agenda.Observacao = string.Empty;

                //tratamento em cima da situação da agenda
                agenda.Situacao = RetornaSituacaoConsulta(this.cmbSituacao);

                if (!string.IsNullOrEmpty(txtValor.Text))
                    agenda.ValorServico = double.Parse(txtValor.Text);
                else
                    agenda.ValorServico = 0;

                agenda.LogRevisao = 0;
                agenda.DescricaoUsuario = lblPacienteNome.Text;
                agenda.LogPeqProcedencia = 0;
                agenda.LogChamou = 1;
                agenda.DataChamou = DateTime.Now;
                agenda.NmAndar = 1;
                agenda.LogPrimeiraVez = 0;
                agenda.LogExcluido = 0;
                agenda.DescricaoMotivo = string.Empty;
                agenda.CodigoCid = 0;
                agenda.LogEncaixe = 0;
                agenda.LogMarcacaoWeb = 1;
                agenda.CodigoInstituicao = user.Instituicao.IdInstituicao;

                new AgendaBU().InserirConsultaByDiaByMedicoByHoraAgendada(Convert.ToDateTime(Request.QueryString["dtConsulta"].ToString()), agenda, hora);
            }
        }

        private string RetornaSituacaoConsulta(ASPxComboBox combo)
        {
            string situacao = combo.SelectedItem.Value.ToString();

            switch (situacao)
            {
                case "0":
                    return "Marcado";
                    break;

                case "1":
                    return "Esperando";
                    break;

                case "2":
                    return "Exame";
                    break;

                case "3":
                    return "Atendido";
                    break;

                case "4":
                    return "Faltou";
                    break;

                case "5":
                    return "Cancelado";
                    break;

                case "6":
                    return "Encaixe";
                    break;

                case "7":
                    return "Confirmado";
                    break;

                case "8":
                    return "Transferido";
                    break;

                case "9":
                    return "Bloqueado";
                    break;

                default:
                    return "Marcado";
                    break;
            }
        }

        protected void gdvResultadoPesquisa_CustomCallback(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewCustomCallbackEventArgs e)
        {
            string[] vet = e.Parameters.Split('#');

            string cpf = vet[0];
            string nome = vet[1];


            DataTable dt = new PacienteBU().RetornaPacienteByCpfDataTable(cpf, nome);
            gdvResultadoPesquisa.DataSource = dt;
            gdvResultadoPesquisa.KeyFieldName = "ds_cpf";
            gdvResultadoPesquisa.DataBind();

            if (dt.Rows.Count > 0)
            {
                //efetua adição do value do codigo do paciente
                idPaciente.Value = dt.Rows[0]["cd_paciente"].ToString();
            }
            else
            {
                gdvResultadoPesquisa.AddNewRow();
            }

        }

        protected void gdvResultadoPesquisa_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            //Efetua inserção de paciente.
            e.Cancel = true;

            Paciente nPaciente = new Paciente();

            nPaciente.DescricaoNome = e.NewValues["ds_nome"].ToString();
            nPaciente.Email = e.NewValues["ds_email"].ToString();
            nPaciente.Telefone1 = e.NewValues["ds_telefone1"].ToString();
            nPaciente.Cpf = e.NewValues["ds_cpf"].ToString();
            nPaciente.DataInclusao = DateTime.Now;

            new PacienteBU().InserirPacienteAgendamentoBasico(nPaciente);

            this.gdvResultadoPesquisa.CancelEdit();
        }
    }
}
