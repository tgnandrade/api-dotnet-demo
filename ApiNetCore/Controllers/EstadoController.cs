using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiNetCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstadoController : ControllerBase
    {
        private static readonly string[] States = new[]
        {
            "AC",
            "AL",
            "AM",
            "AP",
            "BA",
            "CE",
            "DF",
            "ES",
            "GO",
            "MA",
            "MG",
            "MS",
            "MT",
            "PA",
            "PB",
            "PE",
            "PI",
            "PR",
            "RJ",
            "RN",
            "RO",
            "RR",
            "RS",
            "SC",
            "SE",
            "SP",
            "TO"
        };

        private readonly ILogger<EstadoController> _logger;

        public EstadoController(ILogger<EstadoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Estado> Get()
        {
            var rng = new Random();
            return Enumerable.Range(0, States.Length - 1).Select(idx => new Estado
            {
                Id = idx,
                Nome = States[idx],
                Sigla = States[idx]
            })
            .ToArray();
        }

        [HttpGet("{id}")]
        public ActionResult<Estado> Get(int id)
        {
            var rng = new Random();
            return Enumerable.Range(0, States.Length - 1).Select(idx => new Estado
            {
                Id = id,
                Nome = States[id],
                Sigla = States[id]
            })
            .FirstOrDefault();
        }

        [HttpPost]
        public void Post([FromBody] Estado obj)
        {
            _logger.Log(LogLevel.Debug, $"C: {obj.Nome}, F: {obj.Sigla}");
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Estado obj)
        {
            _logger.Log(LogLevel.Debug, $"id: {id}, C: {obj.Nome}, F: {obj.Sigla}");
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _logger.Log(LogLevel.Debug, $"id: {id}");
        }
    }
}