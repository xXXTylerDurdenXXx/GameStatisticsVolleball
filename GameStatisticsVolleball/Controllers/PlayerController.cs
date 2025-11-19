using AutoMapper;
using GameStatisticsVolleball.Models.DTO;
using GameStatisticsVolleball.Models;
using GameStatisticsVolleball.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace GameStatisticsVolleball.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IMapper _mapper;
        public PlayerController(IPlayerRepository playerRepository, IMapper mapper)
        {
            _playerRepository = playerRepository;
            _mapper = mapper;
        }

        [Authorize(Roles ="User")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var players = _playerRepository.GetAll();
            var playerDtos = _mapper.Map<IEnumerable<PlayerDTO>>(players);
            return Ok(playerDtos);
        }

        [Authorize(Roles = "User")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var player = _playerRepository.GetById(id);
            if (player == null)
                return NotFound();

            var playerDto = _mapper.Map<PlayerDTO>(player);
            return Ok(playerDto);
        }
        [Authorize(Roles ="Admin")]
        [HttpPost]
        public IActionResult Create([FromBody] CreatePlayerDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var player = _mapper.Map<Player>(dto);
            _playerRepository.Create(player);

            var playerDto = _mapper.Map<PlayerDTO>(player);
            return CreatedAtAction(nameof(GetById), new { id = player.Id }, playerDto);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdatePlayerDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingPlayer = _playerRepository.GetById(id);
            if (existingPlayer == null)
                return NotFound();

            _mapper.Map(dto, existingPlayer);
            _playerRepository.Update(existingPlayer);

            var playerDto = _mapper.Map<PlayerDTO>(existingPlayer);
            return Ok(playerDto);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_playerRepository.Exists(id))
                return NotFound();

            _playerRepository.Delete(id);
            return NoContent();
        }
        [Authorize(Roles = "User")]
        [HttpGet("position/{positionId}")]
        public IActionResult GetByPosition(int positionId)
        {
            var players = _playerRepository.GetPlayersWithTeamsAndPositionsAsync().Result
                .Where(p => p.Position.Id == positionId);
            var playerDtos = _mapper.Map<IEnumerable<PlayerDTO>>(players);
            return Ok(playerDtos);
        }
    }
}
