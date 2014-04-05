<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManterPerfilForm.aspx.cs"
    Inherits="sighWeb.ManterPerfilForm" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxClasses" TagPrefix="dxw" %>
<%@ Register Assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dxtc" %>
<%@ Register assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab" namespace="DevExpress.Web.ASPxCallback" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab" namespace="DevExpress.Web.ASPxLoadingPanel" tagprefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sistema Integrado de Gerenciamento Hospitalar | Alterar Meus Dados</title>
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
                Width="100%" CssFilePath="~/App_Themes/Glass/{0}/styles.css" 
                CssPostfix="Glass" LoadingPanelText="Carregando..." TabSpacing="5px">
                <LoadingPanelImage Url="~/App_Themes/Glass/Web/Loading.gif">
                </LoadingPanelImage>
                <ContentStyle>
                    <Border BorderColor="#4986A2" />
                </ContentStyle>
                <TabPages>
                    <dxtc:TabPage Text="Dados Pessoais">
                        <ContentCollection>
                            <dxw:ContentControl runat="server">
                                <div class="headerPersonalForm">
                                    <table width="100%" border="0" cellpadding="1" cellspacing="1">
                                        <tr>
                                            <td style="width: 287px;">
                                                CPF:
                                            </td>
                                            <td>
                                                Tipo de Usuário:
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 287px;">
                                                <dx:ASPxTextBox ID="txtCpf" runat="server" Width="200px" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                                                    CssPostfix="Glass" Enabled="False">
                                                    <ValidationSettings>
                                                        <ErrorFrameStyle ImageSpacing="4px">
                                                            <ErrorTextPaddings PaddingLeft="4px" />
                                                        </ErrorFrameStyle>
                                                    </ValidationSettings>
                                                </dx:ASPxTextBox>
                                            </td>
                                            <td>
                                                <dx:ASPxTextBox ID="txtTipoUsuario" runat="server" Width="200px" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                                                    CssPostfix="Glass" Enabled="False">
                                                    <ValidationSettings>
                                                        <ErrorFrameStyle ImageSpacing="4px">
                                                            <ErrorTextPaddings PaddingLeft="4px" />
                                                        </ErrorFrameStyle>
                                                    </ValidationSettings>
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
                                                Nome:
                                            </td>
                                            <td>
                                                E-mail:
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 287px;">
                                                <dx:ASPxTextBox ID="txtNome" runat="server" Width="200px" 
                                                    CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass" 
                                                    ClientInstanceName="txtNome">
                                                    <ValidationSettings Display="Dynamic" EnableCustomValidation="True" ErrorText="*" SetFocusOnError="True">
                                                        <ErrorFrameStyle ImageSpacing="4px">
                                                            <ErrorTextPaddings PaddingLeft="4px" />
                                                        </ErrorFrameStyle>
                                                        <RequiredField ErrorText="*" IsRequired="True" />
                                                    </ValidationSettings>
                                                </dx:ASPxTextBox>
                                            </td>
                                            <td>
                                                <dx:ASPxTextBox ID="txtEmail" runat="server" Width="200px" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                                                    CssPostfix="Glass" ClientInstanceName="txtEmail">
                                                    <ValidationSettings Display="Dynamic" ErrorText="*" EnableCustomValidation="True" ErrorDisplayMode="ImageWithTooltip" 
                                                        SetFocusOnError="True">
                                                        <ErrorFrameStyle ImageSpacing="4px">
                                                            <ErrorTextPaddings PaddingLeft="4px" />
                                                        </ErrorFrameStyle>
                                                        <RegularExpression ErrorText="E-mail inválido!" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                                                        <RequiredField ErrorText="*" IsRequired="True" />
                                                    </ValidationSettings>
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
                                                Telefone:
                                            </td>
                                            <td>
                                                Celular:
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 287px;">
                                                <dx:ASPxTextBox ID="txtTelefone" runat="server" Width="200px" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                                                    CssPostfix="Glass">
                                                    <ValidationSettings Display="Dynamic" ErrorText="*">
                                                        <ErrorFrameStyle ImageSpacing="4px">
                                                            <ErrorTextPaddings PaddingLeft="4px" />
                                                        </ErrorFrameStyle>
                                                        <RequiredField ErrorText="" IsRequired="True" />
                                                    </ValidationSettings>
                                                    <MaskSettings ErrorText="*" Mask="(99) 9999-9999" PromptChar=" " />
                                                </dx:ASPxTextBox>
                                            </td>
                                            <td>
                                                <dx:ASPxTextBox ID="txtCelular" runat="server" Width="200px" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                                                    CssPostfix="Glass">
                                                    <ValidationSettings>
                                                        <ErrorFrameStyle ImageSpacing="4px">
                                                            <ErrorTextPaddings PaddingLeft="4px" />
                                                        </ErrorFrameStyle>
                                                    </ValidationSettings>
                                                    <MaskSettings ErrorText="*" Mask="(99) 9999-9999" PromptChar=" " />
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
                                                Instituição:
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 287px;">
                                                <dx:ASPxTextBox ID="txtInstituicao" runat="server" Width="200px" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                                                    CssPostfix="Glass" ClientEnabled="False">
                                                    <ValidationSettings>
                                                        <ErrorFrameStyle ImageSpacing="4px">
                                                            <ErrorTextPaddings PaddingLeft="4px" />
                                                        </ErrorFrameStyle>
                                                    </ValidationSettings>
                                                </dx:ASPxTextBox>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </dxw:ContentControl>
                        </ContentCollection>
                    </dxtc:TabPage>
                    <dxtc:TabPage Text="Dados de Acesso">
                        <ContentCollection>
                            <dxw:ContentControl ID="ContentControl1" runat="server">
                                <div class="headerPersonalForm">
                                    <table width="100%" border="0" cellpadding="1" cellspacing="1">
                                        <tr>
                                            <td style="width: 287px;">
                                                Login:
                                            </td>
                                            <td>
                                                Senha:
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 287px;">
                                                <dx:ASPxTextBox ID="txtLogin" runat="server" Width="200px" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                                                    CssPostfix="Glass" Enabled="False">
                                                    <ValidationSettings Display="Dynamic" ErrorText="*">
                                                        <ErrorFrameStyle ImageSpacing="4px">
                                                            <ErrorTextPaddings PaddingLeft="4px" />
                                                        </ErrorFrameStyle>
                                                        <RequiredField ErrorText="" IsRequired="True" />
                                                    </ValidationSettings>
                                                    <MaskSettings PromptChar=" " />
                                                </dx:ASPxTextBox>
                                            </td>
                                            <td>
                                                <dx:ASPxTextBox ID="txtSenha" runat="server" Width="200px" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                                                    CssPostfix="Glass" Password="False">
                                                    <ValidationSettings Display="Dynamic" ErrorText="*">
                                                        <ErrorFrameStyle ImageSpacing="4px">
                                                            <ErrorTextPaddings PaddingLeft="4px" />
                                                        </ErrorFrameStyle>
                                                        <RegularExpression ErrorText="" />
                                                        <RequiredField ErrorText="" IsRequired="True" />
                                                    </ValidationSettings>
                                                </dx:ASPxTextBox>
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
        <br />
        <div class="headerPersonalForm">
            <table width="100%" border="0" cellpadding="2" cellspacing="2">
                <tr>
                    <td align="right">
                        
                        <dx:ASPxButton ID="btnSalvar" runat="server" 
                            CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass" 
                            Text="Salvar" Width="100px" AutoPostBack="False">
                            <ClientSideEvents Click="function(s, e) 
{
	var nome = txtNome.GetText();
    var email = txtEmail.GetText();

	if (nome == '' &amp;&amp; email == '')
	{
		alert('Os campos nome e e-mail são obrigatórios.');
    	return;
	}else
	{
		cbSave.PerformCallback();
	}
}" />
                        </dx:ASPxButton>
                        
                    </td>
                    <td style="width: 10%" align="right">
                        
                        <dx:ASPxButton ID="txtCancelar" runat="server" AutoPostBack="False" 
                            ClientInstanceName="txtCancelar" 
                            CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass" 
                            Text="Cancelar" Width="100px">
                            <ClientSideEvents Click="function(s, e) {
	this.window.close();
}" />
                        </dx:ASPxButton>
                        
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <dx:ASPxCallback ID="cbSave" runat="server" ClientInstanceName="cbSave" 
        oncallback="cbSave_Callback">
        <ClientSideEvents BeginCallback="function(s, e) {
	loadingPanelSave.Show();
}" CallbackComplete="function(s, e) {
	loadingPanelSave.Hide();
}" EndCallback="function(s, e) {
	alert('Perfil atualizado com sucesso!');
	this.window.close();
}" CallbackError="function(s, e) {
}" />
    </dx:ASPxCallback>
    <dx:ASPxLoadingPanel ID="loadingPanelSave" runat="server" 
        ClientInstanceName="loadingPanelSave" 
        CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass" 
        HorizontalAlign="Center" Modal="True" Text="Atualizando usuário..." 
        VerticalAlign="Middle">
        <Image Url="~/App_Themes/Glass/Web/Loading.gif">
        </Image>
    </dx:ASPxLoadingPanel>
    </form>
</body>
</html>
