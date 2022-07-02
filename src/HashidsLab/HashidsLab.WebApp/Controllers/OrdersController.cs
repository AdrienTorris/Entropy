using HashidsLab.WebApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HashidsNet;

namespace HashidsLab.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderService _orderService;
        private readonly IHashids _hashids;

        public OrdersController(OrderService orderService, IHashids hashids)
        {
            _orderService = orderService;
            _hashids = hashids;
        }

        [HttpGet("int/{id:int}")]
        public IActionResult Get([FromRoute] int id)
        {
            var order = _orderService.Get(id);
            if (order is null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        [HttpGet("guid/{id:guid}")]
        public IActionResult Get([FromRoute] Guid id)
        {
            var order = _orderService.Get(id);
            if (order is null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        [HttpGet("hashid/{id}")]
        public IActionResult Get([FromRoute] string id)
        {
            int[] rawId = _hashids.Decode(id);
            if (rawId.Length != 1)
            {
                return NotFound();
            }

            var order = _orderService.Get(rawId[0]);
            if (order is null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        [HttpGet("int/{id:int}/hashid")]
        public IActionResult GetHashid([FromRoute] int id)
        {
            return Ok(_hashids.Encode(id));
        }
    }
}
