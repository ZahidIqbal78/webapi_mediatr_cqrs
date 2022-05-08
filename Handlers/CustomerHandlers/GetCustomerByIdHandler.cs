using MediatR;
using webapi_mediatr_cqrs_example.Models;
using webapi_mediatr_cqrs_example.Queries;
using webapi_mediatr_cqrs_example.Queries.CustomerQueries;
using webapi_mediatr_cqrs_example.Services;

namespace webapi_mediatr_cqrs_example.Handlers.CustomerHandlers
{
    public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdQuery, Customer>
    {
        private readonly ICustomerService customerService;

        public GetCustomerByIdHandler(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        public async Task<Customer> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await this.customerService.GetCustomerByIdAsync(request.CustomerId);
            if(customer == null) return null;
            return customer;
        }
    }
}
