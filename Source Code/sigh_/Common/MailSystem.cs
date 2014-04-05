using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Configuration;

namespace Common
{
    /// <summary>
    /// Enumerador de tipo de prioridades de e-mail.
    /// </summary>
    public enum PrioridadeEmail
    {
        Alta = 1,
        Media = 2,
        Baixa = 3,
    };


    public class EmailConfig
    {
        #region Construtor

        /// <summary>
        /// Construtor padrão.
        /// </summary>
        public EmailConfig()
        {

        }
        #endregion

        #region Atributos

        private string _nome;
        private string _telefoneContato;
        private string _email;
        private string _assunto;
        private string _mensagem;
        private PrioridadeEmail _prioridade;
        private bool _isBodyHtml;
        //campos de configuração revistos pelo web.config
        private string _smtpHost;
        private string _loginCredentials;
        private string _senhaCredentials;

        #endregion

        #region Propriedades

        /// <summary>
        /// Nome do usuário que está enviando a mensagem.
        /// </summary>
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        /// <summary>
        /// Telefone para contato do usuário.
        /// </summary>
        public string TelefoneContato
        {
            get { return _telefoneContato; }
            set { _telefoneContato = value; }
        }

        /// <summary>
        /// E-mail do usuário.
        /// </summary>
        public string Email1
        {
            get { return _email; }
            set { _email = value; }
        }

        /// <summary>
        /// Assunto da mensagem.
        /// </summary>
        public string Assunto
        {
            get { return _assunto; }
            set { _assunto = value; }
        }

        /// <summary>
        /// Mensagem a ser enviada.
        /// </summary>
        public string Mensagem
        {
            get { return _mensagem; }
            set { _mensagem = value; }
        }

        /// <summary>
        /// Prioridade de e-mail.
        /// </summary>
        public PrioridadeEmail Prioridade
        {
            get { return _prioridade; }
            set { _prioridade = value; }
        }

        /// <summary>
        /// Booleano que indica se a mensagem será em formato HTML ou não.
        /// </summary>
        public bool IsBodyHtml
        {
            get { return _isBodyHtml; }
            set { _isBodyHtml = value; }
        }

        /// <summary>
        /// Recupera o parâmetro de configuração do servidor SMTP.
        /// </summary>
        public string SmtpHost
        {
            get { return ConfigurationManager.AppSettings["smtpHost"].ToString(); }
        }

        /// <summary>
        /// Recupera o login de credenciamento para envio dos e-mails.
        /// </summary>
        public string LoginCredentials
        {
            get { return ConfigurationManager.AppSettings["loginCredentials"].ToString(); }
        }

        /// <summary>
        /// Recupera a senha de credenciamento para envio dos e-mails.
        /// </summary>
        public string SenhaCredentials
        {
            get { return ConfigurationManager.AppSettings["senhaCredentials"].ToString(); }
        }

        #endregion
    }

    public class EmailSender
    {
        /// <summary>
        /// Método de envio de mensagens.
        /// </summary>
        public static void SendMail(EmailConfig _mail)
        {
            MailMessage _objEmail = new MailMessage();
            try
            {
                _objEmail.From = new MailAddress("contato@vixmidia.com.br", _mail.Nome);
                _objEmail.To.Add(_mail.Email1);
                _objEmail.Subject = _mail.Assunto;

                switch (Convert.ToInt32(_mail.Prioridade))
                {
                    case 1:
                        _objEmail.Priority = MailPriority.High;
                        break;
                    case 2:
                        _objEmail.Priority = MailPriority.Normal;
                        break;
                    case 3:
                        _objEmail.Priority = MailPriority.Low;
                        break;
                }
                _objEmail.Body = _mail.Mensagem;
                _objEmail.IsBodyHtml = _mail.IsBodyHtml;

                SmtpClient mailClient = new SmtpClient(_mail.SmtpHost);

                //Necessário ativar para enviar e-mails pelo SMTP do gmail.
                //DEVE ESTAR COM O VALOR TRUE QUANDO FOR EFETUADO DEPLOY DA APLICAÇÃO
                mailClient.EnableSsl = true;
                //mailClient.EnableSsl = false;
                mailClient.Credentials = new System.Net.NetworkCredential(_mail.LoginCredentials, _mail.SenhaCredentials);
                
                mailClient.Send(_objEmail);

            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }
    }
}
