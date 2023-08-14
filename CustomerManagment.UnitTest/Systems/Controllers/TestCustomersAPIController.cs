using CustomerManagment.Api.Controllers;
using CustomerManagment.BusinessLogicLayer;
using CustomerManagment.BusinessLogicLayer.Interface;
using CustomerManagment.DataAccessLayer.Model;
using CustomerManagment.TestApi.MockData;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
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
            MockCustomerRepository.Setup(x=>x.GetCustomerList()).ReturnsAsync( CustomersMockData.MockCustomers);
            var sut = new CustomersAPIController(MockCustomerRepository.Object);
            //act
            var actionResult =await sut.GetCustomerList();
            var result=actionResult.Result;
          




            result.Should().BeOfType<OkObjectResult>()
                .Which.StatusCode.Should().Be((int)HttpStatusCode.OK);
            ((ObjectResult)actionResult.Result).Value.Should().NotBeNull();
        }
        [Fact]
        public async Task GetCustomer_ShouldReturn200Status()
        {
            //arange

            int id = 1;
            
            
            var MockCustomerRepository = new Mock<ICustomersBLL>();
            MockCustomerRepository.Setup(x => x.GetCustomer(It.IsAny<int>())).ReturnsAsync(CustomersMockData.MockCustomers.First());

            //MockCustomerRepository.Setup(h => h.GetCustomer(It.IsAny<int>())).Callback<int>(r => result = r);
            var sut = new CustomersAPIController(MockCustomerRepository.Object);
            //act
           var actionResult= await sut.GetCustomer(id);
            var result = actionResult.Result;


            result.Should().BeOfType<OkObjectResult>()
                .Which.StatusCode.Should().Be((int)HttpStatusCode.OK);
            ((ObjectResult)actionResult.Result).Value.Should().NotBeNull();
        }
    }
}
