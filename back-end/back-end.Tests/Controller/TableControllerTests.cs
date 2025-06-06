using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business;
using CateringApp.Controllers;
using Business.Interfaces;
using DTO;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;



namespace back_end.Tests.Controller
{
    
    public class TableControllerTests
    {

        private readonly ITableManager _tableManager;

        public TableControllerTests()
        {
            _tableManager = A.Fake<ITableManager>();
        }
       

       [Fact]
       public void TableController_GetAll()
       {
            //Arrange
            var tables = A.Fake<IEnumerable<Table>>();
            A.CallTo(() => _tableManager.getAll()).Returns(tables);

            var controller = new TableController(_tableManager);

            //Act
            var result = controller.getAll();

            //Assert
            result.Should().NotBeNull();
            Assert.Equal(result, tables);

       }

    }
}
