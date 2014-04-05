using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CalendarDataAccess;

namespace Business
{
    public class EscalaBU
    {
        /// <summary>
        /// Método de retorna os dias da semana de atendimento de um serviço
        /// </summary>
        /// <param name="idServico">Identificador do Serviço</param>
        public DataTable RetornaEscalasByServico(int idServico, bool isVisualizacaoDiasServico)
        {
            try
            {
                return new EscalaAccess().RetornaEscalasByServico(idServico, isVisualizacaoDiasServico);
            }
            catch (Exception eX)
            {
                throw eX;
            }
        }
    }
}
