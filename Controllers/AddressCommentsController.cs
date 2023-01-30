using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AddressBookAPI;
using AddressBookAPI.Data;

namespace AddressBookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressCommentsController : ControllerBase
    {
        private readonly DataContext _context;

        public AddressCommentsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/AddressComments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddressComment>>> GetAddressComments()
        {
            return await _context.AddressComments.ToListAsync();
        }

        // GET: api/AddressComments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AddressComment>> GetAddressComment(int id)
        {
            var addressComment = await _context.AddressComments.FindAsync(id);

            if (addressComment == null)
            {
                return NotFound();
            }

            return addressComment;
        }

        // PUT: api/AddressComments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddressComment(int id, AddressComment addressComment)
        {
            if (id != addressComment.CommentId)
            {
                return BadRequest();
            }

            _context.Entry(addressComment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressCommentExists(id))
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

        // POST: api/AddressComments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AddressComment>> PostAddressComment(AddressComment addressComment)
        {
            _context.AddressComments.Add(addressComment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAddressComment", new { id = addressComment.CommentId }, addressComment);
        }

        // DELETE: api/AddressComments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddressComment(int id)
        {
            var addressComment = await _context.AddressComments.FindAsync(id);
            if (addressComment == null)
            {
                return NotFound();
            }

            _context.AddressComments.Remove(addressComment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AddressCommentExists(int id)
        {
            return _context.AddressComments.Any(e => e.CommentId == id);
        }
    }
}
