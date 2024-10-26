using AutoMapper;
using DentalClinic.Context;
using DentalClinic.DTOs.AppointmentDTO;
using DentalClinic.DTOs.EmployeeDTO;
using DentalClinic.Models;
using DentalClinic.Services.Tools;
using Microsoft.EntityFrameworkCore;

namespace DentalClinic.Services.AppointmentService
{
    public class AppointmentService : IAppointmentService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IToolsService _toolsService;
        public AppointmentService(DataContext context, IMapper mapper, IToolsService toolsService)
        {
            _context = context;
            _mapper = mapper;
            _toolsService = toolsService;
        }

        public async Task<Appointment> AddAppointment(AddAppointmentDTO appointmentDTO)
        {

            var patient = await _context.Patients
                .Where(a => a.PatientId == appointmentDTO.PatientID)
                .FirstOrDefaultAsync() ?? throw new KeyNotFoundException("Patient Not Found");

            var Dentist = await _context.Employees
                .Where(e => e.EmployeeId == appointmentDTO.DentistID)
                .FirstOrDefaultAsync() ?? throw new KeyNotFoundException("Dentist Not Found");

            var ActionBY = await _context.Employees
                .Where(e => e.EmployeeId == appointmentDTO.ActionByID)
                .FirstOrDefaultAsync() ?? throw new KeyNotFoundException("ActionBy Not Found");

            if (appointmentDTO.AppointmentStartTime < DateTime.Now)
            {
                throw new ArgumentException("Appointment start time cannot be in the past.");
            }
            if (appointmentDTO.AppointmentEndTime < appointmentDTO.AppointmentStartTime)
            {
                throw new ArgumentException("Appointment end time cannot be in the past of Appointment Start time.");
            }
            var CompSettings = await _context.CompanySettings.FirstOrDefaultAsync();
            var Duration = TimeSpan.FromMinutes(CompSettings.AppointmentDuration);

            TimeSpan appointmentDuration = appointmentDTO.AppointmentEndTime - appointmentDTO.AppointmentStartTime;

            if (Math.Abs(appointmentDuration.TotalMinutes) < Duration.TotalMinutes)
            {
                throw new ArgumentException($"The duration of appointment has to be atleast {Duration.TotalMinutes} minutes long.");
            }

            // Check if Dentist already has an appointment at the specified time
            bool dentistHasConflict = await _context.Appointments
                .AnyAsync(a => a.Dentist.EmployeeId == appointmentDTO.DentistID &&
                               a.AppointmentStartTime < appointmentDTO.AppointmentEndTime &&
                               a.AppointmentEndTime > appointmentDTO.AppointmentStartTime);

            if (dentistHasConflict)
            {
                throw new InvalidOperationException("Dentist already has an appointment at this time.");
            }

            // Check if ActionBy already has an appointment at the specified time
            //bool actionByHasConflict = await _context.Appointments
            //    .AnyAsync(a => a.ActionBy.EmployeeId == appointmentDTO.ActionByID &&
            //                   a.AppointmentStartTime < appointmentDTO.AppointmentEndTime &&
            //                   a.AppointmentEndTime > appointmentDTO.AppointmentStartTime);

            //if (actionByHasConflict)
            //{
            //    throw new InvalidOperationException("ActionBy already has an appointment at this time.");
            //}

            var appointment = new Appointment
            {
                AllDay = appointmentDTO.AllDay,
                AppointmentSetDate = DateTime.Now,
                AppointmentStartTime = appointmentDTO.AppointmentStartTime,
                AppointmentEndTime = appointmentDTO.AppointmentEndTime,
                ActionName = appointmentDTO.ActionName,
                ActivityName = appointmentDTO.ActivityName,
            };
            appointment.Patient = patient;
            appointment.ActionBy = ActionBY;
            appointment.Dentist = Dentist;

            var appointmentLog = new AppointmentLog
            {
                AppointmentId = appointment.AppointmentId,
                PatientName = appointment.Patient.PatientFullName,
                DentistName = appointment.Dentist.EmployeeName,
                AppointmentSetDate = appointment.AppointmentSetDate,
                AppointmentStartTime = appointment.AppointmentStartTime,
                AppointmentEndTime = appointment.AppointmentEndTime,
                ActionByName = appointment.ActionBy.EmployeeName,
                AllDay = appointment.AllDay,
                ActionName = appointment.ActionName,
                LogDate = DateTime.Now,
                ActivityName = appointmentDTO.ActivityName
            };
            _context.AppointmentLogs.Add(appointmentLog);

            await _context.Appointments.AddAsync(appointment);

            await _context.SaveChangesAsync();
            return appointment;
        }

        public async Task<List<Appointment>> GetAllAppointments()
        {
            var appointments = await _context.Appointments
                                        .OrderByDescending(appointment => appointment.AppointmentStartTime)
                                        .Where(appointment => appointment.AppointmentStartTime > DateTime.Now)
                                        .Select(appointment => new Appointment
                                        {
                                            AppointmentId = appointment.AppointmentId,
                                            AllDay = appointment.AllDay,
                                            AppointmentStartTime = appointment.AllDay
                                            ? appointment.AppointmentStartTime.Date
                                            : appointment.AppointmentStartTime,
                                            AppointmentEndTime = appointment.AllDay
                                            ? appointment.AppointmentEndTime.Date
                                            : appointment.AppointmentEndTime,
                                            ActionName = appointment.ActionName,
                                            PatientID = appointment.PatientID,
                                            DentistID = appointment.DentistID,
                                            AppointmentSetDate = appointment.AppointmentSetDate,
                                            ActionBy = appointment.ActionBy,
                                            ActivityName = appointment.ActivityName

                                        })
                                        .ToListAsync();

            return appointments;
        }
        public async Task<List<Appointment>> GetAppointmentByEmployee(int EmployeeID)
        {
            var appointments = await _context.Appointments
                                        .Where(ap => ap.DentistID == EmployeeID && ap.AppointmentStartTime > DateTime.Now)
                                        .OrderByDescending(ap => ap.AppointmentStartTime)
                                        .Select(appointment => new Appointment
                                        {
                                            AppointmentId = appointment.AppointmentId,
                                            AllDay = appointment.AllDay,
                                            AppointmentStartTime = appointment.AllDay
                                            ? appointment.AppointmentStartTime.Date
                                            : appointment.AppointmentStartTime,
                                            AppointmentEndTime = appointment.AllDay
                                            ? appointment.AppointmentEndTime.Date
                                            : appointment.AppointmentEndTime,
                                            ActionName = appointment.ActionName,
                                            PatientID = appointment.PatientID,
                                            DentistID = appointment.DentistID,
                                            AppointmentSetDate = appointment.AppointmentSetDate,
                                            ActionBy = appointment.ActionBy,
                                            ActivityName= appointment.ActivityName
                                        })
                                        .ToListAsync();
            return appointments;
        }
        public async Task<List<Appointment>> GetAppointmentsForEmployee(int patientID)
        {
            var appointments = await _context.Appointments
                .Where(appointment => appointment.ActionByID == patientID)
                .OrderByDescending(appointment => appointment.AppointmentStartTime)
                .ToListAsync();

            return appointments;
        }
        public async Task<Appointment> DeleteAppointment(AppointmentVerificationDTO DTO)
        {
            var appointment = await _context.Appointments
                                    .Where(ap=> ap.AppointmentId == DTO.AppointmentID)
                                    .Include(ap=> ap.Patient)
                                    .Include(ap=> ap.ActionBy)
                                    .Include(ap=> ap.Dentist)
                                    .FirstOrDefaultAsync()?? throw new KeyNotFoundException("Appointment Not Found!");


            AppointmentLog appointmentLog = new AppointmentLog
            {
                AppointmentId = appointment.AppointmentId,
                PatientName = appointment.Patient.PatientFullName,
                DentistName = appointment.Dentist.EmployeeName,
                AppointmentSetDate = appointment.AppointmentSetDate,
                AppointmentStartTime = appointment.AppointmentStartTime,
                AppointmentEndTime = appointment.AppointmentEndTime,
                ActionByName = appointment.ActionBy.EmployeeName,
                AllDay = appointment.AllDay,
                ActionName = appointment.ActionName,
                LogDate = DateTime.Now,
                ActivityName = DTO.ActionName
            };
            _context.AppointmentLogs.Add(appointmentLog);
            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
            return appointment;
        }
        public async Task<Appointment> UpdateAppointment(UpdateAppointmentDTO appointmentDTO)
        {
            var appointment = await _context.Appointments
                                    .Where(ap => ap.AppointmentId == appointmentDTO.AppointmentID)
                                    .Include(ap=> ap.Patient)
                                    .Include(ap=> ap.ActionBy)
                                    .Include(ap=> ap.Dentist)
                                    .FirstOrDefaultAsync() ?? throw new KeyNotFoundException("Appointment Not Found");
            appointment = _mapper.Map(appointmentDTO, appointment);

            var patient = await _context.Patients
                                                .Where(a => a.PatientId == appointmentDTO.PatientID)
                                                .FirstOrDefaultAsync() ?? throw new KeyNotFoundException("Patient Not Found");

            var Dentist = await _context.Employees
                                                .Where(e => e.EmployeeId == appointmentDTO.DentistID)
                                                .FirstOrDefaultAsync() ?? throw new KeyNotFoundException("Dentist Not Found");

            var ActionBY = await _context.Employees
                                                .Where(e => e.EmployeeId == appointmentDTO.ActionByID)
                                                .FirstOrDefaultAsync() ?? throw new KeyNotFoundException("ActionBy Not Found");
            if (appointmentDTO.AppointmentStartTime < DateTime.Now)
            {
                throw new ArgumentException("Appointment start time cannot be in the past.");
            }
            if (appointmentDTO.AppointmentEndTime < appointmentDTO.AppointmentStartTime)
            {
                throw new ArgumentException("Appointment end time cannot be in the past of Appointment Start time.");
            }
            var CompSettings = await _context.CompanySettings.FirstOrDefaultAsync();
            var Duration = TimeSpan.FromMinutes(CompSettings.AppointmentDuration);

            TimeSpan appointmentDuration = appointmentDTO.AppointmentEndTime - appointmentDTO.AppointmentStartTime;

            if (Math.Abs(appointmentDuration.TotalMinutes) < Duration.TotalMinutes)
            {
                throw new ArgumentException($"The duration of appointment has to be atleast {Duration.TotalMinutes} minutes long.");
            }

            // Check if Dentist already has an appointment at the specified time
            bool dentistHasConflict = await _context.Appointments
                .AnyAsync(a => a.AppointmentId != appointmentDTO.AppointmentID &&
                               a.Dentist.EmployeeId == appointmentDTO.DentistID &&
                               a.AppointmentStartTime < appointmentDTO.AppointmentEndTime &&
                               a.AppointmentEndTime > appointmentDTO.AppointmentStartTime);

            if (dentistHasConflict)
            {
                throw new InvalidOperationException("Dentist already has an appointment at this time.");
            }
            AppointmentLog appointmentLog = new AppointmentLog
            {
                AppointmentId = appointment.AppointmentId,
                PatientName =  patient.PatientFullName,
                DentistName = Dentist.EmployeeName,
                AppointmentSetDate = appointment.AppointmentSetDate,
                AppointmentStartTime = appointment.AppointmentStartTime,
                AppointmentEndTime = appointment.AppointmentEndTime,
                
                ActionByName = ActionBY.EmployeeName,
                AllDay = appointment.AllDay,
                ActionName = appointment.ActionName,
                LogDate = DateTime.Now,
                ActivityName = appointment.ActivityName
            };
            _context.AppointmentLogs.Add(appointmentLog);
            _context.Appointments.Update(appointment); 
            await _context.SaveChangesAsync();
            return appointment;
        }

        public async Task<Appointment> AppointmentMake(AppointmentVerificationDTO DTO)
        {
            var appointment = await _context.Appointments
                                            .Where(ap=> ap.AppointmentId == DTO.AppointmentID)
                                            .Include(ap => ap.Patient)
                                            .Include(ap => ap.ActionBy)
                                            .Include(ap => ap.Dentist)
                                            .FirstOrDefaultAsync()?? throw new KeyNotFoundException("Appointment Not Found");
            //appointment.ActionName = DTO.ActionName;
            appointment.ActivityName = DTO.ActionName;

            AppointmentLog appointmentLog = new AppointmentLog
            {
                AppointmentId = appointment.AppointmentId,
                PatientName = appointment.Patient.PatientFullName,
                DentistName = appointment.Dentist.EmployeeName,
                AppointmentSetDate = appointment.AppointmentSetDate,
                AppointmentStartTime = appointment.AppointmentStartTime,
                AppointmentEndTime = appointment.AppointmentEndTime,
                ActionByName = appointment.ActionBy.EmployeeName,
                AllDay = appointment.AllDay,
                ActionName = appointment.ActionName,
                LogDate = DateTime.Now,
                ActivityName = DTO.ActionName
            };
            _context.AppointmentLogs.Add(appointmentLog);
            _context.Appointments.Update(appointment);
            await _context.SaveChangesAsync();
            return appointment;
        }
        public async Task<List<AppointmentLog>> GetAppointmentLog()
        {
            var Log = await _context.AppointmentLogs.OrderByDescending(c=> c.LogDate).ToListAsync();
            return Log;
        }
        public async Task<List<Appointment>> EarlyReminder()
        {
            var CompSettings = await _context.CompanySettings.FirstOrDefaultAsync() ?? throw new KeyNotFoundException("Company Settings Not Set.");
            var EarlyReminderDays = CompSettings.EarlyReminderDate; // stores a value of days such as 1 or 2 

            var EndDate = DateTime.Today.AddDays(EarlyReminderDays); // Calculate the start date for the range
            var StartDate = DateTime.Today; // Current date

            // Retrieve appointments within the date range
            var appointments = await _context.Appointments
                                    .Include(appointment=> appointment.Patient)
                                    .Where(appointment => appointment.AppointmentStartTime >= StartDate && appointment.AppointmentStartTime <= EndDate)
                                    .ToListAsync();

            return appointments;
        }
        public async Task<List<Appointment>> AppointmentsDueToday()
        {
            var CompSettings = await _context.CompanySettings.FirstOrDefaultAsync() ?? throw new KeyNotFoundException("Company Settings Not Set.");
            var EarlyReminderDays = CompSettings.EarlyReminderDate; // stores a value of days such as 1 or 2 

            var EndDate = DateTime.Today.AddDays(EarlyReminderDays); // Calculate the start date for the range
            var StartDate = DateTime.Today.Date; // Current date

            // Retrieve appointments within the entire day
            var appointments = await _context.Appointments
                                        .Where(appointment => appointment.AppointmentStartTime.Date == StartDate)
                                        .Include(ap=> ap.Patient)
                                        .ToListAsync();

            return appointments;
        }


        public async Task<List<Appointment>> AppointmentsDueTodayForEmployee(int id)
        {
            var CompSettings = await _context.CompanySettings.FirstOrDefaultAsync() ?? throw new KeyNotFoundException("Company Settings Not Set.");
            var EarlyReminderDays = CompSettings.EarlyReminderDate; // stores a value of days such as 1 or 2 

            var EndDate = DateTime.Today.AddDays(EarlyReminderDays); // Calculate the start date for the range
            var StartDate = DateTime.Today.Date; // Current date

            // Retrieve appointments within the date range
            var appointments = await _context.Appointments
                                    .Where(appointment => appointment.AppointmentStartTime.Date == StartDate && appointment.DentistID == id)
                                    .ToListAsync();

            return appointments;
        }
        
        public async Task<List<Appointment>> AppointmentsDueThisWeek()
        {
            var CompSettings = await _context.CompanySettings.FirstOrDefaultAsync() ?? throw new KeyNotFoundException("Company Settings Not Set.");
            var EarlyReminderDays = CompSettings.EarlyReminderDate; // stores a value of days such as 1 or 2 

            var EndDate = DateTime.Today.AddDays(7); // Calculate the start date for the range
            var StartDate = DateTime.Today.Date; // Current date

            // Retrieve appointments within the date range
            var appointments = await _context.Appointments
                                    .Include(appointment => appointment.Patient)
                                    .Where(appointment => appointment.AppointmentStartTime >= StartDate && appointment.AppointmentStartTime <= EndDate)
                                    .ToListAsync();

            return appointments;
        }
        public async Task<List<Appointment>> AppointmentsDueThisWeekForEmployee(int id)
        {
            var CompSettings = await _context.CompanySettings.FirstOrDefaultAsync() ?? throw new KeyNotFoundException("Company Settings Not Set.");
            var EarlyReminderDays = CompSettings.EarlyReminderDate; // stores a value of days such as 1 or 2 

            var EndDate = DateTime.Today.AddDays(7); // Calculate the start date for the range
            var StartDate = DateTime.Today.Date; // Current date

            // Retrieve appointments within the date range
            var appointments = await _context.Appointments
                                    .Include(appointment => appointment.Patient)
                                    .Where(appointment => appointment.AppointmentStartTime >= StartDate && appointment.AppointmentStartTime <= EndDate && appointment.DentistID == id)
                                    .ToListAsync();

            return appointments;
        }



    }
}
