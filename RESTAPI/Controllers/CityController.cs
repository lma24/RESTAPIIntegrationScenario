using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RESTAPI.Models;
using RESTAPI.Repository;

namespace RESTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
         IDatabaseHandler dbHandler;
        public CityController(IDatabaseHandler _dbHandler)
        {
            dbHandler = _dbHandler;
        }

        [HttpPost]
        [Route("AddCity")]
        public async Task<IActionResult> AddCity([FromBody]City model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var cityId = await dbHandler.AddCity(model);
                    if (cityId > 0)
                    {
                        return Ok(cityId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }

            }

            return BadRequest();
        }

        [HttpPost]
        [Route("AddCityWeather")]
        public async Task<IActionResult> AddCityWeather([FromBody]CityWeather model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var cityId = await dbHandler.AddCityWeather(model);
                    if (cityId > 0)
                    {
                        return Ok(cityId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                    return BadRequest();
                }

            }

            return BadRequest();
        }

        [HttpPost]
        [Route("UpdateCity")]
        public async Task<IActionResult> UpdateCity([FromBody]City model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await dbHandler.UpdateCity(model);

                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }

            return BadRequest();
        }


        [HttpPost]
        [Route("DeleteCity")]
        public async Task<IActionResult> DeleteCity(int? cityId)
        {
            int result = 0;

            if (cityId == null)
            {
                return BadRequest();
            }

            try
            {
                result = await dbHandler.DeleteCity(cityId);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpGet]
        [Route("SearchCity")]
        public async Task<IActionResult> SearchCity(String city)
        {
            if (city == null)
            {
                return BadRequest();
            }

            try
            {
                var post = await dbHandler.SearchCity(city.Trim());

                if (post == null)
                {
                    return NotFound();
                }
                

                return Ok(post);
            }
            catch (Exception)
            {   
                return BadRequest();
            }
        }
    }
}
