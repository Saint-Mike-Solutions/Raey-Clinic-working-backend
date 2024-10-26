using AutoMapper;
using DentalClinic.Context;
using DentalClinic.DTOs.CreditDTO;
using DentalClinic.DTOs.MobileBankingDTO;
using DentalClinic.DTOs.SettingsDTO;
using DentalClinic.Models;
using DentalClinic.Services.CompanySettingService;
using Microsoft.EntityFrameworkCore;

namespace DentalClinic.Services.CreditService
{
    public class CreditService : ICreditService
    {

        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public CreditService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //Update works by updating only 1 record that's in the database and changing it
        public async Task<Credit> ChargeCredit(ChargeCreditDTO DTO)
        {
            var cr = await _context.Credits.Where(p => p.PatientID == DTO.PatientID).FirstOrDefaultAsync();
            CreditPaymentRecord CPR = new CreditPaymentRecord
            {
                PatientID = DTO.PatientID,
                Paid = DTO.CreditAmount,
                CreateAt = DateTime.Now,
                IssuedBy = DTO.IssuedBy,
                PaymentType = DTO.PaymentType

            };
            if (cr == null)
            {
                Credit credit = new Credit
                {
                    PatientID = DTO.PatientID,
                    TotalCreditAmount = DTO.CreditAmount,
                    UnPaid =0,
                    Paid = DTO.CreditAmount,
                    IssuedBy = DTO.IssuedBy,
                    ChargeDate = DateTime.Now
                    
                };


                _context.Credits.Add(credit);
                _context.CreditPaymentRecords.Add(CPR);
                await _context.SaveChangesAsync();
                return credit;
            }


            cr.TotalCreditAmount = cr.TotalCreditAmount + DTO.CreditAmount;
            cr.Paid = cr.Paid + DTO.CreditAmount;
            cr.UnPaid = cr.UnPaid - DTO.CreditAmount;
            cr.ChargeDate = DTO.DateTime;

            _context.Credits.Update(cr);
            _context.CreditPaymentRecords.Add(CPR);
            await _context.SaveChangesAsync();
            return cr;
        }
        public async Task<Credit> CurrentCreditInfo(int DTO)
        {
            var credit = await _context.Credits.
                            Where(p=> p.PatientID == DTO)
                            .OrderByDescending(p=>p.ChargeDate)
                            .FirstOrDefaultAsync()??throw new KeyNotFoundException("Patient hasn't been Credited with any charges.");
            return credit;
        }
        public async Task<List<DisplayCreditHistoryDTO>> CreditHistoryForPatient(int DTO)
        {
            var creditRecords = await _context.CreditPaymentRecords
                .Where(p => p.PatientID == DTO)
                .Include(p => p.Patient)
                .Include(p => p.Employee)
                .OrderByDescending(p => p.CreateAt)
                .ToListAsync() ?? throw new KeyNotFoundException("Patient hasn't been Credited with any charges.");

            var displayDTOs = new List<DisplayCreditHistoryDTO>();

            foreach (var record in creditRecords)
            {
                var displayDTO = new DisplayCreditHistoryDTO
                {
                    ID = record.ID,
                    Paid = record.Paid,
                    CreateAt = record.CreateAt,
                    PaymentType = record.PaymentType,
                    PatientName = record.Patient?.PatientFullName,
                    IssuedBy = record.Employee?.EmployeeName
                };

                displayDTOs.Add(displayDTO);
            }

            return displayDTOs;
        }
        public async Task<List<PatientWithCreditDTO>> LoanExpireAfter()
        {
            var CompSettings = await _context.CompanySettings.FirstOrDefaultAsync() ?? throw new KeyNotFoundException("Company Settings Not Set.");
            var Loans = await _context.Credits
                                    .Where(c => c.UnPaid < 0)
                                    .Include(c => c.Patient)
                                    .Include(c => c.Employee)
                                    .ToListAsync();
            var LoanExpireAfter = CompSettings.LoanExpireAfter;
            var EarlyReminder = CompSettings.EarlyReminderForLoan;

            // Create a list to hold the DTOs
            List<PatientWithCreditDTO> patientWithCreditDTOs = new List<PatientWithCreditDTO>();

            // Iterate through each loan and create a DTO
            foreach (var loan in Loans)
            {
                // Calculate the expiration date
                DateTime expirationDate = loan.ChargeDate.AddDays(LoanExpireAfter);
                if ((expirationDate - DateTime.Now).Days > EarlyReminder)
                {
                    continue;
                }

                // Create a new DTO instance and populate its properties
                PatientWithCreditDTO dto = new PatientWithCreditDTO
                {
                    Id = loan.CreditID,
                    PatientName = loan.Patient.PatientFullName,
                    PhoneNumber = loan.Patient.Phone,
                    PatientAdress = $"{loan.Patient.Country}, {loan.Patient.City}, {loan.Patient.Subcity}, {loan.Patient.Address}",
                    Age = loan.Patient.Age,
                    CreditAmount = loan.UnPaid,
                    CreditIssuedByName = loan.Employee.EmployeeName,
                    DaysUntilLoanExpire = (expirationDate - DateTime.Now).Days
                };

                // Add the DTO to the list
                patientWithCreditDTOs.Add(dto);
            }

            return patientWithCreditDTOs;
        }



        public async Task<List<PatientWithCreditDTO>> PatientsWithLoan()
        {
            var CompSettings = await _context.CompanySettings.FirstOrDefaultAsync() ?? throw new KeyNotFoundException("Company Settings Not Set.");
            var Loans = await _context.Credits
                                    .Where(c => c.TotalCreditAmount < 0)
                                    .Include(c => c.Patient)
                                    .Include(c => c.Employee)
                                    .ToListAsync();
            var LoanExpireAfter = CompSettings.LoanExpireAfter;

            // Create a list to hold the DTOs
            List<PatientWithCreditDTO> patientWithCreditDTOs = new List<PatientWithCreditDTO>();

            // Iterate through each loan and create a DTO
            foreach (var loan in Loans)
            {
                // Calculate the expiration date
                DateTime expirationDate = loan.ChargeDate.AddDays(LoanExpireAfter);

                // Create a new DTO instance and populate its properties
                PatientWithCreditDTO dto = new PatientWithCreditDTO
                {
                    Id = loan.CreditID,
                    PatientName = loan.Patient.PatientFullName,
                    PhoneNumber = loan.Patient.Phone,
                    PatientAdress = $"{loan.Patient.Country}, {loan.Patient.City}, {loan.Patient.Subcity}, {loan.Patient.Address}",
                    Age = loan.Patient.Age,
                    CreditAmount = loan.UnPaid,
                    CreditIssuedByName = loan.Employee.EmployeeName,
                    DaysUntilLoanExpire = (expirationDate - DateTime.Now).Days
                };

                // Add the DTO to the list
                patientWithCreditDTOs.Add(dto);
            }

            return patientWithCreditDTOs;
        }





    }
}

