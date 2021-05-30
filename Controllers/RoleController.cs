using Microsoft.EntityFrameworkCore;
using UserManagementApi.Models;
using UserManagementApi.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace UserManagementApi.Controllers
{

    [ApiController]
    [Route("v1/roles")]
    public class RoleController : Controller
    {
        private DataContext _context;

        public RoleController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Role>>> Get([FromServices] DataContext context)
        {
            var roles = await context.Roles.ToListAsync();
            return roles;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Role>> Get([FromServices] DataContext context, int id)
        {
            var role = await context.Roles.FindAsync(id);
            return role;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Role>> Post([FromServices] DataContext context, [FromBody] Role role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Roles.Add(role);
            await context.SaveChangesAsync();
            return role;
        }  

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<Role>> Put([FromServices] DataContext context, int id, [FromBody] Role role)
        {
            if (!ModelState.IsValid) {  
                return BadRequest(ModelState);  
            }  
  
            if (id != role.Id) {  
                return BadRequest("Id within body is not same as in request");  
            }  
  
            if (await RoleExists(id)) {
                context.Entry(role).State = EntityState.Modified; 
                await context.SaveChangesAsync();
                return role;
            } else {
                return NotFound();
            }
            
        }                 

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete([FromServices] DataContext context, int id)
        {
            Role role = context.Roles.Find(id);
            if (role == null) {
                return NotFound();
            }

            context.Roles.Remove(role);
            await context.SaveChangesAsync();
            return Ok();
        }                 


        private async Task<bool> RoleExists(int id) {  
            return await _context.Roles.CountAsync(r => r.Id == id) > 0;  
        }          
    }
}
