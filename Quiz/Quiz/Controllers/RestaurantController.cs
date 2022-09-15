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
    public class RestaurantController : ControllerBase
    {
        private restaurantdbContext _restaurantdbContext;

        public RestaurantController(restaurantdbContext restaurantdbContext)
        {
            _restaurantdbContext = restaurantdbContext;
        }
        // GET: api/<RestaurantController>
        [HttpGet]
        public IActionResult Get()
        {
            var x = _restaurantdbContext.Restaurants.ToList();
            if (x.Count()==0)
            {
                return Ok("NotFound");
            }
            return Ok(x);
            
        }

        // GET api/<RestaurantController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var x = _restaurantdbContext.Restaurants.Find(id);
            if (x == null)
            {
                return Ok("NotFound");
            }
            return Ok(x);
        }

        // POST api/<RestaurantController>
        [HttpPost]
        public void Post([FromBody] RestaurantView resReg)
        {
            var resturant = _restaurantdbContext.Restaurants.Add(new Restaurant
            {
                Name = resReg.Name,
                PhoneNumber = resReg.PhoneNumber,
                CraetedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            }).Entity;

            _restaurantdbContext.SaveChanges();
        }

        // PUT api/<RestaurantController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] RestaurantView resReg)
        {
            var x = _restaurantdbContext.Restaurants.Find(id);
            if (x != null)
            {
                x.Name = resReg.Name;
                x.PhoneNumber = resReg.PhoneNumber;
                x.UpdatedDate = DateTime.UtcNow;
                _restaurantdbContext.SaveChanges();
            }
        }

        // DELETE api/<RestaurantController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var restaurant = _restaurantdbContext.Restaurants.Find(id);
            if (restaurant != null)
            {
                _restaurantdbContext.Restaurants.Remove(restaurant);
                _restaurantdbContext.SaveChanges();
            }
        }
    }
}
