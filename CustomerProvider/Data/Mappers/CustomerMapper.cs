using Data.Entities;
using Domain.Dtos;

namespace Data.Mappers;

internal static class CustomerMapper
{
    public static CustomerEntity ConvertTo(CustomerDto dto) => new CustomerEntity
    {
        CustomerName = dto.CustomerName
    };

    public static CustomerDto ConvertFrom(CustomerEntity entity) => new CustomerDto
    {
        CustomerName = entity.CustomerName
    };
}
