using Domain.Dtos;
using Domain.Interfaces;


namespace Business.Services;

public class CustomerService(ICustomerRepository customerRepository) : ICustomerService
{
    private readonly ICustomerRepository _customerRepository = customerRepository;

    public async Task<CustomerObjectResult> CreateCustomerAsync(CustomerDto customer)
    {
        // Check Null-Values
        if (customer is null || customer.CustomerName == "")
            return new CustomerObjectResult
            {
                Succeeded = false,
                StatusCode = 400,
                Error = "Invalid attributes or empty object"
            };

        // Check if Customer Exists
        var existing = await _customerRepository.GetByNameAsync(customer.CustomerName);
        if (existing is not null)
            return new CustomerObjectResult
            {
                Succeeded = false,
                StatusCode = 409,
                Error = "Customer already exists"
            };

        try
        {
            customer.Id = Guid.NewGuid().ToString();

            var result = await _customerRepository.CreateAsync(customer);
            if (result)
                return new CustomerObjectResult
                {
                    Succeeded = true,
                    StatusCode = 201,
                };

            throw new Exception("Unable to create customer");
        }

        catch (Exception ex)
        {
            return new CustomerObjectResult
            {
                Succeeded = false,
                StatusCode = 500,
                Error = ex.Message
            };
        }
    }

    public async Task<CustomerResult> DeleteCustomerAsync(string id)
    {
        // Check Null-Values
        if (string.IsNullOrWhiteSpace(id))
            return new CustomerResult
            {
                Succeeded = false,
                StatusCode = 400,
                Error = "Invalid id"
            };


        // Check if Customer Exists
        var existing = _customerRepository.GetByIdAsync(id);
        if (existing is null)
            return new CustomerResult
            {
                Succeeded = false,
                StatusCode = 404,
                Error = "Customer Not Found"
            };

        // Remove Customer
        try
        {
            var result = await _customerRepository.DeleteAsync(id);
            if (result)
                return new CustomerResult
                {
                    Succeeded = true,
                    StatusCode = 204,
                };

            throw new Exception("Unable to delete customer");
        }

        catch (Exception ex)
        {
            return new CustomerResult
            {
                Succeeded = false,
                StatusCode = 500,
                Error = ex.Message
            };
        }
    }

    public async Task<CustomerObjectResult> GetCustomerByIdAsync(string id)
    {
        // Check Null-Values
        if (string.IsNullOrWhiteSpace(id))
            return new CustomerObjectResult
            {
                Succeeded = false,
                StatusCode = 400,
                Error = "Invalid id"
            };

        // Get Customer
        var customer = await _customerRepository.GetByIdAsync(id);
        if (customer is not null)
            return new CustomerObjectResult
            {
                Succeeded = true,
                StatusCode = 200,
                Result = customer
            };

        return new CustomerObjectResult
        {
            Succeeded = false,
            StatusCode = 404,
            Error = "Customer Not Found"
        };
    }

    public async Task<CustomerObjectResult> GetCustomerByNameAsync(string name)
    {
        // Check Null-Values
        if (string.IsNullOrWhiteSpace(name))
            return new CustomerObjectResult
            {
                Succeeded = false,
                StatusCode = 400,
                Error = "Invalid id"
            };

        // Get Customer
        var customer = await _customerRepository.GetByNameAsync(name);
        if (customer is not null)
            return new CustomerObjectResult
            {
                Succeeded = true,
                StatusCode = 200,
                Result = customer
            };

        return new CustomerObjectResult
        {
            Succeeded = false,
            StatusCode = 404,
            Error = "Customer Not Found"
        };
    }

    public async Task<CustomerObjectListResult> GetCustomersAsync()
    {
        var customers = await _customerRepository.GetAllAsync();

        return new CustomerObjectListResult
        {
            Succeeded = true,
            StatusCode = 200,
            Result = customers
        };
    }

    public async Task<CustomerResult> UpdateCustomerAsync(string id, CustomerDto customer)
    {
        // Check Null-Values
        if (string.IsNullOrWhiteSpace(id) || customer is null)
            return new CustomerResult
            {
                Succeeded = false,
                StatusCode = 400,
                Error = "Invalid id or object"
            };


        // Check if Customer Exists
        var existing = _customerRepository.GetByIdAsync(id);
        if (existing is null)
            return new CustomerResult
            {
                Succeeded = false,
                StatusCode = 404,
                Error = "Customer Not Found"
            };

        // Update Customer
        try
        {
            var result = await _customerRepository.UpdateAsync(customer);
            if (result)
                return new CustomerResult
                {
                    Succeeded = true,
                    StatusCode = 204,
                };

            throw new Exception("Unable to update customer");
        }

        catch (Exception ex)
        {
            return new CustomerResult
            {
                Succeeded = false,
                StatusCode = 500,
                Error = ex.Message
            };
        }
    }
}
