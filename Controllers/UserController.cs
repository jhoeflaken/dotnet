using Microsoft.EntityFrameworkCore;
using UserManagementApi.Models;
using UserManagementApi.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace UserManagementApi.Controllers
{

    [ApiController]
    [Route("v1/users")]
    public class UserController : Controller
    {
        private DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<User>>> Get([FromServices] DataContext context)
        {
            var users = await context.Users.ToListAsync();
            return users;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<User>> Get([FromServices] DataContext context, int id)
        {
            var user = await context.Users.FindAsync(id);
            return user;
        }        

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<User>> Post([FromServices] DataContext context, [FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Users.Add(user);
            await context.SaveChangesAsync();
            return user;
        }  

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<User>> Put([FromServices] DataContext context, int id, [FromBody] User user)
        {
            if (!ModelState.IsValid) {  
                return BadRequest(ModelState);  
            }  
  
            if (id != user.Id) {  
                return BadRequest("Id within body is not same as in request");  
            }  
  
            if (await UserExists(id)) {
                context.Entry(user).State = EntityState.Modified; 
                await context.SaveChangesAsync();
                return user;
            } else {
                return NotFound();
            }
            
        }                 

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete([FromServices] DataContext context, int id)
        {
            User user = context.Users.Find(id);
            if (user == null) {
                return NotFound();
            }

            context.Users.Remove(user);
            await context.SaveChangesAsync();
            return Ok();
        }                 


        private async Task<bool> UserExists(int id) {  
            return await _context.Users.CountAsync(u => u.Id == id) > 0;  
        }          
    }
}
