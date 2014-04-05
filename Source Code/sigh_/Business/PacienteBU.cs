using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CalendarDataAccess;
using CalendarEntity;

namespace Business
{
    public class PacienteBU
    {
        /// <summary>
        /// Método que faz uma inserção básica de um paciente para que seja efetuado o agendamento.
        /// </summary>
        /// <param name="paciente">Objeto Paciente</param>
        public void InserirPacienteAgendamentoBasico(Paciente paciente)
        {
            try
            {
                new PacienteAccess().InserirPacienteAgendamentoBasico(paciente);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    
         /// <summary>
        /// Retorna todos os pacientes
        /// </summary>
        /// <returns>Datatable contendo todos os pacientes do sistema</returns>
        public DataTable RetornaPacientes()
        {
            try
            {
                return new PacienteAccess().RetornaPacientes();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        /// <summary>
        /// Retorna paciente de acordo com o id apresentado
        /// </summary>
        /// <param name="codPaciente">Código do paciente</param>
        /// <returns>Objeto paciente</returns>
        public Paciente RetornaPacienteByCpf(string cpfPaciente)
        {
            try
            {
                //Trata o cpd do paciente
                string newCpf = cpfPaciente;
                newCpf = newCpf.Replace(".", "");
                newCpf = newCpf.Replace("-", "");
            
                //Efetua chamado a camada de dados
                return new PacienteAccess().RetornaPacienteByCpf(newCpf);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Retorna paciente de acordo com o id apresentado
        /// </summary>
        /// <param name="codPaciente">Código do paciente</param>
        /// <returns>Objeto paciente</returns>
        public DataTable RetornaPacienteByCpfDataTable(string cpf, string nome)
        {
            try
            {
                //Trata o cpd do paciente
                string newCpf = cpf;
                newCpf = newCpf.Replace(".", "");
                newCpf = newCpf.Replace("-", "");
                newCpf = newCpf.Replace("_", "");

                //Efetua chamado a camada de dados
                return new PacienteAccess().RetornaPacienteByCpfDataTable(newCpf, nome);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
