using MediatR;
using Microsoft.AspNetCore.Mvc;
using webapi_mediatr_cqrs_example.Commands.CustomerCommands;
using webapi_mediatr_cqrs_example.DTOs.Request;
using webapi_mediatr_cqrs_example.Queries.CustomerQueries;
using webapi_mediatr_cqrs_example.Services;

namespace webapi_mediatr_cqrs_example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        //private readonly ICustomerService customerService; // no longer required...
        private readonly IMediator mediator;

        public CustomersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var query = new GetAllCustomersQuery();
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomer([FromRoute] Guid customerId)
        {
            var query = new GetCustomerByIdQuery(customerId);
            var result = await mediator.Send(query);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCustomerCommand customerRequest)
        {
            var result = await this.mediator.Send(customerRequest);
            return result != null ? Ok(result) : NoContent();
            //or return CreatedAtAction instead of Ok
        }

        [HttpPut("{customerId}")]
        public async Task<IActionResult> Update([FromRoute] Guid customerId, [FromBody] CustomerUpdateRequest customerRequest)
        {
            var command = new UpdateCustomerCommand(customerId, customerRequest);
            var result = await this.mediator.Send(command);
            return result ? Ok() : NoContent();
        }

        [HttpDelete("{customerId}")]
        public async Task<IActionResult> Delete([FromRoute] Guid customerId)
        {
            var command = new DeleteCustomerCommand(customerId);
            var result = await this.mediator.Send(command);
            return result ? Ok() : NotFound(); // a proper return result needed, not not found.
        }
    }
}
