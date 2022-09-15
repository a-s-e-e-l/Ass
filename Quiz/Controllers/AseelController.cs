using LINQtoCSV;
using Microsoft.AspNetCore.Mvc;
using Quiz.Models;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Quiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AseelController : ControllerBase
    {
        private restaurantdbContext _restaurantdbContext;

        public AseelController(restaurantdbContext restaurantdbContext)
        {
            _restaurantdbContext = restaurantdbContext;
        }
        // GET: api/<AseelController>
        [HttpGet]
        public IActionResult Get()
        {
            WriteCsvFile();
            return Ok();
        }
        private void WriteCsvFile()
        {
            var itemList = _restaurantdbContext.CSVViews.ToList();

            var csvFileDescription = new CsvFileDescription
            {
                FirstLineHasColumnNames = true,
                SeparatorChar = ','
            };

            var csvContext = new CsvContext();
            csvContext.Write(itemList, "Resturant.csv", csvFileDescription);
        }
    }
}
