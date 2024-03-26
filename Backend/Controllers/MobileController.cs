using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/Post/[controller]/[action]")]
    [ApiController]
    public class MobileController : Controller
    {
        private readonly AppDbContext _context;
        public MobileController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Mobile>> Get()
        {
            return _context.Mobile.Include(a => a.user).ToList<Mobile>();
        }

        [HttpGet]
        public ActionResult<Mobile>Getindividual(int id)
        {
            var mobile = _context.Mobile.Find(id);
            if (mobile == null)
            {
                return NotFound();
            }
            return Ok(mobile);
        }


        [HttpPost]
        public async Task<ActionResult<Mobile>> Create(DTO DTO)
        {
            User User = _context.User.Find(DTO.UserId);
            Mobile mobile = new Mobile()
            {
                MobileId = DTO.MobileId,
                Mobile_ModelName = DTO.Mobile_ModelName,
                problemDescription = DTO.problemDescription,
                user = User
            };
            _context.Mobile.Add(mobile);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [Route("api/Put/[controller]/[action]")]
        [HttpPut]

        public async Task<ActionResult<Mobile>> Put(DTO DTO)
        {
            User User = _context.User.Find(DTO.UserId);
            Mobile mobile = new Mobile()
            {
                MobileId = DTO.MobileId,
                Mobile_ModelName = DTO.Mobile_ModelName,
                problemDescription = DTO.problemDescription,
                user = User
            };

            _context.Mobile.Update(mobile);
            await _context.SaveChangesAsync();
            return Ok();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var mobile = _context.Mobile.Find(id);
            if(mobile == null)
            {
                return NotFound();
            }
            _context.Mobile.Remove(mobile);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
