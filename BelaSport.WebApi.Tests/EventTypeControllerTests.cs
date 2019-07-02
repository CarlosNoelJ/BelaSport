using AutoFixture;
using BelaSport.Models;
using BelaSport.Repository;
using BelaSport.WebApi.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BelaSport.WebApi.Tests
{
    public class EventTypeControllerTests
    {
        private EventTypeController _eventType;
        [SetUp]
        public void Setup()
        {
            _eventType = new EventTypeController(CreateUnitOfWork());
        }

        [Test]
        public void Get_GoodData_OkResult()
        {
            var request = _eventType.Get() as OkObjectResult;
            var result = (List<EventType>)request.Value;

            result.Count.Should().BeGreaterThan(0);
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

            var unit = new Mock<IUnitOfWork>();
            unit.Setup(x => x.EventType).Returns(eventTyperepository.Object);
            return unit.Object;
        }

        private EventType NewEventType()
        {
            return new EventType
            {
                EventTypeId = 3,
                NameEventType = "E-Sport"
            };
        }
    }
}
