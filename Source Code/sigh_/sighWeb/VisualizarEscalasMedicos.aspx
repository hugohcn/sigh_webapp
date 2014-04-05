<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VisualizarEscalasMedicos.aspx.cs"
    Inherits="sighWeb.VisualizarEscalasMedicos" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Clínica Radiológica Dr. Amantino Soares | Visualizar Escalas</title>
    <link href="styles/principal.css" rel="stylesheet" type="text/css" />
</head>
<body onunload="window.opener.calendarAgenda.SetVisible(true);">
    <form id="form1" runat="server">
    <div>
        <div id="header">
            <img id="imgLogotipo" alt="Clínica Radiológica Dr. Amantino Soares" src="images/logotipo_login.png" />
        </div>
        <div class="headerPersonalForm">
            <div style="color: #3183a9; font-family: Arial; font-size: 13px; line-height: 22px;">
                <span runat="server" id="lblTitulo"></span>
            </div>
            <br />
            <br />
            <dx:ASPxGridView ID="gdvEscalas" runat="server" AutoGenerateColumns="False" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                CssPostfix="Glass" Width="100%" DataSourceID="odsEscalas">
                <Styles CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass">
                    <Header ImageSpacing="5px" SortingImageSpacing="5px">
                    </Header>
                </Styles>
                <SettingsPager Visible="False">
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
                <Columns>
                    <dx:GridViewDataTextColumn Caption="Médico" FieldName="ds_nome" VisibleIndex="0">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Dia da Semana" FieldName="ds_dia" VisibleIndex="1">
                    </dx:GridViewDataTextColumn>
                </Columns>
                <StylesEditors>
                    <CalendarHeader Spacing="1px">
                    </CalendarHeader>
                    <ProgressBar Height="25px">
                    </ProgressBar>
                </StylesEditors>
            </dx:ASPxGridView>
            <asp:ObjectDataSource ID="odsEscalas" runat="server" SelectMethod="RetornaEscalasByServico"
                TypeName="Business.EscalaBU">
                <SelectParameters>
                    <asp:QueryStringParameter Name="idServico" QueryStringField="codExame" Type="Int32" />
                    <asp:Parameter DefaultValue="true" Name="isVisualizacaoDiasServico" 
                        Type="Boolean" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <br />
            <div style="color: #3183a9; font-family: Arial; font-size: 13px; line-height: 22px;">
                <span>Atenção: Visualize o dia correto de trabalho do médico para que você posso selecionar
                    corretamente o dia no calendário assim que fechar esta página.</span>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
