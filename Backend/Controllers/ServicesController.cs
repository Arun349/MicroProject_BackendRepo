using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ServicesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Services>> Get()
        {
            return _context.Services.Include(a => a.user).Include(x => x.mobile).Include(s => s.repairShop).Include(m => m.appointment).ToList();
        }

        [HttpGet]
        public ActionResult<Services> Getindividual(int id)
        {
            var service = _context.Services.Find(id);
            if (service == null)
            {
                return NotFound();
            }
            return Ok(service);
        }

        [HttpPost]
        public async Task<ActionResult<Services>> Create(ServicesDTO DTO)
        {
            User User = _context.User.Find(DTO.UserId);
            RepairShop RepairShop = _context.RepairShop.Find(DTO.RepairShopId);
            Mobile Mobile=_context.Mobile.Find(DTO.MobileId);
            Appointment Appointment= _context.Appointment.Find(DTO.AppointmentId); 

            Services services = new Services()
            {
                ServiceId = DTO.ServiceId,
                Repair_Status = DTO.Repair_Status,
                user = User,
                repairShop= RepairShop,
                mobile= Mobile,
                appointment= Appointment

            };
            _context.Services.Add(services);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]

        public async Task<ActionResult<Services>> Put(ServicesDTO DTO)
        {
            User User = _context.User.Find(DTO.UserId);
            RepairShop RepairShop = _context.RepairShop.Find(DTO.RepairShopId);
            Mobile Mobile = _context.Mobile.Find(DTO.MobileId);
            Appointment Appointment = _context.Appointment.Find(DTO.AppointmentId);

            Services services = new Services()
            {
                ServiceId = DTO.ServiceId,
                Repair_Status = DTO.Repair_Status,
                user = User,
                repairShop = RepairShop,
                mobile = Mobile,
                appointment = Appointment

            };

            _context.Services.Update(services);
            await _context.SaveChangesAsync();
            return Ok();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var service = _context.Services.Find(id);
            if (service == null)
            {
                return NotFound();
            }
            _context.Services.Remove(service);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
