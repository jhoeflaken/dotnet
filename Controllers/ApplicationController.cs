using Microsoft.EntityFrameworkCore;
using UserManagementApi.Models;
using UserManagementApi.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace UserManagementApi.Controllers
{

    [ApiController]
    [Route("v1/apps")]
    public class ApplicationController : Controller
    {
        private DataContext _context;

        public ApplicationController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Application>>> Get([FromServices] DataContext context)
        {
            var apps = await context.Applications.ToListAsync();
            return apps;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Application>> Get([FromServices] DataContext context, int id)
        {

            var app = await context.Applications.FindAsync(id);
            return app;
        }


        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Application>> Post([FromServices] DataContext context, [FromBody] Application app)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Applications.Add(app);
            await context.SaveChangesAsync();
            return app;
        }  

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<Application>> Put([FromServices] DataContext context, int id, [FromBody] Application app)
        {
            if (!ModelState.IsValid) {  
                return BadRequest(ModelState);  
            }  
  
            if (id != app.Id) {  
                return BadRequest("Id within body is not same as in request");  
            }  
  
            if (await ApplicationExists(id)) {
                context.Entry(app).State = EntityState.Modified; 
                await context.SaveChangesAsync();
                return app;
            } else {
                return NotFound();
            }
            
        }                 

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete([FromServices] DataContext context, int id)
        {
            Application app = context.Applications.Find(id);
            if (app == null) {
                return NotFound();
            }

            context.Applications.Remove(app);
            await context.SaveChangesAsync();
            return Ok();
        }                 


        private async Task<bool> ApplicationExists(int id) {  
            return await _context.Applications.CountAsync(a => a.Id == id) > 0;  
        }          
    }
}
