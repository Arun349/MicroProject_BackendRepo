using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class RepairShopController : Controller
    {
        private readonly AppDbContext _context;
        public RepairShopController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<RepairShop>> Get()
        {
            return _context.RepairShop.ToList<RepairShop>();
        }

        [HttpGet]
        public ActionResult<RepairShop> Getindividual(int id)
        {
            var shop = _context.RepairShop.Find(id);
            if (shop == null)
            {
                return NotFound();
            }
            return Ok(shop);
        }


        [HttpPost]

        public async Task<ActionResult<RepairShop>> Create(RepairShop RepairShop)
        {

            if (_context.RepairShop.Any(user => user.Email == RepairShop.Email))
            {

                return Ok("{\"accountexist\":true}");
            }

            else
            {


                _context.Add(RepairShop);

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
                RepairShop olduser = _context.RepairShop.Where(user1 => user1.Email == user.Email).FirstOrDefault()!;

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
    }
}

