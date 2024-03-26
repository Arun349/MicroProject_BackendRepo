using Microsoft.AspNetCore.Mvc;
using System;
using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Backend.Data;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]

        public async Task<ActionResult<User>> Create(User User)
        {

            if (_context.User.Any(user => user.Email == User.Email))
            {
                
                return Ok("{\"accountexist\":true}");
            }

            else
            {


                _context.Add(User);

                await _context.SaveChangesAsync();

                return Ok("{\"accountexist\":false}");





            }

        }

        [Route("api/Signin")]
        [HttpPost]

        public async Task<IActionResult> Signin(Signin user)
        {
            try
            {
                User olduser = _context.User.Where(user1 => user1.Email == user.Email).FirstOrDefault()!;

                if (olduser.Email == user.Email && olduser != null)
                {
                    if (olduser.Password == user.Password)
                    {
                        return Ok("{\"emailstatus\":true,\"passwordstatus\":true}");
                    }
                    else
                    {
                        return Ok("{\"emailstatus\":true,\"passwordstatus\":false}");
                    }
                }
            }
            catch (Exception ex)
            {
                return Ok("{\"emailstatus\":false,\"passwordstatus\":false}");

            }
            return Ok("{\"emailstatus\":false,\"passwordstatus\":false}");


        }
        [Route("api/FindEmail")]
        [HttpPost]
        public ActionResult FindEmail([FromBody] EmailDto email)
        {
            var Email = _context.User.Where(s => s.Email == email.Email).FirstOrDefault();
            if (Email == null)
            {
                return Ok("Not the data");
            }
            else
            {
                return Ok(Email);
            }
        }
    }


}
