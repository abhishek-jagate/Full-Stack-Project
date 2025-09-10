// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using MaterialApi.Data;
// using MaterialApi.Models;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using System;

// namespace MaterialApi.Controllers
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class MaterialsController : ControllerBase
//     {
//         private readonly ApplicationDbContext _context;

//         public MaterialsController(ApplicationDbContext context)
//         {
//             _context = context;
//         }

//         // GET: api/materials
//         [HttpGet]
//         // GET: api/materials
// [HttpGet]
// public async Task<IActionResult> GetMaterials(
//     [FromQuery] int page = 1,
//     [FromQuery] int pageSize = 10,
//     [FromQuery] string? sortField = null,
//     [FromQuery] string? sortDir = "asc",
//     [FromQuery] string? name = null,
//     [FromQuery] string? category = null)
// {
//     var query = _context.Materials.AsQueryable();

//     // 🔎 Filtering
//     if (!string.IsNullOrWhiteSpace(name))
//         query = query.Where(m => m.Name != null && m.Name.Contains(name));
//     if (!string.IsNullOrWhiteSpace(category))
//         query = query.Where(m => m.Category != null && m.Category.Contains(category));

//     var total = await query.CountAsync();

//     // 🔃 Sorting
//     if (!string.IsNullOrWhiteSpace(sortField))
//     {
//         try
//         {
//             if (sortDir?.ToLower() == "desc")
//                 query = query.OrderByDescending(m => EF.Property<object>(m, sortField));
//             else
//                 query = query.OrderBy(m => EF.Property<object>(m, sortField));
//         }
//         catch
//         {
//             query = query.OrderBy(m => m.MaterialId); // fallback
//         }
//     }
//     else
//     {
//         query = query.OrderBy(m => m.MaterialId);
//     }

//     // 📄 Paging
//     var items = await query
//         .Skip((Math.Max(1, page) - 1) * Math.Max(1, pageSize))
//         .Take(Math.Max(1, pageSize))
//         .ToListAsync();

//     return Ok(new { data = items, total });
// }


//         // GET: api/materials/{id}
//         [HttpGet("{id}")]
//         public async Task<ActionResult<Material>> GetMaterial(int id)
//         {
//             var material = await _context.Materials.FindAsync(id);

//             if (material == null)
//             {
//                 return NotFound();
//             }

//             return material;
//         }

//         // POST: api/materials
//         [HttpPost]
//         public async Task<ActionResult<Material>> PostMaterial(Material material)
//         {
//             if (!ModelState.IsValid)
//             {
//                 return BadRequest(ModelState);
//             }
//             Console.WriteLine("Adding new material: " + material.Name);
//             Console.WriteLine("Adding new material: " + material.GstPercent);

//             _context.Materials.Add(material);
//             await _context.SaveChangesAsync();

//             return CreatedAtAction(nameof(GetMaterial), new { id = material.MaterialId }, material);
//         }

//         // PUT: api/materials/{id}
//         [HttpPut("{id}")]
//         public async Task<IActionResult> PutMaterial(int id, Material material)
//         {
//             if (id != material.MaterialId)
//             {
//                 return BadRequest();
//             }

//             _context.Entry(material).State = EntityState.Modified;

//             try
//             {
//                 await _context.SaveChangesAsync();
//             }
//             catch (DbUpdateConcurrencyException)
//             {
//                 if (!_context.Materials.Any(e => e.MaterialId == id))
//                 {
//                     return NotFound();
//                 }
//                 else
//                 {
//                     throw;
//                 }
//             }

//             return NoContent();
//         }

//         // DELETE: api/materials/{id}
//         [HttpDelete("{id}")]
//         public async Task<IActionResult> DeleteMaterial(int id)
//         {
//             var material = await _context.Materials.FindAsync(id);
//             if (material == null)
//             {
//                 return NotFound();
//             }

//             _context.Materials.Remove(material);
//             await _context.SaveChangesAsync();

//             return NoContent();
//         }
//     }
// }

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MaterialApi.Data;
using MaterialApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace MaterialApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MaterialsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/materials
        [HttpGet]
        public async Task<IActionResult> GetMaterials(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? sortField = null,
            [FromQuery] string? sortDir = "asc",
            [FromQuery] string? name = null,
            [FromQuery] string? category = null)
        {
            var query = _context.Materials.AsQueryable();

            // 🔎 Filtering
            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(m => m.Name != null && m.Name.Contains(name));
            if (!string.IsNullOrWhiteSpace(category))
                query = query.Where(m => m.Category != null && m.Category.Contains(category));

            var total = await query.CountAsync();

            // 🔃 Sorting
            if (!string.IsNullOrWhiteSpace(sortField))
            {
                try
                {
                    if (sortDir?.ToLower() == "desc")
                        query = query.OrderByDescending(m => EF.Property<object>(m, sortField));
                    else
                        query = query.OrderBy(m => EF.Property<object>(m, sortField));
                }
                catch
                {
                    query = query.OrderBy(m => m.MaterialId); // fallback
                }
            }
            else
            {
                query = query.OrderBy(m => m.MaterialId);
            }

            // 📄 Paging
            var items = await query
                .Skip((Math.Max(1, page) - 1) * Math.Max(1, pageSize))
                .Take(Math.Max(1, pageSize))
                .ToListAsync();

            return Ok(new { data = items, total });
        }

        // GET: api/materials/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Material>> GetMaterial(int id)
        {
            var material = await _context.Materials.FindAsync(id);

            if (material == null)
            {
                return NotFound();
            }

            return material;
        }

       // POST: api/Materials
[HttpPost]
public async Task<ActionResult<Material>> PostMaterial(Material material)
{
    if (_context.Materials == null)
    {
        return Problem("Entity set 'MaterialContext.Materials' is null.");
    }

    // --- NEW CODE START ---
    // Check if a material with the same name already exists (case-insensitive)
    bool nameExists = await _context.Materials.AnyAsync(m => m.Name.ToLower() == material.Name.ToLower());
    if (nameExists)
    {
        // If the name exists, return a 409 Conflict error with a specific message
        return Conflict("A material with this name already exists.");
    }
    // --- NEW CODE END ---

    _context.Materials.Add(material);
    await _context.SaveChangesAsync();

    return CreatedAtAction("GetMaterial", new { id = material.MaterialId }, material);
}

        // PUT: api/materials/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaterial(int id, Material material)
        {
            if (id != material.MaterialId)
            {
                return BadRequest();
            }

            _context.Entry(material).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Materials.Any(e => e.MaterialId == id))
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

        // DELETE: api/materials/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaterial(int id)
        {
            var material = await _context.Materials.FindAsync(id);
            if (material == null)
            {
                return NotFound();
            }

            _context.Materials.Remove(material);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}