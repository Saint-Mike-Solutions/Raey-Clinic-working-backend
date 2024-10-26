using AutoMapper;
using DentalClinic.Context;
using DentalClinic.DTOs.MedicalCertificateDTO;
using DentalClinic.DTOs.PatientDTO;
using DentalClinic.DTOs.ReferralDTO;
using DentalClinic.Models;
using DentalClinic.Services.PatientService;
using DentalClinic.Services.Tools;
using Microsoft.EntityFrameworkCore;

namespace DentalClinic.Services.ReferralService
{
    public class ReferralService : IReferralService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IToolsService _toolsService;
        public ReferralService(DataContext context, IMapper mapper, IToolsService toolsService)
        {
            _context = context;
            _mapper = mapper;
            _toolsService = toolsService;
        }
        public async Task<Referral> AddReferral(AddReferralDTO referralDTO)
        {

            Patient? patient = await _context.Patients.FindAsync(referralDTO.PatientId);

            Employee? employee = await _context.Employees.FindAsync(referralDTO.ReferredBy);
            var referral = new Referral
            {
                ReferalTo = referralDTO.ReferalTo,
                ReferalNumber = referralDTO.ReferalNumber,
                CardNumber = referralDTO.CardNumber,
                ReferredBy = referralDTO.ReferredBy,
                PatientId = referralDTO.PatientId,
                HealthProblemIdentified = referralDTO.HealthProblemIdentified,
                InvestigationDoneAndResult = referralDTO.InvestigationDoneAndResult,
                AnyActionTaken = referralDTO.AnyActionTaken,
                ReasonsForReferral = referralDTO.ReasonsForReferral,
                ReferralFeedback = referralDTO.ReferralFeedback,

            };

            referral.Patient = patient;
            referral.Employee = employee;

            _context.Referrals.Add(referral);
            await _context.SaveChangesAsync();
            return referral;
        }

        public async Task<Referral> UpdateReferral(UpdateReferralDTO DTO)
        {

            Referral? reff = await _context.Referrals.FindAsync(DTO.Id);


            if (reff == null)
            {
                return null; // Prescription not found
            }

            reff.ReferralFeedback = DTO.ReferralFeedback;
            reff.CardNumber = DTO.CardNumber;
            reff.ReferalNumber = DTO.ReferalNumber;
            reff.ReasonsForReferral = DTO.ReasonsForReferral;
            reff.AnyActionTaken = DTO.AnyActionTaken;
            reff.HealthProblemIdentified = DTO.HealthProblemIdentified;
            reff.InvestigationDoneAndResult = DTO.InvestigationDoneAndResult;
            reff.ReferalTo = DTO.ReferalTo;




            _context.Referrals.Update(reff);
            await _context.SaveChangesAsync();
            return reff;

        }

        public async Task<Referral> GetSpecificReferral(int id)
        {
            return await _context.Referrals
                .Include(p => p.Patient)
                .Include(p => p.Employee)
                .FirstOrDefaultAsync(p => p.Id == id);

        }

        public async Task<List<Referral>> GetAllReferrals()
        {
            return await _context.Referrals
                .Include(p => p.Patient)
                .Include(p => p.Employee)
                .ToListAsync();
        }

        public async Task<List<Referral>> GetReferralByEmployee(int employeeId)
        {
            var referral = await _context.Referrals
                .Include(mc => mc.Employee)
                .Where(mc => mc.Employee != null && mc.Employee.EmployeeId == employeeId)
                .ToListAsync();

            return referral;
        }

        public async Task<List<Referral>> GetReferralByPatient(int patientId)
        {
            var referral = await _context.Referrals
                .Include(mc => mc.Patient)
                .Where(mc => mc.Patient != null && mc.Patient.PatientId == patientId)  // Handle null Patient references
                .ToListAsync();

            return referral;
        }


        public async Task<bool> DeleteReferrals(int id)
        {
            var med = await _context.Referrals.FindAsync(id);
            if (med == null)
            {
                return false; // Prescription not found
            }

            _context.Referrals.Remove(med);
            await _context.SaveChangesAsync();
            return true;
        }


    }
}
