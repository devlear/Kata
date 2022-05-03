using AutoFixture;
using AutoFixture.AutoMoq;
using EntityFramework.Interceptor;
using EntityFramework.Interfaces;
using FluentAssertions;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Moq;
using System;
using System.Linq;
using Xunit;

namespace EntityFramework.Tests
{
    public class AuditableEntityInterceptorTests : IClassFixture<ApplicationDbContextFixture>
    {
        private readonly IFixture _fixture;
        private readonly DbContextEventData _eventData;

        public ApplicationDbContext Context { get; }

        public AuditableEntityInterceptorTests(ApplicationDbContextFixture dbFixture)
        {
            Context = dbFixture.Context;
            _fixture = new Fixture()
                .Customize(new AutoMoqCustomization());
            _fixture.Register<DbContext>(() => Context);
            _eventData = _fixture.Create<DbContextEventData>();
        }

        [Fact]
        public void when_entity_is_added_set_datetime()
        {
            var expected = new DateTime(2008, 5, 12);
            var mockDateTime = new Mock<IDateTime>();
            mockDateTime.Setup(m => m.Now).Returns(expected);
            _fixture.Inject(mockDateTime);

            var target = _fixture.Create<AuditableEntityInterceptor>();
            var entity = new TestEntity();
            Context.Add(entity);
            target.SavingChanges(_eventData, new InterceptionResult<int>());
            Context.SaveChanges();

            var result = Context.TestEntities.First();
            result.Created.Should().Be(expected);
        }
    }

    public class ApplicationDbContextFixture : IDisposable
    {
        private SqliteConnection _connection;

        public ApplicationDbContext Context { get; }
        
        public ApplicationDbContextFixture()
        {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlite(_connection)
                .Options;

            Context = new ApplicationDbContext(options);

            Context.Database.EnsureCreated();
        }

        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}
