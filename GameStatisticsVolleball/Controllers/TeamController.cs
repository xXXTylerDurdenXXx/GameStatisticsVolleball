using AutoMapper;
using GameStatisticsVolleball.Models.DTO;
using GameStatisticsVolleball.Models;
using GameStatisticsVolleball.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameStatisticsVolleball.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {

        private readonly ITeamRepository _teamRepository;
        private readonly IMapper _mapper;

        public TeamController(ITeamRepository teamRepository, IMapper mapper)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
        }

        
        [HttpGet]
        public IActionResult GetAll()
        {
            var teams = _teamRepository.GetAll();
            var result = _mapper.Map<IEnumerable<TeamDTO>>(teams);
            return Ok(result);
        }

        
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var team = _teamRepository.GetById(id);
            if (team == null)
                return NotFound(new { message = "Команда не найдена" });

            var result = _mapper.Map<TeamDTO>(team);
            return Ok(result);
        }

        
        [HttpPost]
        public IActionResult Create([FromBody] CreateTeamDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var team = _mapper.Map<Team>(dto);
            _teamRepository.Create(team);

            var result = _mapper.Map<TeamDTO>(team);
            return CreatedAtAction(nameof(GetById), new { id = team.Id }, result);
        }

        
        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] UpdateTeamDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_teamRepository.Exists(id))
                return NotFound(new { message = "Команда не найдена" });

            var existingTeam = _teamRepository.GetById(id);
            _mapper.Map(dto, existingTeam);

            _teamRepository.Update(existingTeam);

            return Ok(_mapper.Map<TeamDTO>(existingTeam));
        }

        
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            if (!_teamRepository.Exists(id))
                return NotFound(new { message = "Команда не найдена" });

            _teamRepository.Delete(id);
            return NoContent();
        }
    }
}


