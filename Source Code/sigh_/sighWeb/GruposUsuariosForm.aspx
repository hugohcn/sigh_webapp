<%@ Page Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true"
    CodeBehind="GruposUsuariosForm.aspx.cs" Inherits="sighWeb.GruposUsuariosForm"
    Title="Sistema Integrado de Gerenciamento Hospitalar | Grupos de Usuários do Sistema" %>

<%@ Register Assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" width="100%" cellpadding="2" cellspacing="2">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <dx:ASPxButton ID="btnNovoGrupo" runat="server" AutoPostBack="False" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                    CssPostfix="Glass" Text="Novo Grupo" Width="120px">
                    <ClientSideEvents Click="function(s, e) {
	gdvGrupos.AddNewRow();
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
                <dx:ASPxGridView ID="gdvGrupos" runat="server" ClientInstanceName="gdvGrupos"
                    DataSourceID="odsTiposUsuarios" Width="100%" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                    CssPostfix="Glass" KeyFieldName="id_tipo_usuario" 
                    AutoGenerateColumns="False" onrowdeleting="gdvGrupos_RowDeleting" 
                    onrowinserting="gdvGrupos_RowInserting" onrowupdating="gdvGrupos_RowUpdating">
                    <SettingsBehavior EnableRowHotTrack="True" />
                    <Styles CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass">
                        <Header ImageSpacing="5px" SortingImageSpacing="5px">
                        </Header>
                    </Styles>
                    <SettingsPager AlwaysShowPager="True" PageSize="20">
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
                    <SettingsEditing PopupEditFormAllowResize="True" 
                        PopupEditFormHorizontalAlign="WindowCenter" PopupEditFormShowHeader="False" />
                    <SettingsText CommandCancel="Cancelar" CommandClearFilter="Apagar" CommandDelete="Excluir"
                        CommandEdit="Editar" CommandNew="Inserir" CommandSelect="Selecionar" CommandUpdate="Inserir"
                        ConfirmDelete="Deseja realmente excluir este usuário?" EmptyDataRow="Não existem usuários registrados no sistema."
                        PopupEditFormCaption="Editar/Inserir Usuário" />
                    <ClientSideEvents CustomButtonClick="function(s, e) {
                            if(e.buttonID == 'btnEditarNiveis')
                            {
                                var key = gdvGrupos.GetRowKey(e.visibleIndex);
                                
                                AbrirWindowPadrao('ManterNiveisGruposForm.aspx?idGrupoUsuario=' + key);
                            }
                        }" />
                    <Columns>
                       
                        <dx:GridViewDataTextColumn Caption="Identificador" FieldName="id_tipo_usuario" 
                            VisibleIndex="0" Width="100px" CellStyle-HorizontalAlign="Center">
                            <EditFormSettings Visible="False" />
<CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Nome" FieldName="ds_tipo_usuario" 
                            VisibleIndex="1">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewCommandColumn VisibleIndex="3" Width="150px" Caption=" ">
                            <EditButton Visible="True">
                            </EditButton>
                            <DeleteButton Visible="True">
                            </DeleteButton>
                        </dx:GridViewCommandColumn>
                       
                        <dx:GridViewCommandColumn ButtonType="Image" Caption="Editar Níveis" 
                            VisibleIndex="3" Width="35px">
                            <ClearFilterButton Visible="True">
                            </ClearFilterButton>
                            <CustomButtons>
                                <dx:GridViewCommandColumnCustomButton ID="btnEditarNiveis">
                                    <Image AlternateText="Editar Níveis" Url="~/images/smicn_16.png">
                                    </Image>
                                </dx:GridViewCommandColumnCustomButton>
                            </CustomButtons>
                            <CellStyle HorizontalAlign="Center">
                            </CellStyle>
                        </dx:GridViewCommandColumn>
                       
                    </Columns>
                    <StylesEditors>
                        <CalendarHeader Spacing="1px">
                        </CalendarHeader>
                        <ProgressBar Height="25px">
                        </ProgressBar>
                    </StylesEditors>
                </dx:ASPxGridView>
                
                <asp:ObjectDataSource ID="odsTiposUsuarios" runat="server" DataObjectTypeName="TipoUsuario"
                    SelectMethod="RetornaTiposUsuarios" TypeName="Business.UsuarioBU"></asp:ObjectDataSource>
            </td>
        </tr>
    </table>
    <br />
            <div style="text-align: left; color: #3183a9; font-family: Arial; font-size: 13px;
                line-height: 22px; padding-left: 5px;">
                <i><span>Atenção: Após realizar a inserção de um novo grupo, faça a edição dos níveis para liberar o acesso às informações do sistema.</span></i>
            </div>
</asp:Content>
