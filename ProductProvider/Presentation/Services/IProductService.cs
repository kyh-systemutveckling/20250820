using Presentation.Dtos;

namespace Presentation.Services;

public interface IProductService
{
    Task<bool> CreateProductAsync(ProductCreateDto createProductDto);
    Task<ProductDto> GetProductAsync(string id);
    Task<IEnumerable<ProductDto>> GetProductsAsync();
    Task<bool> UpdateProductAsync(ProductDto updatedProductDto);
    Task<bool> DeleteProductAsync(string id);
}
