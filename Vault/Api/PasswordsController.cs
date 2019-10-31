using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vault.Core;
using Vault.Data;

namespace Vault.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordsController : ControllerBase
    {
        private readonly EntityFrameworkDBContext _context;

        public PasswordsController(EntityFrameworkDBContext context)
        {
            _context = context;
        }

        // GET: api/Passwords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Password>>> GetPassword()
        {
            return await _context.Password.ToListAsync();
        }

        // GET: api/Passwords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Password>> GetPassword(int id)
        {
            var password = await _context.Password.FindAsync(id);

            if (password == null)
            {
                return NotFound();
            }

            return password;
        }

        // PUT: api/Passwords/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPassword(int id, Password password)
        {
            if (id != password.Id)
            {
                return BadRequest();
            }

            _context.Entry(password).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PasswordExists(id))
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

        // POST: api/Passwords
        [HttpPost]
        public async Task<ActionResult<Password>> PostPassword(Password password)
        {
            _context.Password.Add(password);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPassword", new { id = password.Id }, password);
        }

        // DELETE: api/Passwords/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Password>> DeletePassword(int id)
        {
            var password = await _context.Password.FindAsync(id);
            if (password == null)
            {
                return NotFound();
            }

            _context.Password.Remove(password);
            await _context.SaveChangesAsync();

            return password;
        }

        private bool PasswordExists(int id)
        {
            return _context.Password.Any(e => e.Id == id);
        }
    }
}
