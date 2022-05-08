using MediatR;
using webapi_mediatr_cqrs_example.Models;

namespace webapi_mediatr_cqrs_example.Commands.CustomerCommands
{
    public class CreateCustomerCommand : IRequest<Customer>
    {
        //using the command as dto instead of CustomerCreateRequest in the DTOs folder
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
    }
}
