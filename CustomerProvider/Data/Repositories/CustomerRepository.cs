using Data.Contexts;
using Data.Entities;
using Data.Mappers;
using Domain.Dtos;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

    public async Task<bool> DeleteAsync(string id)
    {
        try
        {
            var entity = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id); 
            if (entity != null)
            {
                _context.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
        catch
        {
            return false;
        }
    }

    public async Task<IEnumerable<CustomerDto>> GetAllAsync()
    {
        var entities = await _context.Customers.ToListAsync();
        return entities.Select(entity => CustomerMapper.ConvertFrom(entity));
    }

    public async Task<CustomerDto> GetByIdAsync(string id)
    {
        var entity = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
        if (entity != null)
            return CustomerMapper.ConvertFrom(entity);

        return null!;
    }

    public async Task<CustomerDto> GetByNameAsync(string customerName)
    {
        var entity = await _context.Customers.FirstOrDefaultAsync(x => x.CustomerName == customerName);
        if (entity != null)
            return CustomerMapper.ConvertFrom(entity);

        return null!;
    }

    public async Task<bool> UpdateAsync(CustomerDto customer)
    {
        try
        {
            var entity = await _context.Customers.FirstOrDefaultAsync(x => x.Id == customer.Id);
            if (entity != null)
            {
                _context.Entry(entity).CurrentValues.SetValues(customer);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
        catch
        {
            return false;
        }
    }
}
