<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManterConsultaAgenda.aspx.cs"
    Inherits="sighWeb.ManterConsultaAgenda" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxClasses" TagPrefix="dxw" %>
<%@ Register Assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dxtc" %>
<%@ Register Assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxCallback" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxLoadingPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxHiddenField" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="styles/principal.css" rel="stylesheet" type="text/css" />
    <script src="script/principal.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="header">
            <img id="imgLogotipo" alt="Sistema Integrado de Gerenciamento Hospitalar" src="images/logotipo_sigh.jpg" />
        </div>
        <div class="headerPersonalForm">
            <asp:HiddenField ID="hfIdMedico" runat="server" />
            <br />
            <table width="100%" border="0" cellpadding="2" cellspacing="2">
                <tr>
                    <td align="left" colspan="2">
                        <dx:ASPxLabel ID="lblHora" runat="server" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                            CssPostfix="Glass">
                        </dx:ASPxLabel>
                    </td>
                    <td>
                        <asp:HiddenField ID="idPaciente" runat="server" />
                        <dx:ASPxLabel ID="lblDataApresentacao" runat="server" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                            CssPostfix="Glass" Text="Data da Consulta: ">
                        </dx:ASPxLabel>
                        <dx:ASPxLabel ID="lblDataConsulta" runat="server" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                            CssPostfix="Glass" ClientInstanceName="lblDataConsulta">
                        </dx:ASPxLabel>
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="2">
                        <dx:ASPxHyperLink ID="hlInserirPaciente" runat="server" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                            CssPostfix="Glass" Text="Inserir Paciente" 
                            NavigateUrl="javascript:void(0);" ClientInstanceName="hlInserirPaciente">
                            <ClientSideEvents Click="function(s, e) {
	popPacientes.Show();
}" />
                        </dx:ASPxHyperLink>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="left" colspan="2">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="left" style="width: 10%">
                        <dx:ASPxLabel ID="lblPaciente" runat="server" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                            CssPostfix="Glass" Text="Paciente:" ClientInstanceName="lblPaciente" 
                            ClientVisible="False">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 35%">
                        &nbsp;</td>
                    <td>
                        <dx:ASPxLabel ID="lblTelefone" runat="server" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                            CssPostfix="Glass" Text="Telefone:" ClientInstanceName="lblTelefone" 
                            ClientVisible="False">
                        </dx:ASPxLabel>
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="2">
                        <dx:ASPxLabel ID="lblPacienteNome" runat="server" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                            CssPostfix="Glass" ClientInstanceName="lblPacienteNome">
                        </dx:ASPxLabel>
                    </td>
                    <td>
                        <dx:ASPxLabel ID="lblTelefonePaciente" runat="server" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                            CssPostfix="Glass" ClientInstanceName="lblTelefonePaciente">
                        </dx:ASPxLabel>
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="2">
                        &nbsp; &nbsp;
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="2">
                        <dx:ASPxLabel ID="lblSituacao" runat="server" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                            CssPostfix="Glass" Text="Situação:">
                        </dx:ASPxLabel>
                    </td>
                    <td>
                        <dx:ASPxLabel ID="lblValor" runat="server" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                            CssPostfix="Glass" Text="Valor:">
                        </dx:ASPxLabel>
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="2" valign="top">
                        <dx:ASPxComboBox ID="cmbSituacao" runat="server" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                            CssPostfix="Glass" LoadingPanelText="Carregando..." SpriteCssFilePath="~/App_Themes/Glass/{0}/sprite.css"
                            ValueType="System.String" Width="230px" EnableIncrementalFiltering="True">
                            <Items>
                                <dx:ListEditItem ImageUrl="~/images/status/atendido.jpg" Text="Atendido" Value="3" />
                                <dx:ListEditItem ImageUrl="~/images/status/bloqueado.jpg" Text="Bloqueado" Value="9" />
                                <dx:ListEditItem ImageUrl="~/images/status/cancelado.jpg" Text="Cancelado" Value="5" />
                                <dx:ListEditItem ImageUrl="~/images/status/confirmado.jpg" Text="Confirmado" Value="7" />
                                <dx:ListEditItem ImageUrl="~/images/status/encaixe.jpg" Text="Encaixe" Value="6" />
                                <dx:ListEditItem ImageUrl="~/images/status/esperando.jpg" Text="Esperando" Value="1" />
                                <dx:ListEditItem ImageUrl="~/images/status/exame_2.jpg" Text="Exames" Value="2" />
                                <dx:ListEditItem ImageUrl="~/images/status/faltou.jpg" Text="Faltou" Value="4" />
                                <dx:ListEditItem ImageUrl="~/images/status/marcado.jpg" Text="Marcado" Value="0" />
                                <dx:ListEditItem ImageUrl="~/images/status/transferido.jpg" Text="Transferido" Value="8" />
                            </Items>
                            <ButtonStyle Width="13px">
                            </ButtonStyle>
                            <LoadingPanelImage Url="~/App_Themes/Glass/Editors/Loading.gif">
                            </LoadingPanelImage>
                            <ValidationSettings>
                                <ErrorFrameStyle ImageSpacing="4px">
                                    <ErrorTextPaddings PaddingLeft="4px" />
                                </ErrorFrameStyle>
                            </ValidationSettings>
                        </dx:ASPxComboBox>
                    </td>
                    <td>
                        <dx:ASPxTextBox ID="txtValor" runat="server" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                            CssPostfix="Glass" Width="230px">
                            <ValidationSettings>
                                <ErrorFrameStyle ImageSpacing="4px">
                                    <ErrorTextPaddings PaddingLeft="4px" />
                                </ErrorFrameStyle>
                            </ValidationSettings>
                        </dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="2">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="left" colspan="2">
                        <dx:ASPxLabel ID="lblObservacao" runat="server" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                            CssPostfix="Glass" Text="Observação:">
                        </dx:ASPxLabel>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="left" colspan="3">
                        <dx:ASPxMemo ID="txtObservacao" runat="server" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                            CssPostfix="Glass" EnableViewState="False" Height="100px" NullText="Insira uma observação."
                            Width="585px">
                            <ValidationSettings>
                                <ErrorFrameStyle ImageSpacing="4px">
                                    <ErrorTextPaddings PaddingLeft="4px" />
                                </ErrorFrameStyle>
                            </ValidationSettings>
                            <NullTextStyle ForeColor="Silver">
                            </NullTextStyle>
                        </dx:ASPxMemo>
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="3">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="3">
                        <div style="float: left;">
                            <dx:ASPxButton ID="btnSalvar" runat="server" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                                CssPostfix="Glass" Text="Salvar" Width="100px" AutoPostBack="False">
                                <ClientSideEvents Click="function(s, e) {
	cbSalvarConsulta.PerformCallback();
}" />
                            </dx:ASPxButton>
                        </div>
                        <div style="float: left; margin-left: 10px; text-align: left;">
                            <dx:ASPxButton ID="btnCancelar" runat="server" AutoPostBack="False" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                                CssPostfix="Glass" Text="Cancelar" Width="100px">
                                <ClientSideEvents Click="function(s, e) {
	window.close();
}" />
                            </dx:ASPxButton>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <dx:ASPxPopupControl ID="popPacientes" runat="server" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
        CssPostfix="Glass" HeaderText="Inserir/Buscar Pacientes" SpriteCssFilePath="~/App_Themes/Glass/{0}/sprite.css"
        Width="550px" AppearAfter="100" ClientInstanceName="popPacientes" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="TopSides" 
        AllowDragging="True">
        <ModalBackgroundStyle BackColor="#333333" Opacity="60">
        </ModalBackgroundStyle>
        <ClientSideEvents Shown="function(s, e) {
	txtCpf.Focus();
}" />
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <dx:ASPxCallbackPanel ID="cbpBuscaPaciente" runat="server" ClientInstanceName="cbpBuscaPaciente"
                    LoadingPanelText="Carregando..." Width="100%" OnCallback="cbpBuscaPaciente_Callback">
                    <ClientSideEvents EndCallback="function(s, e) {
	
	
}" CallbackError="function(s, e) 
{
	
}" />
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent1" runat="server">
                            <table width="100%" border="0" cellpadding="2" cellspacing="2">
                                <tr>
                                    <td colspan="2">
                                        <div style="text-align: justify; color: #3183a9; font-family: Arial; font-size: 12px; line-height: 22px;">
                                            <span>
                                                Aviso: <i>Efetue a busca pelo paciente informando nome ou cpf, caso o mesmo não seja encontrado em nossa base de dados cadastre-o.</i>
                                            </span>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="width: 50%;">
                                        <dx:ASPxLabel ID="lblCpf" runat="server" 
                                            CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass" 
                                            Text="Informe o C.P.F.:">
                                        </dx:ASPxLabel>
                                    </td>
                                    <td style="width: 50%;">
                                        <dx:ASPxLabel ID="lblNomePaciente" runat="server" 
                                            CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass" 
                                            Text="Informe o Nome do Paciente:">
                                        </dx:ASPxLabel>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="210px">
                                        <dx:ASPxTextBox ID="txtCpf" runat="server" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                                            CssPostfix="Glass" Width="200px" ClientInstanceName="txtCpf">
                                            <MaskSettings Mask="000\.000\.000-00" ShowHints="True" />
                                            <MaskHintStyle Wrap="True">
                                            </MaskHintStyle>
                                            <ValidationSettings Display="Dynamic" ErrorText="" ValidationGroup="paciente" SetFocusOnError="True">
                                                <ErrorFrameStyle ImageSpacing="4px">
                                                    <ErrorTextPaddings PaddingLeft="4px" />
                                                </ErrorFrameStyle>
                                                <RegularExpression ErrorText="" />
                                                <RequiredField ErrorText="" IsRequired="True" />
                                            </ValidationSettings>
                                        </dx:ASPxTextBox>
                                        </td>
                                    <td valign="top">
                                        <dx:ASPxTextBox ID="txtNomePaciente" runat="server" 
                                            ClientInstanceName="txtNomePaciente" 
                                            CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass" 
                                            Width="200px">
                                            <ValidationSettings>
                                                <ErrorFrameStyle ImageSpacing="4px">
                                                    <ErrorTextPaddings PaddingLeft="4px" />
                                                </ErrorFrameStyle>
                                            </ValidationSettings>
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style3">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        <dx:ASPxButton ID="btnPesquisar" runat="server" AutoPostBack="False" 
                                            CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass" 
                                            Text="Pesquisar" Width="100px" AccessKey="1">
                                            <ClientSideEvents Click="function(s, e) {
	var cpf = txtCpf.GetText();
	var nome = txtNomePaciente.GetText();

	if(cpf == '' || cpf == '___.___.___-__' &amp;&amp; nome == '')
	{
		alert('Erro: Dados inválidos.');
		return;
	}
	
	gdvResultadoPesquisa.SetVisible(true);
	gdvResultadoPesquisa.PerformCallback(cpf + '#' + nome);
}" />
                                        </dx:ASPxButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td >
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <div style="overflow: auto; height: 260px">
                                        <dx:ASPxGridView ID="gdvResultadoPesquisa" runat="server" 
                                            AutoGenerateColumns="False" ClientInstanceName="gdvResultadoPesquisa" 
                                            ClientVisible="False" CssFilePath="~/App_Themes/Glass/{0}/styles.css" 
                                            CssPostfix="Glass" 
                                            OnCustomCallback="gdvResultadoPesquisa_CustomCallback" Width="100%" 
                                            OnRowInserting="gdvResultadoPesquisa_RowInserting" 
                                            KeyFieldName="cd_paciente">
                                            <SettingsBehavior AllowFocusedRow="True" EnableRowHotTrack="True" />
                                            <Columns>
                                                <dx:GridViewDataTextColumn Caption="Código" FieldName="cd_paciente" 
                                                    VisibleIndex="0">
                                                    <EditFormSettings Visible="False" />
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Paciente" FieldName="ds_nome" 
                                                    VisibleIndex="1">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings Display="Dynamic" EnableCustomValidation="True" 
                                                            ErrorText="" SetFocusOnError="True">
                                                            <RequiredField ErrorText="" IsRequired="True" />
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                    <EditFormSettings Caption="Nome: " />
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="E-mail" FieldName="ds_email" 
                                                    VisibleIndex="2">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings Display="Dynamic" EnableCustomValidation="True" 
                                                            ErrorText="" SetFocusOnError="True">
                                                            <RegularExpression ErrorText="E-mail inválido." 
                                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                                                            <RequiredField ErrorText="" IsRequired="True" />
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                    <EditFormSettings Caption="E-mail:" />
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Telefone" VisibleIndex="3" 
                                                    CellStyle-HorizontalAlign="Center" FieldName="ds_telefone1">
                                                    <PropertiesTextEdit>
                                                        <MaskSettings Mask="(99) 0000-0000" />
                                                    <ValidationSettings Display="Dynamic" EnableCustomValidation="True" 
                                                            ErrorText="" SetFocusOnError="True">
                                                    
                                                            <RequiredField ErrorText="" IsRequired="True" />
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                    <EditFormSettings Caption="Telefone:" />

<CellStyle HorizontalAlign="Center"></CellStyle>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Cpf" FieldName="ds_cpf" Visible="False" 
                                                    VisibleIndex="4">
                                                    <PropertiesTextEdit>
                                                        
                                                    <MaskSettings Mask="000\.000\.000-00" />
                                                    <ValidationSettings Display="Dynamic" EnableCustomValidation="True" 
                                                            ErrorText="" SetFocusOnError="True">
                                                    
                                                            
                                                        <RequiredField ErrorText="" IsRequired="True" /></ValidationSettings></PropertiesTextEdit>
                                                    <EditFormSettings Caption="Cpf:" Visible="True" />
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption=" " Name="colSelecionarPaciente" 
                                                    VisibleIndex="4" Width="40px">
                                                    <EditFormSettings Visible="False" />
                                                    <DataItemTemplate>
                                                        <asp:HyperLink ID="hlSelecionarPaciente" runat="server" 
                                                            ImageUrl="~/images/impt_16.png" 
                                                            
                                                            
                                                            
                                                            NavigateUrl="javascript:hlInserirPaciente.SetText('Alterar Paciente');lblTelefone.SetVisible(true);lblPaciente.SetVisible(true);gdvResultadoPesquisa.GetRowValues(gdvResultadoPesquisa.GetFocusedRowIndex(), 'cd_paciente;ds_nome;ds_email;ds_telefone1', selectPaciente);"></asp:HyperLink>
                                                    </DataItemTemplate>
                                                    <CellStyle HorizontalAlign="Center">
                                                    </CellStyle>
                                                </dx:GridViewDataTextColumn>
                                            </Columns>
                                            <SettingsPager NumericButtonCount="5" Visible="False" Mode="ShowAllRecords">
                                                <Summary AllPagesText="Páginas: {0} - {1} ({2} itens)" 
                                                    Text="Página {0} de {1} ({2} itens)" />
                                            </SettingsPager>
                                            <SettingsEditing 
                                                PopupEditFormHorizontalAlign="WindowCenter" PopupEditFormModal="True" 
                                                PopupEditFormVerticalAlign="WindowCenter" />
                                            <SettingsText CommandCancel="Cancelar" CommandClearFilter="Apagar" 
                                                CommandDelete="Excluir" CommandEdit="Inserir" CommandNew="Inserir" 
                                                CommandSelect="Selecionar" CommandUpdate="Inserir" 
                                                EmptyDataRow="Sua pesquisa não retornou nenhum resultado." />
                                            <SettingsLoadingPanel Text="Carregando..." />
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
                                            <Styles CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass">
                                                <Header ImageSpacing="5px" SortingImageSpacing="5px">
                                                </Header>
                                            </Styles>
                                            <StylesEditors>
                                                <CalendarHeader Spacing="1px">
                                                </CalendarHeader>
                                                <ProgressBar Height="25px">
                                                </ProgressBar>
                                            </StylesEditors>
                                        </dx:ASPxGridView>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="width: 100px;">
                                    
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        &nbsp;</td>
                                </tr>
                            </table>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxCallbackPanel>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <HeaderStyle>
            <Paddings PaddingLeft="10px" PaddingRight="6px" PaddingTop="1px" />
        </HeaderStyle>
        <HeaderImage Url="~/images/group_16.png">
        </HeaderImage>
    </dx:ASPxPopupControl>
    <dx:ASPxCallback ID="cbSalvarConsulta" runat="server" ClientInstanceName="cbSalvarConsulta"
        OnCallback="cbSalvarConsulta_Callback">
        <ClientSideEvents BeginCallback="function(s, e) {
	loadingPanel.Show();
}" CallbackComplete="function(s, e) {
	loadingPanel.Hide();
	if(confirm('Operação foi realizada com sucesso! Você deseja fechar esta janela?'))
		window.close();
	var x = document.getElementById('hfIdMedico');
	window.opener.cbpGridAgenda.PerformCallback(x.value + '#' + lblDataConsulta.GetText());
}" CallbackError="function(s, e) 
{
	
}" />
    </dx:ASPxCallback>
    <dx:ASPxLoadingPanel ID="loadingPanel" runat="server" ClientInstanceName="loadingPanel"
        CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass" EnableViewState="False"
        Modal="True" Text="Carrengando...">
        <Image Url="~/App_Themes/Glass/Web/Loading.gif">
        </Image>
    </dx:ASPxLoadingPanel>
    </form>
</body>
</html>
