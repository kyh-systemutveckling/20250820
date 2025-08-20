using Presentation.Dtos;

namespace Presentation.Services;

public class ProductService : IProductService
{
    public async Task<bool> CreateProductAsync(ProductCreateDto createProductDto)
    {
        try
        {
            return true;
        }
        catch { return false; }
    }

    public async Task<bool> DeleteProductAsync(string id)
    {
        try
        {
            return true;
        }
        catch { return false; }
    }

    public async Task<ProductDto> GetProductAsync(string id)
    {
        ProductDto product = null;
        return product;
    }

    public async Task<IEnumerable<ProductDto>> GetProductsAsync()
    {
        List<ProductDto> products = [];
        return products;
    }

    public async Task<bool> UpdateProductAsync(ProductDto updatedProductDto)
    {
        try
        {
            return true;
        }
        catch { return false; }
    }
}
