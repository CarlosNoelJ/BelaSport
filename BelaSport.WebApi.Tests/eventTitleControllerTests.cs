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
    [Route("api/eventTitle")]
    [ApiController]
    public class eventTitleControllerTests : ControllerBase
    {
        private EventTitleController _eventTitle;
        [SetUp]
        public void SetUp()
        {
            _eventTitle = new EventTitleController(CreateUnitOfWork());
        }

        [Test]
        public void GET_GoodData_OkResult()
        {
            var request = _eventTitle.Get() as OkObjectResult;
            var result = (List<EventTitle>)request.Value;

            result.Count.Should().BeGreaterThan(0);
        }

        [Test]
        public void GET_ByID_GoodData_OkResult()
        {
            var eventTitleId = 1;

            var request = _eventTitle.GetById(eventTitleId) as OkObjectResult;
            var result = (EventTitle)request.Value;

            result.Should().NotBeNull();
        }

        [Test]
        public void POST_GoodData_OkResult()
        {
            var request = _eventTitle.Post(NewEventTitle()) as OkObjectResult;
            var result = (int)request.Value;

            result.Should().BeGreaterThan(0);
        }

        [Test]
        public void PUT_GoodData_OkResult()
        {
            var request = _eventTitle.Put(NewEventTitle()) as OkObjectResult;
            var result = (int)request.Value;

            result.Should().BeGreaterThan(0);
        }

        [Test]
        public void DELETE_GoodData_OkResult()
        {
            var request = _eventTitle.Delete(NewEventTitle()) as OkObjectResult;
            var result = (int)request.Value;

            result.Should().BeGreaterThan(0);
        }

        private IUnitOfWork CreateUnitOfWork()
        {
            var fixture = new Fixture();
            var EventTitle = fixture.Build<EventTitle>()
                .Without(et => et.EventType)
                .Without(et => et.DniHostNavigation)
                .CreateMany(100).ToList();

            var eventTitlerepository = new Mock<IRepository<EventTitle>>();
            eventTitlerepository.Setup(x => x.Add(It.Is<EventTitle>(a => a.EventId == 1))).Returns(1);
            eventTitlerepository.Setup(x => x.Update(It.Is<EventTitle>(a => a.EventId == 1))).Returns(1);
            eventTitlerepository.Setup(x => x.Delete(It.Is<EventTitle>(a => a.EventId == 1))).Returns(1);
            eventTitlerepository.Setup(x => x.GetList()).Returns(EventTitle);
            eventTitlerepository.Setup(x => x.GetById(1)).Returns(EventTitle[0]);

            var unit = new Mock<IUnitOfWork>();
            unit.Setup(x => x.EventTitle).Returns(eventTitlerepository.Object);
            return unit.Object;
        }

        private EventTitle NewEventTitle()
        {
            return new EventTitle
            {
                EventId = 1,
                NameEvent = "Football Championship Belatrix",
                DniHost = 1,
                EventTypeId = 2
            };
        }
    }
}
