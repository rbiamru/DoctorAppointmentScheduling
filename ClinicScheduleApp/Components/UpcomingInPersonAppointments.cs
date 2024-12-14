using ClinicSchedule.Entities;
using ClinicScheduleApp.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicScheduleApp.Components
{
    public class UpcomingInPersonAppointments : ViewComponent
    {
        private ClinicScheduleDbContext _clinicScheduleDbContext;

        public UpcomingInPersonAppointments(ClinicScheduleDbContext clinicScheduleDbContext)
        {
            _clinicScheduleDbContext = clinicScheduleDbContext;

        }

        //public async Task<IViewComponentResult> InvokeAsync(int numberOfAppointments)
        //{

        //    var upcomingAppointments = await _clinicScheduleDbContext.Appointments
        //        .Where(a => a.AppointmentType == AppointmentTypeOptions.InPerson && a.AppointmentDate > DateTime.Now)
        //        .OrderBy(a => a.AppointmentDate)
        //        .Take(numberOfAppointments)
        //        .ToListAsync();
        //    // Filter and take the specified number of appointments

        //    var model = upcomingAppointments
        //        .OrderBy(a => a.AppointmentDate)
        //        .Take(numberOfAppointments)
        //        .ToList();
        //    //        // Replace this with your actual data retrieval logic
        //    //        var upcomingAppointments = new List<Appointment>
        //    //{
        //    //    new Appointment { PatientName = "John Doe", AppointmentDate = DateTime.Now.AddDays(2), AppointmentType = AppointmentTypeOptions.InPerson },
        //    //    new Appointment { PatientName = "Jane Smith", AppointmentDate = DateTime.Now.AddDays(5), AppointmentType = AppointmentTypeOptions.InPerson },
        //    //    // Add more appointments as needed
        //    //};

        //    //        var model = upcomingAppointments.Where(a => a.AppointmentType == AppointmentTypeOptions.InPerson)
        //    //                                        .OrderBy(a => a.AppointmentDate)
        //    //                                        .Take(numberOfAppointments)
        //    //                                        .ToList();
        //    // Prepare the view model with the filtered appointments
        //    //var model = upcomingAppointments.OrderBy(a => a.AppointmentDate).Take(numberOfAppointments).ToList();
        //    // Return the view with the model
        //    //return View(model);
        //    //
        //    var viewModel = new AppointmentsViewModel
        //    {
        //        Appointments = model,
        //        NumberOfAppointmentsToDisplay = numberOfAppointments
        //    };
        //    return View(viewModel);
        //}

        public IViewComponentResult Invoke(int numberOfAppointmentsToDisplay)
        {
            DateTime now = DateTime.Now;
            var upcomingAppointments = _clinicScheduleDbContext.Appointments
                .Include(a => a.Schedule)
                .Where(a => a.AppointmentDate > now)
                .OrderByDescending(a => a.AppointmentDate)
                .ToList();


            AppointmentsViewModel viewModel = new AppointmentsViewModel()
            {
                Appointments = upcomingAppointments,
                NumberOfAppointmentsToDisplay = numberOfAppointmentsToDisplay
            };
            return View(viewModel);
        }
    }
}
