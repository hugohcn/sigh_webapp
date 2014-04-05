using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CalendarDataAccess;

namespace Business
{
    public class ServicoBU
    {
        /// <summary>
        /// Método que busca todos os serviços do legado.
        /// </summary>
        public DataTable ObterServicosSistema()
        {
            try
            {
                return new ServicoAccess().ObterServicosSistema();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        /// <summary>
        /// Método de busca de todos os serviços de acordo com a categoria informada
        /// </summary>
        public DataTable ObterServicosByCategoria(int categoria)
        {
            try
            {
                return new ServicoAccess().ObterServicosByCategoria(categoria);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
