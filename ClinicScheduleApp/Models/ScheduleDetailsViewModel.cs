using ClinicSchedule.Entities;

namespace ClinicScheduleApp.Models
{
	public class ScheduleDetailsViewModel
	{
		public Schedule? ActiveSchedule { get; set; }
		public Clinician? NewClinician { get; set; }
		public Appointment? NewAppointment { get; set; }
		//public List<Clinician> Clinicians { get; set; }
		//public List<Appointment> Appointments { get; set; }
		//public int TotalClinicians { get; set; }
		//public int TotalAppointments { get; set; }

	}
}
