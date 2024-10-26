using AutoMapper;
using DentalClinic.Context;
using DentalClinic.DTOs;
using DentalClinic.DTOs.MedicalCertificateDTO;
using DentalClinic.Models;
using DentalClinic.Services.Tools;
using Microsoft.EntityFrameworkCore;

namespace DentalClinic.Services.MedicalCertificates
{
    public class MedicalCertificateService : IMedicalCertificateService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IToolsService _toolsService;
        public MedicalCertificateService(DataContext context, IMapper mapper, IToolsService toolsService)
        {
            _context = context;
            _mapper = mapper;
            _toolsService = toolsService;
        }

        public async Task<MedicalCertificate?> CreateMedicalCertificate(AddMedicalCertificateDTO DTO)
        {
            // Check if AttendedFrom or UpTo dates are before today
            if (DTO.AttendedFrom < DateTime.Today)
            {
                throw new ArgumentException("The 'Attended From' date cannot be before today.");
            }

            if (DTO.UpTo < DateTime.Today)
            {
                throw new ArgumentException("The 'Up To' date cannot be before today.");
            }

            // Check if AttendedFrom is less than UpTo
            if (DTO.AttendedFrom >= DTO.UpTo)
            {
                throw new ArgumentException("'Attended From' date must be earlier than 'Up To' date.");
            }

            // Fetch the Patient and Employee
            Patient? patient = await _context.Patients.FindAsync(DTO.PatientId);
            Employee? employee = await _context.Employees.FindAsync(DTO.EmployeeId);

            if (patient == null || employee == null)
            {
                throw new ArgumentException("Invalid Patient or Employee.");
            }

            // Create the MedicalCertificate object
            MedicalCertificate MC = new MedicalCertificate
            {
                Diagnosis = DTO.Diagnosis,
                SickLeave = DTO.SickLeave,
                AttendedFrom = DTO.AttendedFrom,
                UpTo = DTO.UpTo,
                EmployeeId = DTO.EmployeeId,
                PatientId = DTO.PatientId,
                Patient = patient,
                Employee = employee
            };

            // Add to context and save
            _context.MedicalCertificates.Add(MC);
            await _context.SaveChangesAsync();

            return MC;
        }



        public async Task<MedicalCertificate> UpdateMedicalCertificate(UpdateMedicalCertificateDTO DTO)
        {

            MedicalCertificate? medicalCertificate = await _context.MedicalCertificates.FindAsync(DTO.CardNumber);

            //Patient? patient = await _context.Patients.FindAsync(DTO.PatientId);

            //Employee? employee = await _context.Employees.FindAsync(DTO.EmployeeId);

            if (medicalCertificate == null)
            {
                return null; // Prescription not found
            }

            medicalCertificate.UpTo = DTO.UpTo;
            medicalCertificate.AttendedFrom = DTO.AttendedFrom;
            medicalCertificate.Diagnosis = DTO.Diagnosis;
            medicalCertificate.SickLeave = DTO.SickLeave;




            _context.MedicalCertificates.Update(medicalCertificate);
            await _context.SaveChangesAsync();
            return medicalCertificate;

        }

        public async Task<MedicalCertificate> GetSpecificCertificate(int id)
        {
            return await _context.MedicalCertificates
                .Include(p => p.Patient)
                    .ThenInclude(p => p.Prescriptions)
                .Include(p => p.Employee)
                .FirstOrDefaultAsync(p => p.CardNumber == id);

        }

        public async Task<List<MedicalCertificate>> GetAllCertificates()
        {
            return await _context.MedicalCertificates
                .Include(p => p.Patient)
                    .ThenInclude(p=>p.Prescriptions)
                .Include(p => p.Employee)
                .ToListAsync();
        }

        public async Task<List<MedicalCertificate>> GetMedicalCertificatesByEmployee(int employeeId)
        {
            var medicalCertificates = await _context.MedicalCertificates
                .Include(mc => mc.Employee)
                .Include(mc => mc.Patient)
                .Where(mc => mc.Employee != null && mc.Employee.EmployeeId == employeeId)
                .ToListAsync();

            return medicalCertificates;
        }

        public async Task<List<MedicalCertificate>> GetMedicalCertificatesByPatient(int patientId)
        {
            var medicalCertificates = await _context.MedicalCertificates
                .Include(mc => mc.Patient)
                .Include(mc => mc.Employee)
                .Where(mc => mc.Patient != null && mc.Patient.PatientId == patientId)  // Handle null Patient references
                .ToListAsync();

            return medicalCertificates;
        }


        public async Task<bool> DeleteMedicalCertificate(int id)
        {
            var med = await _context.MedicalCertificates.FindAsync(id);
            if (med == null)
            {
                return false; // Prescription not found
            }

            _context.MedicalCertificates.Remove(med);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
