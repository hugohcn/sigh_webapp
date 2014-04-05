using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CalendarDataAccess;

namespace Business
{
    public class CategoriaBU
    {
        /// <summary>
        /// Método que retorna as categorias de serviços prestados de acordo com cada médico
        /// </summary>
        /// <param name="codMedico">Código de identificação do médico</param>
        /// <returns></returns>
        public DataTable RetornaCategoriaByMedico(int codMedico)
        {
            try
            {
                return new CategoriaAccess().RetornaCategoriaByMedico(codMedico);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        /// <summary>
        /// Método que retorna todas as categorias de serviços do banco de dados
        /// </summary>
        /// <returns>Retorna um datatable contendo os resultados obtidos (Categorias de Serviços)</returns>
        public DataTable RetornaCategorias()
        {
            try
            {
                return new CategoriaAccess().RetornaCategorias();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
