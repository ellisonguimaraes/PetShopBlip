using System;
using System.Collections.Generic;
using Api.Models;

namespace Api.Repositories
{
    public interface IAgendamentoRepository
    {
        Agendamento Create(Agendamento agendamento);
        bool TimeIsAvailable(DateTime date);
        List<int> AllTimesAvailable(DateTime date, int startOfficeHours, int endOfficeHours);
    }
}