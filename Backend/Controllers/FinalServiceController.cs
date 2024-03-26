using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FinalServiceController : ControllerBase
    {
        private readonly AppDbContext _context;
        public FinalServiceController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<FinalService>> Get()
        {
            return _context.FinalService.Include(a => a.user).Include(x => x.finalappointment).Include(s => s.repairShop).ToList();
        }

        [HttpGet]
        public ActionResult<FinalService> Getindividual(int id)
        {
            var fservice = _context.FinalService.Find(id);
            if (fservice == null)
            {
                return NotFound();
            }
            return Ok(fservice);
        }

        [HttpPost]
        public async Task<ActionResult<FinalService>> Create(FinalServiceDTO DTO)
        {
            User User = _context.User.Find(DTO.UserId)!;
            RepairShop RepairShop = _context.RepairShop.Find(DTO.RepairShopId)!;
            //Mobile Mobile = _context.Mobile.Find(DTO.MobileId);
            FinalAppointment FinalAppointment = _context.FinalAppointment.Find(DTO.FinalAppointmentId)!;

            FinalService fservice = new FinalService()
            {
                FinalServiceId = DTO.FinalServiceId,
                user = User,
                repairShop = RepairShop,
                finalappointment = FinalAppointment

            };
            _context.FinalService.Add(fservice);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]

        public async Task<ActionResult<FinalService>> Put(FinalServiceDTO DTO)
        {
            User User = _context.User.Find(DTO.UserId)!;
            RepairShop RepairShop = _context.RepairShop.Find(DTO.RepairShopId)!;
            FinalAppointment FinalAppointment = _context.FinalAppointment.Find(DTO.FinalAppointmentId)!;

            FinalService fservice = new FinalService()
            {
                FinalServiceId = DTO.FinalServiceId,
                user = User,
                repairShop = RepairShop,
                finalappointment = FinalAppointment

            };

            _context.FinalService.Update(fservice);
            await _context.SaveChangesAsync();
            return Ok();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var fservice = _context.FinalService.Find(id);
            if (fservice == null)
            {
                return NotFound();
            }
            _context.FinalService.Remove(fservice);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
