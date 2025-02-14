using AutoMapper;
using DentalClinic.Context;
using DentalClinic.DTOs.MedicalRecordDTO;
using DentalClinic.DTOs.PatientDTO;
using DentalClinic.Models;
using DentalClinic.Services.PatientService;
using DentalClinic.Services.Tools;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace DentalClinic.Services.MedicalRecordService
{
    public class MedicalRecordService : IMedicalRecordService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IToolsService _toolsService;
        public MedicalRecordService(DataContext context, IMapper mapper, IToolsService toolsService)
        {
            _context = context;
            _mapper = mapper;
            _toolsService = toolsService;
        }
        public async Task<MedicalRecord> AddMedicalRecord(AddMedicalRecordDTO recordDTO)
        {

            var record = new MedicalRecord();
            var patient = await _context.Patients.Where(p => p.PatientId == recordDTO.PatientId).FirstOrDefaultAsync() ?? throw new KeyNotFoundException("Patient Not Found");
            int cardExpireAfter = 14;
            decimal totalPrice = 0;
            List<Procedure> proceduresList = new List<Procedure>();
            var companySettings = await _context.CompanySettings
                    .FirstOrDefaultAsync();

            if (companySettings == null)
                throw new InvalidOperationException("Company Setting Not Found");
            cardExpireAfter = companySettings.CardExpireAfter;

            var TreatmentBY = await _context.Employees
                        .Where(e => e.EmployeeId == recordDTO.TreatedByID)
                        .FirstOrDefaultAsync() ?? throw new KeyNotFoundException("Employee Not Found!!!");
            PatientCard? patientCard = await _context.PatientCards
                        .Where(e => e.PatientID == recordDTO.PatientId)
                        .FirstOrDefaultAsync();


            //var labServices = new LaboratoryRequests();
            //var payments = new Payment();


            record.TreatedById = recordDTO.TreatedByID;
            record.PrescribedMedicinesandNotes = recordDTO.PrescribedMedicinesandNotes;
            record.ReferalList = recordDTO.ReferalList;
            record.DiscountPercent = recordDTO.DiscountPercent;

            record.TreatedBy = TreatmentBY;
            //record.Payment = payments;
            record.Patient = patient;



            int[] Procedures;

            Procedures = recordDTO.ProceduresIDs;
            string proceduresJson = JsonSerializer.Serialize(Procedures);
            string quantities = JsonSerializer.Serialize(recordDTO.Quantity);

            record.ProcedureIDs = proceduresJson;

            record.Quantities = quantities;



            for (int i = 0; i < (recordDTO.Quantity.Length); i++)
            {
                int procedureId = Procedures[i];
                int quantity = recordDTO.Quantity[i];
                Procedure? procedureItem = new Procedure();

                procedureItem = await _context.Procedures
                                                       .Where(pr => pr.ProcedureID == procedureId)
                                                       .FirstOrDefaultAsync();

                if (procedureItem != null)
                {
                    proceduresList.Add(procedureItem);

                    // Multiply the price with the quantity
                    totalPrice = totalPrice + (decimal)(procedureItem.Price);

                    // Do something with totalPrice if needed.
                }
            }
            record.SubTotalAmount = totalPrice;
            if (record.DiscountPercent != 0)
            {
                totalPrice = (totalPrice) - (decimal)(record.DiscountPercent) / 100 * totalPrice;
            }
            else
            {
                totalPrice = totalPrice;
            }
            record.DiscountPercent = recordDTO.DiscountPercent;
            record.Procedures = proceduresList;
            record.TotalAmount = totalPrice;

            record.ConsultationPrice = recordDTO.ConsultationPrice;
            record.HasConsultationFee = recordDTO.HasConsultationFee;

            //record.IsBacterology = recordDTO.Bacterology;
            //record.IsHematology = recordDTO.Hematology;
            //record.IsSerology = recordDTO.Serology;
            //record.IsMicroscopy = recordDTO.Microscopy;
            //record.IsStoolExamination = recordDTO.StoolExamination;
            //record.IsChemistry  = recordDTO.Chemistry;
            //record.IsUrinalysis = recordDTO.Urinalysis;


            await _context.MedicalRecords.AddAsync(record);
            await _context.SaveChangesAsync();

            var labreq = new LaboratoryRequests();
            labreq.isBacterology = recordDTO.Bacterology;
            labreq.isChemistry = recordDTO.Chemistry;
            labreq.isHematology = recordDTO.Hematology;
            labreq.isSerology = recordDTO.Serology;
            labreq.isMicroscopy = recordDTO.Microscopy;
            labreq.isStoolExamination = recordDTO.StoolExamination;
            labreq.isUrinalyis = recordDTO.Urinalysis;
            labreq.PatientId = recordDTO.PatientId;
            labreq.Patient = patient;
            labreq.RequestedBy = TreatmentBY;
            labreq.RequestedById = recordDTO.TreatedByID;
            labreq.MedicalRecordId = record.Medical_RecordID;
            labreq.MedicalRecord = record;



            //var labreqlist = new LaboratoryRequestList();
            //labreqlist.Bacterology = recordDTO.Bacterology;
            //labreqlist.Hematology = recordDTO.Hematology;
            //labreqlist.Serology = recordDTO.Serology;
            //labreqlist.Microscopy = recordDTO.Microscopy;
            //labreqlist.StoolExamination = recordDTO.StoolExamination;
            //labreqlist.Chemistry = recordDTO.Chemistry;
            //labreqlist.Urinalysis = recordDTO.Urinalysis;
            //labreqlist.PatientId = recordDTO.PatientId;
            //labreqlist.EmployeeId = recordDTO.TreatedByID;
            //labreqlist.MedicalRecoredId = record.Medical_RecordID;
            //labreqlist.MedicalRecord = record;
            //labreqlist.Patient = patient;
            //labreqlist.Requester = TreatmentBY;

            //try
            //{

            //await _context.LaboratoryRequestLists.AddAsync(labreqlist);
            //}
            //catch (Exception ex)
            //{
            //    // Log the exception or inspect it in your debugger
            //    Console.WriteLine($"Error: {ex.Message}");
            //    Console.WriteLine($"Stack Trace: {ex.StackTrace}");
            //    Console.WriteLine("hereee");
            //    throw new Exception("hereeeeee2"); // Re-throw the exception if you want it to propagate
            //}


            try
            {

                await _context.LaboratoryRequests.AddAsync(labreq);
            }
            catch (Exception ex)
            {
                // Log the exception or inspect it in your debugger
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                throw new Exception("hereeeeee"); // Re-throw the exception if you want it to propagate
            }



            //record.LaboratoryRequestsList = labreqlist;
            //record.LaboratoryRequest = labreq;

            //await _context.SaveChangesAsync();
            return record;
        }



        public async Task<MedicalRecord> DeleteMedicalRecord(int MedicalRecordID)
        {
            var MedicalRecord = await _context.MedicalRecords.
                                 Where(mr => mr.Medical_RecordID == MedicalRecordID)
                                .FirstOrDefaultAsync() ?? throw new KeyNotFoundException("Medical Record Not Found!");
            _context.MedicalRecords.Remove(MedicalRecord);
            await _context.SaveChangesAsync();
            return MedicalRecord;
        }

        public async Task<List<DisplayMedicalRecordDTO>> GetAllMedicalRecords()
        {
            var records = await _context.MedicalRecords
                                    //.Include(r => r.Procedures)
                                    .Include(r => r.Procedures)
                                    .Include(r => r.TreatedBy)
                                    .OrderByDescending(r => r.Date)
                                    .ToListAsync();

            var recordDTOs = records.Select(r => new DisplayMedicalRecordDTO
            {
                Medical_RecordID = r.Medical_RecordID,
                PatientId = r.PatientId,
                TreatedById = r.TreatedById.HasValue ? r.TreatedById.Value : 0,
                TreatedByName = r.TreatedBy?.EmployeeName ?? "",
                PrescribedMedicinesandNotes = r.PrescribedMedicinesandNotes,
                ReferalsList = r.ReferalList,
                DiscountPercent = r.DiscountPercent,
                TotalAmount = r.TotalAmount,
                //date = r.Date ?? DateTime.MinValue,
                SubTotalAmount = r.SubTotalAmount,

                ProceduresIDs = string.IsNullOrEmpty(r.ProcedureIDs)
                    ? new int[] { 0 }
                    : JsonSerializer.Deserialize<int[]>(r.ProcedureIDs),

                Quantity = string.IsNullOrEmpty(r.Quantities)
                    ? new int[] { 0 }
                    : JsonSerializer.Deserialize<int[]>(r.Quantities),

                IsPaid = r.IsPaid,
                isCard = r.IsCard,
                IsHematology = r.IsHematology,
                IsUrinalysis = r.IsUrinalysis,
                IsBacterology = r.IsBacterology,
                IsChemistry = r.IsChemistry,
                IsStoolExamination = r.IsStoolExamination,
                IsMicroscopy = r.IsMicroscopy,
                IsSerology = r.IsSerology,
                HasConsultationFee = r.HasConsultationFee,
                ConsultationPrice = r.ConsultationPrice,
            }).ToList().OrderByDescending(r => r.date).ToList();

            if (recordDTOs == null)
            {
                throw new KeyNotFoundException("There are no records found");
            }

            return recordDTOs;
        }

        public async Task<MedicalRecord> UpdateMedicalRecord(UpdateMedicalRecordDTO MrDto)
        {
            var records = await _context.MedicalRecords
                     .Where(pp => pp.Medical_RecordID == MrDto.MedicalRecordID)
                     .Include(r => r.Procedures)
                     .Include(r => r.TreatedBy)
                     .FirstOrDefaultAsync();
            var procedures = string.IsNullOrEmpty(records.ProcedureIDs) ? new int[] { 0 } : JsonSerializer.Deserialize<int[]>(records.ProcedureIDs);
            var quantities = string.IsNullOrEmpty(records.Quantities) ? new int[] { 0 } : JsonSerializer.Deserialize<int[]>(records.Quantities);

            var mergedProcedures = procedures.Concat(MrDto.ProceduresNew).ToArray();
            var mergedQuantities = quantities.Concat(MrDto.QuantitiesNew).ToArray();

            records.ProcedureIDs = JsonSerializer.Serialize(mergedProcedures);
            records.Quantities = JsonSerializer.Serialize(mergedQuantities);
            _context.MedicalRecords.Update(records);
            await _context.SaveChangesAsync();
            return records;
        }

        public async Task<List<DisplayMedicalRecordDTO>> GetAllMedicalRecordsByPatientId(int id)
        {
            // Retrieve all medical records for the given patient
            var records = await _context.MedicalRecords
                                 .Where(pp => pp.PatientId == id)
                                 .Include(r => r.Procedures)
                                 .Include(r => r.TreatedBy)
                                 .OrderByDescending(r => r.Date) // Order by date, if applicable
                                 .ToListAsync();

            if (records != null && records.Any())
            {
                // Map each record to a DTO
                var recordsDTO = records.Select(record => new DisplayMedicalRecordDTO
                {
                    Medical_RecordID = record.Medical_RecordID,
                    PatientId = record.PatientId,
                    TreatedById = record.TreatedById.HasValue ? record.TreatedById.Value : 0,
                    TreatedByName = record.TreatedBy?.EmployeeName ?? "",
                    PrescribedMedicinesandNotes = record.PrescribedMedicinesandNotes,
                    ReferalsList = record.ReferalList,
                    DiscountPercent = record.DiscountPercent,
                    TotalAmount = record.TotalAmount,
                    SubTotalAmount = record.SubTotalAmount,
                    ProceduresIDs = string.IsNullOrEmpty(record.ProcedureIDs)
                        ? new int[] { 0 }
                        : JsonSerializer.Deserialize<int[]>(record.ProcedureIDs),
                    Quantity = string.IsNullOrEmpty(record.Quantities)
                        ? new int[] { 0 }
                        : JsonSerializer.Deserialize<int[]>(record.Quantities),
                    IsPaid = record.IsPaid,
                    isCard = record.IsCard,
                    IsHematology = record.IsHematology,
                    IsUrinalysis = record.IsUrinalysis,
                    IsBacterology = record.IsBacterology,
                    IsChemistry = record.IsChemistry,
                    IsStoolExamination = record.IsStoolExamination,
                    IsMicroscopy = record.IsMicroscopy,
                    IsSerology = record.IsSerology,
                    HasConsultationFee = record.HasConsultationFee,
                    ConsultationPrice = record.ConsultationPrice,
                }).ToList();

                return recordsDTO;
            }
            else
            {
                return null;
            }
        }
    }


}


