using Microsoft.AspNetCore.Mvc;
using Quiz.Models;
using Quiz.ModelsView;
using System;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Quiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private restaurantdbContext _restaurantdbContext;

        public OrderController(restaurantdbContext restaurantdbContext)
        {
            _restaurantdbContext = restaurantdbContext;
        }
        // GET: api/<OrderController>
        [HttpGet]
        public IActionResult Get()
        {
            var x = _restaurantdbContext.ResCustomers.ToList();
            if (x.Count() == 0)
            {
                return Ok("NotFound");
            }
            return Ok(x);
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var x = _restaurantdbContext.ResCustomers.Find(id);
            if (x == null)
            {
                return Ok("NotFound");
            }
            return Ok(x);
        }

        private bool isAvailable(int id)
        {
            var x = _restaurantdbContext.RestaurantMenus.Find(id);
            if (x == null)
            {
                return false;
            }
            if (x.Quantity < 0)
            {
                return false;
            }
            return true;
        }

        // POST api/<OrderController>
        [HttpPost]
        public void Post([FromBody] OrderView orderReg)
        {
            var R = _restaurantdbContext.RestaurantMenus.Find(orderReg.Rid);
            var C = _restaurantdbContext.Customers.Find(orderReg.Cid);
            var Q = isAvailable(orderReg.Rid);
            if (R!=null&&C!=null&&Q)
            {
                var order = _restaurantdbContext.ResCustomers.Add(new ResCustomer
                {
                    Rid = orderReg.Rid,
                    Cid = orderReg.Cid,
                    CraetedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow
                }).Entity;
                _restaurantdbContext.SaveChanges();
            }
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] OrderView orderReg)
        {
            var order = _restaurantdbContext.ResCustomers.Find(id);
            if (order != null)
            {
                var R = _restaurantdbContext.RestaurantMenus.Find(orderReg.Rid);
                var C = _restaurantdbContext.Customers.Find(orderReg.Cid);
                var Q = isAvailable(orderReg.Rid);
                if (R != null && C != null && Q)
                {
                    order.Rid = orderReg.Rid;
                    order.Cid = orderReg.Cid;
                    order.UpdatedDate = DateTime.UtcNow;
                    _restaurantdbContext.SaveChanges();
                }
            }
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var order = _restaurantdbContext.ResCustomers.Find(id);
            if (order != null)
            {
                _restaurantdbContext.ResCustomers.Remove(order);
                _restaurantdbContext.SaveChanges();
            }
        }
    }
}
