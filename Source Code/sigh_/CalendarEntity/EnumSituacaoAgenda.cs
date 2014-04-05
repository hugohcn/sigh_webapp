using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalendarEntity
{
    public enum SituacaoAgenda
    {
        Marcado = 0,
        Esperando,
        Exame,
        Atendido,
        Faltou,
        Cancelado,
        Encaixe,
        Confirmado,
        Transferido,
        Bloqueado
    }
    
    public enum DiaSemana
    {
        Segunda_feira,
        Terça_feira,
        Quarta_feira,
        Quinta_feira,
        Sexta_feira,
        Sábado,
        Domingo
    }
}
