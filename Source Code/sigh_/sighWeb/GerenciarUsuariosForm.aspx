<%@ Page Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true"
    CodeBehind="GerenciarUsuariosForm.aspx.cs" Inherits="sighWeb.UsuariosForm" Title="Sistema Integrado de Gerenciamento Hospitalar | Usuários do Sistema" %>

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
                <dx:ASPxButton ID="ASPxButton1" runat="server" AutoPostBack="False" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                    CssPostfix="Glass" Text="Novo Usuário" Width="120px">
                    <ClientSideEvents Click="function(s, e) {
	gdvUsuarios.AddNewRow();
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
                <dx:ASPxGridView ID="gdvUsuarios" runat="server" ClientInstanceName="gdvUsuarios"
                    DataSourceID="odsUsuarios" Width="100%" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                    CssPostfix="Glass" KeyFieldName="cpf" AutoGenerateColumns="False" OnHtmlDataCellPrepared="gdvUsuarios_HtmlDataCellPrepared"
                    OnRowDeleting="gdvUsuarios_RowDeleting" OnRowInserting="gdvUsuarios_RowInserting"
                    OnRowUpdating="gdvUsuarios_RowUpdating">
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
                        <dx:GridViewDataTextColumn Caption="CPF" FieldName="cpf" VisibleIndex="0">
                            <PropertiesTextEdit MaxLength="14" ClientInstanceName="txtCpf">
                                <MaskSettings Mask="000\.000\.000-00" />
                                <ValidationSettings Display="Dynamic" EnableCustomValidation="True" 
                                    ErrorText="">
                                    <RequiredField ErrorText="" IsRequired="True" />
                                </ValidationSettings>
                            </PropertiesTextEdit>
                            <EditFormSettings Caption="Cpf:" Visible="True" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataComboBoxColumn Caption="Tipo de Usuário" 
                            FieldName="id_tipo_usuario" VisibleIndex="1">
                            <PropertiesComboBox DataSourceID="odsTiposUsuarios" TextField="ds_tipo_usuario" 
                                ValueField="id_tipo_usuario" ValueType="System.String">
                                <ValidationSettings Display="Dynamic" EnableCustomValidation="True">
                                    <RequiredField ErrorText="" IsRequired="True" />
                                </ValidationSettings>
                            </PropertiesComboBox>
                            <EditFormSettings Caption="Tipo de Usuário:" />
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataTextColumn Caption="Nome" FieldName="nomeUsuario" 
                            VisibleIndex="2" Name="txtNome">
                            <PropertiesTextEdit>
                                <ValidationSettings Display="Dynamic" EnableCustomValidation="True" 
                                    ErrorText="">
                                    <RequiredField ErrorText="" IsRequired="True" />
                                </ValidationSettings>
                            </PropertiesTextEdit>
                            <EditFormSettings Caption="Nome:" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Telefone" FieldName="telefone1" 
                            Visible="False" VisibleIndex="3">
                            <PropertiesTextEdit>
                                <MaskSettings Mask="(99) 9999-9999" />
                            </PropertiesTextEdit>
                            <EditFormSettings Caption="Telefone:" Visible="True" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Celular" VisibleIndex="4" 
                            FieldName="telefone2">
                            <PropertiesTextEdit MaxLength="14">
                                <MaskSettings  Mask="(99) 9999-9999" />
                            </PropertiesTextEdit>
                            <EditFormSettings Caption="Celular:" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="E-mail" FieldName="emailUsuario" 
                            VisibleIndex="3">
                            <PropertiesTextEdit>
                                <ValidationSettings Display="Dynamic" EnableCustomValidation="True" 
                                    ErrorText="">
                                    <RegularExpression ErrorText="E-mail inválido!" 
                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                                    <RequiredField ErrorText="" IsRequired="True" />
                                </ValidationSettings>
                            </PropertiesTextEdit>
                            <EditFormSettings Caption="E-mail:" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataCheckColumn Caption="Situação" FieldName="is_ativo" 
                            VisibleIndex="5">
                            <EditFormSettings Caption="Situação:" />
                            <DataItemTemplate>
                                <asp:Image ID="imgStatus" runat="server" ImageAlign="Baseline" />    
                            </DataItemTemplate>
                        </dx:GridViewDataCheckColumn>
                        <dx:GridViewDataTextColumn Caption="Login" FieldName="login" VisibleIndex="6">
                            <PropertiesTextEdit>
                                <ValidationSettings Display="Dynamic" EnableCustomValidation="True" 
                                    ErrorText="">
                                    <RequiredField ErrorText="" IsRequired="True" />
                                </ValidationSettings>
                            </PropertiesTextEdit>
                            <EditFormSettings Caption="Login:" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Senha" FieldName="senha" Visible="False" 
                            VisibleIndex="8">
                            <PropertiesTextEdit>
                                <ValidationSettings Display="Dynamic" EnableCustomValidation="True" 
                                    ErrorText="">
                                    <RequiredField ErrorText="" IsRequired="True" />
                                </ValidationSettings>
                            </PropertiesTextEdit>
                            <EditFormSettings Caption="Senha:" Visible="True" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Último Acesso" FieldName="dt_ultimo_acesso" 
                            VisibleIndex="7">
                            <EditFormSettings Caption="Último Acesso: " Visible="False" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataComboBoxColumn Caption="Instituição" FieldName="id_instituicao" 
                            VisibleIndex="8">
                            <PropertiesComboBox DataSourceID="odsInstituicao" DropDownStyle="DropDown" 
                                EnableIncrementalFiltering="True" TextField="NOME" ValueField="ID_INSTITUICAO" 
                                ValueType="System.String">
                                <ValidationSettings Display="Dynamic" EnableCustomValidation="True">
                                    <RequiredField ErrorText="" IsRequired="True" />
                                </ValidationSettings>
                            </PropertiesComboBox>
                            <EditFormSettings Caption="Instituição:" />
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataCheckColumn Caption="Usuário é Médico?" FieldName="is_medico" 
                            VisibleIndex="9">
                            <editformsettings caption="É Médico?" />
                            <dataitemtemplate>
                                <asp:Label ID="lblIsmedico" runat="server"></asp:Label>
                            </dataitemtemplate>
                        </dx:GridViewDataCheckColumn>
                        <dx:GridViewCommandColumn VisibleIndex="10">
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
                <asp:ObjectDataSource ID="odsUsuarios" runat="server" SelectMethod="RetornaUsuariosSistema"
                    TypeName="Business.UsuarioBU">
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsTiposUsuarios" runat="server" DataObjectTypeName="TipoUsuario"
                    SelectMethod="RetornaTiposUsuarios" TypeName="Business.UsuarioBU"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsInstituicao" runat="server" 
                    SelectMethod="RetornaInstituicoes" TypeName="Business.InstituicaoBU">
                </asp:ObjectDataSource>
            </td>
        </tr>
    </table>
</asp:Content>
