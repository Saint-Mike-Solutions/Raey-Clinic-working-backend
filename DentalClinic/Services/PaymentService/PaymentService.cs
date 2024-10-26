using AutoMapper;
using DentalClinic.Context;
using DentalClinic.DTOs.AppointmentDTO;
using DentalClinic.DTOs.MedicalRecordDTO;
using DentalClinic.DTOs.MobileBankingDTO;
using DentalClinic.DTOs.PaymentDTO;
using DentalClinic.Migrations;
using DentalClinic.Models;
using DentalClinic.Services.Tools;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.Swagger;
using System.Text.Json;

namespace DentalClinic.Services.PaymentService
{
    public class PaymentService : IPaymentService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IToolsService _toolsService;
        public PaymentService(DataContext context, IMapper mapper, IToolsService toolsService)
        {
            _context = context;
            _mapper = mapper;
            _toolsService = toolsService;
        }

        public async Task<Payment> AddPaymentfromMedicalRecord(MakePaymentMedRecDTO DTO)
        {
            var record = await _context.MedicalRecords
                                        .Where(a => a.Medical_RecordID == DTO.MedicalRecordID)
                                        .FirstOrDefaultAsync();

            if (record == null)
            {
                var flag = false;
                var card = await _context.Procedures.Where(p => p.ProcedureName == "card" || p.ProcedureName == "Card" || p.ProcedureName == "CARD").FirstOrDefaultAsync();
                var arr = DTO.ProcedureIDs;
                var patientCard = await _context.PatientCards.Where(p => p.PatientID == DTO.PatientID).FirstOrDefaultAsync();
                var CompanySetting = await _context.CompanySettings.FirstOrDefaultAsync();
                var cardExpireAfter = CompanySetting.CardExpireAfter;
                if (patientCard == null)
                {
                    var pc = new PatientCard
                    {
                        PatientID = DTO.PatientID,
                        CreatedAT = DateTime.Now,
                    };
                    await _context.PatientCards.AddAsync(pc);
                    flag = true;

                }
                else if (patientCard != null && patientCard.CreatedAT < DateTime.Now.AddDays(-cardExpireAfter))
                {

                    patientCard.CreatedAT = DateTime.Now;
                    _context.PatientCards.Update(patientCard);
                    flag = true;

                }

                var newMedicalRecord = new MedicalRecord
                {
                    Date = DateTime.Now,
                    PatientId  = DTO.PatientID,
                    TreatedById = DTO.IssuedByID,
                    DiscountPercent = DTO.Discount,
                    TotalAmount = DTO.Total,
                    ProcedureIDs = JsonSerializer.Serialize(DTO.ProcedureIDs),
                    Quantities = JsonSerializer.Serialize(DTO.Quantity),
                    SubTotalAmount = DTO.SubTotal,
                    IsPaid = true,
                    IsCard = flag                    
                };



                if (DTO.IsCredit == true)
                {
                    var compSet = await _context.CompanySettings.FirstOrDefaultAsync() ?? throw new KeyNotFoundException("Company settings not set!!!");

                    if (DTO.Total > compSet.MaximumLoanAmount)
                    {
                        throw new InvalidOperationException("Credit exceeds Maximum loan amount alloted");
                    }
                    var cr = await _context.Credits.
                                Where(p => p.PatientID == DTO.PatientID).
                                OrderByDescending(p => p.ChargeDate).
                                FirstOrDefaultAsync();

                    var Credit = new Credit
                    {
                        PatientID = DTO.PatientID,
                        TotalCreditAmount = 0 - DTO.Total,
                        IssuedBy = DTO.IssuedByID,
                        ChargeDate = DTO.DateTime,
                        Paid = 0,
                        UnPaid = DTO.Total
                    };

                    if (cr != null)
                    {
                        // Case 1: Update existing Credit record
                        if (cr.UnPaid + DTO.Total > compSet.MaximumLoanAmount)
                        {
                            throw new InvalidOperationException("Credit exceeds Maximum loan amount alloted");
                        }
                        cr.TotalCreditAmount = cr.TotalCreditAmount - DTO.Total;
                        cr.UnPaid = cr.UnPaid + DTO.Total;
                        _context.Credits.Update(cr);

                    }
                    else
                    {
                        _context.Credits.Add(Credit);
                    }
                }



                var newPayment = new Payment
                {
                    IssuedByID = DTO.IssuedByID,
                    PaymentTypeID = DTO.PaymentType,
                    PatientID = DTO.PatientID,
                    SubTotal = DTO.Total + DTO.Discount / 100 * DTO.Total,
                    Total = DTO.Total,
                    Discount = DTO.Discount,
                    PaymentDate = DTO.DateTime,
                    IsCredit = DTO.IsCredit,
                    ReferenceNumber = DTO.ReferenceNumber,
                    ImageAttachment = DTO.ImageAttachment,
                    MobileBanking = DTO.MobileBanking,
                };

                newPayment.MedicalRecord = newMedicalRecord;

                var MedicalRecordsForPatients = await _context.MedicalRecords.Where(mr=>mr.IsCard == true && mr.IsPaid == false).ToListAsync();
                foreach (var mr in MedicalRecordsForPatients)
                {
                    mr.IsCard = false;
                }
                foreach (var mr in MedicalRecordsForPatients)
                {
                    _context.MedicalRecords.Update(mr);
                }

                _context.MedicalRecords.Add(newMedicalRecord);
                _context.Payments.Add(newPayment);
                await _context.SaveChangesAsync();
                return newPayment;

            }

            if (DTO.IsCredit == true)
            {
                var compSet = await _context.CompanySettings.FirstOrDefaultAsync() ?? throw new KeyNotFoundException("Company settings not set!!!");

                if (DTO.Total > compSet.MaximumLoanAmount)
                {
                    throw new InvalidOperationException("Credit exceeds Maximum loan amount alloted");
                }
                var cr = await _context.Credits.
                            Where(p => p.PatientID == DTO.PatientID).
                            OrderByDescending(p => p.ChargeDate).
                            FirstOrDefaultAsync();

                var Credit = new Credit
                {
                    PatientID = DTO.PatientID,
                    TotalCreditAmount = 0 - DTO.Total,
                    IssuedBy = DTO.IssuedByID,
                    ChargeDate = DTO.DateTime,
                    Paid = 0,
                    UnPaid = DTO.Total
                };

                if (cr != null)
                {
                    // Case 1: Update existing Credit record
                    if (cr.UnPaid + DTO.Total > compSet.MaximumLoanAmount)
                    {
                        throw new InvalidOperationException("Credit exceeds Maximum loan amount alloted");
                    }
                    cr.TotalCreditAmount = cr.TotalCreditAmount - DTO.Total;
                    cr.UnPaid = cr.UnPaid + DTO.Total;
                    _context.Credits.Update(cr);

                }
                else
                {
                    _context.Credits.Add(Credit);
                }

            }
            var procedureIDS = DTO.ProcedureIDs;
            var Quantities = DTO.Quantity;
            var cards = await _context.Procedures.Where(p => p.ProcedureName == "card" || p.ProcedureName == "Card" || p.ProcedureName == "CARD").FirstOrDefaultAsync();
            if (record.IsCard == true)
            {
                int[] val = { cards.ProcedureID };
                int[] qua = { 1 };
                procedureIDS = val.Concat(procedureIDS).ToArray();
                Quantities =  qua.Concat(Quantities).ToArray();
            }



            record.Quantities = JsonSerializer.Serialize(Quantities); 
            record.ProcedureIDs = JsonSerializer.Serialize(procedureIDS);
            var payment = new Payment
            {
                IssuedByID = DTO.IssuedByID,
                PaymentTypeID = DTO.PaymentType,
                PatientID = DTO.PatientID,
                SubTotal = DTO.Total + DTO.Discount / 100 * DTO.Total,
                Total = DTO.Total,
                Discount = DTO.Discount,
                PaymentDate = DTO.DateTime,
                IsCredit = DTO.IsCredit,
                ReferenceNumber = DTO.ReferenceNumber,
                ImageAttachment = DTO.ImageAttachment,
                MobileBanking = DTO.MobileBanking
            };
            payment.MedicalRecord = record;
            record.IsPaid = true;
            record.IsCard = false;
            _context.MedicalRecords.Update(record);
            var MedicalRecordsForPatient = await _context.MedicalRecords.Where(mr => mr.IsCard == true && mr.IsPaid == false).ToListAsync();
            foreach (var mr in MedicalRecordsForPatient)
            {
                mr.IsCard = false;
            }
            foreach (var mr in MedicalRecordsForPatient)
            {
                _context.MedicalRecords.Update(mr);
            }
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
            return payment;
        }
        public async Task<GetMDforPaymentDTO> GetMedicalRecordsforPayment(int id)
        {
            var record = await _context.MedicalRecords
                                                   .OrderByDescending(a => a.Date)
                                                   .Where(a => a.PatientId == id )
                                                   .Where(a=> a.IsPaid == false)
                                                   .FirstOrDefaultAsync() ?? throw new KeyNotFoundException("Medical Record Not Found, or Medical Record has been paid for");


            int[] proceduresArray = 
            string.IsNullOrEmpty(record.ProcedureIDs)? new int[] { 0 }: JsonSerializer.Deserialize<int[]>(record.ProcedureIDs);
            int[] quantityArray = 
            string.IsNullOrEmpty(record.Quantities) ? new int[] { 0 } : JsonSerializer.Deserialize<int[]>(record.Quantities);

            var display = new GetMDforPaymentDTO
            {
                PatientId = record.PatientId,
                MedicalRecordID = record.Medical_RecordID,
                Discount = record.DiscountPercent,
                IssuedBy = (int)record.TreatedById, // Adding a null-conditional operator here
                MedicalRecordDate = (DateTime)record.Date,
                SubTotal = record.SubTotalAmount,
                Total = record.TotalAmount,
                ProcedureIDs = proceduresArray,
                Quantity = quantityArray,
                isCard = record.IsCard,   
            };

            return display;

        }
        public async Task<List<Payment>> PaymentLogForPatient(int DTO)
        {
            var PaymentRecord = await _context.Payments.Where(p=> p.PatientID == DTO)
                                                       .Include(p=> p.MedicalRecord)
                                                        .OrderByDescending(p=> p.PaymentDate)
                                                        .ToListAsync();
            return PaymentRecord;
        }
        public async Task<DisplayPaymentHistoryDTO> PaymentHistoryDetails(int DTO)
        {
            var data = await _context.Payments
                                        .Where(p => p.Id == DTO)
                                        .Include(p => p.MedicalRecord)
                                        .FirstOrDefaultAsync() ?? throw new KeyNotFoundException("Payment Record Not Found");

            int[] proceduresArray = string.IsNullOrEmpty(data.MedicalRecord.ProcedureIDs) ? new int[] { 0 } : JsonSerializer.Deserialize<int[]>(data.MedicalRecord.ProcedureIDs);
            int[] quantityArray = string.IsNullOrEmpty(data.MedicalRecord.Quantities) ? new int[] { 0 } : JsonSerializer.Deserialize<int[]>(data.MedicalRecord.Quantities);

            var DisplayRecord = new DisplayPaymentHistoryDTO
            {
                Id = data.Id,
                Discount = data.Discount,
                PatientID = data.PatientID,
                Tax = data.Tax,
                SubTotal = data.SubTotal,
                IssuedByID = data.IssuedByID,
                Total = data.Total,
                PaymentTypeID = data.PaymentTypeID,
                PaymentDate = data.PaymentDate,
                IsCredit = data.IsCredit,
                MobileBanking = data.MobileBanking,
                ReferenceNumber = data.ReferenceNumber,
                ImageAttachment = data.ImageAttachment,
                ProcedureQuantity = new List<ProcedureQuantityDTO>()
            };

            if (proceduresArray != null)
            {
                for (int i = 0; i < proceduresArray.Length; i++)
                {
                    var procedureName = await _context.Procedures.Where(p=> p.ProcedureID == proceduresArray[i]).FirstOrDefaultAsync();
                    int quantity = quantityArray[i];

                    ProcedureQuantityDTO procedureQuantity = new ProcedureQuantityDTO
                    {
                        Name = procedureName.ProcedureName,
                        Quantity = quantity
                    };

                    DisplayRecord.ProcedureQuantity.Add(procedureQuantity);
                }
                if (data.MedicalRecord.IsCard == true)
                {
                    ProcedureQuantityDTO pro = new ProcedureQuantityDTO
                    {
                        Name = "Card",
                        Quantity = 1
                    };
                    DisplayRecord.ProcedureQuantity.Add(pro);
                }
            }

            return DisplayRecord;
        }

        public async Task<List<Payment>> PaymentLogForAll()
        {
            var PaymentRecord = await _context.Payments
                                            .OrderByDescending(p => p.PaymentDate)
                                            .ToListAsync();
            return PaymentRecord;
        }
        //public async Task<Credit> LoanExpireDate()
        //{
        //    var companySetting = await _context.CompanySettings.FirstOrDefaultAsync();
        //    var loanExpireDateDay = companySetting.LoanExpireAfter;

        //}

        

    }
}
