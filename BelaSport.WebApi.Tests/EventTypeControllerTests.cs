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
    public class EventTypeControllerTests
    {
        private EventTypeController _eventType;
        private readonly IValidator<EventType> _validator;
        [SetUp]
        public void Setup()
        {
            _eventType = new EventTypeController(CreateUnitOfWork(), _validator);
        }

        [Test]
        public void GET_GoodData_OkResult()
        {
            var request = _eventType.Get() as OkObjectResult;
            var result = (List<EventType>)request.Value;

            result.Count.Should().BeGreaterThan(0);
        }

        [Test]
        public void GET_ByID_GoodData_OkResult()
        {
            var eventTypeId = 1;

            var request = _eventType.GetById(eventTypeId) as OkObjectResult;
            var result = (EventType)request.Value;

            result.Should().NotBeNull();
        }

        [Test]
        public void POST_GoodData_OkResult()
        {
            var request = _eventType.Post(NewEventType()) as OkObjectResult;
            var result = (int)request.Value;

            result.Should().BeGreaterThan(0);
        }

        [Test]
        public void PUT_GoodData_OkResult()
        {
            var request = _eventType.Put(NewEventType()) as OkObjectResult;
            var result = (int)request.Value;

            result.Should().BeGreaterThan(0);
        }

        [Test]
        public void DELETE_GoodData_OkResult()
        {
            var request = _eventType.Delete(NewEventType()) as OkObjectResult;
            var result = (int)request.Value;

            result.Should().BeGreaterThan(0);
        }

        private IUnitOfWork CreateUnitOfWork()
        {
            var fixture = new Fixture();
            var eventType = fixture.Build<EventType>()
                .Without( et => et.EventTitle)
                .CreateMany<EventType>(100).ToList();

            var eventTyperepository = new Mock<IRepository<EventType>>();
            eventTyperepository.Setup(x => x.Add(It.Is<EventType>(a => a.EventTypeId == 1 ))).Returns(1);
            eventTyperepository.Setup(x => x.Update(It.Is<EventType>(a => a.EventTypeId == 1))).Returns(1);
            eventTyperepository.Setup(x => x.Delete(It.Is<EventType>(a => a.EventTypeId == 1))).Returns(1);
            eventTyperepository.Setup(x => x.GetList()).Returns(eventType);
            eventTyperepository.Setup(x => x.GetById(1)).Returns(eventType[0]);

            var unit = new Mock<IUnitOfWork>();
            unit.Setup(x => x.EventType).Returns(eventTyperepository.Object);
            return unit.Object;
        }

        private EventType NewEventType()
        {
            return new EventType
            {
                EventTypeId = 1,
                NameEventType = "E-Sport"
            };
        }
    }
}
