using DigitalMarket.Core.Contracts;
using DigitalMarket.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DigitalMarket.WebApi.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    /// <summary>
    /// Create orders for partners
    /// </summary>
    /// <param name="order">CreateOrder Model</param>
    /// <returns>An IActionResult</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> CreateOrder(CreateOrderRequest order)
    {
        var createdOrder = await _orderService.CreateOrderAsync(order);
        
        return Created(string.Empty, createdOrder);
    }
}