using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Skynetz.Domain.Models;
using Skynetz.Infra.Context;
using Skynetz.Infra.Repositories;
using Skynetz.Web.DTOs;

namespace Skynetz.Web
{
    public class SimulacaoController : Controller
    {
        private readonly AppDbContext _context;
        private readonly TarifaRepository _tarifaRepository;
        private readonly PlanoRepository _planoRepository;

        public SimulacaoController(AppDbContext context)
        {
            _context = context;
            _tarifaRepository = new TarifaRepository(_context);
            _planoRepository = new PlanoRepository(_context);
        }

        // GET: Tarifas
        public async Task<IActionResult> Index()
        {
            var tarifas = _tarifaRepository.GetAll().ToList();
            var planos = _planoRepository.GetAll().ToList();
            return View(new SimulacaoRequestDTO { Planos = planos, Tarifas = tarifas });
        }

        [HttpPost, ActionName("Calcular")]
        public IActionResult Calcular(int tarifaId, int quantMinutos, int planoId)
        {
            try
            {
                var request = new RequestSimulacaoDTO(quantMinutos, tarifaId, planoId);

                var tarifa = _tarifaRepository.GetById(request.tarifaId);
                var plano = _planoRepository.GetById(request.planoId);

                var minutosDesconto = plano.DescontarMinutos(request.quantMinutos);
                var valorComPlano = tarifa.CalcularTarifa(minutosDesconto);
                var valorSemPlano = tarifa.CalcularTarifa(request.quantMinutos);

                return Ok(new ResponseSimulacaoDTO
                {
                    valorComPlano = valorComPlano.ToString(),
                    valorSemPlano = valorSemPlano.ToString()
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
