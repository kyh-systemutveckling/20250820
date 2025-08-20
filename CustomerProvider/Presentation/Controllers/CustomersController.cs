using Domain.Dtos;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController(ICustomerService customerService) : ControllerBase
{
    private readonly ICustomerService _customerService = customerService;

    [HttpPost]
    public async Task<IActionResult> Create(CustomerDto dto)
    {
        var result = await _customerService.CreateCustomerAsync(dto);

        return result.StatusCode switch
        {
            200 => Ok(result.Result),
            201 => Created("", result.Result),
            204 => NoContent(),
            400 => BadRequest(result),
            404 => NotFound(result),
            409 => Conflict(result),
            _ => Problem(result.Error),
        };
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        if (!ModelState.IsValid) { return BadRequest(ModelState); }

        var result = await _customerService.GetCustomerByIdAsync(id);

        return result.StatusCode switch
        {
            200 => Ok(result.Result),
            201 => Created("", result.Result),
            204 => NoContent(),
            400 => BadRequest(result),
            404 => NotFound(result),
            409 => Conflict(result),
            _ => Problem(result.Error),
        };
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _customerService.GetCustomersAsync();

        return result.StatusCode switch
        {
            200 => Ok(result.Result),
            201 => Created("", result.Result),
            204 => NoContent(),
            400 => BadRequest(result),
            404 => NotFound(result),
            409 => Conflict(result),
            _ => Problem(result.Error),
        };
    }

    [HttpPut]
    public async Task<IActionResult> Update(CustomerDto dto)
    {
        if (!ModelState.IsValid) { return BadRequest(ModelState); }

        var result = await _customerService.UpdateCustomerAsync(dto.Id, dto);

        return result.StatusCode switch
        {
            200 => Ok(result),
            201 => Created("", result),
            204 => NoContent(),
            400 => BadRequest(result),
            404 => NotFound(result),
            409 => Conflict(result),
            _ => Problem(result.Error),
        };
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        if (!ModelState.IsValid) { return BadRequest(ModelState); }

        var result = await _customerService.DeleteCustomerAsync(id);

        return result.StatusCode switch
        {
            200 => Ok(result),
            201 => Created("", result),
            204 => NoContent(),
            400 => BadRequest(result),
            404 => NotFound(result),
            409 => Conflict(result),
            _ => Problem(result.Error),
        };
    }
}
