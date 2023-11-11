using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyStore.Domain;
using MyStore.Helpers;
using MyStore.Models;
using MyStore.Services;

namespace MyStore.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        // GET: api/<OrderController>
        [HttpGet]
        public IEnumerable<OrderModel> Get()
        {
            var allOders = orderService.GetOrders();

            var modelsToReturn = new List<OrderModel>();
            foreach (var order in allOders)
            {
                modelsToReturn.Add(order.ToOrderModel());
            }

            return modelsToReturn;
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public ActionResult<Order> GetById(int id)
        {
            var orderFromDb = orderService.GetOrder(id);

            if (orderFromDb == null)
            {
                return NotFound();
            }

            var model = new OrderModel();
            model = orderFromDb.ToOrderModel();

            return Ok(model);
        }
        // PUT api/<OrderController>/5

        [HttpPut("{id}")]
        public ActionResult<OrderModel> Update(int id, OrderModel model)
        {
            var existingOrder = orderService.GetOrder(id);
            if (existingOrder == null)
            {
                return NotFound();
            }

            TryUpdateModelAsync(existingOrder);

            var orderToUpdate = new Order();
            orderToUpdate = model.ToOrder();
            orderService.Update(orderToUpdate);

            return Ok(orderToUpdate.ToOrderModel());
        }

        // POST api/<OrderController>
        [HttpPost]
        public IActionResult Create(OrderModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orderToSave = new Order();
            orderToSave = model.ToOrder();


            orderService.InsertNew(orderToSave);

            model.Orderid = orderToSave.Orderid;

            return CreatedAtAction(nameof(GetById), new { id = orderToSave.Orderid }, model);

        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var order = orderService.GetOrder(id);
            if (order == null)
            {
                return NotFound(order);
            }

            orderService.Remove(order);

            return NoContent();
        }
    }
}
