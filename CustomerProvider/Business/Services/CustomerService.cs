using Domain.Dtos;
using Domain.Interfaces;
using System.Data;

namespace Business.Services;

public class CustomerService(ICustomerRepository customerRepository) // : ICustomerService
{
    //private readonly ICustomerRepository _customerRepository = customerRepository;

    //public async Task<CustomerObjectResult> CreateCustomerAsync(CustomerDto customer)
    //{

    //    // kontrollera att in-data är korrekt
    //    if (customer is null)
    //    {
    //        return new CustomerObjectResult
    //        {
    //            Succeeded = false,
    //            StatusCode = 400,
    //            Error = "customer payload is null"
    //        };
    //    }

    //    // kontrollera så att kunden inte redan finns
    //    var existing = await _customerRepository.GetAsync(customer);
    //    if (existing is not null)
    //    {
    //        return new CustomerObjectResult
    //        {
    //            Succeeded = false,
    //            StatusCode = 409, // Conflict
    //            Error = "customer already exists"
    //        };
    //    }

    //    // skapa en själva kunden
    //    try
    //    {
    //        // Create the customer
    //        var created = await _customerRepository.CreateAsync(customer);

    //        if (!created)
    //        {
    //            return new CustomerObjectResult
    //            {
    //                Succeeded = false,
    //                StatusCode = 500,
    //                Error = "failed to create customer"
    //            };
    //        }

    //        // 4) Return created
    //        existing = await _customerRepository.GetAsync(customer);
    //        if (existing is not null)
    //        {
    //            return new CustomerObjectResult
    //            {
    //                Succeeded = true,
    //                StatusCode = 201, 
    //                Result = existing,
    //            };
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        return new CustomerObjectResult
    //        {
    //            Succeeded = false,
    //            StatusCode = 500,
    //            Error = ex.Message
    //        };
    //    }

    //}

    //public Task<CustomerObjectResult> GetCustomerByIdAsync(string id)
    //{
    //    throw new NotImplementedException();
    //}

    //public Task<CustomerObjectResult> GetCustomerByNameAsync(string name)
    //{
    //    throw new NotImplementedException();
    //}

    //public Task<IEnumerable<CustomerObjectResult>> GetCustomersAsync()
    //{
    //    throw new NotImplementedException();
    //}

    //public Task<CustomerObjectResult> UpdateCustomerAsync(string id, CustomerDto customer)
    //{
    //    throw new NotImplementedException();
    //}

    //public Task<CustomerResult> DeleteCustomerAsync(string id)
    //{
    //    throw new NotImplementedException();
    //}
}
