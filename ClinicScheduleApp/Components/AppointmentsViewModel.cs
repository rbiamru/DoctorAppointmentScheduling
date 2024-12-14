using ClinicSchedule.Entities;

namespace ClinicScheduleApp.Components
{
    public class AppointmentsViewModel
    {
        public List<Appointment>? Appointments { get; set; }

        public int NumberOfAppointmentsToDisplay { get; set; }

        public TimeSpan AverageAppointmentDuration { get; set; } // Add this property
        public string PatientName { get; set; } // Add this property
    }
}
