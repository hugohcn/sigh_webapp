<%@ Page Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true"
    CodeBehind="RelatorioTrabalhoMedicoForm.aspx.cs" Inherits="sighWeb.reports.RelatorioTrabalhoMedicoForm"
    Title="Clínica Radiológica Dr. Amantino Soares | Relatório de Trabalho" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.3.Export, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxGridView.Export" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div style="padding: 10px;">
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td runat="server" id="tdMedicos1">
                        <dx:ASPxLabel ID="lblMedico" runat="server" CssClass="labels" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                            CssPostfix="Glass" Text="Médico" Visible="False">
                        </dx:ASPxLabel>
                    </td>
                    <td style="padding-right: 30px">
                        <!-- AKI -->
                        <dx:ASPxLabel ID="lblDataInicio" runat="server" CssClass="labels" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                            CssPostfix="Glass" Text="Data Inicial">
                        </dx:ASPxLabel>
                    </td>
                    <td>
                        <dx:ASPxLabel ID="lblDataFim" runat="server" CssClass="labels" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                            CssPostfix="Glass" Text="Data Final:">
                        </dx:ASPxLabel>
                    </td>
                    <td>
                        &nbsp; &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="width: 230px" runat="server" id="tdMedicos2">
                        <dx:ASPxComboBox ID="cmbMedicos" runat="server" ClientInstanceName="cmbMedicos" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                            CssPostfix="Glass" EnableIncrementalFiltering="True" LoadingPanelText="Carregando..."
                            SpriteCssFilePath="~/App_Themes/Glass/{0}/sprite.css" ValueType="System.String"
                            Visible="False" Width="200px">
                            <ButtonStyle Width="13px">
                            </ButtonStyle>
                            <LoadingPanelImage Url="~/App_Themes/Glass/Editors/Loading.gif">
                            </LoadingPanelImage>
                            <ValidationSettings Display="Dynamic" EnableCustomValidation="True" ErrorText=""
                                SetFocusOnError="True">
                                <ErrorFrameStyle ImageSpacing="4px">
                                    <ErrorTextPaddings PaddingLeft="4px" />
                                </ErrorFrameStyle>
                                <RequiredField ErrorText="" IsRequired="True" />
                            </ValidationSettings>
                        </dx:ASPxComboBox>
                    </td>
                    <td style="width: 230px">
                        <dx:ASPxDateEdit ID="dteDataInicio" runat="server" ClientInstanceName="dteDataInicio"
                            CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass" SpriteCssFilePath="~/App_Themes/Glass/{0}/sprite.css"
                            Width="200px" AllowNull="False">
                            <ValidationSettings Display="Dynamic" EnableCustomValidation="True" ErrorText="">
                                <ErrorFrameStyle ImageSpacing="4px">
                                    <ErrorTextPaddings PaddingLeft="4px" />
                                </ErrorFrameStyle>
                                <RequiredField ErrorText="" IsRequired="True" />
                            </ValidationSettings>
                            <CalendarProperties ClearButtonText="Apagar" TodayButtonText="Hoje">
                                <HeaderStyle Spacing="1px" />
                                <FooterStyle Spacing="4px" />
                            </CalendarProperties>
                        </dx:ASPxDateEdit>
                    </td>
                    <td style="width: 230px">
                        <dx:ASPxDateEdit ID="dteDataFim" runat="server" ClientInstanceName="dteDataFim" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                            CssPostfix="Glass" SpriteCssFilePath="~/App_Themes/Glass/{0}/sprite.css" Width="200px"
                            AllowNull="False">
                            <ValidationSettings Display="Dynamic" EnableCustomValidation="True" ErrorText="">
                                <ErrorFrameStyle ImageSpacing="4px">
                                    <ErrorTextPaddings PaddingLeft="4px" />
                                </ErrorFrameStyle>
                                <RequiredField ErrorText="" IsRequired="True" />
                            </ValidationSettings>
                            <CalendarProperties ClearButtonText="Apagar" TodayButtonText="Hoje">
                                <HeaderStyle Spacing="1px" />
                                <FooterStyle Spacing="4px" />
                            </CalendarProperties>
                        </dx:ASPxDateEdit>
                    </td>
                    <td valign="middle" align="left">
                        <dx:ASPxButton ID="btnGerarRelatório" runat="server" ClientInstanceName="btnGerarRelatório"
                            CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass" OnClick="btnGerarRelatório_Click"
                            Text="Gerar Relatório">
                        </dx:ASPxButton>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="right">
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="padding-right: 4px">
                                    <dx:ASPxButton ID="btnExportarXls" runat="server" ClientInstanceName="btnExportarXls"
                                        ClientVisible="False" CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass"
                                        Text="Exportar para XLS" OnClick="btnExportarXls_Click">
                                    </dx:ASPxButton>
                                </td>
                                <td style="padding-right: 4px">
                                </td>
                                <td>
                                    <dx:ASPxButton ID="btnExportarPDF" runat="server" ClientVisible="False" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                                        CssPostfix="Glass" Text="Exportar para PDF" OnClick="btnExportarPDF_Click">
                                    </dx:ASPxButton>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="4" valign="middle">
                        <dx:ASPxGridView ID="gdvResultado" runat="server" AutoGenerateColumns="False" ClientInstanceName="gdvResultado"
                            CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass" DataSourceID="odsTrabalhoMedico"
                            Width="100%" KeyFieldName="servico">
                            <SettingsBehavior AllowFocusedRow="True" EnableRowHotTrack="True" />
                            <Styles CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass">
                                <Header ImageSpacing="5px" SortingImageSpacing="5px">
                                </Header>
                            </Styles>
                            <SettingsLoadingPanel Text="Carregando..." />
                            <SettingsPager NumericButtonCount="5" PageSize="25">
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
                            <SettingsText EmptyDataRow="Sua pesquisa não retornou nenhum resultado." CommandCancel="Cancelar"
                                CommandClearFilter="Apagar" CommandDelete="Excluir" CommandEdit="Inserir" CommandNew="Inserir"
                                CommandSelect="Selecionar" CommandUpdate="Inserir" />
                            <Columns>
                                <dx:GridViewDataTextColumn Caption="Serviço" FieldName="servico" VisibleIndex="0"
                                    CellStyle-HorizontalAlign="Left">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Quantidade" FieldName="qtd" VisibleIndex="1"
                                    CellStyle-HorizontalAlign="Center">
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </dx:GridViewDataTextColumn>
                            </Columns>
                            <Settings ShowFilterRow="True" />
                            <StylesEditors>
                                <CalendarHeader Spacing="1px">
                                </CalendarHeader>
                                <ProgressBar Height="25px">
                                </ProgressBar>
                            </StylesEditors>
                        </dx:ASPxGridView>
                        <asp:ObjectDataSource ID="odsTrabalhoMedico" runat="server" SelectMethod="GetRelatorioTrabalhoMedico"
                            TypeName="Business.ReportBU">
                            <SelectParameters>
                                <asp:Parameter Name="dtInicio" Type="DateTime" />
                                <asp:Parameter Name="dtFim" Type="DateTime" />
                                <asp:Parameter Name="idMedico" Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        <dx:ASPxGridViewExporter ID="gdvResultadoExporter" runat="server" FileName="RelatorioTrabalhoMedico"
                            GridViewID="gdvResultado">
                        </dx:ASPxGridViewExporter>
                    </td>
                </tr>
            </table>
            <br />
            <div style="margin-left: 6px; text-align: left; color: #3183a9; font-family: Arial;
                font-size: 13px; line-height: 22px;">
                <span><i>Atenção: Para gerar o relatório de trabalho do médico, selecione a data inicial
                    do relatório e a data final do relatório.</i> </span>
            </div>
        </div>
    </div>
</asp:Content>
