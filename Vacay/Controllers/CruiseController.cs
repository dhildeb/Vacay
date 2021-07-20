using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vacay.Models;
using Vacay.Services;

namespace Vacay.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  class CruiseController : ControllerBase
  {
    private readonly CruiseService _cs;

    public CruiseController(CruiseService cs)
    {
      _cs = cs;
    }

    [HttpGet]
    public ActionResult<List<Cruise>> GetAll()
    {
      try
      {
        var Cruises = _cs.GetAll();
        return Ok(Cruises);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<Cruise> GetById(string id)
    {
      try
      {
        var cruise = _cs.GetById(id);
        return Ok(cruise);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpPost("{id}")]
    public ActionResult<Cruise> PostCruise([FromBody] Cruise cruiseData, string id)
    {
      try
      {
        var Cruise = _cs.PostCruise(cruiseData, id);
        return Created("Cruise Created", Cruise);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [Authorize]
    [HttpPut("{id}")]
    public ActionResult<Cruise> EditCruise([FromBody] Cruise cruiseData, string id)
    {
      try
      {
        _cs.EditCruise(cruiseData, id);
        return Ok(cruiseData);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [Authorize]
    [HttpDelete("{id}")]
    public async Task<ActionResult<string>> DeleteCruise(string id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        _cs.DeleteCruise(id, userInfo.Id);
        return "Deleted";
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}