using AutoMapper;
using DentalClinic.Context;
using DentalClinic.Models;
using DentalClinic.DTOs.PatientDTO;
using Microsoft.EntityFrameworkCore;
using DentalClinic.Services.Tools;
using DentalClinic.Migrations;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System;

namespace DentalClinic.Services.PatientService
{
    public class PatientService : IPatientService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IToolsService _toolsService;
        public PatientService(DataContext context, IMapper mapper, IToolsService toolsService)
        {
            _context = context;
            _mapper = mapper;
            _toolsService = toolsService;
        }
        public async Task<Patient> AddPatient(AddPatientDTO patientDTO)
        {
            var patient = _mapper.Map<Patient>(patientDTO);
            patient.CreatedAt = DateTime.Now;
            patient.UpdatedAt = DateTime.Now;

            if (patientDTO.Age == 0)
            {
                patient.Age = _toolsService.CalculateAge(patientDTO.DateOfBirth);
            }
            else
            {
                patient.DateOfBirth = _toolsService.CalculateDOB(patient.Age);
            }

            var lab = new LaboratoryRequests
            {
                ReportedBy = null,
                RequestedBy = null,
                Bacterology = null,
                Chemistry = null,
                Microscopy = null,
                Hematology = null,
                Serology = null,
                Urinalysis = null,
                StoolExamination = null,

            };

            var medicalRecord = new MedicalRecord
            {
                PatientId = 0, // Set to 0; will be updated once the patient is saved
                Date = null,
                PrescribedMedicinesandNotes = string.Empty,
                ReferalList = string.Empty,
                Procedures = null,
                TreatedById = null,
                DiscountPercent = 0,
                TotalAmount = 0,
                IsPaid = false,
                ProcedureIDs = string.Empty,
                Quantities = string.Empty,
                SubTotalAmount = 0,
                IsCard = false,
                IsHematology = false,
                IsSerology = false,
                IsStoolExamination = false,
                IsMicroscopy = false,
                IsChemistry = false,
                IsBacterology = false,
                IsUrinalysis = false,
            };

            patient.LaboratoryRequests = lab;
            patient.MedicalRecord = medicalRecord;

            var patientProfile = _mapper.Map<PatientProfile>(patientDTO);
            patient.Profile = patientProfile;

            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();

            // Update the MedicalRecord's PatientId after the Patient is saved
            medicalRecord.PatientId = patient.PatientId;
                //= patient.Id;
            await _context.SaveChangesAsync();

            return patient;
        }
        public async Task<Patient> DeletePatient(int ID)
        {
            var patient = await _context.Patients.Where(p=> p.PatientId == ID)
                                                 .Include(p=> p.PatientVisits)
                                                 .Include(p=>p.HealthProgresses)
                                                 .Include(p=>p.Appointments)
                                                 .Include(p => p.Profile)
                                                 .Include(p=>p.MedicalRecord)
                                                 .Include(p=> p.Credits)
                                                .FirstOrDefaultAsync();
            //if (patient != null)
            //{
            //    // Step 2: Delete associated referrals
            //    if(patient.MedicalRecords != null) 
            //    {
            //        //var referralIds =  patient.MedicalRecords.SelectMany(mr => mr.Referals.Select(r => r.ReferalID)).ToList();
            //        //var referrals =  _context.Referals.Where(r => referralIds.Contains(r.ReferalID));
            //        //_context.Referals.RemoveRange(referrals);
            //        _context.MedicalRecords.RemoveRange(patient.MedicalRecords);
            //    }

            //}

            if (patient == null) throw new KeyNotFoundException("Patient Not Found");
            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
            return patient;
        }
        public async Task<Patient> UpdatePatient(UpdatePatientDTO patientDTO)
        {
            var patient = await _context.Patients
                        .Where(p => p.PatientId == patientDTO.PatientID)
                        .Include(p=>p.Profile)
                        .FirstOrDefaultAsync()
                        ?? throw new KeyNotFoundException("Patient Not Found");
            patient.UpdatedAt = DateTime.Now;
            var PatientProfile = await _context.patientProfiles
            .Where(p => p.Patient_Id == patientDTO.PatientID)
            .FirstOrDefaultAsync()
            ?? throw new KeyNotFoundException("Patient Not Found");



            patient = _mapper.Map(patientDTO, patient);
            PatientProfile = _mapper.Map(patientDTO, PatientProfile);
            patient.Profile = PatientProfile;
            patient.DateOfBirth = _toolsService.CalculateDOB(patientDTO.Age);
            _context.Patients.Update(patient);
            await _context.SaveChangesAsync();

            return patient;
                                                
        }
        public async Task<List<DisplayPatientDTO>> GetAllPatients()
        {
            DateTime date = new DateTime(2000, 1, 1);
            var patients = await _context.Patients
                .OrderByDescending(c => c.UpdatedAt)
                .Include(p => p.PatientCard)
                .Include(p => p.LaboratoryRequests)
                    .ThenInclude(lr => lr.Hematology)  
                        .ThenInclude(hm => hm.Diff)// Include Hematology
                .Include(p => p.LaboratoryRequests)
                    .ThenInclude(lr => lr.Urinalysis)       // Include Urinalysis
                .Include(p => p.LaboratoryRequests)
                    .ThenInclude(lr => lr.Serology)         // Include Serology
                .Include(p => p.LaboratoryRequests)
                    .ThenInclude(lr => lr.StoolExamination) // Include StoolExamination
                .Include(p => p.LaboratoryRequests)
                    .ThenInclude(lr => lr.Microscopy)       // Include Microscopy
                .Include(p => p.LaboratoryRequests)
                    .ThenInclude(lr => lr.Chemistry)        // Include Chemistry
                .Include(p => p.LaboratoryRequests)
                    .ThenInclude(lr => lr.Bacterology)  
                        .ThenInclude(br => br.AFB) // Include Bacterology
                .Include(p => p.Prescriptions)              // Include Prescriptions
                .Include(p => p.Referrals)                  // Include Referrals
                .ToListAsync();

            var compSettings = await _context.CompanySettings.FirstOrDefaultAsync() ?? throw new KeyNotFoundException("Company Settings Not Found!");
            var cardExpireAfter = compSettings.CardExpireAfter;


            // Create a list of PatientDTO with calculated ages
            var patientDTOs = patients.Select(patients => new DisplayPatientDTO
            {
                PatientId = patients.PatientId,
                PatientFullName = patients.PatientFullName,
                Age = _toolsService.CalculateAge(patients.DateOfBirth ?? DateTime.MinValue),
                Phone = patients.Phone,
                Gender = patients.Gender,
                Country = patients.Country,
                City = patients.City,
                Subcity = patients.Subcity,
                Address = patients.Address,
                CreatedAt = patients.CreatedAt,
                UpdateAt = patients.UpdatedAt ?? date,
                Weight = patients.Weight,
                Region = patients.Region,
                Town = patients.Town,
                Woreda = patients.Woreda,
                Kebele = patients.Kebele,
                HouseNumber = patients.HouseNumber,
                DateOfBirth = patients.DateOfBirth ?? DateTime.MinValue,
                laboratoryRequests = patients.LaboratoryRequests,
                prescriptions = patients.Prescriptions,
                referals = patients.Referrals,

            }).ToList();

            return patientDTOs;
        }
        public async Task<DisplayPatientDTO> GetSpecificPatient(int ID)
        {
            DateTime date = new DateTime(2000, 1, 1);
            var compSettings = await _context.CompanySettings.FirstOrDefaultAsync() ?? throw new KeyNotFoundException("Company Settings Not Found!");
            var cardExpireAfter = compSettings.CardExpireAfter;
            var patients = await _context.Patients.
                                                 Where(pp => pp.PatientId == ID)
                                                    .OrderByDescending(c => c.UpdatedAt)
                                                    .Include(p => p.PatientCard)
                                                    .Include(p => p.LaboratoryRequests)
                                                        .ThenInclude(lr => lr.Hematology)
                                                            .ThenInclude(hm => hm.Diff)// Include Hematology
                                                    .Include(p => p.LaboratoryRequests)
                                                        .ThenInclude(lr => lr.Urinalysis)       // Include Urinalysis
                                                    .Include(p => p.LaboratoryRequests)
                                                        .ThenInclude(lr => lr.Serology)         // Include Serology
                                                    .Include(p => p.LaboratoryRequests)
                                                        .ThenInclude(lr => lr.StoolExamination) // Include StoolExamination
                                                    .Include(p => p.LaboratoryRequests)
                                                        .ThenInclude(lr => lr.Microscopy)       // Include Microscopy
                                                    .Include(p => p.LaboratoryRequests)
                                                        .ThenInclude(lr => lr.Chemistry)        // Include Chemistry
                                                    .Include(p => p.LaboratoryRequests)
                                                        .ThenInclude(lr => lr.Bacterology)
                                                            .ThenInclude(br => br.AFB) // Include Bacterology
                                                    .Include(p => p.Prescriptions)              // Include Prescriptions
                                                    .Include(p => p.Referrals)
                                                    .FirstOrDefaultAsync();
            var patientCard = await _context.PatientCards.Where(p => p.PatientID == ID).FirstOrDefaultAsync();
            var boolcheck = false;
            if (patientCard == null)
            {
                boolcheck = true;
            }
            else if (patientCard.CreatedAT < DateTime.Now.AddDays(-cardExpireAfter))
            {
                boolcheck = true;
            }
            var PatientProfile = await _context.patientProfiles
                                                .Where(pp=> pp.Patient_Id == ID)
                                                .FirstOrDefaultAsync();
            
            var procedure = await _context.Procedures.Where(p=> p.ProcedureName == "card" || p.ProcedureName == "Card" || p.ProcedureName == "CARD")
                .FirstOrDefaultAsync(); 


            
            var patientDTO = new DisplayPatientDTO
            {
                PatientId = patients.PatientId,
                PatientFullName = patients.PatientFullName,
                Age = _toolsService.CalculateAge(patients.DateOfBirth ?? DateTime.MinValue) ,
                Phone = patients.Phone,
                Gender = patients.Gender,
                Country = patients.Country,
                City = patients.City,
                Subcity = patients.Subcity,
                Address = patients.Address,
                MedicalHistory = PatientProfile.MedicalHistory,
                Chronics = PatientProfile.Chronics,
                Allergies = PatientProfile.Allergies,
                CreatedAt = patients.CreatedAt,
                UpdateAt = patients.UpdatedAt ?? date,
                CardNeeded = boolcheck,
                Weight = patients.Weight,
                Region = patients.Region,
                Town = patients.Town,
                Woreda  = patients.Woreda,
                Kebele = patients.Kebele,
                HouseNumber = patients.HouseNumber,
                DateOfBirth = patients.DateOfBirth ?? DateTime.MinValue,
                laboratoryRequests = patients.LaboratoryRequests,

            };
            
            return patientDTO;
        }

    }
}
