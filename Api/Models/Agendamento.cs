using System;

namespace Api.Models
{
    public class Agendamento
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Nome { get; set; }
        public string Especie { get; set; }
        public string Servico { get; set; }
    }
}