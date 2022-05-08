using MediatR;
using webapi_mediatr_cqrs_example.Models;

namespace webapi_mediatr_cqrs_example.Queries.CustomerQueries
{
    public class GetAllCustomersQuery : IRequest<List<Customer>>
    {
    }
}
