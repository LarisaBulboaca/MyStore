using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyStore.Domain;
using MyStore.Helpers;
using MyStore.Models;
using MyStore.Services;

namespace MyStore.Controllers
{
    public class OrderDetailController : Controller
    {

        private readonly IOrderDetailService orderDetailService;

        public OrderDetailController(IOrderDetailService orderDetailService)
        {
            this.orderDetailService = orderDetailService;
        }

        // GET: api/<OrderDetailController>
        [HttpGet]
        public IEnumerable<OrderDetailModel> Get()
        {
            var allOrderDetails = orderDetailService.GetOrderDetails();

            var modelsToReturn = new List<OrderDetailModel>();
            foreach (var orderDetail in allOrderDetails)
            {
                modelsToReturn.Add(orderDetail.ToOrderDetailModel());
            }

            return modelsToReturn;
        }

        // GET api/<OrderDetailController>/5
        [HttpGet("{id}")]
        public ActionResult<OrderDetail> GetById(int id)
        {
            var orderDetailFromDb = orderDetailService.GetOrderDetail(id);

            if (orderDetailFromDb == null)
            {
                return NotFound();
            }

            var model = new OrderDetailModel();
            model = orderDetailFromDb.ToOrderDetailModel();

            return Ok(model);
        }
        // PUT api/<OrderDetailController>/5

        [HttpPut("{id}")]
        public ActionResult<OrderDetailModel> Update(int id, OrderDetailModel model)
        {
            var existingOrderDetail = orderDetailService.GetOrderDetail(id);
            if (existingOrderDetail == null)
            {
                return NotFound();
            }

            TryUpdateModelAsync(existingOrderDetail);

            var orderDetailToUpdate = new OrderDetail();
            orderDetailToUpdate = model.ToOrderDetail();
            orderDetailService.Update(orderDetailToUpdate);

            return Ok(orderDetailToUpdate.ToOrderDetailModel());
        }

        // POST api/<OrderDetailController>
        [HttpPost]
        public IActionResult Create(OrderDetailModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orderDetailToSave = new OrderDetail();
            orderDetailToSave = model.ToOrderDetail();


            orderDetailService.InsertNew(orderDetailToSave);

            model.Orderid = orderDetailToSave.Orderid;

            return CreatedAtAction(nameof(GetById), new { id = orderDetailToSave.Orderid }, model);

        }

        // DELETE api/<OrderDetailController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var orderDetail = orderDetailService.GetOrderDetail(id);
            if (orderDetail == null)
            {
                return NotFound(orderDetail);
            }

            orderDetailService.Remove(orderDetail);

            return NoContent();
        }
    }
}
