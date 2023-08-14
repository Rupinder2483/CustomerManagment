using CustomerManagment.Api.Controllers;
using CustomerManagment.BusinessLogicLayer;
using CustomerManagment.BusinessLogicLayer.Interface;
using CustomerManagment.DataAccessLayer.Model;
using CustomerManagment.TestApi.Mock;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Xunit;

namespace CustomerManagment.TestApi.Systems.Controllers
{
    public class TestCustomersAPIController
    {
        public TestCustomersAPIController()
        {
        }
        [Fact]
        public async Task GetCustomerList_ShouldReturn200Status()
        {
            //arange
            var MockCustomerRepository = new Mock<ICustomersBLL>();
            var sut = new CustomersAPIController(MockCustomerRepository.Object);

            //act
            var actionResult =await sut.GetCustomerList();
            var result=actionResult.Result;

            result.Should().BeOfType<OkObjectResult>()
                .Which.StatusCode.Should().Be((int)HttpStatusCode.OK);

            ((ObjectResult)actionResult.Result).Value.Should().NotBeNull();
        }
        [Fact]
        public async Task GetCustomer_WhenRequestingAnExistingCustomerAsynchronously_ThenReturnASingleCustomer()
        {
            //arange

            int id = 1;
            var MockCustomerRepository = new Mock<ICustomersBLL>();
            var sut = new CustomersAPIController(MockCustomerRepository.Object);
            //act
            var actionResult= await sut.GetCustomer(id);
            var result = actionResult.Result;

            Assert.NotNull(result);
            Assert.Equal(CustomersMockData.MockCustomers.First(), ((ObjectResult)actionResult.Result).Value);
        }
        [Fact]
        public async Task DeleteCustomer_ShouldReturn204Status()
        {
            int id = 1;
            var MockCustomerRepository =new Mock<ICustomersBLL>();
            var sut = new CustomersAPIController(MockCustomerRepository.Object);
            //act
          var actionResult = sut.DeleteCustomer(id);
            actionResult.Should().BeOfType<NoContentResult>()
                .Which.StatusCode.Should().Be((int)HttpStatusCode.NoContent);
        }
        [Fact]
        public async Task CreateCustomer_shouldReturnCreatedAtRouteResult()
        {
            var MockCustomerRepository = new Mock<ICustomersBLL>();
            var sut = new CustomersAPIController(MockCustomerRepository.Object);
            ActionResult<Customer> actionResult = sut.CreateCustomer(new Customer { Id = 0, First_Name = "Mock", Last_Name = "Test", });
            var result = actionResult.Result;
            result.Should().BeOfType<CreatedAtRouteResult>()
              .Which.RouteName.Should().Be("GetCustomer");
            result.Should().BeOfType<CreatedAtRouteResult>()
              .Which.StatusCode.Should().Be((int)HttpStatusCode.Created);
        }
        [Fact]
        public async Task UpdateCustomer_shouldReturnAcceptedStatusCode()
        {
            var MockCustomerRepository = new Mock<ICustomersBLL>();
            var sut = new CustomersAPIController(MockCustomerRepository.Object);
            IActionResult actionResult = sut.UpdateCustomer(1 ,new Customer { Id = 1, First_Name = "UpdateFirstName" });
            actionResult.Should().BeOfType<AcceptedResult>()
                 .Which.StatusCode.Should().Be((int)HttpStatusCode.Accepted);

        }
    }
}
