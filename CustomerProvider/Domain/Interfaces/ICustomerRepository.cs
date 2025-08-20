using Domain.Dtos;

namespace Domain.Interfaces;

public interface ICustomerRepository
{
    Task<bool> CreateAsync(CustomerDto customer);
    Task<CustomerDto> GetAsync();
    Task<IEnumerable<CustomerDto>> GetAllAsync();
    Task<bool> UpdateAsync(CustomerDto customer);
    Task<bool> DeleteAsync(CustomerDto customer);
}
