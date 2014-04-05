<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContatoAdministradorForm.aspx.cs"
    Inherits="sighWeb.ContatoAdministradorForm" %>

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
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sistema Integrado de Gerenciamento Hospitalar | Dúvidas / Sugestões </title>
    <link href="styles/principal.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="header">
            <img id="imgLogotipo" alt="Clínica Radiológica Dr. Amantino Soares" src="images/logotipo_login.png" />
        </div>
        <br />
        <div style="padding: 10px;">
            <dxtc:ASPxPageControl ID="carTabPage" runat="server" ActiveTabIndex="0" EnableHierarchyRecreation="True"
                Width="100%" CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass"
                LoadingPanelText="Carregando..." TabSpacing="5px">
                <LoadingPanelImage Url="~/App_Themes/Glass/Web/Loading.gif">
                </LoadingPanelImage>
                <ContentStyle>
                    <Border BorderColor="#4986A2" />
                </ContentStyle>
                <TabPages>
                    <dxtc:TabPage Text="Dúvidas/Sugestões">
                        <ContentCollection>
                            <dxw:ContentControl runat="server">
                                <div class="headerPersonalForm">
                                    <table width="100%" border="0" cellpadding="1" cellspacing="1">
                                        <tr>
                                            <td style="width: 287px;">
                                                <dx:ASPxLabel ID="lblNome" CssClass="labels" runat="server" Text="Nome">
                                                </dx:ASPxLabel>
                                            </td>
                                            <td>
                                                <dx:ASPxLabel ID="lblTipoContato" CssClass="labels" runat="server" Text="Tipo de Contato">
                                                </dx:ASPxLabel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 287px;">
                                                <dx:ASPxTextBox ID="txtNome" runat="server" Width="200px" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                                                    CssPostfix="Glass">
                                                    <ValidationSettings>
                                                        <ErrorFrameStyle ImageSpacing="4px">
                                                            <ErrorTextPaddings PaddingLeft="4px" />
                                                        </ErrorFrameStyle>
                                                    </ValidationSettings>
                                                </dx:ASPxTextBox>
                                            </td>
                                            <td>
                                                <dx:ASPxComboBox ID="cmbTipoContato" runat="server" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                                                    CssPostfix="Glass" LoadingPanelText="Carregando..." SpriteCssFilePath="~/App_Themes/Glass/{0}/sprite.css"
                                                    Width="200px" ClientInstanceName="cmbTipoContato">
                                                    <Items>
                                                        <dx:ListEditItem Text="Sugestão" Value="0" />
                                                        <dx:ListEditItem Text="Reclamação" Value="1" />
                                                        <dx:ListEditItem Text="Dúvida" Value="2" />
                                                    </Items>
                                                    <LoadingPanelImage Url="~/App_Themes/Glass/Editors/Loading.gif">
                                                    </LoadingPanelImage>
                                                    <ButtonStyle Width="13px">
                                                    </ButtonStyle>
                                                    <ValidationSettings Display="Dynamic" ErrorText="">
                                                        <ErrorFrameStyle ImageSpacing="4px">
                                                            <ErrorTextPaddings PaddingLeft="4px" />
                                                        </ErrorFrameStyle>
                                                        <RequiredField ErrorText="" IsRequired="True" />
                                                    </ValidationSettings>
                                                </dx:ASPxComboBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 287px;">
                                                &nbsp;
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 287px;">
                                                <dx:ASPxLabel ID="lblEmail" CssClass="labels" runat="server" Text="E-mail">
                                                </dx:ASPxLabel>
                                            </td>
                                            <td>
                                                <dx:ASPxLabel ID="lblCelular" CssClass="labels" runat="server" Text="Celular">
                                                </dx:ASPxLabel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 287px;">
                                                <dx:ASPxTextBox ID="txtEmail" runat="server" Width="200px" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                                                    CssPostfix="Glass">
                                                    <ValidationSettings Display="Dynamic" ErrorText="">
                                                        <ErrorFrameStyle ImageSpacing="4px">
                                                            <ErrorTextPaddings PaddingLeft="4px" />
                                                        </ErrorFrameStyle>
                                                        <RegularExpression ErrorText="E-mail inválido!" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                                                        <RequiredField ErrorText="" IsRequired="True" />
                                                    </ValidationSettings>
                                                </dx:ASPxTextBox>
                                            </td>
                                            <td>
                                                <dx:ASPxTextBox ID="txtCelular" runat="server" Width="200px" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                                                    CssPostfix="Glass">
                                                    <MaskSettings ErrorText="" Mask="(99) 9999-9999" PromptChar="_" />
                                                </dx:ASPxTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 287px;">
                                                &nbsp;
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 287px;">
                                                <dx:ASPxLabel ID="lblTelefone" CssClass="labels" runat="server" Text="Telefone">
                                                </dx:ASPxLabel>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 287px;">
                                                <dx:ASPxTextBox ID="txtTelefone" runat="server" Width="200px" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                                                    CssPostfix="Glass">
                                                    <MaskSettings ErrorText="" Mask="(99) 9999-9999" PromptChar="_" />
                                                </dx:ASPxTextBox>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 287px;">
                                                &nbsp;
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 287px;">
                                                <dx:ASPxLabel ID="lblMensagem" runat="server" CssClass="labels" Text="Mensagem">
                                                </dx:ASPxLabel>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <dx:ASPxMemo ID="txtMensagem" runat="server" Height="100px" Width="490px" CssClass="memoBox"
                                                    CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass" 
                                                    ClientInstanceName="txtMensagem">
                                                    <ValidationSettings Display="Dynamic" EnableCustomValidation="True" ErrorText="">
                                                        <ErrorFrameStyle ImageSpacing="4px">
                                                            <ErrorTextPaddings PaddingLeft="4px" />
                                                        </ErrorFrameStyle>
                                                        <RequiredField ErrorText="" IsRequired="True" />
                                                    </ValidationSettings>
                                                </dx:ASPxMemo>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </dxw:ContentControl>
                        </ContentCollection>
                    </dxtc:TabPage>
                </TabPages>
                <Paddings PaddingLeft="0px" />
            </dxtc:ASPxPageControl>
        </div>
        <div class="headerPersonalForm">
            <table width="100%" border="0" cellpadding="2" cellspacing="2">
                <tr>
                    <td align="right">
                        <dx:ASPxButton ID="btnSalvar" runat="server" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                            CssPostfix="Glass" Text="Salvar" Width="100px" AutoPostBack="False">
                            <ClientSideEvents Click="function(s, e) 
{
	var tipoContato = cmbTipoContato.GetValue();
    var mensagem = txtMensagem.GetText();
	if (tipoContato == null &amp;&amp; mensagem == '')
	{
    	return;
	}else
	{
		cbSaveData.PerformCallback();
	}
}" />
                        </dx:ASPxButton>
                    </td>
                    <td style="width: 10%" align="right">
                        <dx:ASPxButton ID="txtCancelar" runat="server" AutoPostBack="False" ClientInstanceName="txtCancelar"
                            CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass" Text="Cancelar"
                            Width="100px" CausesValidation="False">
                            <ClientSideEvents Click="function(s, e) {
	this.window.close();
}" />
                        </dx:ASPxButton>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <dx:ASPxCallback ID="cbSaveData" runat="server" ClientInstanceName="cbSaveData" 
        oncallback="cbSaveData_Callback">
        <ClientSideEvents BeginCallback="function(s, e) {
	lpSave.Show();
}" CallbackComplete="function(s, e) {
	alert('Contato efetuado com sucesso!');
	lpSave.Hide();
	window.close();	
}" />
    </dx:ASPxCallback>
    <dx:ASPxLoadingPanel ID="lpSave" runat="server" ClientInstanceName="lpSave" 
        CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass" Modal="True" 
        Text="Enviando...">
        <Image Url="~/App_Themes/Glass/Web/Loading.gif">
        </Image>
    </dx:ASPxLoadingPanel>
    </form>
</body>
</html>
