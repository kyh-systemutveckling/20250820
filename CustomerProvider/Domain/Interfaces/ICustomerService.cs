using Domain.Dtos;

namespace Domain.Interfaces;

public interface ICustomerService
{
    Task<CustomerObjectResult> CreateCustomerAsync(CustomerDto customer);
    Task<IEnumerable<CustomerObjectResult>> GetCustomersAsync();
    Task<CustomerObjectResult> GetCustomerByIdAsync(string id);
    Task<CustomerObjectResult> GetCustomerByNameAsync(string name);
    Task<CustomerObjectResult> UpdateCustomerAsync(string id, CustomerDto customer);
    Task<CustomerResult> DeleteCustomerAsync(string id);
}

