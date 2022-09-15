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
    public class MenuController : ControllerBase
    {
        private restaurantdbContext _restaurantdbContext;

        public MenuController(restaurantdbContext restaurantdbContext)
        {
            _restaurantdbContext = restaurantdbContext;
        }
        // GET: api/<MenuController>
        [HttpGet]
        public IActionResult Get()
        {
            var x = _restaurantdbContext.RestaurantMenus.ToList();
            if (x.Count() == 0)
            {
                return Ok("NotFound");
            }
            return Ok(x);
        }

        // GET api/<MenuController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var x = _restaurantdbContext.RestaurantMenus.Find(id);
            if (x == null)
            {
                return Ok("NotFound");
            }
            return Ok(x);
        }

        // POST api/<MenuController>
        [HttpPost]
        public void Post([FromBody] MenuView menuReg)
        {
            var x = _restaurantdbContext.Restaurants.Find(menuReg.Rid);
            if (x!=null)
            {
                var menu = _restaurantdbContext.RestaurantMenus.Add(new RestaurantMenu
            {
                MealName = menuReg.MealName,
                Rid = menuReg.Rid,
                PriceInNis = menuReg.PriceInNis,
                PriceInUsd= (menuReg.PriceInNis*3.50), 
                Quantity = menuReg.Quantity,
                CraetedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            }).Entity;
            

            _restaurantdbContext.SaveChanges();
            }
        }

        // PUT api/<MenuController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] MenuView menuReg)
        {
            var x = _restaurantdbContext.Restaurants.Find(menuReg.Rid);
            if (x != null)
            {
                var menu = _restaurantdbContext.RestaurantMenus.Find(id);
                if (menu != null)
                {
                    menu.MealName = menuReg.MealName;
                    menu.Rid = menuReg.Rid;
                    menu.PriceInNis = menuReg.PriceInNis;
                    menu.PriceInUsd = (menuReg.PriceInNis / 3.50);
                    menu.Quantity = menuReg.Quantity;
                    menu.UpdatedDate = DateTime.UtcNow;
                }
                _restaurantdbContext.SaveChanges();
            }
        }

        // DELETE api/<MenuController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var x = _restaurantdbContext.RestaurantMenus.Find(id);
            if (x != null)
            {
                _restaurantdbContext.RestaurantMenus.Remove(x);
                _restaurantdbContext.SaveChanges();
            }
        }
    }
}
