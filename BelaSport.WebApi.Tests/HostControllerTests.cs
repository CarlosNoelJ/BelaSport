using AutoFixture;
using BelaSport.Models;
using BelaSport.Repository;
using BelaSport.WebApi.Controllers;
using FluentAssertions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace BelaSport.WebApi.Tests
{
    public class HostControllerTests
    {
        private HostController _host;
        private readonly IValidator<Host> _validator;
        [SetUp]
        public void Setup()
        {
            _host = new HostController(CreateUnitOfWork(),_validator);
        }

        [Test]
        public void GET_GoodData_OkResult()
        {
            var request = _host.Get() as OkObjectResult;
            var result = (List<Host>)request.Value;

            result.Count.Should().BeGreaterThan(0);
        }

        [Test]
        public void GET_ByID_GoodData_OkResult()
        {
            var hostId = 1;

            var request = _host.GetById(hostId) as OkObjectResult;
            var result = (Host)request.Value;

            result.Should().NotBeNull();
        }

        [Test]
        public void POST_GoodData_OkResult()
        {
            var request = _host.Post(NewHost()) as OkObjectResult;
            var result = (int)request.Value;

            result.Should().BeGreaterThan(0);
        }

        [Test]
        public void PUT_GoodData_OkResult()
        {
            var request = _host.Put(NewHost()) as OkObjectResult;
            var result = (int)request.Value;

            result.Should().BeGreaterThan(0);
        }

        [Test]
        public void DELTE_GoodData_OkResult()
        {
            var request = _host.Delete(NewHost()) as OkObjectResult;
            var result = (int)request.Value;

            result.Should().BeGreaterThan(0);
        }

        private IUnitOfWork CreateUnitOfWork()
        {
            var fixture = new Fixture();
            var host = fixture.Build<Host>()
                .Without(et => et.EventTitle)
                .CreateMany<Host>(100).ToList();

            var hostrepository = new Mock<IRepository<Host>>();
            hostrepository.Setup(x => x.Add(It.Is<Host>(a => a.DniHost == 1))).Returns(1);
            hostrepository.Setup(x => x.Update(It.Is<Host>(a => a.DniHost == 1))).Returns(1);
            hostrepository.Setup(x => x.Delete(It.Is<Host>(a => a.DniHost == 1))).Returns(1);
            hostrepository.Setup(x => x.GetList()).Returns(host);
            hostrepository.Setup(x => x.GetById(1)).Returns(host[0]);

            var unit = new Mock<IUnitOfWork>();
            unit.Setup(x => x.Host).Returns(hostrepository.Object);
            return unit.Object;
        }

        public Host NewHost()
        {
            return new Host
            {
                DniHost = 1,
                NameHost = "Samuel",
                LastNameHost = "Umtiti"
            };
        }
    }
}
