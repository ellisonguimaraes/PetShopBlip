using System.Globalization;
using System;
using Microsoft.AspNetCore.Mvc;
using Api.Models;
using Api.Repositories;
using System.Collections.Generic;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgendamentoController : ControllerBase
    {
        private readonly IAgendamentoRepository _agendamentoRepository;

        public AgendamentoController(IAgendamentoRepository agendamentoRepository)
        {
            _agendamentoRepository = agendamentoRepository;
        }

        [HttpGet]
        [Route("availabletime")]
        public IActionResult GetAvailableTime([FromQuery]string datastring)
        {
            DateTime data = DateTime.ParseExact(
                datastring.Replace("/", "-"),
                "dd-MM-yyyy", CultureInfo.InvariantCulture
            );

            List<int> hoursAvailable = _agendamentoRepository.AllTimesAvailable(data, 8, 18);
    
            return Ok(new {horarios = String.Join("H, ", hoursAvailable) + "H"});
        }

        [HttpPost]
        public IActionResult Post(
            [FromQuery]string datastring,
            [FromQuery]int horario,
            [FromQuery]string nome,
            [FromQuery]string especie,
            [FromQuery]string servico)
        {
            Agendamento agendamento = new Agendamento{
                Data = DateTime.ParseExact(
                    datastring + $" {horario:D2}:00:00",
                    "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture
                ),
                Especie = especie,
                Servico = servico,
                Nome = nome
            };

            if(!_agendamentoRepository.TimeIsAvailable(agendamento.Data)) 
                return BadRequest("Este horário já foi marcado por outra pessoa.");

            return Ok(_agendamentoRepository.Create(agendamento));
        }
    }
}