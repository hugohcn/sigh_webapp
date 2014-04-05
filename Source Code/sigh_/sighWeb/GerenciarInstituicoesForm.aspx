<%@ Page Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true"
    CodeBehind="GerenciarInstituicoesForm.aspx.cs" Inherits="sighWeb.GerenciarInstituicoesForm"
    Title="Sistema Integrado de Gerenciamento Hospitalar | Instituições do Sistema" %>

<%@ Register Assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dx" %>
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
                <dx:ASPxButton ID="btnNovaInstituicao" runat="server" AutoPostBack="False" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                    CssPostfix="Glass" Text="Nova Instituição" Width="130px">
                    <ClientSideEvents Click="function(s, e) {
	gdvInstituicoes.AddNewRow();
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
                <dx:ASPxGridView ID="gdvInstituicoes" runat="server" ClientInstanceName="gdvInstituicoes"
                    DataSourceID="odsInstituicoes" Width="100%" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                    CssPostfix="Glass" KeyFieldName="id_instituicao" AutoGenerateColumns="False"
                    OnRowDeleting="gdvInstituicoes_RowDeleting" OnRowInserting="gdvInstituicoes_RowInserting"
                    OnRowUpdating="gdvInstituicoes_RowUpdating">
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
                        ConfirmDelete="Deseja realmente excluir este usuário?" EmptyDataRow="Não existem usuários registrados no sistema."
                        PopupEditFormCaption="Editar/Inserir Usuário" />
                    <Columns>
                        <dx:GridViewDataTextColumn Caption="Identificador" FieldName="id_instituicao" 
                            ReadOnly="True" VisibleIndex="0">
                            <EditFormSettings Caption="Identificador:" Visible="True" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Cnpj" FieldName="cnpj_instituicao" 
                            VisibleIndex="1">
                            <PropertiesTextEdit MaxLength="18">
                                <MaskSettings Mask="00\.000\.000/0000-00" />
                                <ValidationSettings Display="Dynamic" EnableCustomValidation="True" 
                                    ErrorText="">
                                    <RequiredField ErrorText="" IsRequired="True" />
                                </ValidationSettings>
                            </PropertiesTextEdit>
                            <EditFormSettings Caption="Cnpj:" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Nome" FieldName="nome" VisibleIndex="2">
                            <PropertiesTextEdit>
                                <ValidationSettings Display="Dynamic" EnableCustomValidation="True" 
                                    ErrorText="" SetFocusOnError="True">
                                    <RequiredField ErrorText="" IsRequired="True" />
                                </ValidationSettings>
                            </PropertiesTextEdit>
                            <EditFormSettings Caption="Nome:" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Endereço" FieldName="endereco" 
                            Visible="False" VisibleIndex="3">
                            <PropertiesTextEdit>
                                <ValidationSettings Display="Dynamic" EnableCustomValidation="True" 
                                    ErrorText="" SetFocusOnError="True">
                                    <RequiredField ErrorText="" IsRequired="True" />
                                </ValidationSettings>
                            </PropertiesTextEdit>
                            <EditFormSettings Caption="Endereço:" Visible="True" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Número" FieldName="numero" Visible="False" 
                            VisibleIndex="3">
                            <PropertiesTextEdit>
                                <ValidationSettings Display="Dynamic" EnableCustomValidation="True" 
                                    ErrorText="" SetFocusOnError="True">
                                    <RequiredField ErrorText="" IsRequired="True" />
                                </ValidationSettings>
                            </PropertiesTextEdit>
                            <EditFormSettings Caption="Número:" Visible="True" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Bairro" FieldName="bairro" Visible="False" 
                            VisibleIndex="3">
                            <PropertiesTextEdit>
                                <ValidationSettings Display="Dynamic" EnableCustomValidation="True" 
                                    ErrorText="">
                                    <RequiredField ErrorText="" IsRequired="True" />
                                </ValidationSettings>
                            </PropertiesTextEdit>
                            <EditFormSettings Caption="Bairro:" Visible="True" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Cidade" FieldName="cidade" Visible="False" 
                            VisibleIndex="3">
                            <PropertiesTextEdit>
                                <ValidationSettings Display="Dynamic" EnableCustomValidation="True" 
                                    ErrorText="" SetFocusOnError="True">
                                    <RequiredField ErrorText="" IsRequired="True" />
                                </ValidationSettings>
                            </PropertiesTextEdit>
                            <EditFormSettings Caption="Cidade:" Visible="True" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Estado" FieldName="estado" Visible="False" 
                            VisibleIndex="3">
                            <PropertiesTextEdit>
                                <ValidationSettings Display="Dynamic" EnableCustomValidation="True" 
                                    ErrorText="">
                                    <RequiredField ErrorText="" IsRequired="True" />
                                </ValidationSettings>
                            </PropertiesTextEdit>
                            <EditFormSettings Caption="Estado:" Visible="True" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Cep" FieldName="cep" Visible="False" 
                            VisibleIndex="3">
                            <PropertiesTextEdit MaxLength="10">
                                <MaskSettings Mask="00\.000-000" />
                                <ValidationSettings Display="Dynamic" EnableCustomValidation="True" 
                                    ErrorText="" SetFocusOnError="True">
                                    <RequiredField ErrorText="" IsRequired="True" />
                                </ValidationSettings>
                            </PropertiesTextEdit>
                            <EditFormSettings Caption="Cep:" Visible="True" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataDateColumn Caption="Data de Registro" FieldName="dt_registro" 
                            VisibleIndex="3">
                            <PropertiesDateEdit DisplayFormatString="">
                                <ValidationSettings Display="Dynamic" EnableCustomValidation="True" 
                                    ErrorText="">
                                    <RequiredField ErrorText="" IsRequired="True" />
                                </ValidationSettings>
                            </PropertiesDateEdit>
                            <EditFormSettings Caption="Data de Registro:" />
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataTextColumn Caption="Responsável" FieldName="nome_responsavel" 
                            VisibleIndex="4">
                            <PropertiesTextEdit>
                                <ValidationSettings Display="Dynamic" EnableCustomValidation="True" 
                                    ErrorText="" SetFocusOnError="True">
                                    <RequiredField ErrorText="" IsRequired="True" />
                                </ValidationSettings>
                            </PropertiesTextEdit>
                            <EditFormSettings Caption="Responsável:" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Função" FieldName="funcao" VisibleIndex="5">
                            <PropertiesTextEdit>
                                <ValidationSettings Display="Dynamic" EnableCustomValidation="True" 
                                    ErrorText="" SetFocusOnError="True">
                                    <RequiredField ErrorText="" IsRequired="True" />
                                </ValidationSettings>
                            </PropertiesTextEdit>
                            <EditFormSettings Caption="Função:" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="E-mail" FieldName="email" VisibleIndex="6">
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
                        <dx:GridViewDataTextColumn Caption="Telefone da Instituição" 
                            FieldName="telefone" VisibleIndex="7">
                            <PropertiesTextEdit>
                                <MaskSettings Mask="(99) 0000-0000" />
                                <ValidationSettings Display="Dynamic" EnableCustomValidation="True" 
                                    ErrorText="" SetFocusOnError="True">
                                    <RequiredField ErrorText="" IsRequired="True" />
                                </ValidationSettings>
                            </PropertiesTextEdit>
                            <EditFormSettings Caption="Telefone:" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewCommandColumn VisibleIndex="8">
                            <EditButton Visible="True">
                            </EditButton>
                            <DeleteButton Visible="True">
                            </DeleteButton>
                        </dx:GridViewCommandColumn>
                    </Columns>
                    <Settings ShowFilterRow="True" />
                    <StylesEditors>
                        <CalendarHeader Spacing="1px">
                        </CalendarHeader>
                        <ProgressBar Height="25px">
                        </ProgressBar>
                    </StylesEditors>
                </dx:ASPxGridView>
                <asp:ObjectDataSource ID="odsInstituicoes" runat="server" SelectMethod="RetornaInstituicoes"
                    TypeName="Business.InstituicaoBU"></asp:ObjectDataSource>
            </td>
        </tr>
    </table>
</asp:Content>
