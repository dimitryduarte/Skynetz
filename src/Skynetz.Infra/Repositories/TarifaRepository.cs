using Skynetz.Domain.Models;
using Skynetz.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skynetz.Infra.Repositories
{
    public class TarifaRepository : Repository<Tarifa>
    {
        public TarifaRepository(AppDbContext context) : base(context)
        { }

        public override Tarifa GetById(int id)
        {
            var query = _context.Set<Tarifa>().Where(e => e.Id == id);

            if (query.Any())
                return query.First();

            return null;
        }

        public override IEnumerable<Tarifa> GetAll()
        {
            var query = _context.Set<Tarifa>();

            return query.Any() ? query.ToList() : new List<Tarifa>();
        }
    }
}
