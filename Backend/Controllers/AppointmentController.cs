using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AppointmentController : Controller
    {

        private readonly AppDbContext _context;
        public AppointmentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Appointment>> Get()
        {
            return _context.Appointment.Include(a=>a.user).Include(x=>x.mobile).Include(s=>s.repairShop).ToList();
        }

        [HttpGet]
        public ActionResult<Appointment> Getindividual(int id)
        {
            var service = _context.Appointment.Find(id);
            if (service == null)
            {
                return NotFound();
            }
            return Ok(service);
        }

        [HttpPost]
        public async Task<ActionResult<Appointment>> Create(AppointmentDTO DTO)
        {
            User User = _context.User.Find(DTO.UserId)!;
            Mobile Mobile = _context.Mobile.Find(DTO.MobileId)!;
            RepairShop RepairShop = _context.RepairShop.Find(DTO.RepairShopId)!;
            //Services Services= _context.Services.Find(DTO.ServicesId)!;

            Appointment appointment = new Appointment()
            {
                AppointmentId = DTO.AppointmentId,
                AppointmentStatus = DTO.AppointmentStatus,
                Date = DTO.Date,
                user = User,
                repairShop = RepairShop,
                mobile = Mobile,
                //services= Services
            };
            _context.Appointment.Add(appointment);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]

        public async Task<ActionResult<Appointment>> Put(AppointmentDTO DTO)
        {

            User User = _context.User.Find(DTO.UserId);
            Mobile Mobile = _context.Mobile.Find(DTO.MobileId);
            RepairShop RepairShop = _context.RepairShop.Find(DTO.RepairShopId);

            Appointment appointment = new Appointment()
            {
                AppointmentId = DTO.AppointmentId,
                AppointmentStatus = DTO.AppointmentStatus,
                Date = DTO.Date,
                user = User,
                repairShop = RepairShop,
                mobile = Mobile
            };

            _context.Appointment.Update(appointment);
            await _context.SaveChangesAsync();
            return Ok();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var appointment = _context.Appointment.Find(id);
            if (appointment == null)
            {
                return NotFound();
            }
            _context.Appointment.Remove(appointment);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
