using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZuydSpeelt.Models;

namespace ZuydSpeelt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserGamesController : ControllerBase
    {
        private readonly ZuydSpeeltContext _context;

        public UserGamesController(ZuydSpeeltContext context)
        {
            _context = context;
        }

        // GET: api/UserGames/user/5
        [HttpGet("user/{id}")]
        public async Task<ActionResult<IEnumerable<UserGame>>> GetUserGameByUser(int id)
        {
            if (_context.UserGame == null)
            {
                return NotFound();
            }
            var userGame = await _context.UserGame
                .Where(ug => ug.UserId == id)
                .Include(ug => ug.Game)
                .Include(ug => ug.User)
                .OrderByDescending(ug => ug.Score)
                .ToListAsync();

            if (userGame == null)
            {
                return NotFound();
            }

            return userGame;
        }

        // GET: api/UserGames/game/5
        [HttpGet("game/{id}")]
        public async Task<ActionResult<IEnumerable<UserGame>>> GetUserGameByGame(int id)
        {
            if (_context.UserGame == null)
            {
                return NotFound();
            }
            var userGame = await _context.UserGame
                .Where(ug => ug.GameId == id)
                .Include(ug => ug.Game)
                .Include(ug => ug.User)
                .OrderByDescending(ug => ug.Score)
                .ToListAsync();

            if (userGame == null)
            {
                return NotFound();
            }

            return userGame;
        }

        // PUT: api/UserGames/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserGame(int id, UserGame userGame)
        {
            if (id != userGame.UserId)
            {
                return BadRequest();
            }

            _context.Entry(userGame).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserGameExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UserGames
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserGame>> PostUserGame(UserGame userGame)
        {
            if (_context.UserGame == null)
            {
                return Problem("Entity set 'ZuydSpeeltContext.UserGame'  is null.");
            }
            _context.UserGame.Add(userGame);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserGameExists(userGame.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserGame", new { id = userGame.UserId }, userGame);
        }

        // DELETE: api/UserGames/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserGame(int id)
        {
            if (_context.UserGame == null)
            {
                return NotFound();
            }
            var userGame = await _context.UserGame.FindAsync(id);
            if (userGame == null)
            {
                return NotFound();
            }

            _context.UserGame.Remove(userGame);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserGameExists(int id)
        {
            return (_context.UserGame?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}
