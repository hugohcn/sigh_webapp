<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginForm.aspx.cs" Inherits="sighWeb.LoginForm" %>

<%@ Register Assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sistema Integrado de Gerenciamento Hospitalar | Página de Login</title>
</head>
<body>
    <form id="form1" runat="server">
    <img alt="Clínica Dr. Amantino Soares" src="images/logotipo_sigh.jpg" style="position: absolute; top: 50%; left: 50%; margin-top: -185px; margin-left: -80px;" />
    <div style="position: absolute; top: 50%; left: 50%; margin-top: -100px; margin-left: -175px;">
        <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" BackColor="#EBF2F4" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
            CssPostfix="Glass" HeaderText="Login | SIGH WEB" Height="250px" HorizontalAlign="Center"
            SpriteCssFilePath="~/App_Themes/Glass/{0}/sprite.css" Width="350px">
            <LeftEdge>
                <BackgroundImage ImageUrl="~/App_Themes/Glass/Web/rpLeftRightEdge.gif" Repeat="RepeatX"
                    VerticalPosition="bottom" />
            </LeftEdge>
            <ContentPaddings PaddingBottom="10px" PaddingLeft="4px" PaddingTop="10px" />
            <RightEdge>
                <BackgroundImage ImageUrl="~/App_Themes/Glass/Web/rpLeftRightEdge.gif" Repeat="RepeatX"
                    VerticalPosition="bottom" />
            </RightEdge>
            <HeaderRightEdge>
                <BackgroundImage ImageUrl="~/App_Themes/Glass/Web/rpHeaderRightEdge.gif" VerticalPosition="bottom" />
            </HeaderRightEdge>
            <Border BorderColor="#7EACB1" BorderStyle="Solid" BorderWidth="1px" />
            <Content>
                <BackgroundImage ImageUrl="~/App_Themes/Glass/Web/rpContentBack.gif" Repeat="RepeatX"
                    VerticalPosition="bottom" />
            </Content>
            <HeaderLeftEdge>
                <BackgroundImage ImageUrl="~/App_Themes/Glass/Web/rpHeaderLeftEdge.gif" Repeat="RepeatX"
                    VerticalPosition="bottom" />
            </HeaderLeftEdge>
            <HeaderStyle BackColor="White" Height="23px">
                <Paddings PaddingBottom="0px" PaddingLeft="2px" PaddingTop="0px" />
                <BorderBottom BorderStyle="None" />
            </HeaderStyle>
            <BottomEdge BackColor="#D7E9F1">
            </BottomEdge>
            <HeaderContent>
                <BackgroundImage ImageUrl="~/App_Themes/Glass/Web/rpHeaderBack.gif" Repeat="RepeatX"
                    VerticalPosition="bottom" />
            </HeaderContent>
            <NoHeaderTopEdge BackColor="#EBF2F4">
            </NoHeaderTopEdge>
            <PanelCollection>
                <dx:PanelContent runat="server">
                    <table border="0" cellpadding="2" cellspacing="2" width="80%">
                        <tr>
                            <td>
                                Login:
                            </td>
                            <td>
                                <dx:ASPxTextBox ID="txtLogin" runat="server" Width="205px" 
                                    CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass" 
                                    ClientInstanceName="txtLogin">
                                    <ValidationSettings Display="Dynamic" ErrorDisplayMode="Text" ErrorText="*" 
                                        SetFocusOnError="True">
                                        <ErrorFrameStyle ImageSpacing="4px">
                                            <ErrorTextPaddings PaddingLeft="4px" />
                                        </ErrorFrameStyle>
                                        <RequiredField ErrorText="" IsRequired="True" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Senha:
                            </td>
                            <td>
                                <dx:ASPxTextBox ID="txtSenha" runat="server" Width="205px" 
                                    CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass" 
                                    Password="True">
                                    <ValidationSettings Display="Dynamic" ErrorDisplayMode="Text" ErrorText="*" 
                                        SetFocusOnError="True">
                                        <ErrorFrameStyle ImageSpacing="4px">
                                            <ErrorTextPaddings PaddingLeft="4px" />
                                        </ErrorFrameStyle>
                                        <RequiredField ErrorText="" IsRequired="True" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2"  align="center">
                                <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                    <tr>
                                        <td align="left">
                                            <dx:ASPxHyperLink ID="lnkRecuperarSenha" runat="server" Text="Recuperar Senha" 
                                                CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass" 
                                                NavigateUrl="#">
                                                
                                                <ClientSideEvents Click="function(s, e) {
	popRecuperarSenha.Show();
	txtNome_Recuperar_Senha.Focus();
}" />
                                                
                                            </dx:ASPxHyperLink>                                             
                                        </td>
                                        <td align="right">
                                            <dx:ASPxButton ID="btnLogin" runat="server" Text="Login" Width="85px" 
                                                CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass" 
                                                OnClick="btnLogin_Click">
                                            </dx:ASPxButton>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </dx:PanelContent>
            </PanelCollection>
        </dx:ASPxRoundPanel>
    </div>
    <br />
    <div style="text-align: center; color: #3183a9; font-family: Arial; font-size: 10pt; line-height: 22px;
                position: absolute; top: 50%; left: 50%; margin-top: 120px; margin-left: -135px;
    ">
        <span>
            Sistema Integrado de Gerenciamento Hospitalar
        </span>
        <br />
        <span style="font-size: 8.5pt;">
            Desenvolvido por <a style="text-decoration: none; color: #3183a9" href="http://www.vixmidia.com.br" target="_blank">Vixmidia Soluções Web</a>
        </span>
      
    </div>
    <dx:ASPxPopupControl ID="popRecuperarSenha" runat="server" 
        ClientInstanceName="popRecuperarSenha" CloseAction="CloseButton" 
        CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass" 
        FooterText="" HeaderText="Recuperar Senha" Height="200px" Modal="True" 
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" 
        SpriteCssFilePath="~/App_Themes/Glass/{0}/sprite.css" Width="350px" 
        DisappearAfter="800">
        <ContentStyle>
            <Paddings Padding="15px" />
        </ContentStyle>
        <ModalBackgroundStyle BackColor="#666666" Opacity="60">
        </ModalBackgroundStyle>
        <ClientSideEvents CloseButtonClick="function(s, e) {
	txtNome_Recuperar_Senha.SetText('');
	txtEmail.SetText('');
	txtCpf.SetText('');
	txtLogin.Focus();
	popRecuperarSenha.Hide();
}" Closing="function(s, e) {

}" />
        <ContentCollection>
<dx:PopupControlContentControl runat="server">
    <table border="0" cellpadding="2" cellspacing="2" width="100%">
        <tr>
            <td>
                Login:
            </td>
            <td>
                
                <dx:ASPxTextBox ID="txtNome_Recuperar_Senha" 
                    ClientInstanceName="txtNome_Recuperar_Senha" runat="server" 
                    CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass" 
                    Width="200px">
                    <ValidationSettings Display="Dynamic" ErrorDisplayMode="Text" ErrorText="" 
                        ValidationGroup="recuperacao">
                        <ErrorFrameStyle ImageSpacing="4px">
                            <ErrorTextPaddings PaddingLeft="4px" />
                        </ErrorFrameStyle>
                        <RequiredField ErrorText="" IsRequired="True" />
                    </ValidationSettings>
                </dx:ASPxTextBox>
                
            </td>
        </tr>
        <tr>
            <td>
                E-mail:
            </td>
            <td>
                
                <dx:ASPxTextBox ID="txtEmail" ClientInstanceName="txtEmail" runat="server" 
                    CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass" 
                    Width="200px">
                    <ValidationSettings Display="Dynamic" ErrorDisplayMode="Text" ErrorText="" 
                        ValidationGroup="recuperacao" SetFocusOnError="True">
                        <ErrorFrameStyle ImageSpacing="4px">
                            <ErrorTextPaddings PaddingLeft="4px" />
                        </ErrorFrameStyle>
                        <RegularExpression ErrorText="E-mail inválido." 
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                        <RequiredField ErrorText="" IsRequired="True" />
                    </ValidationSettings>
                </dx:ASPxTextBox>
                
            </td>
        </tr>
        <tr>
            <td>
                Cpf:
            </td>
            <td>
                                
                <dx:ASPxTextBox ID="txtCpf" ClientInstanceName="txtCpf" runat="server" 
                    CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass" 
                    Width="200px">
                    <MaskSettings Mask="000\.000\.000-00" />
                    <ValidationSettings Display="Dynamic" ErrorDisplayMode="Text" ErrorText="*" 
                        ValidationGroup="recuperacao">
                        <ErrorFrameStyle ImageSpacing="4px">
                            <ErrorTextPaddings PaddingLeft="4px" />
                        </ErrorFrameStyle>
                        <RequiredField ErrorText="" IsRequired="True" />
                    </ValidationSettings>
                </dx:ASPxTextBox>
                                
            </td>
        </tr>
        <tr>
            <td colspan="2">
             &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <dx:ASPxButton ID="btnEnviar" runat="server" Text="Enviar" Width="100px" 
                    CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass" 
                    OnClick="btnEnviar_Click" ValidationGroup="recuperacao">
                </dx:ASPxButton>
                &nbsp;</td>
        </tr>
    </table>
</dx:PopupControlContentControl>
</ContentCollection>
        <HeaderStyle>
        <Paddings PaddingLeft="10px" PaddingRight="6px" PaddingTop="1px" />
        </HeaderStyle>
    </dx:ASPxPopupControl>
    </form>
</body>
</html>
