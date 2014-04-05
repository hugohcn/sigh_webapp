using System;
using Common;
using Entity;
using DataAccess;
using System.Text;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Business
{
    public class UsuarioBU
    {

        /// <summary>
        /// Método para atualização dos tipos de usuário.
        /// </summary>
        /// <param name="tipoUsuario">Objeto Tipo usuário</param>
        public void AtualizarTipoUsuario(TipoUsuario tpUsuario)
        {
            new UsuarioDA().AtualizarTipoUsuario(tpUsuario);
        }

        /// <summary>
        /// Método para deleção de tipos de usuário.
        /// </summary>
        /// <param name="tipoUsuario">Objeto Tipo usuário</param>
        public void ExcluirTipoUsuario(TipoUsuario tpUsuario)
        {
            new UsuarioDA().ExcluirTipoUsuario(tpUsuario);
        }


        /// <summary>
        /// Método para inserção de tipos de usuário.
        /// </summary>
        /// <param name="tipoUsuario">Objeto Tipo usuário</param>
        public void InserirTipoUsuario(TipoUsuario tpUsuario)
        {
            try
            {
                new UsuarioDA().InserirTipoUsuario(tpUsuario);
            }
            catch (Exception eX)
            {
                throw;
            }
        }


        /// <summary>
        /// Método que efetua deleção de usuário no banco de dados.
        /// </summary>
        /// <param name="cpf">Cpf do usuário</param>
        public void ExcluirUsuarioByCpf(string cpf)
        {
            try
            {
                new UsuarioDA().ExcluirUsuarioBycpf(cpf);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Método que retorna um usuário pelo seu CPF
        /// </summary>
        /// <returns>Objeto usuário</returns>
        public Usuario RetornaUsuarioByCpf(string cpf)
        {
            try
            {
                //Retorna o objeto vindo do banco de dados.
                return new UsuarioDA().RetornaUsuarioBycpf(cpf);
            }
            catch (Exception eX)
            {
                throw eX;
            }
        }
        /// <summary>
        /// Método que retorna todos os usuários registrados no sistema.
        /// </summary>
        /// <returns>Dataset com resultados das querys.</returns>
        public DataSet RetornaUsuariosSistema()
        {
            return new UsuarioDA().RetornaUsuariosSistema();
        }

        /// <summary>
        /// Método que efetua chamada ao acesso a dados de autenticação de login e retorna um Usuário.
        /// </summary>
        /// <param name="login">Login do usuário</param>
        /// <param name="pass">Senha do usuário</param>
        public Usuario EfetuarLogin(string login, string pass)
        {
            try
            {
                return new UsuarioDA().Efetuarlogin(login, pass);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Método para recuperação de senha do usuário
        /// </summary>
        /// <param name="login">Login do usuário</param>
        /// <param name="cpf">Cpf do usuário</param>
        /// <returns>Inteiro que verifica se houve sucesso no processo de recuperação de senha ou não.</returns>
        public int RecuperarSenhaLogin(string login, string cpf)
        {
            int flag = 0;
            UsuarioDA userDataAccessnew = new UsuarioDA();

            try
            {
                //Busca pelo usuário
                Usuario user = userDataAccessnew.RecuperaUsuarioByloginAndcpf(login, cpf);

                //Caso o usuário exista, é gerado o template para envio de uma nova senha para o seu e-mail
                if (user != null)
                {
                    if (user.IsAtivo)
                    {
                        SecurityCommon common = new SecurityCommon();

                        //Parâmetro de tamanho limite de senha do sistema.
                        user.Senha = common.GeraSenha(15);

                        //Efetua atualização no banco de dados
                        userDataAccessnew.AtualizarUsuario(user, user.Cpf, user.Login);

                        //Envia os novos dados para o usuário
                        //
                        //Monta o objeto e-mail
                        EmailConfig mail = new EmailConfig();

                        mail.Prioridade = PrioridadeEmail.Alta;
                        mail.IsBodyHtml = true;

                        //Parâmetro com o nome da empresa.
                        mail.Assunto = "SIGH WEB | Recuperação de Senha";
                        mail.Email1 = user.Email;
                        mail.Nome = "SIGH WEB | Recuperação de Senha";

                        //Montagem do corpo da mensagem
                        StringBuilder sb = new StringBuilder();
                        sb.Append("<body>");
                        sb.Append("<body>");
                        sb.Append("<img src='http://sigh.vixmidia.com.br/images/topo_email_template.gif' alt='Seja bem-vindo ao Sistema de Gerenciamento Hospitalar Integrado (SIGH) Web'/>");
                        sb.Append("<p style='font-family: Verdana;'>");
                        sb.Append("<br/>");
                        sb.Append("Olá, recebemos seu pedido para alteração de senha no Sistema Integrado de Gerenciamento Hospitalar (SIGH) da Clínica Dr. Amantino Soares.<br/><br/>");
                        sb.Append("<br/>");
                        sb.Append("Sua nova senha é:");
                        sb.Append("<b>" + user.Senha + "</b>");
                        sb.Append("</p>");
                        sb.Append("<br/>");
                        sb.Append("<br/>");
                        sb.Append("<p>");
                        sb.Append("Esta é uma mensagem automática. Não responda este e-mail.");
                        sb.Append("</p>");
                        sb.Append("</body>");
                        mail.Mensagem = sb.ToString();

                        //Enviando e-mail...
                        EmailSender.SendMail(mail);

                        //Retorna o flag para indicar a camada de interface que o e-mail foi enviado com sucesso.
                        flag = 1;
                    }
                    else
                    {
                        flag = -1;
                    }
                }
                else
                {
                    flag = -1;
                }

                return flag;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public void EfetuarContatoAdministrativo(string usuario, string email, string tipoContato, string telefone1, string telefone2, string mensagem)
        {
            try
            {

                //Envia os novos dados para o usuário
                //
                //Monta o objeto e-mail
                EmailConfig mail = new EmailConfig();

                mail.Prioridade = PrioridadeEmail.Alta;
                mail.IsBodyHtml = true;

                //Parâmetro com o nome da empresa.
                mail.Assunto = "SIGH WEB | " + tipoContato;
                mail.Email1 = ParametersEntity.RecuperarParametro("emailAdmin");
                mail.Nome = "SIGH WEB | " + tipoContato;

                //Montagem do corpo da mensagem
                StringBuilder sb = new StringBuilder();
                sb.Append("<body>");
                sb.Append("<body>");
                //sb.Append("<img src='http://administracao.crdas.com.br/images/topo_email_template.gif' alt='Seja bem-vindo ao Sistema de Gerenciamento Hospitalar Integrado (SIGH) Web'/>");
                sb.Append("<img src='http://sigh.vixmidia.com.br/images/topo_email_template.gif' alt='Seja bem-vindo ao Sistema Integrado de Gerenciamento Hospitalar (SIGH) Web'/>");
                sb.Append("<p style='font-family: Verdana;'>");
                sb.Append("<br/>");
                sb.Append("<i>Novo contato do usuário: " + usuario + "</i>");
                sb.Append("<br/>");
                sb.Append("<i>Tipo de Contato: " + tipoContato + "</i>");
                sb.Append("<br/>");
                sb.Append("<i>Telefone de contato do usuário: " + telefone1 + "</i>");
                sb.Append("<br/>");
                sb.Append("<i>Telefone de contato do usuário: " + telefone2 + "</i>");
                sb.Append("<br/>");
                sb.Append("<br/>");
                sb.Append("Mensagem:");
                sb.Append("<br/>");
                sb.Append(mensagem);
                sb.Append("</p>");
                sb.Append("<br/>");
                sb.Append("<br/>");
                sb.Append("<p>");
                sb.Append("<i>Esta é uma mensagem automática. Não responda este e-mail.</i>");
                sb.Append("</p>");
                sb.Append("</body>");
                mail.Mensagem = sb.ToString();

                //Enviando e-mail...
                EmailSender.SendMail(mail);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Método que retorna todos os tipos de usuários.
        /// </summary>
        /// <returns>Datatable contendo todos os tipos de usuários do sistema.</returns>
        public DataTable RetornaTiposUsuarios()
        {
            try
            {
                return new UsuarioDA().RetornaTodosTiposUsuarios();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Método que altera um usuário
        /// </summary>
        /// <param name="user">Objeto usuário com os dados atualizados.</param>
        public void AtualizarUsuario(Usuario user, string cpf, string login)
        {
            try
            {
                new UsuarioDA().AtualizarUsuario(user, cpf, login);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Método que altera um usuário
        /// </summary>
        /// <param name="user">Objeto usuário com os dados atualizados.</param>
        public void InserirUsuario(Usuario user)
        {
            try
            {
                //Inseri o usuário no banco de dados.
                new UsuarioDA().InserirUsuario(user);

                //Envia e-mail para o usuário
                //
                //Monta o objeto e-mail
                EmailConfig mail = new EmailConfig();

                mail.Prioridade = PrioridadeEmail.Alta;
                mail.IsBodyHtml = true;

                //Parâmetro com o nome da empresa.
                mail.Assunto = "SIGH WEB - Amantino Soares";
                mail.Email1 = user.Email;
                mail.Nome = "SIGH WEB - Amantino Soares";

                //Montagem do corpo da mensagem
                StringBuilder sb = new StringBuilder();
                sb.Append("<body>");
                sb.Append("<img src='http://sigh.vixmidia.com.br/images/topo_email_template.gif' alt='Seja bem-vindo ao Sistema de Gerenciamento Hospitalar Integrado (SIGH) Web'/>");
                sb.Append("<p style='font-family: Verdana;'>");
                sb.Append("<br/>");
                sb.Append("Seja bem-vindo ao Sistema Integrado de Gerenciamento Hospitalar (SIGH) da Clínica Dr. Amantino Soares.<br/><br/>");
                sb.Append("Estes são os seus dados para acesso:");
                sb.Append("<br/>");
                sb.Append("<br/>");
                sb.Append("Login: " + user.Login);
                sb.Append("<br/>");
                sb.Append("Senha: " + user.Senha);
                sb.Append("<br/>");
                sb.Append("<br/>");
                sb.Append("Para acessar a aplicação <a href='http://sigh.vixmidia.com.br' target='_blank'>clique aqui</a>");
                sb.Append("</p>");
                sb.Append("<br/>");
                sb.Append("<br/>");
                sb.Append("<p><i>");
                sb.Append("Esta é uma mensagem automática. Não responda este e-mail.");
                sb.Append("</i></p>");
                sb.Append("</body>");
                mail.Mensagem = sb.ToString();

                //Enviando e-mail...
                EmailSender.SendMail(mail);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Método que retorna o grupo de usuário pelo seu nome
        /// </summary>
        /// <returns></returns>
        public TipoUsuario RetornaTipoUsuarioByNome(string nomeGrupo)
        {
            return new UsuarioDA().RetornaTipoUsuarioBynome(nomeGrupo);
        }
    }
}
