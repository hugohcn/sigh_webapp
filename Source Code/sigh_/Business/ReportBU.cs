using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CalendarDataAccess;

namespace Business
{
    public class ReportBU
    {
        /// <summary>
        /// Método que recupera os dados do relatório de um médico
        /// </summary>
        /// <param name="dtInicio">Data de início do relatório</param>
        /// <param name="dtFim">Data de fim do relatório</param>
        /// <param name="idMedico">Código do médico</param>
        /// <returns>DataTable contendo os dados do relatório corrente.</returns>
        public DataSet GetRelatorioTrabalhoMedico(DateTime dtInicio, DateTime dtFim, int idMedico)
        {
            try
            {
                //Cria as strings para concatenar e deixar no formato correto
                string yearInicio, monthInicio, dayInicio;
                string yearFim, monthFim, dayFim;


                yearInicio = dtInicio.Year.ToString();
                monthInicio = dtInicio.Month.ToString();
                dayInicio = dtInicio.Day.ToString();

                if (Convert.ToInt32(monthInicio) < 10)
                {
                    monthInicio = "0" + monthInicio;
                }

                if (Convert.ToInt32(dayInicio) < 10)
                {
                    dayInicio = "0" + dayInicio;
                }


                yearFim = dtFim.Year.ToString();
                monthFim = dtFim.Month.ToString();
                dayFim = dtFim.Day.ToString();

                if (Convert.ToInt32(monthFim) < 10)
                {
                    monthFim = "0" + monthFim;
                }

                if (Convert.ToInt32(dayFim) < 10)
                {
                    dayFim = "0" + dayFim;
                }

                return new ReportAccess().GetRelatorioTrabalhoMedico(yearInicio+monthInicio+dayInicio,yearFim+monthFim+dayFim, idMedico);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
