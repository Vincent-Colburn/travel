
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using travel.Models;
using travel.Services;

namespace travel
{
    [ApiController]
    [Route("api/[controller]")]

    public class CruisesController : ControllerBase
    {
        private readonly CruisesService _service;

        public CruisesController(CruisesService service)
        {
            _service = service;
        }

        [HttpGet]

        public ActionResult<IEnumerable<Cruise>> Get()
        {
            try
            {
                return Ok(_service.Get());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]

        public ActionResult<Cruise> Get(int id)
        {
            try
            {
                return (_service.Get(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]

        public ActionResult<Cruise> Create([FromBody] Cruise newCruise)
        {
            try
            {
                return Ok(_service.Create(newCruise));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]

        public ActionResult<Cruise> Edit([FromBody] Cruise editCruise, int id)
        {
            try
            {
                editCruise.Id = id;
                return Ok(_service.Edit(editCruise));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]

        public ActionResult<Cruise> Delete(int id)
        {
            try
            {
                return Ok(_service.Delete(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



    }

}