using DentalClinic.DTOs.AppointmentDTO;
using DentalClinic.Models;

namespace DentalClinic.Services.AppointmentService
{
    public interface IAppointmentService
    {
        Task<Appointment> AddAppointment(AddAppointmentDTO appointmentDTO);
        Task<Appointment> AppointmentMake(AppointmentVerificationDTO DTO);
        Task<List<Appointment>> AppointmentsDueThisWeek();
        Task<List<Appointment>> AppointmentsDueThisWeekForEmployee(int id);
        Task<List<Appointment>> AppointmentsDueToday();
        Task<List<Appointment>> AppointmentsDueTodayForEmployee(int id);
        Task<Appointment> DeleteAppointment(AppointmentVerificationDTO DTO);
        Task<List<Appointment>> EarlyReminder();
        Task<List<Appointment>> GetAllAppointments();
        Task<List<Appointment>> GetAppointmentByEmployee(int EmployeeID);
        Task<List<AppointmentLog>> GetAppointmentLog();
        Task<Appointment> UpdateAppointment(UpdateAppointmentDTO appointmentDTO);
    }
}