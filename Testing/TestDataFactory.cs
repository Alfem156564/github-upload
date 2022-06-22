namespace Testing
{
    using Data.Models.Entities;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    internal static class TestDataFactory
    {
        public const string ValidUserTypeId = "89151b41-45e1-44da-ac75-ee0e084f1d22";

        public static Mock<DbSet<UserTypeEntity>> GetUserTypeMock()
        {
            return new List<UserTypeEntity>
            {
                new UserTypeEntity
                    {
                        Id = ValidUserTypeId,
                        IsEnabled = true,
                        Name = "admin",
                    },
                new UserTypeEntity
                    {
                        Id = Guid.NewGuid().ToString(),
                        IsEnabled = true,
                        Name = "user",
                    }
            }.AsDbSetMock();
        }

        public static Mock<DbSet<T>> AsDbSetMock<T>(this IEnumerable<T> data) where T : class
        {
            var queryable = (data ?? Enumerable.Empty<T>()).AsQueryable();
            var dbSetMock = new Mock<DbSet<T>>();

            dbSetMock
           .As<IQueryable<T>>()
           .Setup(dbSet => dbSet.Provider)
           .Returns(new TestAsyncQueryProvider<T>(queryable.Provider));

            dbSetMock
           .As<IQueryable<T>>()
           .Setup(dbSet => dbSet.Expression)
           .Returns(queryable.Expression);

            dbSetMock
           .As<IQueryable<T>>()
           .Setup(dbSet => dbSet.ElementType)
           .Returns(queryable.ElementType);

            dbSetMock
           .As<IQueryable<T>>()
           .Setup(dbSet => dbSet.GetEnumerator())
           .Returns(queryable.GetEnumerator());

            dbSetMock
           .As<IAsyncEnumerable<T>>()
           .Setup(dbSet => dbSet.GetAsyncEnumerator(CancellationToken.None))
           .Returns(new TestAsyncEnumerator<T>(queryable.GetEnumerator()));

            return dbSetMock;
        }

        public static Mock<DbSet<T>> CreateDbSetMock<T>() where T : class =>
         AsDbSetMock(Enumerable.Empty<T>());
    }
}
