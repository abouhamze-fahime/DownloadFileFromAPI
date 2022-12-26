using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        [HttpGet("GetCities1")]
        public JsonResult GetCities()
        {
           return new JsonResult(
                new List<object>
                {
                    new {id=1 , Name="Tehran"},
                    new {id =2, Name="Shiraz"}
                });
        }


        [HttpGet("GetCities2")]
        public List<CityDto> GetCities2()
        {
            return CityDataStore.current.Cities;
         
        }


        [HttpGet("GetCities3")]
        public JsonResult GetCities3()
        {
            var result = new JsonResult(CityDataStore.current.Cities);
            result.StatusCode = 200;
            return new JsonResult(CityDataStore.current.Cities);

        }

        [HttpGet("GetCitiesAcctionResult")]
        public ActionResult<IEnumerable<CityDto>> GetCitiesAcctionResult()
        {

         var result= CityDataStore.current.Cities;
            if (result==null)
            {
                return NotFound();
            }
            return Ok(result);
        }



        [HttpGet("GetCity")]
        public JsonResult GetCity(int id )
        {
            return new JsonResult(CityDataStore.current.Cities.FirstOrDefault(c => c.Id == id));
         

        }


        [HttpGet("GetCityByActionResult")]
        public ActionResult<CityDto> GetCityByActionResult(int id)
        {
            var result = CityDataStore.current.Cities.FirstOrDefault(c => c.Id == id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);

        }


        [HttpGet("PointOfInterestOfACity")]
        public ActionResult<IEnumerable< PointOfInterestDto>> PointOfInterestOfACity(int id)
        {
            var result = CityDataStore.current.Cities.FirstOrDefault(c => c.Id == id);
            var points=   result.PointsOfInterest;
            if (result == null)
            {
                return NotFound();
            }
            return Ok(points);

        }


        [HttpGet("PointOfInterestOfACity/{id}")]
        public ActionResult<IEnumerable<PointOfInterestDto>> PointOfInterestOfACity(int cityid ,  int id)
        {
            var result = CityDataStore.current.Cities.FirstOrDefault(c => c.Id == cityid);
            var points = result.PointsOfInterest.FirstOrDefault(p=>p.Id==id);
            if (result == null)
            {
                return NotFound();
            }
            if (points==null)
            {
                return NotFound();
            }
            return Ok(points);

        }
    }
}
