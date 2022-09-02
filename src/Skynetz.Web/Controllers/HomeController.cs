using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Skynetz.Domain.Interfaces;
using Skynetz.Domain.Models;
using Skynetz.Web.Models;

namespace Skynetz.Web.Controllers
{
    public class TarifaController : Controller
    {
        private readonly ILogger<TarifaController> _logger;
        private readonly TarifaService _tarifaService;
        private readonly IRepository<Tarifa> _tarifaRepository;
        public TarifaController(TarifaService tarifaService,
            IRepository<Tarifa> tarifaRepository)
        {
            _tarifaService = tarifaService;
            _tarifaRepository = tarifaRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IEnumerable<Tarifa> GetTarifa()
        {
            var tarifas = _tarifaRepository.GetAll();
            return tarifas;
        }
        [HttpGet("{id}")]
        public ActionResult<Tarifa> GetTarifa(int id)
        {
            var tarifa = _tarifaRepository.GetById(id);
            if (tarifa == null)
            {
                return NotFound(new { message = $"Tarifa de id={id} não encontrado" });
            }
            return tarifa;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
