using MediatR;
using webapi_mediatr_cqrs_example.Models;

namespace webapi_mediatr_cqrs_example.Queries.CustomerQueries
{
    public class GetCustomerByIdQuery : IRequest<Customer>
    {
        public Guid CustomerId { get; set; }

        public GetCustomerByIdQuery(Guid id)
        {
            CustomerId = id;
        }

    }
}
