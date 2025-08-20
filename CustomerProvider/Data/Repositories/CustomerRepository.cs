using Domain.Dtos;
using Domain.Interfaces;

namespace Data.Repositories;

public class CustomerRepository : ICustomerRepository
{
    public Task<bool> CreateAsync(CustomerDto customer)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(CustomerDto customer)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CustomerDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<CustomerDto> GetAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(CustomerDto customer)
    {
        throw new NotImplementedException();
    }
}
