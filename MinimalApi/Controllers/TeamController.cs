using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinimalApi.Models;

namespace MinimalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        public ITeamService _teamService { get; set; }
        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpPost]
        public IActionResult Create(team team)
        {
            return Ok(_teamService.Create(team));
        }

        [HttpGet]
        public IActionResult Get(int Id)
        {
            return Ok(_teamService.Get(Id));
        }

        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            _teamService.Delete(Id);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(int Id, team team)
        {
            _teamService.Update(team, Id);
            return Ok();
        }
    }
}
