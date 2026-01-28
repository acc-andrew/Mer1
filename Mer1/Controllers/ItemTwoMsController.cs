using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mer1.Data;
using Mer1.Models;

namespace Mer1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemTwoMsController : ControllerBase
    {
        private readonly DataContext _context;

        public ItemTwoMsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/ItemTwoMs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemTwoM>>> Get_item2M()
        {
            return await _context._item2M.ToListAsync();
        }

        // GET: api/ItemTwoMs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemTwoM>> GetItemTwoM(int id)
        {
            var itemTwoM = await _context._item2M.FindAsync(id);

            if (itemTwoM == null)
            {
                return NotFound();
            }

            return itemTwoM;
        }

        // PUT: api/ItemTwoMs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemTwoM(int id, ItemTwoM itemTwoM)
        {
            if (id != itemTwoM.ID)
            {
                return BadRequest();
            }

            _context.Entry(itemTwoM).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemTwoMExists(id))
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

        // POST: api/ItemTwoMs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ItemTwoM>> PostItemTwoM(ItemTwoM itemTwoM)
        {
            _context._item2M.Add(itemTwoM);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItemTwoM", new { id = itemTwoM.ID }, itemTwoM);
        }

        // DELETE: api/ItemTwoMs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemTwoM(int id)
        {
            var itemTwoM = await _context._item2M.FindAsync(id);
            if (itemTwoM == null)
            {
                return NotFound();
            }

            _context._item2M.Remove(itemTwoM);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemTwoMExists(int id)
        {
            return _context._item2M.Any(e => e.ID == id);
        }
    }
}
