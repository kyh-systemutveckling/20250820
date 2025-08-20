using Domain.Dtos;
using System.Linq.Expressions;

namespace Domain.Interfaces;

public interface ICustomerRepository
{
    Task<bool> CreateAsync(CustomerDto customer);
    Task<CustomerDto> GetByIdAsync(string id);
    Task<CustomerDto> GetByNameAsync(string customerName);
    Task<IEnumerable<CustomerDto>> GetAllAsync();
    Task<bool> UpdateAsync(CustomerDto customer);
    Task<bool> DeleteAsync(string id);
}
