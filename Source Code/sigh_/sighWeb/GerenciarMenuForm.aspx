<%@ Page Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true"
    CodeBehind="GerenciarMenuForm.aspx.cs" Inherits="sighWeb.GerenciarMenuForm" Title="Clínica Radiológica Dr. Amantino Soares | Gerenciar Menu do Sistema" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dxtc" %>
<%@ Register Assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxClasses" TagPrefix="dxw" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" width="100%" cellpadding="2" cellspacing="2">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <dx:ASPxButton ID="btnNovoNivel" runat="server" AutoPostBack="False" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                    CssPostfix="Glass" Text="Novo Menu" Width="120px" 
                    ClientInstanceName="btnNovoNivel">
                    <ClientSideEvents Click="function(s, e) {
	                    gdvMenuSistema.AddNewRow();
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
                <dx:ASPxGridView ID="gdvMenuSistema" runat="server" ClientInstanceName="gdvMenuSistema"
                    Width="100%" CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass"
                    AutoGenerateColumns="False" DataSourceID="odsMenu" 
                    OnHtmlDataCellPrepared="gdvMenuSistema_HtmlDataCellPrepared" 
                    KeyFieldName="id_menu" onrowinserting="gdvMenuSistema_RowInserting" 
                    onrowdeleting="gdvMenuSistema_RowDeleting" 
                    onrowupdating="gdvMenuSistema_RowUpdating">
                    <SettingsBehavior EnableRowHotTrack="True" />
                    <Styles CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass">
                        <Header ImageSpacing="5px" SortingImageSpacing="5px">
                        </Header>
                    </Styles>
                    <SettingsLoadingPanel Text="Carregando..." />
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
                    <SettingsEditing PopupEditFormAllowResize="True" PopupEditFormHorizontalAlign="WindowCenter"
                        PopupEditFormModal="True" PopupEditFormWidth="800px" Mode="PopupEditForm" />
                    <SettingsText CommandCancel="Cancelar" CommandClearFilter="Apagar" CommandDelete="Excluir"
                        CommandEdit="Editar" CommandNew="Inserir" CommandSelect="Selecionar" CommandUpdate="Inserir"
                        ConfirmDelete="Deseja realmente excluir este menu?" EmptyDataRow="Não existem menus registrados no sistema."
                        PopupEditFormCaption="Editar/Inserir Menu" />
                    <ClientSideEvents CustomButtonClick="function(s, e) {
                           
                        }" />
                    <Columns>
                        <dx:GridViewDataTextColumn Caption="Identificador" FieldName="id_menu" 
                            VisibleIndex="0" Name="identificador">
                            <EditFormSettings Visible="False" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Nome" FieldName="ds_nome_menu" 
                            VisibleIndex="1">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataCheckColumn Caption="Situação" FieldName="is_ativo" 
                            VisibleIndex="2">
                            <EditFormSettings Caption="Menu Ativo?" />
                            <DataItemTemplate>
                                <asp:Image ID="imgStatus" runat="server" ImageAlign="Baseline" />
                            </DataItemTemplate>
                        </dx:GridViewDataCheckColumn>
                        <dx:GridViewDataComboBoxColumn Caption="Menu Pai" FieldName="id_menu_pai" Visible="False"
                            VisibleIndex="2">
                            <PropertiesComboBox ValueType="System.String">
                            </PropertiesComboBox>
                            <EditFormSettings Visible="False" />
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataTextColumn Caption="Endereço da Página" FieldName="path" 
                            VisibleIndex="3">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewCommandColumn VisibleIndex="4">
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
                    <Templates>
                        <DetailRow>
                            <dx:ASPxButton ID="btnNovoMenu" runat="server" AutoPostBack="False" 
                                ClientInstanceName="btnNovoMenu" 
                                CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass" 
                                Text="Novo Sub-Menu" Width="130px">
                                <ClientSideEvents Click="function(s, e) {
	                    gdvSubMenuSistema.AddNewRow();
                    }" />
                            </dx:ASPxButton>
                            <br />
                            <dx:ASPxGridView ID="gdvSubMenuSistema" runat="server" 
                                AutoGenerateColumns="False" ClientInstanceName="gdvSubMenuSistema" 
                                CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass" 
                                DataSourceID="odsSubMenu" KeyFieldName="id_menu" 
                                onbeforeperformdataselect="gdvSubMenuSistema_BeforePerformDataSelect" 
                                OnHtmlDataCellPrepared="gdvSubMenuSistema_HtmlDataCellPrepared" 
                                onrowinserting="gdvSubMenuSistema_RowInserting" Width="100%" 
                                onrowdeleting="gdvSubMenuSistema_RowDeleting" 
                                onrowupdating="gdvSubMenuSistema_RowUpdating">
                                <SettingsBehavior EnableRowHotTrack="True" />
                                <Styles CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass">
                                    <Header ImageSpacing="5px" SortingImageSpacing="5px">
                                    </Header>
                                </Styles>
                                <SettingsLoadingPanel Text="Carregando..." />
                                <SettingsPager AlwaysShowPager="True" PageSize="20" Visible="False">
                                    <Summary AllPagesText="Páginas: {0} - {1} ({2} itens)" 
                                        Text="Página {0} de {1} ({2} itens)" />
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
                                <SettingsEditing Mode="PopupEditForm" PopupEditFormAllowResize="True" 
                                    PopupEditFormHorizontalAlign="WindowCenter" PopupEditFormModal="True" 
                                    PopupEditFormWidth="800px" />
                                <SettingsText CommandCancel="Cancelar" CommandClearFilter="Apagar" 
                                    CommandDelete="Excluir" CommandEdit="Editar" CommandNew="Inserir" 
                                    CommandSelect="Selecionar" CommandUpdate="Inserir" 
                                    ConfirmDelete="Deseja realmente excluir este menu?" 
                                    EmptyDataRow="Não existem menus registrados no sistema." 
                                    PopupEditFormCaption="Editar/Inserir Menu" />
                                <ClientSideEvents CustomButtonClick="function(s, e) {
                           
                        }" />
                                <Columns>
                                    <dx:GridViewDataTextColumn Caption="Identificador" FieldName="id_menu" 
                                        VisibleIndex="0">
                                        <EditFormSettings Visible="False" />
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Nome" FieldName="ds_nome_menu" 
                                        VisibleIndex="1">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataCheckColumn Caption="Situação" FieldName="is_ativo" 
                                        VisibleIndex="2">
                                        <EditFormSettings Caption="Menu Ativo?" />
                                        <DataItemTemplate>
                                            <asp:Image ID="imgSubMenuStatus" runat="server" ImageAlign="Baseline" />
                                        </DataItemTemplate>
                                    </dx:GridViewDataCheckColumn>
                                    <dx:GridViewDataComboBoxColumn Caption="Menu Pai" FieldName="id_menu_pai" 
                                        Visible="False" VisibleIndex="2">
                                        <PropertiesComboBox ValueType="System.String"></PropertiesComboBox>
                                        <EditFormSettings Visible="False" />
                                    </dx:GridViewDataComboBoxColumn>
                                    <dx:GridViewDataTextColumn Caption="Endereço da Página" FieldName="path" 
                                        VisibleIndex="3">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewCommandColumn VisibleIndex="4">
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
                                <Templates>
                                    <EditForm>
                                        <div style="padding: 4px 4px 3px 4px">
                                            <dxtc:ASPxPageControl ID="pageControl" runat="server" ActiveTabIndex="0" 
                                                CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass" 
                                                Height="140px" LoadingPanelText="Carregando..." TabSpacing="0px" Width="100%">
                                                <LoadingPanelImage Url="~/App_Themes/Glass/Web/Loading.gif">
                                                </LoadingPanelImage>
                                                <ContentStyle>
                                                    <Border BorderColor="#4986A2" />
                                                </ContentStyle>
                                                <TabPages>
                                                    <dxtc:TabPage Text="Informações Básicas" Visible="true">
                                                        <ContentCollection>
                                                            <dxw:ContentControl runat="server">
                                                                <dx:ASPxGridViewTemplateReplacement ID="Editors" runat="server" 
                                                                    ReplacementType="EditFormEditors">
                                                                </dx:ASPxGridViewTemplateReplacement>
                                                            </dxw:ContentControl>
                                                        </ContentCollection>
                                                    </dxtc:TabPage>
                                                </TabPages>
                                                <Paddings PaddingLeft="0px" />
                                            </dxtc:ASPxPageControl>
                                        </div>
                                        <div style="text-align: right; padding: 2px 2px 2px 2px">
                                            <dx:ASPxGridViewTemplateReplacement ID="UpdateButton" runat="server" 
                                                ReplacementType="EditFormUpdateButton">
                                            </dx:ASPxGridViewTemplateReplacement>
                                            <dx:ASPxGridViewTemplateReplacement ID="CancelButton" runat="server" 
                                                ReplacementType="EditFormCancelButton">
                                            </dx:ASPxGridViewTemplateReplacement>
                                        </div>
                                    </EditForm>
                                </Templates>
                                <SettingsDetail AllowOnlyOneMasterRowExpanded="True" IsDetailGrid="True" 
                                    ShowDetailButtons="False" />
                            </dx:ASPxGridView>
                        </DetailRow>
                        <EditForm>
                            <div style="padding: 4px 4px 3px 4px">
                                <dxtc:ASPxPageControl runat="server" ID="pageControl" Width="100%" Height="140px"
                                    ActiveTabIndex="0" CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass"
                                    LoadingPanelText="Carregando..." TabSpacing="0px">
                                    <LoadingPanelImage Url="~/App_Themes/Glass/Web/Loading.gif">
                                    </LoadingPanelImage>
                                    <ContentStyle>
                                        <Border BorderColor="#4986A2" />
                                    </ContentStyle>
                                    <TabPages>
                                        <dxtc:TabPage Text="Informações Básicas" Visible="true">
                                            <ContentCollection>
                                                <dxw:ContentControl runat="server">
                                                    <dx:ASPxGridViewTemplateReplacement ID="Editors" ReplacementType="EditFormEditors"
                                                        runat="server">
                                                    </dx:ASPxGridViewTemplateReplacement>
                                                </dxw:ContentControl>
                                            </ContentCollection>
                                        </dxtc:TabPage>
                                    </TabPages>
                                    <Paddings PaddingLeft="0px" />
                                </dxtc:ASPxPageControl>
                            </div>
                            <div style="text-align: right; padding: 2px 2px 2px 2px">
                                <dx:ASPxGridViewTemplateReplacement ID="UpdateButton" ReplacementType="EditFormUpdateButton"
                                    runat="server">
                                </dx:ASPxGridViewTemplateReplacement>
                                <dx:ASPxGridViewTemplateReplacement ID="CancelButton" ReplacementType="EditFormCancelButton"
                                    runat="server">
                                </dx:ASPxGridViewTemplateReplacement>
                            </div>
                        </EditForm>
                    </Templates>
                    <SettingsDetail ShowDetailRow="True" />
                </dx:ASPxGridView>
                <asp:ObjectDataSource ID="odsMenu" runat="server" SelectMethod="ObterMenusPaisSistema"
                    TypeName="Business.PermissaoMenuBU"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsSubMenu" runat="server" 
                    SelectMethod="ObterSubMenusPaisSistema" TypeName="Business.PermissaoMenuBU">
                    <SelectParameters>
                        <asp:SessionParameter Name="idMenuPai" SessionField="CategoryId" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
    </table>
    <br />
    </asp:Content>
