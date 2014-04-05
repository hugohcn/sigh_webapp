<%@ Page Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true"
    CodeBehind="GerenciarAgendaForm.aspx.cs" Inherits="sighWeb.GerenciarAgendaForm"
    Title="Sistema Integrado de Gerenciamento Hospitalar | Cosultar Agenda" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxCallback" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx1" %>
<%@ Register Assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxLoadingPanel" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="padding: 8px;">
        <table border="0" cellpadding="2" cellspacing="2" width="100%">
            <tr>
                <td colspan="2">
                    <dx:ASPxLabel ID="lblDataMes" runat="server" ClientInstanceName="lblDataMes" ClientVisible="False"
                        CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass" Text="Data da Consulta:"
                        CssClass="labels">
                    </dx:ASPxLabel>
                    &nbsp;<dx:ASPxLabel ID="lblDataConsulta" runat="server" ClientInstanceName="lblDataConsulta"
                        CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass" CssClass="labels">
                    </dx:ASPxLabel>
                </td>
                <td>
                    &nbsp;
                </td>
                <td align="right">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <input enableviewstate="true" type="hidden" id="hdnIdMedico" value="" />
                    <input enableviewstate="true" type="hidden" id="hdnDataConsulta" value="" />
                    <input enableviewstate="true" type="hidden" id="hdnIdServico" value="" />
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <dx:ASPxLabel ID="lblExame" runat="server" Text="Selecione um Exame:" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                        CssPostfix="Glass" CssClass="labels">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxLabel ID="lblServico" runat="server" Text="Selecione um Tipo de Serviço:"
                        CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass" ClientInstanceName="lblServico"
                        CssClass="labels">
                    </dx:ASPxLabel>
                </td>
                <td style="width: 250px">
                    <dx:ASPxLabel ID="lblConvenio" runat="server" Text="Selecione um Convênio:" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                        CssPostfix="Glass" ClientInstanceName="lblConvenio" CssClass="labels">
                    </dx:ASPxLabel>
                </td>
                <td align="left" style="padding-left: 20px" valign="top">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td valign="top" style="width: 250px">
                    <dx:ASPxComboBox ID="cmbCategoria" runat="server" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                        CssPostfix="Glass" SpriteCssFilePath="~/App_Themes/Glass/{0}/sprite.css" ValueType="System.String"
                        ClientInstanceName="cmbCategoria" DataSourceID="odsCategoria" TextField="ds_nome"
                        ValueField="cd_categoria" Width="220px" TextFormatString="{0}" EnableCallbackMode="True"
                        EnableIncrementalFiltering="True" CallbackPageSize="20" LoadingPanelText="Carregando...">
                        <ButtonStyle Width="13px">
                        </ButtonStyle>
                        <LoadingPanelImage Url="~/App_Themes/Glass/Editors/Loading.gif">
                        </LoadingPanelImage>
                        <ClientSideEvents SelectedIndexChanged="function(s, e) {
	cmbServicos.PerformCallback(cmbCategoria.GetValue().toString());
}" />
                        <ValidationSettings>
                            <ErrorFrameStyle ImageSpacing="4px">
                                <ErrorTextPaddings PaddingLeft="4px" />
                            </ErrorFrameStyle>
                        </ValidationSettings>
                    </dx:ASPxComboBox>
                    <asp:ObjectDataSource ID="odsCategoria" runat="server" SelectMethod="RetornaCategorias"
                        TypeName="Business.CategoriaBU"></asp:ObjectDataSource>
                </td>
                <td valign="top" style="width: 250px">
                    <dx:ASPxComboBox ID="cmbServicos" runat="server" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                        DropDownWidth="550px" CssPostfix="Glass" SpriteCssFilePath="~/App_Themes/Glass/{0}/sprite.css"
                        ValueType="System.String" ClientInstanceName="cmbServicos" DataSourceID="odsTipoServico"
                        TextField="ds_nome" ValueField="cd_servico" Width="220px" TextFormatString="{0}"
                        EnableCallbackMode="True" EnableIncrementalFiltering="True" CallbackPageSize="20"
                        LoadingPanelText="Carregando..." IncrementalFilteringDelay="50" OnCallback="cmbServicos_Callback">
                        <ButtonStyle Width="13px">
                        </ButtonStyle>
                        <LoadingPanelImage Url="~/App_Themes/Glass/Editors/Loading.gif">
                        </LoadingPanelImage>
                        <ClientSideEvents SelectedIndexChanged="function(s, e) {
	var idServico = document.getElementById('hdnIdServico');
	idServico.value = cmbServicos.GetSelectedItem().value;
}" />
                        <ValidationSettings>
                            <ErrorFrameStyle ImageSpacing="4px">
                                <ErrorTextPaddings PaddingLeft="4px" />
                            </ErrorFrameStyle>
                        </ValidationSettings>
                    </dx:ASPxComboBox>
                    <asp:ObjectDataSource ID="odsTipoServico" runat="server" SelectMethod="ObterServicosByCategoria"
                        TypeName="Business.ServicoBU">
                        <SelectParameters>
                            <asp:Parameter Name="categoria" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
                <td valign="top" style="width: 250px">
                    <dx:ASPxComboBox ID="cmbConvenios" runat="server" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                        CssPostfix="Glass" SpriteCssFilePath="~/App_Themes/Glass/{0}/sprite.css" ValueType="System.String"
                        ClientInstanceName="cmbConvenios" DataSourceID="odsConvenio" TextField="ds_nome"
                        ValueField="cd_convenio" Width="220px" TextFormatString="{0}" EnableCallbackMode="True"
                        EnableIncrementalFiltering="True" CallbackPageSize="20" LoadingPanelText="Carregando..."
                        IncrementalFilteringDelay="50">
                        <ButtonStyle Width="13px">
                        </ButtonStyle>
                        <LoadingPanelImage Url="~/App_Themes/Glass/Editors/Loading.gif">
                        </LoadingPanelImage>
                        <ClientSideEvents SelectedIndexChanged="function(s, e) {
	btnMontarAgenda.SetEnabled(true);
}" />
                        <ValidationSettings>
                            <ErrorFrameStyle ImageSpacing="4px">
                                <ErrorTextPaddings PaddingLeft="4px" />
                            </ErrorFrameStyle>
                        </ValidationSettings>
                    </dx:ASPxComboBox>
                    <asp:ObjectDataSource ID="odsConvenio" runat="server" SelectMethod="RetornaConvenios"
                        TypeName="Business.ConvenioBU"></asp:ObjectDataSource>
                </td>
                <td align="left" style="padding-left: 20px" valign="top">
                    <dx:ASPxButton ID="btnMontarAgenda" runat="server" Text="Montar Agenda" ClientEnabled="False"
                        ClientInstanceName="btnMontarAgenda" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                        CssPostfix="Glass" ImagePosition="Right">
                        <ClientSideEvents Click="function(s, e) {
	popDateCalendar.Show();
}" />
                    </dx:ASPxButton>
                </td>
            </tr>
        </table>
        <br />
        <table border="0" cellpadding="2" cellspacing="2" width="100%">
            <tr>
                <td valign="top">
                    <dx:ASPxCallbackPanel ID="cbpGridAgenda" runat="server" ClientInstanceName="cbpGridAgenda"
                        ClientVisible="False" LoadingPanelText="Montando Agenda..." OnCallback="cbpGridAgenda_Callback"
                        Width="100%" CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass">
                        <LoadingPanelImage Url="~/App_Themes/Glass/Web/Loading.gif">
                        </LoadingPanelImage>
                        <PanelCollection>
                            <dx:PanelContent runat="server">
                                <dx:ASPxGridView ID="gdvAgenda" runat="server" ClientInstanceName="gdvAgenda" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                                    CssPostfix="Glass" Width="100%" AutoGenerateColumns="False" OnHtmlDataCellPrepared="gdvAgenda_HtmlDataCellPrepared"
                                    KeyFieldName="Hora" OnHtmlRowPrepared="gdvAgenda_HtmlRowPrepared">
                                    <SettingsBehavior AllowFocusedRow="True" AllowGroup="False" AllowSort="False" EnableRowHotTrack="True" />
                                    <Styles CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass">
                                        <Header ImageSpacing="5px" SortingImageSpacing="5px">
                                        </Header>
                                    </Styles>
                                    <ClientSideEvents RowDblClick="function(s, e) 
{
	var hdnDataConsulta = document.getElementById('hdnDataConsulta');
	hdnDataConsulta.value = lblDataEscolhida.GetText();	
	gdvAgenda.GetRowValues(e.visibleIndex,'Situacao;Hora;Nome;Telefone;Convenio;Servico;Observacao;',validaDadosGridRow);
}" />
                                    <Columns>
                                        <dx:GridViewDataTextColumn Caption="Situação" VisibleIndex="0" Width="40px" FieldName="Situacao"
                                            CellStyle-HorizontalAlign="Center">
                                            <DataItemTemplate>
                                                <asp:Image ID="imgSituacao" runat="server" ImageAlign="Baseline" />
                                            </DataItemTemplate>
                                            <CellStyle HorizontalAlign="Center">
                                            </CellStyle>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Hora" FieldName="Hora" VisibleIndex="1" Width="45px"
                                            CellStyle-HorizontalAlign="Center">
                                            <CellStyle HorizontalAlign="Center">
                                            </CellStyle>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Paciente" FieldName="Nome" VisibleIndex="2" CellStyle-HorizontalAlign="Center">
                                            <CellStyle HorizontalAlign="Center">
                                            </CellStyle>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Telefone" FieldName="Telefone" VisibleIndex="3"
                                            CellStyle-HorizontalAlign="Center">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Convênio" FieldName="Convenio" VisibleIndex="4"
                                            CellStyle-HorizontalAlign="Center">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Serviço" FieldName="Servico" VisibleIndex="5"
                                            CellStyle-HorizontalAlign="Center">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Observação" FieldName="Observacao" VisibleIndex="6"
                                            Width="30px" CellStyle-HorizontalAlign="Center">
                                            <DataItemTemplate>
                                                <asp:HyperLink ID="hlObservacao" runat="server" ImageUrl="~/images/status/blank_status.gif"></asp:HyperLink>
                                            </DataItemTemplate>
                                            <CellStyle HorizontalAlign="Center">
                                            </CellStyle>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Name="colDelete" VisibleIndex="7" Width="40px" CellStyle-HorizontalAlign="Center">
                                            <DataItemTemplate>
                                                <asp:HyperLink ID="hlDelete" runat="server" ImageUrl="~/images/status/blank_status.gif"></asp:HyperLink>
                                            </DataItemTemplate>
                                            <CellStyle HorizontalAlign="Center">
                                            </CellStyle>
                                        </dx:GridViewDataTextColumn>
                                    </Columns>
                                    <SettingsPager Mode="ShowAllRecords">
                                    </SettingsPager>
                                    <Settings ShowGroupButtons="False" />
                                    <Images SpriteCssFilePath="~/App_Themes/Glass/{0}/sprite.css">
                                        <LoadingPanelOnStatusBar Url="~/App_Themes/Glass/GridView/gvLoadingOnStatusBar.gif">
                                        </LoadingPanelOnStatusBar>
                                        <LoadingPanel Url="~/App_Themes/Glass/GridView/Loading.gif">
                                        </LoadingPanel>
                                    </Images>
                                    <ImagesFilterControl>
                                        <LoadingPanel Url="~/App_Themes/Glass/Editors/Loading.gif">
                                        </LoadingPanel>
                                    </ImagesFilterControl>
                                    <StylesEditors>
                                        <CalendarHeader Spacing="1px">
                                        </CalendarHeader>
                                        <ProgressBar Height="25px">
                                        </ProgressBar>
                                    </StylesEditors>
                                </dx:ASPxGridView>
                            </dx:PanelContent>
                        </PanelCollection>
                    </dx:ASPxCallbackPanel>
                </td>
                <td style="width: 130px;" valign="top">
                    <table border="0" cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td valign="middle" style="width: 20px;">
                                <img alt="Marcado" title="Marcado" src="images/status/marcado.jpg" />
                            </td>
                            <td valign="top">
                                <span style="color: #3183a9; font-family: Arial; font-size: 13px; line-height: 22px;">
                                    Marcado</span>
                            </td>
                        </tr>
                        <tr>
                            <td valign="middle" style="width: 20px;">
                                <img alt="Esperando" title="Esperando" src="images/status/esperando.jpg" />
                            </td>
                            <td valign="top">
                                <span style="color: #3183a9; font-family: Arial; font-size: 13px; line-height: 22px;">
                                    Esperando</span>
                            </td>
                        </tr>
                        <tr>
                            <td valign="middle" style="width: 20px;">
                                <img alt="Exames" title="Exames" src="images/status/exame_2.jpg" />
                            </td>
                            <td valign="top">
                                <span style="color: #3183a9; font-family: Arial; font-size: 13px; line-height: 22px;">
                                    Exames</span>
                            </td>
                        </tr>
                        <tr>
                            <td valign="middle" style="width: 20px;">
                                <img alt="Atendido" title="Atendido" src="images/status/atendido.jpg" />
                            </td>
                            <td valign="top">
                                <span style="color: #3183a9; font-family: Arial; font-size: 13px; line-height: 22px;">
                                    Atendido</span>
                            </td>
                        </tr>
                        <tr>
                            <td valign="middle" style="width: 20px;">
                                <img alt="Faltou" title="Faltou" src="images/status/faltou.jpg" />
                            </td>
                            <td valign="top">
                                <span style="color: #3183a9; font-family: Arial; font-size: 13px; line-height: 22px;">
                                    Faltou</span>
                            </td>
                        </tr>
                        <tr>
                            <td valign="middle" style="width: 20px;">
                                <img alt="Cancelado" title="Cancelado" src="images/status/cancelado.jpg" />
                            </td>
                            <td valign="top">
                                <span style="color: #3183a9; font-family: Arial; font-size: 13px; line-height: 22px;">
                                    Cancelado</span>
                            </td>
                        </tr>
                        <tr>
                            <td valign="middle" style="width: 20px;">
                                <img alt="Encaixe" title="Encaixe" src="images/status/encaixe.jpg" />
                            </td>
                            <td valign="top">
                                <span style="color: #3183a9; font-family: Arial; font-size: 13px; line-height: 22px;">
                                    Encaixe</span>
                            </td>
                        </tr>
                        <tr>
                            <td valign="middle" style="width: 20px;">
                                <img alt="Confirmado" title="Confirmado" src="images/status/confirmado.jpg" />
                            </td>
                            <td valign="top">
                                <span style="color: #3183a9; font-family: Arial; font-size: 13px; line-height: 22px;">
                                    Confirmado</span>
                            </td>
                        </tr>
                        <tr>
                            <td valign="middle" style="width: 20px;">
                                <img alt="Transferido" title="Transferido" src="images/status/transferido.jpg" />
                            </td>
                            <td valign="top">
                                <span style="color: #3183a9; font-family: Arial; font-size: 13px; line-height: 22px;">
                                    Transferido</span>
                            </td>
                        </tr>
                        <tr>
                            <td valign="middle" style="width: 20px;">
                                <img alt="Bloqueado" title="Bloqueado" src="images/status/bloqueado.jpg" />
                            </td>
                            <td valign="top">
                                <span style="color: #3183a9; font-family: Arial; font-size: 13px; line-height: 22px;">
                                    Bloqueado</span>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <dx:ASPxPopupControl ID="popObservacoes" runat="server" AppearAfter="100" ClientInstanceName="popObservacoes"
            AllowDragging="true" PopupHorizontalAlign="WindowCenter" HeaderText="Observação"
            CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass" SpriteCssFilePath="~/App_Themes/Glass/{0}/sprite.css"
            PopupVerticalAlign="WindowCenter">
            <ContentCollection>
                <dx:PopupControlContentControl ID="PopupControlContentControl2" runat="server">
                    <dx:ASPxCallbackPanel ID="cbpObservacoes" runat="server" ClientInstanceName="cbpObservacoes"
                        Width="320px" Height="100px" RenderMode="Table" OnCallback="cbpObservacoes_Callback">
                        <PanelCollection>
                            <dx:PanelContent runat="server">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Literal ID="litObservacao" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                </table>
                            </dx:PanelContent>
                        </PanelCollection>
                    </dx:ASPxCallbackPanel>
                </dx:PopupControlContentControl>
            </ContentCollection>
            <ClientSideEvents Shown="popup_Shown" />
        </dx:ASPxPopupControl>
        <dx:ASPxPopupControl ID="popDateCalendar" runat="server" AppearAfter="100" ClientInstanceName="popDateCalendar"
            DisappearAfter="200" EnableAnimation="False" FooterText="" HeaderText="Escolha a Data da Agenda:"
            Height="300px" Modal="True" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="TopSides"
            Width="500px" CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass"
            SpriteCssFilePath="~/App_Themes/Glass/{0}/sprite.css">
            <ContentCollection>
                <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
                    <table border="0" cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td align="left" colspan="2">
                                <!--
                                <div style"display: hidden; color: #3183a9; font-family: Arial; font-size: 13px; line-height: 22px;padding-left: 44px;">
                                    <img alt="Visualizar escala de médicos." src="images/cal_24.png" /><b><span style="display: block; position: relative; top: -20px; left: 30px;"><a onclick="AbrirWindowPadrao('VisualizarEscalasMedicos.aspx?exame=' + cmbCategoria.GetText() + '&tipoExame=' + cmbServicos.GetText() + '&codExame=' + cmbServicos.GetValue())" 
                                        style="text-decoration: none; color: #3183a9; cursor: pointer;">Visualize os dias de atendimento deste exame.</a> </span></b>
                                    
                                </div> -->
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <dx:ASPxCalendar ID="calendarAgenda" runat="server" ClearButtonText="Apagar" ClientInstanceName="calendarAgenda"
                                    CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass" EnableYearNavigation="False"
                                    Font-Names="Trebuchet MS" Font-Size="16px" HighlightWeekends="False" OnDayRender="calendarAgenda_DayRender"
                                    ReadOnly="True" ShowClearButton="False" ShowTodayButton="False" ShowWeekNumbers="False"
                                    SpriteCssFilePath="~/App_Themes/Glass/{0}/sprite.css" TodayButtonText="Hoje"
                                    Width="380px" EnableMonthNavigation="False">
                                    <DayOtherMonthStyle ForeColor="#BBBBBB">
                                    </DayOtherMonthStyle>
                                    <DayStyle ForeColor="#585858" />
                                    <TodayStyle>
                                        <Border BorderStyle="None" />
                                    </TodayStyle>
                                    <FooterStyle Spacing="4px" />
                                    <FastNavStyle MonthYearSpacing="4px">
                                    </FastNavStyle>
                                    <FastNavFooterStyle Spacing="4px">
                                    </FastNavFooterStyle>
                                    <ClientSideEvents SelectionChanged="function(s, e) {
	lblDataConsultada.SetVisible(true);
	cmbMedicos.SetVisible(true);
}" />
                                    <FastNavProperties CancelButtonText="Cancelar" Enabled="False" EnablePopupAnimation="False"
                                        OkButtonText="Selecionar" />
                                    <ValidationSettings>
                                        <ErrorFrameStyle ImageSpacing="4px">
                                            <ErrorTextPaddings PaddingLeft="4px" />
                                        </ErrorFrameStyle>
                                    </ValidationSettings>
                                </dx:ASPxCalendar>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                &nbsp;
                            </td>
                            <td align="right" style="width: 4%">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <div style="float: right; margin-left: 10px">
                                    <dx:ASPxLabel ID="lblLegendaVerde" runat="server"
                                        ClientVisible="True" CssClass="labels" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                                        CssPostfix="Glass" Text="Dia Agendável">
                                    </dx:ASPxLabel>
                                </div>
                                <div style="float: right; width: 20px; height: 18px; border: 1px solid #538a05; background-color: #6d9e27;">
                                    &nbsp;
                                </div>
                            </td>
                            <td align="right">
                                <div style="float:left; margin-left: 20px;">
                                <div style="float: right; margin-left: 10px">
                                    <dx:ASPxLabel ID="lblLegendaVermelha" runat="server"
                                        ClientVisible="True" CssClass="labels" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                                        CssPostfix="Glass" Text="Dia Não-Agendável">
                                    </dx:ASPxLabel>
                                </div>
                                <div style="float: right; width: 20px; height: 18px; border: 1px solid #7d1503; background-color: #c22005;">
                                    &nbsp;
                                </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                &nbsp;
                            </td>
                            <td align="right" style="width: 4%">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="2" style="padding-left: 17px">
                                <dx:ASPxLabel ID="lblDataConsultada" runat="server" ClientInstanceName="lblDataConsultada"
                                    ClientVisible="False" CssClass="labels" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                                    CssPostfix="Glass" Text="Data da Consulta:">
                                </dx:ASPxLabel>
                                <dx:ASPxLabel ID="lblDataEscolhida" runat="server" ClientInstanceName="lblDataEscolhida"
                                    ClientVisible="False" CssClass="labels" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                                    CssPostfix="Glass">
                                </dx:ASPxLabel>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" colspan="2">
                                &nbsp; &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="2" style="padding-left: 18px">
                                <dx:ASPxLabel ID="lblMedico" runat="server" ClientInstanceName="lblMedico" ClientVisible="False"
                                    CssClass="labels" CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass"
                                    Text="Selecione um Médico:">
                                </dx:ASPxLabel>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="2" style="padding-left: 17px">
                                <dx:ASPxComboBox ID="cmbMedicos" runat="server" CallbackPageSize="20" ClientInstanceName="cmbMedicos"
                                    ClientVisible="False" CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass"
                                    DataSourceID="odsMedicos" DropDownWidth="550px" EnableCallbackMode="True" EnableIncrementalFiltering="True"
                                    OnCallback="cmbMedicos_Callback" SpriteCssFilePath="~/App_Themes/Glass/{0}/sprite.css"
                                    TextField="ds_nome" TextFormatString="{0}" ValueField="cd_medicor" ValueType="System.String"
                                    Width="220px">
                                    <LoadingPanelImage Url="~/App_Themes/Glass/Editors/Loading.gif">
                                    </LoadingPanelImage>
                                    <ButtonStyle Width="13px">
                                    </ButtonStyle>
                                    <ValidationSettings>
                                        <ErrorFrameStyle ImageSpacing="4px">
                                            <ErrorTextPaddings PaddingLeft="4px" />
                                        </ErrorFrameStyle>
                                    </ValidationSettings>
                                </dx:ASPxComboBox>
                                <asp:ObjectDataSource ID="odsMedicos" runat="server" SelectMethod="RetornaMedicoByDiaServicoByIdServico"
                                    TypeName="Business.MedicorBU">
                                    <SelectParameters>
                                        <asp:Parameter Name="dtConsulta" Type="DateTime" />
                                        <asp:Parameter Name="codServico" Type="Int32" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                &nbsp;
                            </td>
                            <td align="right" style="width: 4%">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 50%">
                                <dx:ASPxButton ID="btnSalvarData" runat="server" AutoPostBack="False" ClientInstanceName="btnSalvarData"
                                    CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass" Text="Selecionar"
                                    Width="100px">
                                    <ClientSideEvents Click="function(s, e) {

	var data = lblDataEscolhida.GetText();
	lblDataMes.SetVisible(true);
	lblDataConsulta.SetText(lblDataEscolhida.GetText());
	if(data != null &amp;&amp; data != '')
	{
		var hdnIdMedico = document.getElementById('hdnIdMedico');
		hdnIdMedico.value = cmbMedicos.GetValue();
		cbpGridAgenda.SetVisible(true);
		cbpGridAgenda.PerformCallback(cmbMedicos.GetValue() + '#' + data);	
		cmbMedicos.SetVisible(false);
		cmbMedicos.SetText('');
		popDateCalendar.Hide();
	}
}" />
                                </dx:ASPxButton>
                            </td>
                            <td align="left" style="width: 50%">
                                <dx:ASPxButton ID="btnCancelar" runat="server" AutoPostBack="False" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                                    CssPostfix="Glass" Text="Cancelar" Width="100px">
                                    <ClientSideEvents Click="function(s, e) {
	cmbMedicos.SetVisible(false);
	cmbMedicos.SetText('');
	popDateCalendar.Hide();
}" />
                                </dx:ASPxButton>
                            </td>
                        </tr>
                    </table>
                </dx:PopupControlContentControl>
            </ContentCollection>
            <HeaderStyle>
                <Paddings PaddingLeft="10px" PaddingRight="6px" PaddingTop="1px" />
            </HeaderStyle>
        </dx:ASPxPopupControl>
        <dx:ASPxCallback ID="cbDeletaConsulta" runat="server" ClientInstanceName="cbDeletaConsulta"
            OnCallback="cbDeletaConsulta_Callback">
            <ClientSideEvents CallbackComplete="function(s, e) {
	alert('Deleção efetuada com sucesso!');
	var data = lblDataConsulta.GetText();
	var x =	document.getElementById('hdnIdMedico');
	cbpGridAgenda.PerformCallback(x.value + '#' + data);	
}" CallbackError="function(s, e) {
	alert(e.message);
}" />
        </dx:ASPxCallback>
    </div>
</asp:Content>
