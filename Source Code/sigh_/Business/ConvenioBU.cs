using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CalendarDataAccess;
using System.Data;

namespace Business
{
    public class ConvenioBU
    {
        /// <summary>
        /// Método que retorna os convênios registrados no banco de dados
        /// </summary>
        /// <returns></returns>
        public DataTable RetornaConvenios()
        {
            try
            {
                return new ConvenioAccess().RetornaConvenios();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public DataTable RetornaConveniosByMedico(int idCodigoMedico)
        {
            try
            {
                return new ConvenioAccess().RetornaConveniosByMedico(idCodigoMedico);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
