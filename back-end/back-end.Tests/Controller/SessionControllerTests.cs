using Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CateringApp.Controllers;
using DTO;
using FakeItEasy;
using FluentAssertions;
using Business;
using DTO.Viewmodels;

namespace back_end.Tests.Controller
{
    public class SessionControllerTests
    {
        private readonly ISessionBusiness _sessionBusiness;

        public SessionControllerTests()
        {
            _sessionBusiness = A.Fake<ISessionBusiness>();

        }

        [Fact]
        public void TableController_AddSession()
        {
            //Arrange
            int tableId = 1;
            var session = A.Fake<SessionViewModel>();
            A.CallTo(() => _sessionBusiness.createSession(tableId)).Returns(session);

            var controller = new SessionController(_sessionBusiness);

            //Act
            var result = controller.createSession(tableId);

            //Assert
            result.Should().NotBeNull();
            Assert.Equal(result, session);

        }

        [Fact]
        public void TableController_GetCurrentSession()
        {
            //Arrange
            int id = 1;
            var session = A.Fake<Session>();
            A.CallTo(() => _sessionBusiness.getCurrentSession(id)).Returns(session);

            var controller = new SessionController(_sessionBusiness);

            //Act
            var result = controller.GetCurrentSession(id);

            //Assert
            result.Should().NotBeNull();
            Assert.Equal(result, session);

        }

        [Fact]
        public void TableController_GetOrdersForSession()
        {
            //Arrange
            int id = 1;
            var orders = A.Fake<List<Order>>();
            A.CallTo(() => _sessionBusiness.GetOrdersForSession(id)).Returns(orders);

            var controller = new SessionController(_sessionBusiness);

            //Act
            var result = controller.GetOrdersForSession(id);

            //Assert
            result.Should().NotBeNull();
            result.Should().Equal();
            //Assert.Equal(result, orders);
           

        }
    }
}
