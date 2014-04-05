using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class NiveisPermissao
    {
        private int _idNivelPermissao;
        /// <summary>
        /// Identificador do Nível de Permissão
        /// </summary>
        public int IdNivelPermissao
        {
            get { return _idNivelPermissao; }
            set { _idNivelPermissao = value; }
        }
        private TipoUsuario _tipoUsuario;
        /// <summary>
        /// Tipo de Usuário do Nível
        /// </summary>
        public TipoUsuario TipoUsuario
        {
            get { return _tipoUsuario; }
            set { _tipoUsuario = value; }
        }
        private int _idMenu;
        /// <summary>
        /// Identificador do menu (Reconhecido como funcionalidade)
        /// </summary>
        public int IdMenu
        {
            get { return _idMenu; }
            set { _idMenu = value; }
        }
        private int _permissaoLeitura;
        /// <summary>
        /// Permissão de Leitura
        /// </summary>
        public int PermissaoLeitura
        {
            get { return _permissaoLeitura; }
            set { _permissaoLeitura = value; }
        }
        private int _permissaoCriacao;
        /// <summary>
        /// Permissão de Criação
        /// </summary>
        public int PermissaoCriacao
        {
            get { return _permissaoCriacao; }
            set { _permissaoCriacao = value; }
        }
        private int _permissaoAtualizacao;
        /// <summary>
        /// Permissão de Atualização
        /// </summary>
        public int PermissaoAtualizacao
        {
            get { return _permissaoAtualizacao; }
            set { _permissaoAtualizacao = value; }
        }
        private int _permissaoRemocao;
        /// <summary>
        /// Permissão de Remoção
        /// </summary>
        public int PermissaoRemocao
        {
            get { return _permissaoRemocao; }
            set { _permissaoRemocao = value; }
        }
    }
}
