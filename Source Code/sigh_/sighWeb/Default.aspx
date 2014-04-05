<%@ Page Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="sighWeb.Default" Title="Sistema Integrado de Gerenciamento Hospitalar | Clínica X" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="divApresentacao">
        <br />
        <br />
        <img alt="SIGH" src="images/topo_sigh.png" />
        <br />
        <br />
        <p>
            O Sistema Integrado de Gerenciamento Hospitalar (SIGH Web) tem por finalidade agilizar
            os processos de agendamento de consultas e exames da Clínica X.
        </p>
        <br />
        <p>
            Além de agendar, o sistema integra os laudos dos pacientes facilitando a análise
            de exames em qualquer hora e lugar do mundo, assim como mantém o médico atualizado
            com relatórios que facilitam a tomada de decisões.
        </p>
        <br />
        <p>
            Em caso de dúvidas, falhas ou sugestões, entre em contato conosco <a id="duvida"
                href="javascript:void(0);" onclick="AbrirWindowPadrao('ContatoAdministradorForm.aspx?nome=<%= user.Nome %>&email=<%= user.Email %>&telefone=<%= user.Telefone1 %>&celular=<%= user.Telefone2 %>')">
                <b>clicando aqui</b></a>.
        </p>
        <br />
        <p>
            <%--<a href="javascript:void(0);" onclick="AbrirWindowPadrao('ManterPerfilForm.aspx')">
                <b>Leia o manual SIGH WEB</b>
            </a>--%>
        </p>
    </div>
    <div id="dadosUsuario">
        <br />
        <br />
        <img alt="SIGH" src="images/meus_dados.jpg" />
        <br />
        <br />
        <table id="tblDados" border="0" cellpadding="2" cellspacing="2" width="100%">
            <tr>
                <td align="left" class="celula">
                    Usuário:
                </td>
                <td align="left">
                    <b>
                        <label runat="server" id="lblUsuario">
                        </label>
                    </b>
                </td>
            </tr>
            <tr>
                <td align="left" class="celula">
                    Tipo de Usuário:
                </td>
                <td align="left">
                    <b>
                        <label runat="server" id="lblTipoUsuario">
                        </label>
                    </b>
                </td>
            </tr>
            <tr>
                <td align="left" class="celula">
                    Login:
                </td>
                <td align="left">
                    <b>
                        <label runat="server" id="lblLogin">
                        </label>
                    </b>
                </td>
            </tr>
            <tr>
                <td align="left" class="celula">
                    Último Acesso:
                </td>
                <td align="left">
                    <b>
                        <label runat="server" id="lblUltimoAcesso">
                        </label>
                    </b>
                </td>
            </tr>
            <tr>
                <td align="left" class="celula" colspan="2">
                    <a href="javascript:void(0);" onclick="AbrirWindowPadrao('ManterPerfilForm.aspx?idUsuario=<%= security.EncriptarObjeto(user.Cpf).ToString() %>');"
                        class="linkTabelaDados">Atualizar dados</a>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
