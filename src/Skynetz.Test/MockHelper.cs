using Microsoft.EntityFrameworkCore;
using Moq;
using Skynetz.Infra.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;

namespace Skynetz.Test
{
    public class MockHelper<T> where T : class
    {
        public Mock<AppDbContext> _db = new Mock<AppDbContext>();
        public Mock<DbSet<T>> _table = new Mock<DbSet<T>>();

        public MockHelper(Mock<AppDbContext> mockDb = null)
        {
            _db = mockDb ?? new Mock<AppDbContext>();
        }

        public Mock<AppDbContext> MoqContext(List<T> modelData)
        {
            var data = modelData.AsQueryable();

            var _table = new Mock<DbSet<T>>();

            _table.As<IDbAsyncEnumerable<T>>()
                    .Setup(m => m.GetAsyncEnumerator())
                    .Returns(new TestDbAsyncEnumerator<T>(data.GetEnumerator()));

            _table.As<IQueryable<T>>()
                .Setup(m => m.Provider)
                .Returns(new TestDbAsyncQueryProvider<T>(data.Provider));

            _table.As<IQueryable<T>>().Setup(m => m.Expression).Returns(data.Expression);
            _table.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(data.ElementType);
            _table.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            _db.Setup(m => m.Set<T>()).Returns(_table.Object);

            return _db;
        }

    }
}
