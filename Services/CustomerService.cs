using Microsoft.EntityFrameworkCore;
using webapi_mediatr_cqrs_example.Data;
using webapi_mediatr_cqrs_example.Models;

namespace webapi_mediatr_cqrs_example.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly DatabaseContext databaseContext;

        public CustomerService(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<bool> CreateCustomerAsync(Customer customer)
        {
            await this.databaseContext.Customer.AddAsync(customer);
            var created = await this.databaseContext.SaveChangesAsync();
            return created > 0;
        }

        public async Task<bool> DeleteCustomerAsync(Guid id)
        {
            var customerToDelete = await GetCustomerByIdAsync(id);
            this.databaseContext.Customer.Remove(customerToDelete);
            var deleted = await this.databaseContext.SaveChangesAsync();
            return deleted > 0;
        }

        public async Task<Customer> GetCustomerByIdAsync(Guid id)
        {
            return await this.databaseContext.Customer.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            return await this.databaseContext.Customer.ToListAsync();
        }

        public async Task<bool> UpdateCustomerAsync(Customer customer)
        {
            this.databaseContext.Customer.Update(customer);
            var updated = await this.databaseContext.SaveChangesAsync();
            return updated > 0;
        }
    }
}
