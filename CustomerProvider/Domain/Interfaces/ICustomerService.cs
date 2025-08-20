using Domain.Dtos;

namespace Domain.Interfaces;

public interface ICustomerService
{
    Task<CustomerObjectResult> CreateCustomerAsync(CustomerDto customer);
    Task<CustomerObjectListResult> GetCustomersAsync();
    Task<CustomerObjectResult> GetCustomerByIdAsync(string id);
    Task<CustomerObjectResult> GetCustomerByNameAsync(string name);
    Task<CustomerResult> UpdateCustomerAsync(string id, CustomerDto customer);
    Task<CustomerResult> DeleteCustomerAsync(string id);
}

