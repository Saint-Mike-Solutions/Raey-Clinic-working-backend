using AutoMapper;
using DentalClinic.Context;
using DentalClinic.DTOs.EmployeeDTO;
using DentalClinic.DTOs.HealthProgressDTO;
using DentalClinic.Models;
using Microsoft.EntityFrameworkCore;

namespace DentalClinic.Services.HealthProgressService
{
    public class HealthProgressService : IHealthProgressService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public HealthProgressService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        public async Task<HealthProgress> AddHealthProgressToEmployee(AddHealthProgressDTO progressDTO)
        {
            var Patient = await _context.Patients
                        .FirstOrDefaultAsync(p => p.PatientId == progressDTO.PatientID);
            var Employee = await _context.Employees
                        .FirstOrDefaultAsync(e => e.EmployeeId == progressDTO.AdministeredBY);
            var healthProgress = new HealthProgress
            {
                Weight = progressDTO.Weight,
                BloodPressure = progressDTO.BloodPressure,
                OtherVitalSigns = progressDTO.OtherVitalSigns,
                NotesOnProgress = progressDTO.NotesOnProgress,
                Employee = Employee,
                Patient = Patient,
            };
            //var progress = _mapper.Map<HealthProgress>(progressDTO);
            //progress.Patient = Patient;
            //progress.Employee = Employee;
            _context.HealthProgresses.Add(healthProgress);
            await _context.SaveChangesAsync();
            return healthProgress;
        }
        public async Task<List<HealthProgress>> GetHealthProgressesForPatient(int patientId)
        {
            var patient = await _context.Patients
                                        .Where(p => p.PatientId == patientId)
                                        .Include(p => p.HealthProgresses) // Include the related HealthProgresses
                                        .FirstOrDefaultAsync();

            if (patient != null)
            {
                return patient.HealthProgresses; // Return the HealthProgresses for the patient
            }

            return new List<HealthProgress>();
        }
        public async Task<List<HealthProgress>> GetHealthProgressesAdministeredByEmployee(int employeeId)
        {
            var employee = await _context.Employees
                                        .Where(e => e.EmployeeId == employeeId)
                                        .Include(e=> e.HealthProgresses) // Include the related HealthProgresses
                                        .FirstOrDefaultAsync();

            if (employee != null)
            {
                return employee.HealthProgresses; // Return the HealthProgresses by employee
            }

            return new List<HealthProgress>();
        }


    }
}
