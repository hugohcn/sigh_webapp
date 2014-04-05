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
using Common;

namespace sighWeb
{
    public partial class GruposUsuariosForm : System.Web.UI.Page
    {
        public SecurityCommon security = new SecurityCommon();
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gdvGrupos_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            try
            {
                e.Cancel = true;
                
                UsuarioBU userBU = new UsuarioBU();

                //Adiciona o grupo 
                TipoUsuario tpUsuario = new TipoUsuario();
                
                //cria o objeto de níveis de permissões
                NiveisPermissao nPermissoes = new NiveisPermissao();

                //Seta o id como 0 para o banco ter controle do campo auto-incremental
                tpUsuario.IdTipoUsuario = 0;
                tpUsuario.DescricaoTipoUsuario = e.NewValues["ds_tipo_usuario"].ToString();
                
                userBU.InserirTipoUsuario(tpUsuario);
                
                //Cancela edição e atualiza o grid
                this.gdvGrupos.CancelEdit();
            }
            catch (Exception eX)
            {
                throw eX;
            }
        }

        protected void gdvGrupos_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            try
            {
                e.Cancel = true;
                
                TipoUsuario tpUsuario = new TipoUsuario();
                
                tpUsuario.IdTipoUsuario = Convert.ToInt32(e.Keys["id_tipo_usuario"].ToString());
                
                new UsuarioBU().ExcluirTipoUsuario(tpUsuario);
            }
            catch (Exception eX)
            {
                throw eX;
            }
        }

        protected void gdvGrupos_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            try
            {
                e.Cancel = true;
                
                TipoUsuario tpUsuario = new TipoUsuario();
                
                tpUsuario.IdTipoUsuario = Convert.ToInt32(e.Keys["id_tipo_usuario"].ToString());
                tpUsuario.DescricaoTipoUsuario = e.NewValues["ds_tipo_usuario"].ToString();
                
                new UsuarioBU().AtualizarTipoUsuario(tpUsuario);
                
                this.gdvGrupos.CancelEdit();
            }
            catch (Exception eX)
            {
                throw eX;
            }
        }
    }
}
