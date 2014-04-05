using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CalendarDataAccess;
using CalendarEntity;

namespace Business
{
    public class AgendaBU
    {
        /// <summary>
        /// Método que efetua deleção de consulta na agenda
        /// </summary>
        /// <param name="date">Data da consulta</param>
        /// <param name="agenda">Objeto agenda para população de parâmetros</param>
        /// <param name="horaAgendada">Hora agendada</param>
        public void DeletarConsultaByDiaByMedicoByHoraAgendada(DateTime date, int codMedicor, string horaAgendada)
        {
            //Cria as strings para concatenar e deixar no formato correto
            string year, month, day;

            try
            {
                year = date.Year.ToString();
                month = date.Month.ToString();
                day = date.Day.ToString();

                if (Convert.ToInt32(month) < 10)
                {
                    month = "0" + month;
                }

                if (Convert.ToInt32(day) < 10)
                {
                    day = "0" + day;
                }

                //Formata a hora
                string newHora = horaAgendada.Replace(":", "");

                new AgendaAccess().DeletarConsultaByDiaByMedicoByHoraAgendada(year + month + day, codMedicor, newHora);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    
        /// <summary>
        /// Método que insere os dados de uma consulta na tabela de agendamentos
        /// </summary>
        /// <param name="agenda">Objeto agenda que permite receber os parametros e propriedades do mesmo.</param>
        public void InserirConsultaByDiaByMedicoByHoraAgendada(DateTime date, Agenda agenda, string horaAgendada)
        {
            //Cria as strings para concatenar e deixar no formato correto
            string year, month, day;

            try
            {
                year = date.Year.ToString();
                month = date.Month.ToString();
                day = date.Day.ToString();

                if (Convert.ToInt32(month) < 10)
                {
                    month = "0" + month;
                }

                if (Convert.ToInt32(day) < 10)
                {
                    day = "0" + day;
                }

                //Formata a hora
                string newHora = horaAgendada.Replace(":", "");

                new AgendaAccess().InserirConsultaByDiaByMedicoByHoraAgendada(year + month + day, agenda, newHora);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    
        /// <summary>
        /// Método que atualiza uma consulta
        /// </summary>
        /// <param name="date">Data da consulta</param>
        /// <param name="codMedico">Código do médico</param>
        /// <param name="horaAgendada">Hora agendada para a consulta</param>
        public void AtualizarConsultaByDiaByMedicoByHoraAgendada(DateTime date, Agenda agenda, string horaAgendada)
        {
            //Cria as strings para concatenar e deixar no formato correto
            string year, month, day;

            try
            {
                year = date.Year.ToString();
                month = date.Month.ToString();
                day = date.Day.ToString();

                if (Convert.ToInt32(month) < 10)
                {
                    month = "0" + month;
                }

                if (Convert.ToInt32(day) < 10)
                {
                    day = "0" + day;
                }
                
                //Formata a hora
                string newHora = horaAgendada.Replace(":","");

                new AgendaAccess().AtualizarConsultaByDiaByMedicoByHoraAgendada(year + month + day, agenda, newHora);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        /// <summary>
        /// Retorna as consultas marcadas para o médico na data informada.
        /// </summary>
        /// <param name="date">Data da agenda</param>
        /// <param name="codMedico">Código do médico</param>
        /// <returns>DataTable contendo os dados das consultas do dia do médico</returns>
        public DataTable RetornaAgendaByDiaByMedico(DateTime date, int codMedico)
        {
            //Cria as strings para concatenar e deixar no formato correto
            string year, month, day;

            try
            {
                year = date.Year.ToString();
                month = date.Month.ToString();
                day = date.Day.ToString();

                if (Convert.ToInt32(month) < 10)
                {
                    month = "0" + month;
                }

                if (Convert.ToInt32(day) < 10)
                {
                    day = "0" + day;
                }

                return new AgendaAccess().RetornaAgendaByDiaByMedico(year + month + day, codMedico);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        /// <summary>
        /// Retorna a consulta em determinada hora, feita por determinado médico.
        /// </summary>
        /// <param name="date">Data da consulta na agenda</param>
        /// <param name="codMedico">Código do médico no qual fará o serviço</param>
        /// <param name="horaAgendada">Hora agendada para o paciente</param>
        /// <returns></returns>
        public DataTable RetornaConsultaByDiaByMedicoByHoraAgendada(DateTime date, int codMedico, string horaAgendada)
        {
            //Cria as strings para concatenar e deixar no formato correto
            string year, month, day;

            try
            {
                year = date.Year.ToString();
                month = date.Month.ToString();
                day = date.Day.ToString();

                if (Convert.ToInt32(month) < 10)
                {
                    month = "0" + month;
                }

                if (Convert.ToInt32(day) < 10)
                {
                    day = "0" + day;
                }
                
                //Formata a hora
                string newHora = horaAgendada.Replace(":","");

                return new AgendaAccess().RetornaConsultaByDiaByMedicoByHoraAgendada(year + month + day, codMedico, newHora);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
