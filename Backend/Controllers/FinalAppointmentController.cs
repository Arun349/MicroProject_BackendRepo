using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FinalAppointmentController : ControllerBase
    {

        private readonly AppDbContext _context;
        public FinalAppointmentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<FinalAppointment>> Get()
        {
            return _context.FinalAppointment.Include(a => a.user).Include(s => s.repairShop).ToList();
        }

        [HttpGet]
        public ActionResult<FinalAppointment> Getindividual(int id)
        {
            var appointment = _context.FinalAppointment.Find(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return Ok(appointment);
        }

        [HttpPost]
        public async Task<ActionResult<FinalAppointment>> Create(FinalAppointmentDTO DTO)
        {
            User User = _context.User.Find(DTO.UserId)!;
            RepairShop RepairShop = _context.RepairShop.Find(DTO.RepairShopId)!;
            //Services Services= _context.Services.Find(DTO.ServicesId)!;

            FinalAppointment fappointment = new FinalAppointment()
            {
                FinalAppointmentId = DTO.FinalAppointmentId,
                Date=DTO.Date,
                MobileModel = DTO.MobileModel,
                ProblemDescription = DTO.ProblemDescription,
                AppointmentStatus = DTO.AppointmentStatus,
                RepairStatus = DTO.RepairStatus,
                user = User,
                repairShop = RepairShop,
                //mobile = Mobile,
                //services= Services
            };
            _context.FinalAppointment.Add(fappointment);

            await _context.SaveChangesAsync();

            return Ok();
        }

        //[HttpPost]

        //public async Task<ActionResult<FinalAppointment>> Put(UpdateAppointmentStatusDto DTO)
        //{

        //    var User = _context.FinalAppointment.Find(DTO.Id);
        //    //Mobile Mobile = _context.Mobile.Find(DTO.MobileId);
        //    //RepairShop RepairShop = _context.RepairShop.Find(DTO.RepairShopId)!;


        //    User.AppointmentStatus = DTO.Status;
        //    _context.FinalAppointment.Update(User);
        //    await _context.SaveChangesAsync();
        //    return Ok();

        //}

        [HttpPost]
        public async Task<IActionResult> Put(UpdateAppointmentStatusDto DTO)
        {
            // Find the FinalAppointment by id
            var fappointment = await _context.FinalAppointment.FindAsync(DTO.Id);

           

            //User User = _context.User.Find(DTO.Id)!;
           
            fappointment.AppointmentStatus = DTO.Status;
           // fappointment.RepairStatus = DTO.RepairStatus;
            //fappointment.user = User;
            //fappointment.repairShop = RepairShop;   
                _context.FinalAppointment.Update(fappointment);
                await _context.SaveChangesAsync();
                       return Ok();
        }


        [HttpPost]
        public async Task<IActionResult> Update(UpdateRepairStatusDto DTO)
        {
            // Find the FinalAppointment by id
            var fappointment = await _context.FinalAppointment.FindAsync(DTO.Id);



            //User User = _context.User.Find(DTO.Id)!;

            //fappointment.AppointmentStatus = DTO.Status;
            fappointment.RepairStatus = DTO.rStatus;
            //fappointment.user = User;
            //fappointment.repairShop = RepairShop;   
            _context.FinalAppointment.Update(fappointment);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var fappointment = _context.FinalAppointment.Find(id);
            if (fappointment == null)
            {
                return NotFound();
            }
            _context.FinalAppointment.Remove(fappointment);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
