using MediatR;

namespace webapi_mediatr_cqrs_example.Commands.CustomerCommands
{
    public class DeleteCustomerCommand : IRequest<bool>
    {
        public Guid CustomerId { get; set; }

        public DeleteCustomerCommand(Guid id)
        {
            CustomerId = id;
        }
    }
}
