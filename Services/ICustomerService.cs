using webapi_mediatr_cqrs_example.Models;

namespace webapi_mediatr_cqrs_example.Services
{
    public interface ICustomerService
    {
        Task<bool> CreateCustomerAsync(Customer customer);
        Task<List<Customer>> GetCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(Guid id);
        Task<bool> UpdateCustomerAsync(Customer customer);
        Task<bool> DeleteCustomerAsync(Guid id);
    }
}
