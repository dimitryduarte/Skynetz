using Skynetz.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skynetz.Domain.Models
{
    public class PlanoService
    {
        private readonly IRepository<Plano> _planoRepository;

        public PlanoService(IRepository<Plano> planoRepository)
        {
            _planoRepository = planoRepository;
        }

        public void Save(int id, string nome, int minutos)
        {
            var plano = _planoRepository.GetById(id);
            if (plano == null)
                plano = new Plano(nome, minutos);
            else
                plano.Update(nome, minutos);

            _planoRepository.Save(plano);
        }

        public IEnumerable<Plano> GetAll()
        {
            return _planoRepository.GetAll();
        }

        public Plano GetById(int id)
        {
            return _planoRepository.GetById(id);
        }
    }
}
