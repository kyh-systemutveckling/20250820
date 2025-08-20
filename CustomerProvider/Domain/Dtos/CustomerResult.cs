namespace Domain.Dtos;

public class CustomerResult
{
    public bool Succeeded { get; set; }
    public int StatusCode { get; set; }
    public string? Error {  get; set; }
}

public class CustomerObjectResult : CustomerResult
{
    public CustomerDto? Result { get; set; }
}