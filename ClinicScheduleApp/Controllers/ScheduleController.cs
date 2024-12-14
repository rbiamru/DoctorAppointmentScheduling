using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using ClinicScheduleApp.DataAccess;
using ClinicSchedule.Entities;
using ClinicScheduleApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace ClinicScheduleApp.Controllers
{
    public class ScheduleController : Controller
    {
        public ScheduleController(ClinicScheduleDbContext clinicScheduleDbContext)
        {
            _clinicScheduleDbContext = clinicScheduleDbContext;
        }

        [HttpGet("/schedules")]
        public IActionResult GetAllSchedules()
        {
            var schedules = _clinicScheduleDbContext.Schedules
                    .Include(s => s.Clinicians)
                    .Include(s => s.Appointments)
                    .OrderByDescending(s => s.DateCreated)
                    .ToList();

            return View("Items", schedules);
        }

        [HttpGet("/schedules/{id}/details")]
        public IActionResult GetScheduleById(int? id)
        {
            var schedule = _clinicScheduleDbContext.Schedules
                    .Include(s => s.Clinicians)
                    .Include(s => s.Appointments)
                    .Where(s => s.ScheduleId == id)
                    .FirstOrDefault();

            if (schedule == null)
                return NotFound();

            // TODO: complete this action method


            var model = new ScheduleDetailsViewModel
            {
                ActiveSchedule = schedule,
                NewClinician = new Clinician { ScheduleId = id },
                NewAppointment = new Appointment { ScheduleId = id },
                //Clinicians = schedule.Clinicians,
                //Appointments = schedule.Appointments,
                //TotalClinicians = schedule.Clinicians.Count,
                //TotalAppointments = schedule.Appointments.Count
            };

            return View("Details", model);
        }
        [HttpGet("/schedules/add-request")]
        public IActionResult GetAddScheduleRequest()
        {
            return View("AddSchedule", new Schedule());
        }

        [HttpPost("/schedules")]
        [Authorize()]
        public IActionResult AddNewSchedule(Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                _clinicScheduleDbContext.Schedules.Add(schedule);
                _clinicScheduleDbContext.SaveChanges();

                TempData["LastActionMessage"] = $"The schedule \"{schedule.Name}\" was added.";

                return RedirectToAction("GetAllSchedules", "Schedule");
            }
            else
            {
                return View("AddSchedule", schedule);
            }
        }

        [HttpGet("/schedules/{id}/edit-request")]
        public IActionResult GetEditRequestById(int id)
        {
            var schedule = _clinicScheduleDbContext.Schedules.Find(id);
            return View("EditSchedule", schedule);
        }


        [HttpPost("/schedules/edit-requests")]
        [Authorize()]
        public IActionResult ProcessEditRequest(Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                _clinicScheduleDbContext.Schedules.Update(schedule);
                _clinicScheduleDbContext.SaveChanges();

                TempData["LastActionMessage"] = $"The schedule \"{schedule.Name}\" was updated.";

                return RedirectToAction("GetAllSchedules", "Schedule");
            }
            else
            {
                return View("EditSchedule", schedule);
            }
        }

        [HttpGet("/schedules/{id}/delete-request")]
        public IActionResult GetDeleteRequestById(int id)
        {
            var schedule = _clinicScheduleDbContext.Schedules.Find(id);
            return View("DeleteConfirmation", schedule);
        }

        [Authorize(Roles = "admin")]
        public IActionResult ProcessDeleteRequestById(int id)
        {
            var schedule = _clinicScheduleDbContext.Schedules.Find(id);

            _clinicScheduleDbContext.Schedules.Remove(schedule);
            _clinicScheduleDbContext.SaveChanges();

            TempData["LastActionMessage"] = $"The schedule \"{schedule.Name}\" was deleted.";

            return RedirectToAction("GetAllSchedules", "Schedule");
        }







        /// <summary>
        /// ///
        /// </summary>
        [Authorize]
        public IActionResult AddNewClinician(int id, ScheduleDetailsViewModel scheduleViewModel)
        {
            var scheduleNew = _clinicScheduleDbContext.Schedules.Where(s => s.ScheduleId == id).FirstOrDefault(); ;
            scheduleNew.Clinicians ??= new List<Clinician>();

            if (ModelState.IsValid)
            {
                scheduleNew.Clinicians.Add(scheduleViewModel.NewClinician);

                _clinicScheduleDbContext.SaveChanges();

                TempData["LastActionMessage"] = $"The clinician \"{scheduleViewModel.NewClinician.FullName}\" was added.";
                return RedirectToAction("GetScheduleById", "Schedule", new { id = id });
            }
            else
            {
                var schedule = _clinicScheduleDbContext.Schedules
                   .Include(s => s.Clinicians)
                   .Include(s => s.Appointments)
                   .Where(s => s.ScheduleId == id)
                   .FirstOrDefault();

                if (schedule == null)
                    return NotFound();

                ScheduleDetailsViewModel scheduleDetailsVMData = new ScheduleDetailsViewModel()
                {
                    ActiveSchedule = schedule
                };

                return View("Details", scheduleDetailsVMData);
            }
        }

        [Authorize]
        public async Task<IActionResult> AddNewAppointment(Appointment newAppointment)
        {
            if (ModelState.IsValid)
            {
                _clinicScheduleDbContext.Add(newAppointment);
                await _clinicScheduleDbContext.SaveChangesAsync();

                var schedule = await _clinicScheduleDbContext.Schedules
                                                .Include(s => s.Clinicians)
                                                .Include(s => s.Appointments)
                                                .Where(s => s.ScheduleId == newAppointment.ScheduleId)
                                                .FirstOrDefaultAsync();

                var model = new ScheduleDetailsViewModel
                {
                    ActiveSchedule = schedule,
                    NewClinician = new Clinician { ScheduleId = newAppointment.ScheduleId },
                    NewAppointment = new Appointment { ScheduleId = newAppointment.ScheduleId },
                    //Clinicians = schedule.Clinicians,
                    //Appointments = schedule.Appointments,
                    //TotalClinicians = schedule.Clinicians.Count,
                    //TotalAppointments = schedule.Appointments.Count
                };

                return View("Details", model);
            }
            return View("Details", GetScheduleById(newAppointment.ScheduleId));
        }

        private ClinicScheduleDbContext _clinicScheduleDbContext;
    }
}
