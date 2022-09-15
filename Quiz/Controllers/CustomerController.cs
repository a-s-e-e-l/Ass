using Microsoft.AspNetCore.Mvc;
using Quiz.Extentions;
using Quiz.Models;
using Quiz.ModelsView;
using System;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Quiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private restaurantdbContext _restaurantdbContext;

        public CustomerController(restaurantdbContext restaurantdbContext)
        {
            _restaurantdbContext = restaurantdbContext;
        }
        // GET: api/<CustomerController>
        [HttpGet]
        public IActionResult Get()
        {
            var x = _restaurantdbContext.Customers.ToList();
            if (x.Count() == 0)
            {
                return Ok("NotFound");
            }
            return Ok(x);
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var x = _restaurantdbContext.Customers.Find(id);
            if (x == null)
            {
                return Ok("NotFound");
            }
            return Ok(x);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public void Post([FromBody] CustomerView customerReg)
        {
                var customer = _restaurantdbContext.Customers.Add(new Customer
                {
                    FirstName = customerReg.FirstName.capitalizeFirstChar(),
                    LastName = customerReg.LastName.capitalizeFirstChar(),
                    CraetedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow
                }).Entity;
                _restaurantdbContext.SaveChanges();
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CustomerView customerReg)
        {
                var x = _restaurantdbContext.Customers.Find(id);
                if (x != null)
                {
                    x.FirstName = customerReg.FirstName.capitalizeFirstChar();
                    x.LastName = customerReg.LastName.capitalizeFirstChar();
                    x.UpdatedDate = DateTime.UtcNow;
                }
                _restaurantdbContext.SaveChanges();
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var x = _restaurantdbContext.Customers.Find(id);
            if (x != null)
            {
                _restaurantdbContext.Customers.Remove(x);
                _restaurantdbContext.SaveChanges();
            }
        }
    }
}
