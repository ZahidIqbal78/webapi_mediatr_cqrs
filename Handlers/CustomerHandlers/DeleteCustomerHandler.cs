using MediatR;
using webapi_mediatr_cqrs_example.Commands.CustomerCommands;
using webapi_mediatr_cqrs_example.Services;

namespace webapi_mediatr_cqrs_example.Handlers.CustomerHandlers
{
    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand, bool>
    {
        private readonly ICustomerService customerService;

        public DeleteCustomerHandler(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        public async Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var isDeleted = await this.customerService.DeleteCustomerAsync(request.CustomerId);
            return isDeleted;
        }
    }
}
