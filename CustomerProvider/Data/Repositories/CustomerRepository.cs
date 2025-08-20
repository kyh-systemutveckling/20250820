using Data.Contexts;
using Data.Mappers;
using Domain.Dtos;
using Domain.Interfaces;

namespace Data.Repositories;

public class CustomerRepository(CustomerContext context) : ICustomerRepository
{
    private readonly CustomerContext _context = context;

    public async Task<bool> CreateAsync(CustomerDto customer)
    {
        try
        {
            var entity = CustomerMapper.ConvertTo(customer);

            _context.Add(entity);
            await _context.SaveChangesAsync();

            return true;
        }
        catch 
        {
            return false;
        }
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
