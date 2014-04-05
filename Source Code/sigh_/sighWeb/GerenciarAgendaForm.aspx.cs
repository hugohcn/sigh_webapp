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
using Business;
using CalendarEntity;
using System.Collections.Generic;
using System.Globalization;
using DevExpress.Web.ASPxEditors;
using Entity;
using System.Drawing;

namespace sighWeb
{
    public partial class GerenciarAgendaForm : System.Web.UI.Page
    {
        //substring iniciando em 2 por conta da #
        DateTime dtAgenda;
        DataTable dtConsultasMedico;
        DataTable dtDiasSemanaByServico = new DataTable();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        Usuario user;

        protected void Page_Load(object sender, EventArgs e)
        {
            user = (Usuario)Session["usuarioLogado"];

            if (user == null)
            {
                //Destroi todos os tickets existentes
                FormsAuthentication.SignOut();

                //Limpa as sessões existentes
                Session.Clear();

                //Redireciona para a página principal
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void cbpGridAgenda_Callback(object sender, DevExpress.Web.ASPxClasses.CallbackEventArgsBase e)
        {
            try
            {
                //recupera identificador do médico
                int idMedico = Convert.ToInt32(e.Parameter.Substring(0, e.Parameter.IndexOf("#")).ToString());

                dtAgenda = Convert.ToDateTime(e.Parameter.Substring(e.Parameter.IndexOf("#") + 1));

                //Verifica a existência do id do médico
                if (!idMedico.Equals(0))
                {
                    //Busca as possíveis Jornadas do médico dentro de uma escala
                    Escala escala = new MedicorBU().RetornaEscalaMedico(idMedico, dtAgenda);

                    //significa que a escala não existe para o dia selecionado
                    if (escala.CodigoEscala == 0)
                    {
                        gdvAgenda.SettingsText.EmptyDataRow = "Não existe escala neste dia para o médico selecionado. Confira as escalas disponíveis antes de selecionar uma data.";
                    }

                    //Cria dataset para armazenar os dados
                    ds = new DataSet();
                    dt = new DataTable();

                    dt.Columns.Add("Hora", typeof(string));
                    dt.Columns.Add("Nome", typeof(string));
                    dt.Columns.Add("Telefone", typeof(string));
                    dt.Columns.Add("Convenio", typeof(string));
                    dt.Columns.Add("Servico", typeof(string));
                    dt.Columns.Add("Observacao", typeof(string));
                    dt.Columns.Add("Situacao", typeof(string));

                    //Retorna as consultas do médico no dia indicado
                    dtConsultasMedico = new AgendaBU().RetornaAgendaByDiaByMedico(dtAgenda, idMedico);

                    if (escala.Jornada1 != null)
                    {
                        dt = (DataTable)this.RetornaEscalaJornada(escala.Jornada1, escala.Jornada1, escala.Jornada2, escala.Jornada3, dt);
                    }

                    if (escala.Jornada2 != null)
                    {
                        dt = (DataTable)this.RetornaEscalaJornada(escala.Jornada2, escala.Jornada1, escala.Jornada2, escala.Jornada3, dt);
                    }

                    if (escala.Jornada3 != null)
                    {
                        dt = (DataTable)this.RetornaEscalaJornada(escala.Jornada3, escala.Jornada1, escala.Jornada2, escala.Jornada3, dt);
                    }

                    ds.Tables.Add(dt);

                    this.gdvAgenda.DataSource = ds;
                    this.gdvAgenda.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alertAgenda", "alert('Selecione um médico e tente novamente!');", true);
                }
            }
            catch (Exception eX)
            {
                throw eX;
            }
        }

        private DataTable RetornaEscalaJornada(Jornada j, Jornada j1, Jornada j2, Jornada j3, DataTable dt)
        {
            //Flag para contagem de horário
            int hora = 0, horaCorrente = 0;
            int minuto = 0, minutoCorrente = 0;
            int horaFim = 0, horaFimCorrente = 0;
            int minutoFim = 0, minutoFimCorrente = 0, k = 0, l = 0, minutoAgendado = 0, horaAgendado = 0;

            int auxHora = 0, auxMinuto = 0;
            string nomeCorrente = string.Empty;
            string telefoneCorrente = string.Empty;
            string convenioCorrente = string.Empty;
            string servicoCorrente = string.Empty;
            string observacaoCorrente = string.Empty;
            string ds_situacaoCorrente = string.Empty;
            string instituicaoCorrente = string.Empty;

            DateTime dtFim, dtFimCorrente;
            DateTime dtInicio, dtInicioCorrente;

            DateTime dtFimAux, dtInicioAux;
            //OK
            #region Monta horário inicial e final do dia do médico
            if (j1 != null)
            {
                if (j1.HoraInicio.ToString().Length == 3)
                {
                    hora = Convert.ToInt32(j1.HoraInicio.ToString().Substring(0, 1));
                    minuto = Convert.ToInt32(j1.HoraInicio.ToString().Substring(1, 2));
                }
                else if (j1.HoraInicio.ToString().Length == 4)
                {
                    //Recupera a hora e o minuto
                    hora = Convert.ToInt32(j1.HoraInicio.ToString().Substring(0, 2));
                    minuto = Convert.ToInt32(j1.HoraInicio.ToString().Substring(2, 2));
                }
            }
            else if (j2 != null)
            {
                if (j2.HoraInicio.ToString().Length == 3)
                {
                    hora = Convert.ToInt32(j2.HoraInicio.ToString().Substring(0, 1));
                    minuto = Convert.ToInt32(j2.HoraInicio.ToString().Substring(1, 2));
                }
                else if (j2.HoraInicio.ToString().Length == 4)
                {
                    //Recupera a hora e o minuto
                    hora = Convert.ToInt32(j2.HoraInicio.ToString().Substring(0, 2));
                    minuto = Convert.ToInt32(j2.HoraInicio.ToString().Substring(2, 2));
                }
            }
            else
            {
                if (j3.HoraInicio.ToString().Length == 3)
                {
                    hora = Convert.ToInt32(j3.HoraInicio.ToString().Substring(0, 1));
                    minuto = Convert.ToInt32(j3.HoraInicio.ToString().Substring(1, 2));
                }
                else if (j3.HoraInicio.ToString().Length == 4)
                {
                    //Recupera a hora e o minuto
                    hora = Convert.ToInt32(j3.HoraInicio.ToString().Substring(0, 2));
                    minuto = Convert.ToInt32(j3.HoraInicio.ToString().Substring(2, 2));
                }
            }



            //Recupera data final
            if (j3 != null)
            {
                if (j3.HoraFim.ToString().Length == 3)
                {
                    horaFim = Convert.ToInt32(j3.HoraFim.ToString().Substring(0, 1));
                    minutoFim = Convert.ToInt32(j3.HoraFim.ToString().Substring(1, 2));
                }
                else if (j3.HoraFim.ToString().Length == 4)
                {
                    horaFim = Convert.ToInt32(j3.HoraFim.ToString().Substring(0, 2));
                    minutoFim = Convert.ToInt32(j3.HoraFim.ToString().Substring(2, 2));
                }
            }
            else if (j2 != null)
            {
                if (j2.HoraFim.ToString().Length == 3)
                {
                    horaFim = Convert.ToInt32(j2.HoraFim.ToString().Substring(0, 1));
                    minutoFim = Convert.ToInt32(j2.HoraFim.ToString().Substring(1, 2));
                }
                else if (j2.HoraFim.ToString().Length == 4)
                {
                    horaFim = Convert.ToInt32(j2.HoraFim.ToString().Substring(0, 2));
                    minutoFim = Convert.ToInt32(j2.HoraFim.ToString().Substring(2, 2));
                }
            }
            else
            {
                if (j1.HoraFim.ToString().Length == 3)
                {
                    horaFim = Convert.ToInt32(j1.HoraFim.ToString().Substring(0, 1));
                    minutoFim = Convert.ToInt32(j1.HoraFim.ToString().Substring(1, 2));
                }
                else if (j1.HoraFim.ToString().Length == 4)
                {
                    //Recupera a hora e o minuto
                    horaFim = Convert.ToInt32(j1.HoraFim.ToString().Substring(0, 2));
                    minutoFim = Convert.ToInt32(j1.HoraFim.ToString().Substring(2, 2));
                }
            }



            //Monta as horas
            dtInicio = new DateTime(dtAgenda.Year, dtAgenda.Month, dtAgenda.Day, hora, minuto, 0);
            dtFim = new DateTime(dtAgenda.Year, dtAgenda.Month, dtAgenda.Day, horaFim, minutoFim, 0);

            #endregion
            //OK
            #region Verifica se existem alguns encaixes ou consultas antes do horário de início corrente do dia do médico

            //Verifica se existem consultas marcadas para o médico no dia
            if (dtConsultasMedico.Rows.Count > 0)
            {
                //Foreach para adicionar horários que não existem
                foreach (DataRow x in dtConsultasMedico.Rows)
                {
                    //Monta a data para comparar.
                    if (x["HR_AGENDA"].ToString().Length == 3)
                    {
                        auxHora = Convert.ToInt32(x["HR_AGENDA"].ToString().Substring(0, 1));
                        auxMinuto = Convert.ToInt32(x["HR_AGENDA"].ToString().Substring(1, 2));

                        dtInicioAux = new DateTime(dtAgenda.Year, dtAgenda.Month, dtAgenda.Day, auxHora, auxMinuto, 0);

                    }
                    else if (x["HR_AGENDA"].ToString().Length == 4)
                    {
                        //Recupera a hora e o minuto
                        auxHora = Convert.ToInt32(x["HR_AGENDA"].ToString().Substring(0, 2));
                        auxMinuto = Convert.ToInt32(x["HR_AGENDA"].ToString().Substring(2, 2));

                        dtInicioAux = new DateTime(dtAgenda.Year, dtAgenda.Month, dtAgenda.Day, auxHora, auxMinuto, 0);
                    }
                    else
                    {
                        dtInicioAux = new DateTime(dtAgenda.Year, dtAgenda.Month, dtAgenda.Day, auxHora, auxMinuto, 0);
                    }

                    //Verifica se o horário marcado é anterior ao horários de início padrão                    
                    if (dtInicioAux < dtInicio)
                    {
                        if (auxMinuto == 0)
                        {

                            if (dt.Rows.Count > 0)
                            {
                                //Efetua verificação de existencia de dados no row que será retornado
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    //Verifica se já existe este horário no datatable de consultas montadas
                                    if (dt.Rows[i]["Hora"].ToString().Equals(dtInicioAux.Hour.ToString() + ":00"))
                                    {
                                        k++;
                                    }
                                }

                                if (k.Equals(0))
                                {
                                    if (!string.IsNullOrEmpty(x["nome"].ToString()))
                                    {
                                        if (x["cd_instituicao"].ToString().Equals(user.Instituicao.IdInstituicao.ToString()))
                                        {
                                            //Se o código da instituição for o mesmo, ele poderá ver a agenda
                                            dt.Rows.Add(dtInicioAux.Hour.ToString() + ":00", x["nome"].ToString(), x["telefone"].ToString(), x["convenio"].ToString(), x["servico"].ToString(), x["observacao"].ToString(), x["ds_situacao"].ToString());
                                            dt.AcceptChanges();
                                        }
                                        else
                                        {
                                           //caso contrário bloqueia a roww
                                            dt.Rows.Add(dtInicioAux.Hour.ToString() + ":00", "Horário Bloqueado", string.Empty, string.Empty, string.Empty, string.Empty, "Marcado");
                                            dt.AcceptChanges();
                                        }
                                    }
                                    else
                                    {
                                        dt.Rows.Add(dtInicioAux.Hour.ToString() + ":00", x["nome"].ToString(), x["telefone"].ToString(), x["convenio"].ToString(), x["servico"].ToString(), x["observacao"].ToString(), x["ds_situacao"].ToString());
                                        dt.AcceptChanges();
                                    }
                                }

                                k = 0;
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(x["nome"].ToString()))
                                {
                                    if (x["cd_instituicao"].ToString().Equals(user.Instituicao.IdInstituicao.ToString()))
                                    {
                                        //Se o código da instituição for o mesmo, ele poderá ver a agenda
                                        dt.Rows.Add(dtInicioAux.Hour.ToString() + ":00", x["nome"].ToString(), x["telefone"].ToString(), x["convenio"].ToString(), x["servico"].ToString(), x["observacao"].ToString(), x["ds_situacao"].ToString());
                                        dt.AcceptChanges();
                                    }
                                    else
                                    {
                                        //caso contrário bloqueia a roww
                                        dt.Rows.Add(dtInicioAux.Hour.ToString() + ":00", "Horário Bloqueado", string.Empty, string.Empty, string.Empty, string.Empty, "Marcado");
                                        dt.AcceptChanges();
                                    }
                                }
                                else
                                {
                                    dt.Rows.Add(dtInicioAux.Hour.ToString() + ":00", x["nome"].ToString(), x["telefone"].ToString(), x["convenio"].ToString(), x["servico"].ToString(), x["observacao"].ToString(), x["ds_situacao"].ToString());
                                    dt.AcceptChanges();
                                }
                            }
                        }
                        else
                        {
                            if (dt.Rows.Count > 0)
                            {
                                //Efetua verificação de existencia de dados no row que será retornado
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    //Verifica se já existe este horário no datatable de consultas montadas
                                    if (dt.Rows[i]["Hora"].ToString().Equals(dtInicioAux.Hour.ToString() + ":" + dtInicioAux.Minute.ToString()))
                                    {
                                        k++;
                                    }
                                }

                                if (k == 0)
                                {
                                    if (!string.IsNullOrEmpty(x["nome"].ToString()))
                                    {
                                        if (x["cd_instituicao"].ToString().Equals(user.Instituicao.IdInstituicao.ToString()))
                                        {
                                            //Se o código da instituição for o mesmo, ele poderá ver a agenda
                                            dt.Rows.Add(dtInicioAux.Hour.ToString() + ":" + dtInicioAux.Minute.ToString(), x["nome"].ToString(), x["telefone"].ToString(), x["convenio"].ToString(), x["servico"].ToString(), x["observacao"].ToString(), x["ds_situacao"].ToString());
                                            dt.AcceptChanges();
                                        }
                                        else
                                        {
                                            //caso contrário bloqueia a roww
                                            dt.Rows.Add(dtInicioAux.Hour.ToString() + ":" + dtInicioAux.Minute.ToString(), "Horário Bloqueado", string.Empty, string.Empty, string.Empty, string.Empty, "Marcado");
                                            dt.AcceptChanges();
                                        }
                                    }
                                    else
                                    {
                                        dt.Rows.Add(dtInicioAux.Hour.ToString() + ":" + dtInicioAux.Minute.ToString(), x["nome"].ToString(), x["telefone"].ToString(), x["convenio"].ToString(), x["servico"].ToString(), x["observacao"].ToString(), x["ds_situacao"].ToString());
                                        dt.AcceptChanges();
                                    }
                                }

                                k = 0;
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(x["nome"].ToString()))
                                {
                                    if (x["cd_instituicao"].ToString().Equals(user.Instituicao.IdInstituicao.ToString()))
                                    {
                                        //Se o código da instituição for o mesmo, ele poderá ver a agenda
                                        //Adiciona a linha em questão
                                        dt.Rows.Add(dtInicioAux.Hour.ToString() + ":" + dtInicioAux.Minute.ToString(), x["nome"].ToString(), x["telefone"].ToString(), x["convenio"].ToString(), x["servico"].ToString(), x["observacao"].ToString(), x["ds_situacao"].ToString());
                                        dt.AcceptChanges();
                                    }
                                    else
                                    {
                                        //caso contrário bloqueia a roww
                                        dt.Rows.Add(dtInicioAux.Hour.ToString() + ":" + dtInicioAux.Minute.ToString(), "Horário Bloqueado", string.Empty, string.Empty, string.Empty, string.Empty, "Marcado");
                                        dt.AcceptChanges();
                                    }
                                }
                                else
                                {
                                    //Adiciona a linha em questão
                                    dt.Rows.Add(dtInicioAux.Hour.ToString() + ":" + dtInicioAux.Minute.ToString(), x["nome"].ToString(), x["telefone"].ToString(), x["convenio"].ToString(), x["servico"].ToString(), x["observacao"].ToString(), x["ds_situacao"].ToString());
                                    dt.AcceptChanges();
                                }
                            }
                        }
                    }
                }
            }
            #endregion
            //OK
            #region Desenvolvimento da estrutura padrão da agenda (horário corrente) 
            //Monta hora de início da jornada corrente
            if (j.HoraInicio.ToString().Length == 3)
            {
                horaCorrente = Convert.ToInt32(j.HoraInicio.ToString().Substring(0, 1));
                minutoCorrente = Convert.ToInt32(j.HoraInicio.ToString().Substring(1, 2));
            }
            else if (j.HoraInicio.ToString().Length == 4)
            {
                //Recupera a hora e o minuto
                horaCorrente = Convert.ToInt32(j.HoraInicio.ToString().Substring(0, 2));
                minutoCorrente = Convert.ToInt32(j.HoraInicio.ToString().Substring(2, 2));
            }

            //Monta a hora de fim da jornada corrente
            if (j.HoraFim.ToString().Length == 3)
            {
                horaFimCorrente = Convert.ToInt32(j.HoraFim.ToString().Substring(0, 1));
                minutoFimCorrente = Convert.ToInt32(j.HoraFim.ToString().Substring(1, 2));
            }
            else if (j.HoraFim.ToString().Length == 4)
            {
                horaFimCorrente = Convert.ToInt32(j.HoraFim.ToString().Substring(0, 2));
                minutoFimCorrente = Convert.ToInt32(j.HoraFim.ToString().Substring(2, 2));
            }

            //Monta as horas
            dtInicioCorrente = new DateTime(dtAgenda.Year, dtAgenda.Month, dtAgenda.Day, horaCorrente, minutoCorrente, 0);
            dtFimCorrente = new DateTime(dtAgenda.Year, dtAgenda.Month, dtAgenda.Day, horaFimCorrente, minutoFimCorrente, 0);

            //Percorre o horário padrão para preencher as vagas no grid
            while (dtInicioCorrente <= dtFimCorrente)
            {
                //Adição dos itens
                if (dtInicioCorrente.Minute.Equals(0))
                {
                    //Verifica cada horário incrementado na tabela de consultas marcadas par adicionar no grid o nome do paciente
                    foreach (DataRow x in dtConsultasMedico.Rows)
                    {
                        //Monta os minutos referentes à data agendada
                        if (x["HR_AGENDA"].ToString().Length == 3)
                        {
                            horaAgendado = Convert.ToInt32(x["HR_AGENDA"].ToString().Substring(0, 1));
                            minutoAgendado = Convert.ToInt32(x["HR_AGENDA"].ToString().Substring(1, 2));
                        }
                        else if (x["HR_AGENDA"].ToString().Length == 4)
                        {
                            horaAgendado = Convert.ToInt32(x["HR_AGENDA"].ToString().Substring(0, 2));
                            minutoAgendado = Convert.ToInt32(x["HR_AGENDA"].ToString().Substring(2, 2));
                        }

                        //Verifica se o agendamento é encaixe
                        if (minutoAgendado > 0 && minutoAgendado < dtInicioCorrente.Minute && horaAgendado.Equals(dtInicioCorrente.Hour))
                        {
                            //verificacao para adicionar linha
                            //Efetua verificação de existencia de dados no row que será retornado
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                //Verifica se já existe este horário no datatable de consultas montadas
                                if (dt.Rows[i]["Hora"].ToString().Equals(horaAgendado.ToString() + ":" + minutoAgendado.ToString()))
                                {
                                    k++;
                                }
                            }

                            if (k.Equals(0))
                            {
                                if (minutoAgendado == 0)
                                {
                                    if (!string.IsNullOrEmpty(x["nome"].ToString()))
                                    {
                                        if (x["cd_instituicao"].ToString().Equals(user.Instituicao.IdInstituicao.ToString()))
                                        {
                                            //Se o código da instituição for o mesmo, ele poderá ver a agenda
                                            //Adiciona a linha em questão
                                            dt.Rows.Add(horaAgendado.ToString() + ":00", x["nome"].ToString(), x["telefone"].ToString(), x["convenio"].ToString(), x["servico"].ToString(), x["observacao"].ToString(), x["ds_situacao"].ToString());
                                            dt.AcceptChanges();
                                        }
                                        else
                                        {
                                            //caso contrário bloqueia a roww
                                            dt.Rows.Add(horaAgendado.ToString() + ":00", "Horário Bloqueado", string.Empty, string.Empty, string.Empty, string.Empty, "Marcado");
                                            dt.AcceptChanges();
                                        }
                                    }
                                    else
                                    {
                                        //Adiciona a linha em questão
                                        dt.Rows.Add(horaAgendado.ToString() + ":00", x["nome"].ToString(), x["telefone"].ToString(), x["convenio"].ToString(), x["servico"].ToString(), x["observacao"].ToString(), x["ds_situacao"].ToString());
                                        dt.AcceptChanges();
                                    }
                                }
                                else
                                {
                                    if (!string.IsNullOrEmpty(x["nome"].ToString()))
                                    {
                                        if (x["cd_instituicao"].ToString().Equals(user.Instituicao.IdInstituicao.ToString()))
                                        {
                                            //Se o código da instituição for o mesmo, ele poderá ver a agenda
                                            //Adiciona a linha em questão
                                            dt.Rows.Add(horaAgendado.ToString() + ":" + minutoAgendado.ToString(), x["nome"].ToString(), x["telefone"].ToString(), x["convenio"].ToString(), x["servico"].ToString(), x["observacao"].ToString(), x["ds_situacao"].ToString());
                                            dt.AcceptChanges();
                                        }
                                        else
                                        {
                                            //caso contrário bloqueia a roww
                                            dt.Rows.Add(horaAgendado.ToString() + ":" + minutoAgendado.ToString(), "Horário Bloqueado", string.Empty, string.Empty, string.Empty, string.Empty, "Marcado");
                                            dt.AcceptChanges();
                                        }
                                    }
                                    else
                                    {
                                        //Adiciona a linha em questão
                                        dt.Rows.Add(horaAgendado.ToString() + ":" + minutoAgendado.ToString(), x["nome"].ToString(), x["telefone"].ToString(), x["convenio"].ToString(), x["servico"].ToString(), x["observacao"].ToString(), x["ds_situacao"].ToString());
                                        dt.AcceptChanges();
                                    }
                                }
                            }

                            k = 0;
                        }
                        else
                        {
                            //Verifica se existe um registro de consulta dentro dos horários correntes da jornada
                            if (x["HR_AGENDA"].ToString().Equals(dtInicioCorrente.Hour.ToString() + "00"))
                            {
                                l++;
                                nomeCorrente = x["nome"].ToString();
                                telefoneCorrente = x["telefone"].ToString();
                                convenioCorrente = x["convenio"].ToString();
                                servicoCorrente = x["servico"].ToString();
                                observacaoCorrente = x["observacao"].ToString();
                                ds_situacaoCorrente = x["ds_situacao"].ToString();
                                instituicaoCorrente = x["cd_instituicao"].ToString();
                                break;
                            }
                            else
                            {
                                nomeCorrente = string.Empty;
                                telefoneCorrente = string.Empty;
                                convenioCorrente = string.Empty;
                                servicoCorrente = string.Empty;
                                observacaoCorrente = string.Empty;
                                ds_situacaoCorrente = string.Empty;
                                instituicaoCorrente = string.Empty;
                            }
                        }
                    }

                    if (l > 0)
                    {
                        if (!string.IsNullOrEmpty(nomeCorrente))
                        {
                            if (instituicaoCorrente.Equals(user.Instituicao.IdInstituicao.ToString()))
                            {
                                //Se o código da instituição for o mesmo, ele poderá ver a agenda
                                //Adiciona a linha em questão
                                dt.Rows.Add(dtInicioCorrente.Hour.ToString() + ":00", nomeCorrente, telefoneCorrente, convenioCorrente, servicoCorrente, observacaoCorrente, ds_situacaoCorrente);
                                dt.AcceptChanges();
                            }
                            else
                            {
                                //caso contrário bloqueia a roww
                                dt.Rows.Add(dtInicioCorrente.Hour.ToString() + ":00", "Horário Bloqueado", string.Empty, string.Empty, string.Empty, string.Empty, "Marcado");
                                dt.AcceptChanges();
                            }
                        }
                        else
                        {
                            //Adiciona a linha em questão
                            dt.Rows.Add(dtInicioCorrente.Hour.ToString() + ":00", nomeCorrente, telefoneCorrente, convenioCorrente, servicoCorrente, observacaoCorrente, ds_situacaoCorrente);
                            dt.AcceptChanges();
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(nomeCorrente))
                        {
                            if (instituicaoCorrente.Equals(user.Instituicao.IdInstituicao.ToString()))
                            {
                                //Se o código da instituição for o mesmo, ele poderá ver a agenda
                                //Adiciona a linha em questão
                                dt.Rows.Add(dtInicioCorrente.Hour.ToString() + ":00", nomeCorrente, telefoneCorrente, convenioCorrente, servicoCorrente, observacaoCorrente, ds_situacaoCorrente);
                                dt.AcceptChanges();
                            }
                            else
                            {
                                //caso contrário bloqueia a roww
                                dt.Rows.Add(dtInicioCorrente.Hour.ToString() + ":00", "Horário Bloqueado", string.Empty, string.Empty, string.Empty, string.Empty, "Marcado");
                                dt.AcceptChanges();
                            }
                        }
                        else
                        {
                            //Adiciona a linha em questão
                            dt.Rows.Add(dtInicioCorrente.Hour.ToString() + ":00", nomeCorrente, telefoneCorrente, convenioCorrente, servicoCorrente, observacaoCorrente, ds_situacaoCorrente);
                            dt.AcceptChanges();
                        }
                    }

                    l = 0;
                }
                else
                {
                    //Verifica cada horário incrementado na tabela de consultas marcadas par adicionar no grid o nome do paciente
                    foreach (DataRow x in dtConsultasMedico.Rows)
                    {
                        //Monta os minutos referentes à data agendada
                        if (x["HR_AGENDA"].ToString().Length == 3)
                        {
                            horaAgendado = Convert.ToInt32(x["HR_AGENDA"].ToString().Substring(0, 1));
                            minutoAgendado = Convert.ToInt32(x["HR_AGENDA"].ToString().Substring(1, 2));
                        }
                        else if (x["HR_AGENDA"].ToString().Length == 4)
                        {
                            horaAgendado = Convert.ToInt32(x["HR_AGENDA"].ToString().Substring(0, 2));
                            minutoAgendado = Convert.ToInt32(x["HR_AGENDA"].ToString().Substring(2, 2));
                        }

                        //Verifica se o agendamento é encaixe
                        if (minutoAgendado > 0 && minutoAgendado < dtInicioCorrente.Minute && horaAgendado.Equals(dtInicioCorrente.Hour))
                        {
                            //Efetua verificação de existencia de dados no row que será retornado
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                //Verifica se já existe este horário no datatable de consultas montadas
                                if (dt.Rows[i]["Hora"].ToString().Equals(horaAgendado.ToString() + ":" + minutoAgendado.ToString()))
                                {
                                    k++;
                                }
                            }

                            if (k.Equals(0))
                            {
                                if (!string.IsNullOrEmpty(x["nome"].ToString()))
                                {
                                    if (x["cd_instituicao"].ToString().Equals(user.Instituicao.IdInstituicao.ToString()))
                                    {
                                        //Se o código da instituição for o mesmo, ele poderá ver a agenda
                                        //Adiciona a linha em questão
                                        dt.Rows.Add(horaAgendado.ToString() + ":" + minutoAgendado.ToString(), x["nome"].ToString(), x["telefone"].ToString(), x["convenio"].ToString(), x["servico"].ToString(), x["observacao"].ToString(), x["ds_situacao"].ToString());
                                        dt.AcceptChanges();
                                    }
                                    else
                                    {
                                        //caso contrário bloqueia a roww
                                        dt.Rows.Add(horaAgendado.ToString() + ":" + minutoAgendado.ToString(), "Horário Bloqueado", string.Empty, string.Empty, string.Empty, string.Empty, "Marcado");
                                        dt.AcceptChanges();
                                    }
                                }
                                else
                                {
                                    //Adiciona a linha em questão
                                    dt.Rows.Add(horaAgendado.ToString() + ":" + minutoAgendado.ToString(), x["nome"].ToString(), x["telefone"].ToString(), x["convenio"].ToString(), x["servico"].ToString(), x["observacao"].ToString(), x["ds_situacao"].ToString());
                                    dt.AcceptChanges();
                                }
                            }

                            k = 0;
                        }
                        else
                        {
                            if (x["HR_AGENDA"].ToString().Equals(dtInicioCorrente.Hour.ToString() + dtInicioCorrente.Minute.ToString()))
                            {
                                l++;
                                nomeCorrente = x["nome"].ToString();
                                telefoneCorrente = x["telefone"].ToString();
                                convenioCorrente = x["convenio"].ToString();
                                servicoCorrente = x["servico"].ToString();
                                observacaoCorrente = x["observacao"].ToString();
                                ds_situacaoCorrente = x["ds_situacao"].ToString();
                                instituicaoCorrente = x["cd_instituicao"].ToString();
                                break;
                            }
                            else
                            {
                                nomeCorrente = string.Empty;
                                telefoneCorrente = string.Empty;
                                convenioCorrente = string.Empty;
                                servicoCorrente = string.Empty;
                                observacaoCorrente = string.Empty;
                                ds_situacaoCorrente = string.Empty;
                                instituicaoCorrente = string.Empty;
                            }
                        }
                    }

                    if (l > 0)
                    {
                        if (!string.IsNullOrEmpty(nomeCorrente))
                        {
                            if (instituicaoCorrente.Equals(user.Instituicao.IdInstituicao.ToString()))
                            {
                                //Se o código da instituição for o mesmo, ele poderá ver a agenda
                                //Adiciona a linha em questão
                                dt.Rows.Add(dtInicioCorrente.Hour.ToString() + ":" + dtInicioCorrente.Minute.ToString(), nomeCorrente, telefoneCorrente, convenioCorrente, servicoCorrente, observacaoCorrente, ds_situacaoCorrente);
                                dt.AcceptChanges();
                            }
                            else
                            {
                                //caso contrário bloqueia a roww
                                dt.Rows.Add(dtInicioCorrente.Hour.ToString() + ":" + dtInicioCorrente.Minute.ToString(), "Horário Bloqueado", string.Empty, string.Empty, string.Empty, string.Empty, "Marcado");
                                dt.AcceptChanges();
                            }
                        }
                        else
                        {
                            //Adiciona a linha em questão
                            dt.Rows.Add(dtInicioCorrente.Hour.ToString() + ":" + dtInicioCorrente.Minute.ToString(), nomeCorrente, telefoneCorrente, convenioCorrente, servicoCorrente, observacaoCorrente, ds_situacaoCorrente);
                            dt.AcceptChanges();
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(nomeCorrente))
                        {
                            if (instituicaoCorrente.Equals(user.Instituicao.IdInstituicao.ToString()))
                            {
                                //Se o código da instituição for o mesmo, ele poderá ver a agenda
                                //Adiciona a linha em questão
                                dt.Rows.Add(dtInicioCorrente.Hour.ToString() + ":" + dtInicioCorrente.Minute.ToString(), string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
                                dt.AcceptChanges();
                            }
                            else
                            {
                                //caso contrário bloqueia a roww
                                dt.Rows.Add(dtInicioCorrente.Hour.ToString() + ":" + dtInicioCorrente.Minute.ToString(), "Horário Bloqueado", string.Empty, string.Empty, string.Empty, string.Empty, "Marcado");
                                dt.AcceptChanges();
                            }
                        }
                        else
                        {
                            //Adiciona a linha em questão
                            dt.Rows.Add(dtInicioCorrente.Hour.ToString() + ":" + dtInicioCorrente.Minute.ToString(), string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
                            dt.AcceptChanges();
                        }
                    }

                    l = 0;
                }

                dtInicioCorrente = dtInicioCorrente.AddMinutes(j.NmDuracao);
            }
            
            #endregion

            #region Verifica se existem alguns encaixes ou consultas depois do horário de fim corrente do dia do médico
            if (dtConsultasMedico.Rows.Count > 0)
            {
                //Foreach para adicionar horários que não existem
                foreach (DataRow x in dtConsultasMedico.Rows)
                {
                    //Monta a data para comparar.
                    if (x["HR_AGENDA"].ToString().Length == 3)
                    {
                        auxHora = Convert.ToInt32(x["HR_AGENDA"].ToString().Substring(0, 1));
                        auxMinuto = Convert.ToInt32(x["HR_AGENDA"].ToString().Substring(1, 2));

                        dtFimAux = new DateTime(dtAgenda.Year, dtAgenda.Month, dtAgenda.Day, auxHora, auxMinuto, 0);

                    }
                    else if (x["HR_AGENDA"].ToString().Length == 4)
                    {
                        //Recupera a hora e o minuto
                        auxHora = Convert.ToInt32(x["HR_AGENDA"].ToString().Substring(0, 2));
                        auxMinuto = Convert.ToInt32(x["HR_AGENDA"].ToString().Substring(2, 2));

                        dtFimAux = new DateTime(dtAgenda.Year, dtAgenda.Month, dtAgenda.Day, auxHora, auxMinuto, 0);
                    }
                    else
                    {
                        dtFimAux = new DateTime(dtAgenda.Year, dtAgenda.Month, dtAgenda.Day, auxHora, auxMinuto, 0);
                    }
                    
                    //Verifica se o horário marcado é anterior ao horários de início padrão
                    if (dtFimAux > dtFim)
                    {
                        if (auxMinuto == 0)
                        {
                            if (dt.Rows.Count > 0)
                            {
                                //Efetua verificação de existencia de dados no row que será retornado
                                //foreach (DataRow row in dt.Rows)
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    //Verifica se já existe este horário no datatable de consultas montadas
                                    if (dt.Rows[i]["Hora"].ToString().Equals(dtFimAux.Hour.ToString() + ":00"))
                                    {
                                        k++;
                                    }
                                }

                                if (k == 0)
                                {
                                    if (!string.IsNullOrEmpty(x["nome"].ToString()))
                                    {
                                        if (x["cd_instituicao"].ToString().Equals(user.Instituicao.IdInstituicao.ToString()))
                                        {
                                            //Se o código da instituição for o mesmo, ele poderá ver a agenda
                                            //Adiciona a linha em questão
                                            dt.Rows.Add(dtFimAux.Hour.ToString() + ":00", x["nome"].ToString(), x["telefone"].ToString(), x["convenio"].ToString(), x["servico"].ToString(), x["observacao"].ToString(), x["ds_situacao"].ToString());
                                            dt.AcceptChanges();
                                        }
                                        else
                                        {
                                            //caso contrário bloqueia a roww
                                            dt.Rows.Add(dtFimAux.Hour.ToString() + ":00", "Horário Bloqueado", string.Empty, string.Empty, string.Empty, string.Empty, "Marcado");
                                            dt.AcceptChanges();
                                        }
                                    }
                                    else
                                    {
                                        //Adiciona a linha em questão
                                        dt.Rows.Add(dtFimAux.Hour.ToString() + ":00", x["nome"].ToString(), x["telefone"].ToString(), x["convenio"].ToString(), x["servico"].ToString(), x["observacao"].ToString(), x["ds_situacao"].ToString());
                                        dt.AcceptChanges();
                                    }
                                }

                                k = 0;
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(x["nome"].ToString()))
                                {
                                    if (x["cd_instituicao"].ToString().Equals(user.Instituicao.IdInstituicao.ToString()))
                                    {
                                        //Se o código da instituição for o mesmo, ele poderá ver a agenda
                                        //Adiciona a linha em questão
                                        dt.Rows.Add(dtFimAux.Hour.ToString() + ":00", x["nome"].ToString(), x["telefone"].ToString(), x["convenio"].ToString(), x["servico"].ToString(), x["observacao"].ToString(), x["ds_situacao"].ToString());
                                        dt.AcceptChanges();
                                    }
                                    else
                                    {
                                        //caso contrário bloqueia a roww
                                        dt.Rows.Add(dtFimAux.Hour.ToString() + ":00", "Horário Bloqueado", string.Empty, string.Empty, string.Empty, string.Empty, "Marcado");
                                        dt.AcceptChanges();
                                    }
                                }
                                else
                                {
                                    //Adiciona a linha em questão
                                    dt.Rows.Add(dtFimAux.Hour.ToString() + ":00", x["nome"].ToString(), x["telefone"].ToString(), x["convenio"].ToString(), x["servico"].ToString(), x["observacao"].ToString(), x["ds_situacao"].ToString());
                                    dt.AcceptChanges();
                                }
                            }
                        }
                        else
                        {
                            //Minuto eh maior q zero...
                            if (dt.Rows.Count > 0)
                            {
                                //Efetua verificação de existencia de dados no row que será retornado
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    //Verifica se já existe este horário no datatable de consultas montadas
                                    if (dt.Rows[i]["Hora"].ToString().Equals(dtFimAux.Hour.ToString() + ":" + dtFimAux.Minute.ToString()))
                                    {
                                        k++;
                                    }
                                }


                                if (k == 0)
                                {
                                    if (!string.IsNullOrEmpty(x["nome"].ToString()))
                                    {
                                        if (x["cd_instituicao"].ToString().Equals(user.Instituicao.IdInstituicao.ToString()))
                                        {
                                            //Se o código da instituição for o mesmo, ele poderá ver a agenda
                                            //Adiciona a linha em questão
                                            dt.Rows.Add(dtFimAux.Hour.ToString() + ":" + dtFimAux.Minute.ToString(), x["nome"].ToString(), x["telefone"].ToString(), x["convenio"].ToString(), x["servico"].ToString(), x["observacao"].ToString(), x["ds_situacao"].ToString());
                                            dt.AcceptChanges();
                                        }
                                        else
                                        {
                                            //caso contrário bloqueia a roww
                                            dt.Rows.Add(dtFimAux.Hour.ToString() + ":" + dtFimAux.Minute.ToString(), "Horário Bloqueado", string.Empty, string.Empty, string.Empty, string.Empty, "Marcado");
                                            dt.AcceptChanges();
                                        }
                                    }
                                    else
                                    {
                                        //Adiciona a linha em questão
                                        dt.Rows.Add(dtFimAux.Hour.ToString() + ":" + dtFimAux.Minute.ToString(), x["nome"].ToString(), x["telefone"].ToString(), x["convenio"].ToString(), x["servico"].ToString(), x["observacao"].ToString(), x["ds_situacao"].ToString());
                                        dt.AcceptChanges();
                                    }
                                }

                                k = 0;
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(x["nome"].ToString()))
                                {
                                    if (x["cd_instituicao"].ToString().Equals(user.Instituicao.IdInstituicao.ToString()))
                                    {
                                        //Se o código da instituição for o mesmo, ele poderá ver a agenda
                                        //Adiciona a linha em questão
                                        dt.Rows.Add(dtFimAux.Hour.ToString() + ":" + dtFimAux.Minute.ToString(), x["nome"].ToString(), x["telefone"].ToString(), x["convenio"].ToString(), x["servico"].ToString(), x["observacao"].ToString(), x["ds_situacao"].ToString());
                                        dt.AcceptChanges();
                                    }
                                    else
                                    {
                                        //caso contrário bloqueia a roww
                                        dt.Rows.Add(dtFimAux.Hour.ToString() + ":" + dtFimAux.Minute.ToString(), "Horário Bloqueado", string.Empty, string.Empty, string.Empty, string.Empty, "Marcado");
                                        dt.AcceptChanges();
                                    }
                                }
                                else
                                {
                                    //Adiciona a linha em questão
                                    dt.Rows.Add(dtFimAux.Hour.ToString() + ":" + dtFimAux.Minute.ToString(), x["nome"].ToString(), x["telefone"].ToString(), x["convenio"].ToString(), x["servico"].ToString(), x["observacao"].ToString(), x["ds_situacao"].ToString());
                                    dt.AcceptChanges();
                                }
                            }
                        }
                    }
                }
            }

            #endregion
            
            return dt;
        }

        protected void gdvAgenda_HtmlDataCellPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableDataCellEventArgs e)
        {
            try
            {
                
                if (e.DataColumn.Caption == "Paciente")
                {
                    string paciente = e.CellValue.ToString();

                    if (!string.IsNullOrEmpty(paciente))
                    {
                        if (!paciente.Equals("Horário Bloqueado"))
                        {
                            //Horário liberado, então podemos procurar pelo link de observação
                            HyperLink hd = (HyperLink)this.gdvAgenda.FindRowCellTemplateControl(e.VisibleIndex, (DevExpress.Web.ASPxGridView.GridViewDataColumn)gdvAgenda.Columns["colDelete"], "hlDelete");

                            if (hd != null)
                            {
                                hd.ImageUrl = "images/trash_16.png";
                                hd.NavigateUrl = string.Format("javascript:var x = document.getElementById('hdnIdMedico');cbDeletaConsulta.PerformCallback('{0}|' + lblDataConsulta.GetText() + '|' + x.value)", e.KeyValue.ToString());
                            }
                        }
                    }
                }

                if (e.DataColumn.Caption == "Observação")
                {
                    string observacao = e.CellValue.ToString();

                    HyperLink hl = (HyperLink)this.gdvAgenda.FindRowCellTemplateControl(e.VisibleIndex, (DevExpress.Web.ASPxGridView.GridViewDataColumn)gdvAgenda.Columns["observacao"], "hlObservacao");

                    if (hl != null)
                    {
                        if (!string.IsNullOrEmpty(observacao))
                        {
                            hl.ImageUrl = "images/notep_16.png";
                            hl.NavigateUrl = string.Format("javascript:OnMoreInfoClick(this, '{0}');", observacao);
                        }
                    }
                }

                if (e.DataColumn.FieldName == "Situacao")
                {
                    string situacao = e.CellValue.ToString();

                    System.Web.UI.WebControls.Image img = (System.Web.UI.WebControls.Image)this.gdvAgenda.FindRowCellTemplateControl(e.VisibleIndex, (DevExpress.Web.ASPxGridView.GridViewDataColumn)gdvAgenda.Columns["ds_situacao"], "imgSituacao");

                    switch (situacao)
                    {
                        case "Marcado":
                            if (img != null)
                            {
                                //Usuário Ativo
                                img.AlternateText = "Marcado";
                                img.Attributes["title"] = "Marcado";
                                img.ImageUrl = "images/status/marcado.jpg";
                            }
                            break;

                        case "Esperando":
                            if (img != null)
                            {
                                //Usuário Ativo
                                img.AlternateText = "Esperando";
                                img.Attributes["title"] = "Esperando";
                                img.ImageUrl = "images/status/esperando.jpg";
                            }
                            break;

                        case "Exames":
                            if (img != null)
                            {
                                //Usuário Ativo
                                img.AlternateText = "Exames";
                                img.Attributes["title"] = "Exames";
                                img.ImageUrl = "images/status/exame_2.jpg";
                            }
                            break;

                        case "Atendido":
                            if (img != null)
                            {
                                //Usuário Ativo
                                img.AlternateText = "Atendido";
                                img.Attributes["title"] = "Atendido";
                                img.ImageUrl = "images/status/atendido.jpg";
                            }
                            break;

                        case "Faltou":
                            if (img != null)
                            {
                                //Usuário Ativo
                                img.AlternateText = "Faltou";
                                img.Attributes["title"] = "Faltou";
                                img.ImageUrl = "images/status/faltou.jpg";
                            }
                            break;

                        case "Cancelado":
                            if (img != null)
                            {
                                //Usuário Ativo
                                img.AlternateText = "Cancelado";
                                img.Attributes["title"] = "Cancelado";
                                img.ImageUrl = "images/status/cancelado.jpg";
                            }
                            break;

                        case "Encaixe":
                            if (img != null)
                            {
                                //Usuário Ativo
                                img.AlternateText = "Encaixe";
                                img.Attributes["title"] = "Encaixe";
                                img.ImageUrl = "images/status/encaixe.jpg";
                            }
                            break;

                        case "Confirmado":
                            if (img != null)
                            {
                                //Usuário Ativo
                                img.AlternateText = "Confirmado";
                                img.Attributes["title"] = "Confirmado";
                                img.ImageUrl = "images/status/confirmado.jpg";
                            }
                            break;

                        case "Transferido":
                            if (img != null)
                            {
                                //Usuário Ativo
                                img.AlternateText = "Transferido";
                                img.Attributes["title"] = "Transferido";
                                img.ImageUrl = "images/status/transferido.jpg";
                            }
                            break;

                        case "Bloqueado":
                            if (img != null)
                            {
                                //Usuário Ativo
                                img.AlternateText = "Bloqueado";
                                img.Attributes["title"] = "Bloqueado";
                                img.ImageUrl = "images/status/bloqueado.jpg";
                            }
                            break;

                        default:
                            if (img != null)
                            {
                                //Usuário Ativo
                                img.AlternateText = "";
                                img.Attributes["title"] = "";
                                img.ImageUrl = "images/status/blank_status.gif";
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void calendarAgenda_DayRender(object sender, DevExpress.Web.ASPxEditors.DayRenderEventArgs e)
        {
            if (!cmbServicos.SelectedIndex.Equals(-1))
            {
                calendarAgenda.Enabled = true;

                if (dtDiasSemanaByServico.Rows.Count <= 0)
                {
                    dtDiasSemanaByServico = new EscalaBU().RetornaEscalasByServico(Convert.ToInt32(cmbServicos.SelectedItem.Value), false);
                }

                foreach (DataRow x in dtDiasSemanaByServico.Rows)
                {
                    if (ReturnDayOfWeek(e.Day.DateTime.DayOfWeek.ToString()) == x["DS_DIA"].ToString() && e.Day.DateTime.Date >= DateTime.Now.Date)
                    {
                        e.Controls.Add(CreateHyperLink(e.Day.DateTime));
                    }
                    else
                    {
                        e.Style.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
            else
            {
                calendarAgenda.Enabled = false;
            }
        }

        private Control CreateHyperLink(DateTime date)
        {
            HyperLink link = new HyperLink();
            link.Text = date.Day.ToString();
            link.NavigateUrl = string.Format("javascript:lblDataConsultada.SetVisible(true);cmbMedicos.PerformCallback('{0}#' +  cmbServicos.GetValue());cmbMedicos.SetVisible(true); lblDataEscolhida.SetVisible(true); var hdnDataConsulta = document.getElementById('hdnDataConsulta'); lblDataEscolhida.SetText('{0}');", date.ToString("d/M/yyyy", CultureInfo.InvariantCulture));
            link.Style[HtmlTextWriterStyle.Display] = "block";
            link.Style[HtmlTextWriterStyle.Padding] = "4px";
            link.Style[HtmlTextWriterStyle.FontFamily] = "Arial";
            link.Style[HtmlTextWriterStyle.Color] = "Green";
            return link;
        }

        private string ReturnDayOfWeek(string dia)
        {
            try
            {
                switch (dia.ToLower())
                {
                    case "sunday":
                        return "domingo";
                        break;

                    case "monday":
                        return "segunda-feira";
                        break;

                    case "tuesday":
                        return "terça-feira";
                        break;

                    case "wednesday":
                        return "quarta-feira";
                        break;

                    case "thursday":
                        return "quinta-feira";
                        break;

                    case "friday":
                        return "sexta-feira";
                        break;

                    case "saturday":
                        return "quinta-feira";
                        break;

                    default:
                        return string.Empty;
                        break;
                }
            }
            catch (Exception eX)
            {
                throw eX;
            }
        }

        protected void cbpObservacoes_Callback(object sender, DevExpress.Web.ASPxClasses.CallbackEventArgsBase e)
        {
            if (!string.IsNullOrEmpty(e.Parameter.ToString()))
            {
                litObservacao.Text = e.Parameter.ToString();
            }
            else
            {
                litObservacao.Text = "Não existe observação para este agendamento.";
            }
        }

        protected void cbDeletaConsulta_Callback(object source, DevExpress.Web.ASPxCallback.CallbackEventArgs e)
        {
            //Chama evento para deletar a agenda
            try
            {
                string[] vet = e.Parameter.Split('|');

                string hora = vet[0].ToString();

                //recupera os parâmetros necessários para deleção de consultas.
                DateTime dtConsulta = Convert.ToDateTime(vet[1].ToString());

                int codMedico = Convert.ToInt32(vet[2].ToString());

                hora = hora.Replace(":", "");

                //efetua chamada de deleção
                new AgendaBU().DeletarConsultaByDiaByMedicoByHoraAgendada(dtConsulta, codMedico, hora);
            }
            catch (Exception eX)
            {
                throw eX;
            }
        }

        protected void cmbServicos_Callback(object sender, DevExpress.Web.ASPxClasses.CallbackEventArgsBase e)
        {
            string cdCategoria = e.Parameter.ToString();
            
            if (!string.IsNullOrEmpty(cdCategoria))
            {
                odsTipoServico.SelectParameters[0].DefaultValue = cdCategoria;                
                cmbServicos.DataBind();
            }
        }

        protected void cmbMedicos_Callback(object sender, DevExpress.Web.ASPxClasses.CallbackEventArgsBase e)
        {
            string []vet = e.Parameter.Split('#');
            
            DateTime dtConsulta = Convert.ToDateTime(vet[0]);
            int codServico = Convert.ToInt32(vet[1]);
            
            odsMedicos.SelectParameters[0].DefaultValue = dtConsulta.Date.ToString();
            odsMedicos.SelectParameters[1].DefaultValue = codServico.ToString();
            
            cmbMedicos.DataBind();
        }

        protected void gdvAgenda_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
        {
            if (e.RowType != DevExpress.Web.ASPxGridView.GridViewRowType.Data)
                return;

            if (e.GetValue("Nome").Equals("Horário Bloqueado"))
            {
                e.Row.ForeColor =  Color.LightBlue;
            }
        }
    }
}