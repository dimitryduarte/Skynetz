using Skynetz.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skynetz.Domain.Models
{
    public class TarifaService
    {
        private readonly IRepository<Tarifa> _tarifaRepository;

        public TarifaService(IRepository<Tarifa> tarifaRepository)
        {
            _tarifaRepository = tarifaRepository;
        }

        public void Save(int id, string origem, string destino, decimal tarifaMin)
        {
            var tarifa = _tarifaRepository.GetById(id);
            if (tarifa == null)
                tarifa = new Tarifa(origem, destino, tarifaMin);
            else
                tarifa.Update(origem, destino, tarifaMin);

            _tarifaRepository.Save(tarifa);
        }

        public IEnumerable<Tarifa> GetAll()
        {
            return _tarifaRepository.GetAll();
        }

        public Tarifa GetById(int id)
        {
            return _tarifaRepository.GetById(id);
        }
    }
}
