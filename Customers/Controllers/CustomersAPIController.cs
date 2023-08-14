using CustomerManagment.BusinessLogicLayer.Interface;
using CustomerManagment.DataAccessLayer.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace CustomerManagment.Api.Controllers
{
    [Route("/api/CustomersAPI")]
    [ApiController]
    public class CustomersAPIController:ControllerBase
    {
       private readonly ICustomersBLL _bll;
        public CustomersAPIController(ICustomersBLL bll)
        {
            
            _bll = bll;
            
        }
        [HttpGet(Name ="GetCustomerList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async  Task <ActionResult<IEnumerable<Customer>>> GetCustomerList()
        {
            IEnumerable <Customer> cust = await _bll.GetCustomerList();
            if (cust is null)
            {
                return NotFound();
            }
            return Ok(cust);
        }
        [HttpGet("{id:int}",Name ="GetCustomer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
       
        public async Task<ActionResult< Customer>> GetCustomer(int id)
        {
            if(id==0)
            {
                return BadRequest();
            }
            Customer cust=await _bll.GetCustomer(id);
            if (cust == null)
            {
                return NotFound();
            }
            return  Ok(cust);
        }

        [HttpPost(Name ="CreateCustomer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult< Customer> CreateCustomer([FromBody]Customer customer)
        {
            
            if(customer == null)
            {
               return BadRequest();
            }
            if (customer.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            _bll.CreateCustomer(customer);
            return CreatedAtRoute("GetCustomer", new {id=customer.Id},customer);
        }
        [HttpDelete("{id:int}",Name ="DeleteCustomer")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult DeleteCustomer(int id)
        {
            if (id==0)
            { return BadRequest(); }    
           var result=  _bll.DeleteCustomer(id);
            if(result==HttpStatusCode.NotFound)
            { return NotFound() ; }
            return NoContent();
            
        }

        [HttpPut("{id:int}",Name ="UpdateCustomer")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult UpdateCustomer(int id,[FromBody] Customer customer)
        {
            if(id==0||customer==null||id!=customer.Id)
            { return BadRequest(); }    
            var result= _bll.UpdateCustomer(id, customer);
            if(result==HttpStatusCode.NotFound)
            {
                return NotFound() ;
            }
            return NoContent();
        }
    }
}
