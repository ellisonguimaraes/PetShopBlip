using System;
using System.Collections.Generic;
using System.Linq;
using Api.Data;
using Api.Models;

namespace Api.Repositories
{
    public class AgendamentoRepository : IAgendamentoRepository
    {
        private readonly ApplicationDbContext _context;

        public AgendamentoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Agendamento Create(Agendamento agendamento)
        {
            try {
                _context.Agendamentos.Add(agendamento);
                _context.SaveChanges();
            
            } catch(Exception) {
                throw;
            }

            return agendamento;
        }

        public bool TimeIsAvailable(DateTime date)
        {
            var scheduleOfDay = _context.Agendamentos
                .Where(ag =>    ag.Data.Year == date.Year && 
                                ag.Data.Month == date.Month && 
                                ag.Data.Day == date.Day &&
                                ag.Data.Hour == date.Hour)
                .ToList();
        
            return scheduleOfDay.Count == 0;
        }

        public List<int> AllTimesAvailable(DateTime date, int startOfficeHours, int endOfficeHours)
        {
            List<int> hoursAvailable = new List<int>();

            for(int i = startOfficeHours; i < endOfficeHours; i++)
            {
                DateTime d = new DateTime(date.Year, date.Month, date.Day, i, 0, 0);
                if(this.TimeIsAvailable(d))
                {
                    hoursAvailable.Add(i);
                }
            }

            return hoursAvailable;
        }
    }
}