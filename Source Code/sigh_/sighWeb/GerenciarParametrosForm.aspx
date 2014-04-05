<%@ Page Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true"
    CodeBehind="GerenciarParametrosForm.aspx.cs" Inherits="sighWeb.GerenciarParametrosForm"
    Title="Clínica Radiológica Dr. Amantino Soares | Cadastrar Parâmetros do Sistema" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxClasses" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" width="100%" cellpadding="2" cellspacing="2">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <dx:ASPxButton ID="btnAdicionarParametro" runat="server" AutoPostBack="False" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                    CssPostfix="Glass" Text="Novo Parâmetro" Width="130px">
                    <ClientSideEvents Click="function(s, e) {
	gdvParametros.AddNewRow();
}" />
                </dx:ASPxButton>
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
                <dx:ASPxGridView ID="gdvParametros" runat="server" ClientInstanceName="gdvParametros"
                    Width="100%" CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass"
                    AutoGenerateColumns="False" DataSourceID="odsParametros" KeyFieldName="id_parametro"
                    OnRowInserting="gdvParametros_RowInserting" OnRowDeleting="gdvParametros_RowDeleting"
                    OnRowUpdating="gdvParametros_RowUpdating">
                    <Styles CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass">
                        <Header ImageSpacing="5px" SortingImageSpacing="5px">
                        </Header>
                    </Styles>
                    <SettingsLoadingPanel Text="Carregando..." />
                    <SettingsPager ShowSeparators="True" AlwaysShowPager="True" PageSize="20">
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
                        PopupEditFormModal="True" PopupEditFormWidth="800px" />
                    <SettingsText CommandCancel="Cancelar" CommandClearFilter="Apagar" CommandDelete="Excluir"
                        CommandEdit="Editar" CommandNew="Inserir" CommandSelect="Selecionar" CommandUpdate="Inserir"
                        ConfirmDelete="Deseja realmente excluir este parâmetro?" EmptyDataRow="Não existem parâmetros registrados no sistema."
                        PopupEditFormCaption="Editar/Inserir Usuário" />
                    <Columns>
                        <dx:GridViewDataTextColumn Caption="Identificador do Parâmetro" FieldName="id_parametro"
                            VisibleIndex="0" Width="70px" CellStyle-HorizontalAlign="Center">
                            <EditFormSettings Caption="Chave do Parâmetro:" Visible="False" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Parâmetro" FieldName="key_parametro" VisibleIndex="1">
                            <EditFormSettings Caption="Parâmetro:" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Valor do Parâmetro" FieldName="value_parametro"
                            VisibleIndex="2">
                            <EditFormSettings Caption="Valor do Parâmetro:" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewCommandColumn VisibleIndex="3">
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
                <asp:ObjectDataSource ID="odsParametros" runat="server" SelectMethod="RetornaTodosParametros"
                    TypeName="Business.ParametersBU"></asp:ObjectDataSource>
            </td>
        </tr>
    </table>
</asp:Content>
