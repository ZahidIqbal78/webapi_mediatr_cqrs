using MediatR;
using webapi_mediatr_cqrs_example.Commands.CustomerCommands;
using webapi_mediatr_cqrs_example.Services;

namespace webapi_mediatr_cqrs_example.Handlers.CustomerHandlers
{
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, bool>
    {
        private readonly ICustomerService customerService;

        public UpdateCustomerHandler(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        public async Task<bool> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await this.customerService.GetCustomerByIdAsync(request.CustomerId);
            if (customer == null) return false;

            customer.Id = request.CustomerId;
            customer.FirstName = request.customerRequest.FirstName;
            customer.MiddleName = string.IsNullOrEmpty(request.customerRequest.MiddleName) ? null : request.customerRequest.MiddleName;
            customer.LastName = request.customerRequest.LastName;
            customer.Address = string.IsNullOrEmpty(request.customerRequest.Address) ? null : request.customerRequest.Address;


            var isUpdated = await this.customerService.UpdateCustomerAsync(customer);
            return isUpdated;
        }
    }
}
