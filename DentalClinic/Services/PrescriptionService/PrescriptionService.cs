using AutoMapper;
using DentalClinic.Context;
using DentalClinic.DTOs;
using DentalClinic.Models;
using DentalClinic.Services.Tools;
using Microsoft.EntityFrameworkCore;

namespace DentalClinic.Services.PrescriptionService
{
    public class PrescriptionService : IPrescriptionService1
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IToolsService _toolsService;
        public PrescriptionService(DataContext context, IMapper mapper, IToolsService toolsService)
        {
            _context = context;
            _mapper = mapper;
            _toolsService = toolsService;
        }

        public async Task<Prescription> CreatePrescriptionAsync(AddPrescriptionDTO prescription)
        {
            Patient? patient = await _context.Patients.FindAsync(prescription.PatientID);

            Employee? employee = await _context.Employees.FindAsync(prescription.EmployeeID);

            Prescription presc = new Prescription
            {
                //Patient = patient,
                DrugName = prescription.DrugName,
                Strength = prescription.Strength,
                Duration = prescription.Duration,
                Quantity = prescription.Quantity,
                Frequency = prescription.Frequency,
                inPatient = prescription.inPatient,
                Dosage = prescription.Dosage,
                HowToUse = prescription.HowToUse,
                OtherInformation = prescription.OtherInformation,
                TotalPrice = prescription.TotalPrice,
                Registrations = prescription.Registrations,
                Qualification = prescription.Qualification,

            };

            presc.Patient = patient;
            presc.Emp = employee;


            _context.Prescriptions.Add(presc);
            await _context.SaveChangesAsync();
            return presc;

        }

        public async Task<List<Prescription>> GetAllPrescriptionsAsync()
        {
            return await _context.Prescriptions
                .Include(p=>p.Patient)
                .Include(p=>p.Emp)
                .ToListAsync();
        }


        public async Task<Prescription?> GetPrescriptionByIdAsync(int id)
        {
            return await _context.Prescriptions.
                Include(p=>p.Patient)
                .Include(p=>p.Emp).
                FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Prescription?>> GetPrescriptionByEmployee(int id)
        {
            return await _context.Prescriptions
                .Include(p => p.Patient)
                .Where(p => p.Emp.EmployeeId == id)  // Filter by Employee ID
                .ToListAsync();               // Fetch results as a list
        }


        public async Task<List<Prescription?>> GetPrescriptionByPatient(int id)
        {
            return await _context.Prescriptions
                .Include(p => p.Emp)
                .Where(p => p.Patient.PatientId == id)  // Filter by Employee ID
                .ToListAsync();
        }

        public async Task<Prescription?> UpdatePrescriptionAsync(UpdatePrescriptionDTO updatedPrescription)
        {
            var prescription = await _context.Prescriptions.FindAsync(updatedPrescription.PrescriptionID);
            var employee = await _context.Employees.FindAsync(updatedPrescription.EmployeeID);

            if (prescription == null)
            {
                return null; // Prescription not found
            }

            // Update fields with the new values
            prescription.DrugName = updatedPrescription.DrugName;
            prescription.Strength = updatedPrescription.Strength;
            prescription.Duration = updatedPrescription.Duration;
            prescription.Quantity = updatedPrescription.Quantity;
            prescription.HowToUse = updatedPrescription.HowToUse;
            prescription.Frequency = updatedPrescription.Frequency;
            prescription.inPatient = updatedPrescription.inPatient;
            prescription.Dosage = updatedPrescription.Dosage;
            prescription.TotalPrice = updatedPrescription.TotalPrice;
            prescription.OtherInformation = updatedPrescription.OtherInformation;
            prescription.TotalPrice = updatedPrescription.TotalPrice;
            prescription.Registrations = updatedPrescription.Registrations;
            prescription.Qualification = updatedPrescription.Qualification;
            prescription.UpdatedAt = updatedPrescription.UpdatedAt;

            prescription.Emp = employee;

            _context.Prescriptions.Update(prescription);
            await _context.SaveChangesAsync();

            return prescription;
        }

        public async Task<bool> DeletePrescriptionAsync(int id)
        {
            var prescription = await _context.Prescriptions.FindAsync(id);
            if (prescription == null)
            {
                return false; // Prescription not found
            }

            _context.Prescriptions.Remove(prescription);
            await _context.SaveChangesAsync();
            return true;
        }


    }
}
