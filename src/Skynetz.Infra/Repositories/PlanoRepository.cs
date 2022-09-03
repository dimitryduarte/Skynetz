using Skynetz.Domain.Models;
using Skynetz.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skynetz.Infra.Repositories
{
    public class PlanoRepository : Repository<Plano>
    {
        public PlanoRepository(AppDbContext context) : base(context)
        { }

        public override Plano GetById(int id)
        {
            var query = _context.Set<Plano>().Where(e => e.Id == id);

            if (query.Any())
                return query.First();

            return null;
        }

        public override IEnumerable<Plano> GetAll()
        {
            var query = _context.Set<Plano>();

            return query.Any() ? query.ToList() : new List<Plano>();
        }

        public Plano GetByNome(string nome)
        {
            return _context.Set<Plano>().Where(x => x.Nome.Contains(nome)).FirstOrDefault();
        }
    }
}
