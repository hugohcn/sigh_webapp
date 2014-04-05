using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using Entity;
using Business;
using DevExpress.Web.ASPxGridView;

namespace sighWeb
{
    public partial class GerenciarInstituicoesForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gdvInstituicoes_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            try
            {
                //cancela transação pradrão com o datasource.
                e.Cancel = true;
                
                //cria novo objeto de instituição
                InstituicaoEN instituicao = new InstituicaoEN();
                
                instituicao.IdInstituicao = 0;                    
                instituicao.Nome = e.NewValues["nome"].ToString();
                instituicao.Endereco = e.NewValues["endereco"].ToString();
                instituicao.Numero = Convert.ToInt32(e.NewValues["numero"].ToString());
                instituicao.Bairro = e.NewValues["bairro"].ToString();
                instituicao.Cidade = e.NewValues["cidade"].ToString();
                instituicao.Estado = e.NewValues["estado"].ToString();
                instituicao.Cep = e.NewValues["cep"].ToString();
                instituicao.DtRegistro = Convert.ToDateTime(e.NewValues["dt_registro"].ToString());
                instituicao.NomeResponsavel = e.NewValues["nome_responsavel"].ToString();
                instituicao.Funcao = e.NewValues["funcao"].ToString();
                instituicao.Email = e.NewValues["email"].ToString();
                instituicao.Telefone = e.NewValues["telefone"].ToString();
                instituicao.CnpjInstituicao = e.NewValues["cnpj_instituicao"].ToString();
                
                //invoka método para execução da inserção no sistema.
                new InstituicaoBU().InserirInstituicao(instituicao);
                
                //cancela o modo de edição do usuário e da um bind no grid.
                ((ASPxGridView)sender).CancelEdit();
            }
            catch (Exception eX)
            {
                throw eX;
            }
        }

        protected void gdvInstituicoes_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            try
            {
                //cancela transação pradrão com o datasource.
                e.Cancel = true;

                //cria novo objeto de instituição
                InstituicaoEN instituicao = new InstituicaoEN();

                instituicao.IdInstituicao = Convert.ToInt32(e.NewValues["id_instituicao"].ToString());
                instituicao.Nome = e.NewValues["nome"].ToString();
                instituicao.Endereco = e.NewValues["endereco"].ToString();
                instituicao.Numero = Convert.ToInt32(e.NewValues["numero"].ToString());
                instituicao.Bairro = e.NewValues["bairro"].ToString();
                instituicao.Cidade = e.NewValues["cidade"].ToString();
                instituicao.Estado = e.NewValues["estado"].ToString();
                instituicao.Cep = e.NewValues["cep"].ToString();
                instituicao.DtRegistro = Convert.ToDateTime(e.NewValues["dt_registro"].ToString());
                instituicao.NomeResponsavel = e.NewValues["nome_responsavel"].ToString();
                instituicao.Funcao = e.NewValues["funcao"].ToString();
                instituicao.Email = e.NewValues["email"].ToString();
                instituicao.Telefone = e.NewValues["telefone"].ToString();
                instituicao.CnpjInstituicao = e.NewValues["cnpj_instituicao"].ToString();

                //invoka método para execução da inserção no sistema.
                new InstituicaoBU().AtualizarInstituicao(instituicao);

                //cancela o modo de edição do usuário e da um bind no grid.
                ((ASPxGridView)sender).CancelEdit();
            }
            catch (Exception eX)
            {
                throw eX;
            }
        }

        protected void gdvInstituicoes_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            try
            {
                e.Cancel = true;
                
                //recupera a linha selecionada com o id da instituição
                int idInstituicao = Convert.ToInt32(e.Keys["id_instituicao"].ToString());
                
                new InstituicaoBU().RemoverInstituicao(idInstituicao);
            }
            catch (Exception eX)
            {
                throw eX;
            }
        }
    }
}
