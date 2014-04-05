<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManterNiveisGruposForm.aspx.cs"
    Inherits="sighWeb.ManterNiveisGruposForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Clínica Radiológica Dr. Amantino Soares | Manter Níveis de Acesso</title>
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
            <table border="0" width="100%" cellpadding="2" cellspacing="2">
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <dxe:ASPxButton ID="btnNovoNivel" runat="server" AutoPostBack="False" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                            CssPostfix="Glass" Text="Novo Nível" Width="120px" ClientInstanceName="btnNovoNivel">
                            <ClientSideEvents Click="function(s, e) {
	windowNovoNivel.Show();	                    
}" />
                        </dxe:ASPxButton>
                    </td>
                    <td>
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
                    <td colspan="2">
                        <dx:ASPxGridView ID="gdvNiveis" runat="server" ClientInstanceName="gdvNiveis" Width="100%"
                            CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass" AutoGenerateColumns="False"
                            OnRowUpdating="gdvNiveis_RowUpdating" OnHtmlDataCellPrepared="gdvNiveis_HtmlDataCellPrepared"
                            KeyFieldName="id_niveis_permissao" 
                            oncustomcallback="gdvNiveis_CustomCallback" 
                            oncustomerrortext="gdvNiveis_CustomErrorText" 
                            onrowdeleting="gdvNiveis_RowDeleting" DataSourceID="odsPermissoes">
                            <SettingsBehavior EnableRowHotTrack="True" />
                            <Styles CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass">
                                <Header ImageSpacing="5px" SortingImageSpacing="5px">
                                </Header>
                            </Styles>
                            <SettingsLoadingPanel Text="Carregando..." />
                            <SettingsPager AlwaysShowPager="True" PageSize="20" Visible="False">
                                <Summary AllPagesText="Páginas: {0} - {1} ({2} itens)" Text="Página {0} de {1} ({2} itens)" />
                            </SettingsPager>
                            <ImagesFilterControl>
                                <LoadingPanel Url="~/App_Themes/Glass/Editors/Loading.gif">
                                </LoadingPanel>
                            </ImagesFilterControl>
                            <Images SpriteCssFilePath="~/App_Themes/Glass/{0}/sprite.css">
                                <LoadingPanelOnStatusBar Url="~/App_Themes/Glass/GridView/gvLoadingOnStatusBar.gif">
                                </LoadingPanelOnStatusBar>
                                <LoadingPanel Url="~/App_Themes/Glass/GridView/Loading.gif">
                                </LoadingPanel>
                            </Images>
                            <SettingsEditing PopupEditFormAllowResize="True" PopupEditFormHorizontalAlign="WindowCenter"
                                PopupEditFormModal="True" PopupEditFormWidth="700px" Mode="PopupEditForm" />
                            <SettingsText CommandCancel="Cancelar" CommandClearFilter="Apagar" CommandDelete="Excluir"
                                CommandEdit="Editar" CommandNew="Inserir" CommandSelect="Selecionar" CommandUpdate="Inserir"
                                ConfirmDelete="Deseja realmente excluir este nível de visualização?" EmptyDataRow="Não existem níveis registrados para este grupo de usuários."
                                PopupEditFormCaption="Editar/Inserir Níveis de Visualização" />
                            <ClientSideEvents CustomButtonClick="function(s, e) {
	
}                     " EndCallback="function(s, e) {
	chkPermissaoVisualizacao.SetChecked(false);
	chkPermissaoCriacao.SetChecked(false);
	chkPermissaoAtualizacao.SetChecked(false);
	chkPermissaoRemocao.SetChecked(false);
	cmbFuncionalidade. SetSelectedIndex(-1);
	windowNovoNivel.Hide();
}" />
                            <Columns>
                                <dx:GridViewDataTextColumn FieldName="id_menu" Caption="Identificador do Menu" VisibleIndex="0"
                                    Width="60px" CellStyle-HorizontalAlign="Center" ReadOnly="True">
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Funcionalidade" FieldName="funcionalidade" VisibleIndex="1">
                                    <EditFormSettings Visible="False" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataCheckColumn Caption="Situação" FieldName="situacao" VisibleIndex="2">
                                    <EditFormSettings Caption="Permitir Visualização?" />
                                    <DataItemTemplate>
                                        <asp:Image ID="imgStatus" runat="server" ImageAlign="Baseline" />
                                    </DataItemTemplate>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewDataCheckColumn Caption="Permissão de Criação" FieldName="criacao" VisibleIndex="3"
                                    CellStyle-HorizontalAlign="Center">
                                    <EditFormSettings Caption="Permitir Criação?" />
                                    <DataItemTemplate>
                                        <asp:Image ID="imgCriacao" runat="server" ImageAlign="Baseline" />
                                    </DataItemTemplate>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewDataCheckColumn Caption="Permissão de Atualização" FieldName="atualizacao"
                                    VisibleIndex="4" CellStyle-HorizontalAlign="Center">
                                    <EditFormSettings Caption="Permitir Atualização?" />
                                    <DataItemTemplate>
                                        <asp:Image ID="imgAtualizacao" runat="server" ImageAlign="Baseline" />
                                    </DataItemTemplate>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewDataCheckColumn Caption="Permissão de Remoção" FieldName="remocao" VisibleIndex="5"
                                    CellStyle-HorizontalAlign="Center">
                                    <EditFormSettings Caption="Permitir Remoção?" />
                                    <DataItemTemplate>
                                        <asp:Image ID="imgRemocao" runat="server" ImageAlign="Baseline" />
                                    </DataItemTemplate>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewCommandColumn VisibleIndex="6">
                                    <EditButton Visible="True">
                                    </EditButton>
                                    <DeleteButton Visible="True">
                                    </DeleteButton>
                                </dx:GridViewCommandColumn>
                            </Columns>
                            <StylesEditors>
                                <CalendarHeader Spacing="1px">
                                </CalendarHeader>
                                <ProgressBar Height="25px">
                                </ProgressBar>
                            </StylesEditors>
                        </dx:ASPxGridView>
                        <asp:ObjectDataSource ID="odsPermissoes" runat="server" 
                            SelectMethod="ObterPermissoesGrupoUsuario" TypeName="Business.PermissaoMenuBU">
                            <SelectParameters>
                                <asp:QueryStringParameter Name="idGrupoUsuario" 
                                    QueryStringField="idGrupoUsuario" Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <dx:ASPxPopupControl ID="windowNovoNivel" runat="server" ClientInstanceName="windowNovoNivel"
        CloseAction="CloseButton" CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass"
        DisappearAfter="200" FooterText="" HeaderText="Novo Nível de Visualização" Height="320px"
        Modal="True" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter"
        ResizingMode="Postponed" SpriteCssFilePath="~/App_Themes/Glass/{0}/sprite.css"
        Width="420px">
        <ModalBackgroundStyle BackColor="#666666" Opacity="60">
        </ModalBackgroundStyle>
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <table width="100%" border="0" cellpadding="2" cellspacing="2">
                    <tr>
                        <td colspan="2">
                            <div style="text-align: left; color: #3183a9; font-family: Arial; font-size: 13px;
                                line-height: 22px; padding-left: 5px;">
                                <i><span>Funcionalidades:</span></i>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <dxe:ASPxComboBox ID="cmbFuncionalidade" runat="server" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                                CssPostfix="Glass" DataSourceID="odsFuncionalidades" LoadingPanelText="Carregando..."
                                SpriteCssFilePath="~/App_Themes/Glass/{0}/sprite.css" TextField="ds_nome_menu"
                                ValueField="id_menu" ValueType="System.Int32" Width="200px" 
                                ClientInstanceName="cmbFuncionalidade">
                                <LoadingPanelImage Url="~/App_Themes/Glass/Editors/Loading.gif">
                                </LoadingPanelImage>
                                <ButtonStyle Width="13px">
                                </ButtonStyle>
                                <ValidationSettings>
                                    <ErrorFrameStyle ImageSpacing="4px">
                                        <ErrorTextPaddings PaddingLeft="4px" />
                                    </ErrorFrameStyle>
                                </ValidationSettings>
                            </dxe:ASPxComboBox>
                            <asp:ObjectDataSource ID="odsFuncionalidades" runat="server" SelectMethod="ObterSubMenusSistema"
                                TypeName="Business.PermissaoMenuBU"></asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <div style="text-align: left; color: #3183a9; font-family: Arial; font-size: 13px;
                                line-height: 22px; padding-left: 5px;">
                                <i><span>Permissões:</span></i>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <dxe:ASPxCheckBox ID="chkPermissaoVisualizacao" runat="server" 
                                ClientInstanceName="chkPermissaoVisualizacao" 
                                CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass" 
                                Text="Permissão de Visualização">
                            </dxe:ASPxCheckBox>
                        </td>
                        <td>
                            <dxe:ASPxCheckBox ID="chkPermissaoCriacao" runat="server" 
                                ClientInstanceName="chkPermissaoCriacao" 
                                CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass" 
                                Text="Permissão de Criação">
                            </dxe:ASPxCheckBox>
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
                        <td>
                            <dxe:ASPxCheckBox ID="chkPermissaoAtualizacao" runat="server" 
                                ClientInstanceName="chkPermissaoAtualizacao" 
                                CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass" 
                                Text="Permissão de Atualização">
                            </dxe:ASPxCheckBox>
                        </td>
                        <td>
                            <dxe:ASPxCheckBox ID="chkPermissaoRemocao" runat="server" 
                                ClientInstanceName="chkPermissaoRemocao" 
                                CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass" 
                                Text="Permissão de Remoção">
                            </dxe:ASPxCheckBox>
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
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <dxe:ASPxButton ID="btnEnviar" runat="server" AutoPostBack="False" 
                                CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass" 
                                Text="Enviar" Width="100px">
                                <ClientSideEvents Click="function(s, e) {
	gdvNiveis.PerformCallback();
}" />
                            </dxe:ASPxButton>
                        </td>
                        <td>
                            <dxe:ASPxButton ID="btnCancelar" runat="server" AutoPostBack="False" 
                                CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass" 
                                Text="Cancelar" Width="100px">
                                <ClientSideEvents Click="function(s, e) {
	chkPermissaoVisualizacao.SetChecked(false);
	chkPermissaoCriacao.SetChecked(false);
	chkPermissaoAtualizacao.SetChecked(false);
	chkPermissaoRemocao.SetChecked(false);
	cmbFuncionalidade. SetSelectedIndex(-1);
	windowNovoNivel.Hide();
}" />
                            </dxe:ASPxButton>
                        </td>
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
