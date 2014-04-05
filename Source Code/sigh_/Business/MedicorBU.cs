using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CalendarEntity;
using CalendarDataAccess;

namespace Business
{
    public class MedicorBU
    {
        /// <summary>
        /// Método que retorna o código do médico pelo cpf
        /// </summary>
        /// <param name="cpf">Cpf do médico</param>
        /// <returns>Inteiro resolvido como código do médico</returns>
        public int RetornaMedicoByCpf(string cpf)
        {
            try
            {
                string newCpf = cpf;
                newCpf = newCpf.Replace("-","");
                newCpf = newCpf.Replace(".", "");
                newCpf = newCpf.Replace("_", "");
                
                return new MedicorAccess().RetornaMedicoByCpf(newCpf);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// Método que retorna os médicos que trabalham em um determinado com um determinado serviço
        /// </summary>
        /// <param name="diaServico">Dia do serviço</param>
        /// <param name="codServico">Código do Serviço</param>
        /// <returns></returns>
        public DataTable RetornaMedicoByDiaServicoByIdServico(DateTime dtConsulta, int codServico)
        {
            string diaSemana = string.Empty;

            //Tratamento do dia para chamada ao método de retorno da escala
            switch (dtConsulta.DayOfWeek.ToString())
            {
                case "Sunday":
                    {
                        diaSemana = "domingo";
                        break;
                    }

                case "Monday":
                    {
                        diaSemana = "segunda-feira";
                        break;
                    }

                case "Tuesday":
                    {
                        diaSemana = "terça-feira";
                        break;
                    }

                case "Wednesday":
                    {
                        diaSemana = "quarta-feira";
                        break;
                    }

                case "Thursday":
                    {
                        diaSemana = "quinta-feira";
                        break;
                    }

                case "Friday":
                    {
                        diaSemana = "sexta-feira";
                        break;
                    }

                case "Saturday":
                    {
                        diaSemana = "sábado";
                        break;
                    }

                default:
                    {
                        throw new Exception("Não foi possível definir o dia da semana.");
                    }
            }

            //chamada ao método de retorna da escala
            return new MedicorAccess().RetornaMedicoByDiaServicoByIdServico(diaSemana, codServico);
        }
    
        /// <summary>
        /// Método qque busca todos os médicos do legado
        /// </summary>
        public DataTable RetornaMedicosByServico(int idServico)
        {
            try
            {
                return new MedicorAccess().RetornaMedicosByServico(idServico);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        /// <summary>
        /// Método de retorna da escala de um médico
        /// </summary>
        /// <param name="idMedico">Identificador do médico</param>
        /// <param name="diaSemana">Dia da semana</param>
        /// <returns>DataTable com a escala e possíveis escalas no dia</returns>
        public Escala RetornaEscalaMedico(int idMedico, DateTime dtAgenda)
        {
            try
            {
                string diaSemana = string.Empty;
                
                //Tratamento do dia para chamada ao método de retorno da escala
                switch (dtAgenda.DayOfWeek.ToString())
                {
                    case "Sunday":
                    {
                        diaSemana = "domingo";
                        break;
                    }

                    case "Monday":
                    {
                        diaSemana = "segunda-feira";
                        break;
                    }

                    case "Tuesday":
                    {
                        diaSemana = "terça-feira";
                        break;
                    }

                    case "Wednesday":
                    {
                        diaSemana = "quarta-feira";
                        break;
                    }

                    case "Thursday":
                    {
                        diaSemana = "quinta-feira";
                        break;
                    }

                    case "Friday":
                    {
                        diaSemana = "sexta-feira";
                        break;
                    }

                    case "Saturday":
                    {
                        diaSemana = "sábado";
                        break;
                    }
                    
                    default:
                    {
                        throw new Exception("Não foi possível definir o dia da semana.");                  
                    }
                }   
                
                //chamada ao método de retorna da escala
                return new MedicorAccess().RetornaEscalaMedico(idMedico, diaSemana);              
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        /// <summary>
        /// Método qque busca todos os médicos do legado
        /// </summary>
        public DataTable RetornaMedicos()
        {
            try
            {
                return new MedicorAccess().RetornaMedicos();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    
    }
}
