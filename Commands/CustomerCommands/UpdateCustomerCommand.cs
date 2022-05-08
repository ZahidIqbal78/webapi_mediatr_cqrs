using MediatR;
using webapi_mediatr_cqrs_example.DTOs.Request;

namespace webapi_mediatr_cqrs_example.Commands.CustomerCommands
{
    public class UpdateCustomerCommand : IRequest<bool>
    {
        public Guid CustomerId { get; set; }
        public CustomerUpdateRequest customerRequest { get; set; }

        public UpdateCustomerCommand(Guid customerId, CustomerUpdateRequest customerRequest)
        {
            CustomerId = customerId;
            this.customerRequest = customerRequest;
        }
    }
}
