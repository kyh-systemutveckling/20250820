namespace Data.Entities;

public class CustomerEntity
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string CustomerName { get; set; } = null!;
}
