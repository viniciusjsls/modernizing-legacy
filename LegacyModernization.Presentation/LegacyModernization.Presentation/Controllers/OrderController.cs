using LegacyModernization.Presentation.Data;
using LegacyModernization.Presentation.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LegacyModernization.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController(AppDbContext dbContext) : ControllerBase
    {

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var order = dbContext.Orders.Include(x => x.Items).First(x => x.Id == id);

            decimal totalPrice = order.Items.Sum(x => x.Price);
            int numberOfItems = order.Items.Count;

            return Ok(new { TotalAmount = totalPrice, NumberOfItems = numberOfItems, order.Items });
        }

        [HttpPost()]
        public IActionResult Post([FromBody] List<OrderItem> items)
        {
            var order = new Order { Items = items };
            order.Id = Guid.NewGuid();

            Validate(order);

            dbContext.Orders.Add(order);
            dbContext.SaveChanges();

            return Ok();
        }

        private void Validate(Order order)
        {
            // run some validation logic
            if (order == null)
            {
                throw new Exception("Order cannot be null");
            }
        }
    }
}
