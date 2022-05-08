using MediatR;
using webapi_mediatr_cqrs_example.Models;
using webapi_mediatr_cqrs_example.Queries.CustomerQueries;
using webapi_mediatr_cqrs_example.Services;

namespace webapi_mediatr_cqrs_example.Handlers.CustomerHandlers
{
    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, List<Customer>>
    {
        private readonly ICustomerService customerService;
        public GetAllCustomersQueryHandler(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        public async Task<List<Customer>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var customers = await this.customerService.GetCustomersAsync();
            return customers;
        }
    }
}
