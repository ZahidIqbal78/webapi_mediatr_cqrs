using MediatR;
using webapi_mediatr_cqrs_example.Commands.CustomerCommands;
using webapi_mediatr_cqrs_example.Models;
using webapi_mediatr_cqrs_example.Services;

namespace webapi_mediatr_cqrs_example.Handlers.CustomerHandlers
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, Customer?>
    {
        private readonly ICustomerService customerService;

        public CreateCustomerHandler(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        public async Task<Customer?> Handle(CreateCustomerCommand customerRequest, CancellationToken cancellationToken)
        {
            var customer = new Customer
            {
                FirstName = customerRequest.FirstName,
                MiddleName = string.IsNullOrEmpty(customerRequest.MiddleName) ? null : customerRequest.MiddleName,
                LastName = customerRequest.LastName,
                Address = string.IsNullOrEmpty(customerRequest.Address) ? null : customerRequest.Address,
                Email = string.IsNullOrEmpty(customerRequest.Email) ? null : customerRequest.Email,
            };

            var created = await this.customerService.CreateCustomerAsync(customer);
            return created ? customer : null;
        }
    }
}
