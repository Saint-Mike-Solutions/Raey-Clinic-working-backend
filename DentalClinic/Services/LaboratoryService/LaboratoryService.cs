using AutoMapper;
using DentalClinic.Context;
using DentalClinic.DTOs.LaboratoryRequestsDTO;
using DentalClinic.DTOs.MedicalCertificateDTO;
using DentalClinic.Models;
using DentalClinic.Services.Tools;
using Microsoft.EntityFrameworkCore;

namespace DentalClinic.Services.LaboratoryService
{
    public class LaboratoryService : ILaboratoryService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IToolsService _toolsService;
        public LaboratoryService(DataContext context, IMapper mapper, IToolsService toolsService)
        {
            _context = context;
            _mapper = mapper;
            _toolsService = toolsService;
        }

        public async Task<Hematology> AddHematology(AddHematologyDTO DTO)
        {
            var dd = new Diff
            {
                N = DTO.HemaN,
                E = DTO.HemaE,
                B = DTO.HemaB,
                L = DTO.HemaL,
                M = DTO.HemaM,
            };

            var Hema = new Hematology
            {
                Wbc = DTO.Wbc,
                Hgb = DTO.Hgb,
                Hct = DTO.Hct,
                Esr = DTO.Esr,
                Platletes = DTO.Platletes,
                BloodFilm = DTO.BloodFilm,
                BloodGroup = DTO.BloodGroup,
                Rh = DTO.Rh,
                Diff = dd // Assign the Diff entity
            };

            Patient? patient = await _context.Patients.FindAsync(DTO.PatientId);
            if (patient == null)
            {
                return null; // Return null if the patient is not found
            }

            Employee? requestedBy = await _context.Employees.FindAsync(DTO.RequestedById);
            if (requestedBy == null)
            {
                return null; // Return null if the requestedBy employee is not found
            }

            Employee? reportedBy = await _context.Employees.FindAsync(DTO.ReportedById); // Correct ID check for ReportedById
            if (reportedBy == null)
            {
                return null; // Return null if the reportedBy employee is not found
            }

            // Retrieve the existing LaboratoryRequest for the patient
            var labreq = await _context.LaboratoryRequests.FirstOrDefaultAsync(x => x.PatientId == DTO.PatientId);

            var labreqlist = await _context.LaboratoryRequestLists.FirstOrDefaultAsync(lr => lr.Id == DTO.LabReqListId);

            labreqlist.Status = "Complete";

            _context.LaboratoryRequestLists.Update(labreqlist);

            if (labreq == null)
            {
                // If no existing laboratory request exists, create a new one
                labreq = new LaboratoryRequests
                {
                    PatientId = DTO.PatientId,
                    Hematology = Hema // Assign Hematology to the new lab request
                };

                _context.LaboratoryRequests.Add(labreq); // Add the new lab request to the context
            }
            else
            {
                // Update the existing lab request
                labreq.Hematology = Hema;
                labreq.ReportedById = DTO.ReportedById;
                labreq.ReportedBy = reportedBy;
                labreq.RequestedBy = requestedBy;
                labreq.RequestedById = DTO.RequestedById;
                labreq.Patient = patient;

                _context.LaboratoryRequests.Update(labreq); // Update the existing lab request in the context
            }

            labreq.isHematology = true;
            await _context.SaveChangesAsync();

            return Hema;
        }



        public async Task<Urinalysis> AddUrinalysis(AddUrinalysisDTO DTO)
        {
            var uri = new Urinalysis
            {
                Color = DTO.Color,
                Appearance = DTO.Appearance,
                Ph = DTO.Ph,
                Sg = DTO.Sg,
                Protein = DTO.Protein,
                Glucose = DTO.Glucose,
                Leukocyte = DTO.Leukocyte,
                Ketone = DTO.Ketone,
                Bilirubin = DTO.Bilirubin,
                Urobilingen = DTO.Urobilingen,
                Blood = DTO.Blood,
            };

            Patient? patient = await _context.Patients.FindAsync(DTO.PatientId);
            if (patient == null)
            {
                return null; // Return null if the patient is not found
            }

            Employee? requestedBy = await _context.Employees.FindAsync(DTO.RequestedById);
            if (requestedBy == null)
            {
                return null; // Return null if the requestedBy employee is not found
            }

            Employee? reportedBy = await _context.Employees.FindAsync(DTO.ReportedById); // Correct ID check for ReportedById
            if (reportedBy == null)
            {
                return null; // Return null if the reportedBy employee is not found
            }

            // Retrieve the existing LaboratoryRequest for the patient
            var labreq = await _context.LaboratoryRequests.FirstOrDefaultAsync(x => x.PatientId == DTO.PatientId);

            var labreqlist = await _context.LaboratoryRequestLists.FirstOrDefaultAsync(lr => lr.Id == DTO.LabReqListId);


            labreqlist.Status = "Complete";

            _context.LaboratoryRequestLists.Update(labreqlist);
            labreq.isUrinalyis = true;
            if (labreq == null)
            {
                // If no existing laboratory request exists, create a new one
                labreq = new LaboratoryRequests
                {
                    PatientId = DTO.PatientId,
                    Urinalysis = uri // Assign Hematology to the new lab request
                };

                _context.LaboratoryRequests.Add(labreq); // Add the new lab request to the context
            }
            else
            {
                // Update the existing lab request
                labreq.Urinalysis = uri;
                labreq.ReportedById = DTO.ReportedById;
                labreq.ReportedBy = reportedBy;
                labreq.RequestedBy = requestedBy;
                labreq.Patient = patient;

                labreq.RequestedById = DTO.RequestedById;
                _context.LaboratoryRequests.Update(labreq); // Update the existing lab request in the context
            }


            await _context.SaveChangesAsync();

            return uri;
        }


        public async Task<Serology> AddSerology(AddSerologyDTO DTO)
        {
            var ser = new Serology
            {
                Vdlr = DTO.Vdlr,
                WidalH = DTO.WidalH,
                WeilFelix = DTO.WeilFelix,
                HbsAg = DTO.HbsAg,
                HcvAb = DTO.HcvAb,
                Aso = DTO.Aso,
                Rf = DTO.Rf,
                HPyloryAb = DTO.HPyloryAb,
                HPyloryAg = DTO.HPyloryAg,
            };

            Patient? patient = await _context.Patients.FindAsync(DTO.PatientId);
            if (patient == null)
            {
                return null; // Return null if the patient is not found
            }

            Employee? requestedBy = await _context.Employees.FindAsync(DTO.RequestedById);
            if (requestedBy == null)
            {
                return null; // Return null if the requestedBy employee is not found
            }

            Employee? reportedBy = await _context.Employees.FindAsync(DTO.ReportedById); // Correct ID check for ReportedById
            if (reportedBy == null)
            {
                return null; // Return null if the reportedBy employee is not found
            }

            // Retrieve the existing LaboratoryRequest for the patient
            var labreq = await _context.LaboratoryRequests.FirstOrDefaultAsync(x => x.PatientId == DTO.PatientId);

            var labreqlist = await _context.LaboratoryRequestLists.FirstOrDefaultAsync(lr => lr.Id == DTO.LabReqListId);


            labreqlist.Status = "Complete";
            labreq.isSerology = true;
            _context.LaboratoryRequestLists.Update(labreqlist);
            if (labreq == null)
            {
                // If no existing laboratory request exists, create a new one
                labreq = new LaboratoryRequests
                {
                    PatientId = DTO.PatientId,
                    Serology = ser // Assign Hematology to the new lab request
                };

                _context.LaboratoryRequests.Add(labreq); // Add the new lab request to the context
            }
            else
            {
                // Update the existing lab request
                labreq.Serology = ser;
                labreq.ReportedById = DTO.ReportedById;
                labreq.ReportedBy = reportedBy;
                labreq.RequestedBy = requestedBy;
                labreq.RequestedById = DTO.RequestedById;
                labreq.Patient = patient;

                _context.LaboratoryRequests.Update(labreq); // Update the existing lab request in the context
            }

            await _context.SaveChangesAsync();

            return ser;
        }


        public async Task<StoolExamination> AddStoolExamination(AddStoolExaminationDTO DTO)
        {
            var stool = new StoolExamination
            {
                Consistency = DTO.Consistency,
                OP = DTO.OP,
                Concentration = DTO.Concentration,
                OccultBlood = DTO.OccultBlood,
            };

            Patient? patient = await _context.Patients.FindAsync(DTO.PatientId);
            if (patient == null)
            {
                return null; // Return null if the patient is not found
            }

            Employee? requestedBy = await _context.Employees.FindAsync(DTO.RequestedById);
            if (requestedBy == null)
            {
                return null; // Return null if the requestedBy employee is not found
            }

            Employee? reportedBy = await _context.Employees.FindAsync(DTO.ReportedById); // Correct ID check for ReportedById
            if (reportedBy == null)
            {
                return null; // Return null if the reportedBy employee is not found
            }

            // Retrieve the existing LaboratoryRequest for the patient
            var labreq = await _context.LaboratoryRequests.FirstOrDefaultAsync(x => x.PatientId == DTO.PatientId);
            var labreqlist = await _context.LaboratoryRequestLists.FirstOrDefaultAsync(lr => lr.Id == DTO.LabReqListId);


            labreqlist.Status = "Complete";
            labreq.isStoolExamination = true;
            _context.LaboratoryRequestLists.Update(labreqlist);
            if (labreq == null)
            {
                // If no existing laboratory request exists, create a new one
                labreq = new LaboratoryRequests
                {
                    PatientId = DTO.PatientId,
                    StoolExamination = stool // Assign Hematology to the new lab request
                };

                _context.LaboratoryRequests.Add(labreq); // Add the new lab request to the context
            }
            else
            {
                // Update the existing lab request
                labreq.StoolExamination = stool;
                labreq.ReportedById = DTO.ReportedById;
                labreq.ReportedBy = reportedBy;
                labreq.RequestedBy = requestedBy;
                labreq.RequestedById = DTO.RequestedById;
                labreq.Patient = patient;

                _context.LaboratoryRequests.Update(labreq); // Update the existing lab request in the context
            }

            await _context.SaveChangesAsync();

            return stool;
        }


        public async Task<Microscopy> AddMicroscopy(AddMicroscopyDTO DTO)
        {
            var micro = new Microscopy
            {
                EpitCells = DTO.EpitCells,
                Wbc = DTO.MWbc,
                Rbc = DTO.Rbc,
                casts = DTO.casts,
                crystals = DTO.crystals,
                Bacteria = DTO.Bacteria,
                Hcg = DTO.Hcg,
            };

            Patient? patient = await _context.Patients.FindAsync(DTO.PatientId);
            if (patient == null)
            {
                return null; // Return null if the patient is not found
            }

            Employee? requestedBy = await _context.Employees.FindAsync(DTO.RequestedById);
            if (requestedBy == null)
            {
                return null; // Return null if the requestedBy employee is not found
            }

            Employee? reportedBy = await _context.Employees.FindAsync(DTO.ReportedById); // Correct ID check for ReportedById
            if (reportedBy == null)
            {
                return null; // Return null if the reportedBy employee is not found
            }

            // Retrieve the existing LaboratoryRequest for the patient
            var labreq = await _context.LaboratoryRequests.FirstOrDefaultAsync(x => x.PatientId == DTO.PatientId);
            var labreqlist = await _context.LaboratoryRequestLists.FirstOrDefaultAsync(lr => lr.Id == DTO.LabReqListId);

            labreq.isMicroscopy = true;
            labreqlist.Status = "Complete";

            _context.LaboratoryRequestLists.Update(labreqlist);
            if (labreq == null)
            {
                // If no existing laboratory request exists, create a new one
                labreq = new LaboratoryRequests
                {
                    PatientId = DTO.PatientId,
                    Microscopy = micro // Assign Hematology to the new lab request
                };

                _context.LaboratoryRequests.Add(labreq); // Add the new lab request to the context
            }
            else
            {
                // Update the existing lab request
                labreq.Microscopy = micro;
                labreq.ReportedById = DTO.ReportedById;
                labreq.ReportedBy = reportedBy;
                labreq.Patient = patient;

                labreq.RequestedBy = requestedBy;
                labreq.RequestedById = DTO.RequestedById;
                _context.LaboratoryRequests.Update(labreq); // Update the existing lab request in the context
            }

            await _context.SaveChangesAsync();

            return micro;
        }


        public async Task<Chemistry> AddChemistry(AddChemistryDTO DTO)
        {
            var chemistry = new Chemistry
            {
                FbsRbs = DTO.FbsRbs,
                Sgot = DTO.Sgot,
                Sgpt = DTO.Sgpt,
                AlkalinePhosphates = DTO.AlkalinePhosphates,
                BilirubinDirect = DTO.BilirubinDirect,
                BilirubinTotal = DTO.BilirubinTotal,
                Urea = DTO.Urea,
                Bun = DTO.Bun,
                Creatine = DTO.Creatine,
                UricAcid = DTO.UricAcid,
                TotalAcid = DTO.TotalAcid,
                TotalProtein = DTO.TotalProtein,
                Triglycerides = DTO.Triglycerides,
                cholesterol = DTO.cholesterol,
                Hdl = DTO.Hdl,
                Ldl = DTO.Ldl,
            };
            Patient? patient = await _context.Patients.FindAsync(DTO.PatientId);
            if (patient == null)
            {
                return null; // Return null if the patient is not found
            }

            Employee? requestedBy = await _context.Employees.FindAsync(DTO.RequestedById);
            if (requestedBy == null)
            {
                return null; // Return null if the requestedBy employee is not found
            }

            Employee? reportedBy = await _context.Employees.FindAsync(DTO.ReportedById); // Correct ID check for ReportedById
            if (reportedBy == null)
            {
                return null; // Return null if the reportedBy employee is not found
            }

            // Retrieve the existing LaboratoryRequest for the patient
            var labreq = await _context.LaboratoryRequests.FirstOrDefaultAsync(x => x.PatientId == DTO.PatientId);
            var labreqlist = await _context.LaboratoryRequestLists.FirstOrDefaultAsync(lr => lr.Id == DTO.LabReqListId);
            labreq.isChemistry = true;

            labreqlist.Status = "Complete";

            _context.LaboratoryRequestLists.Update(labreqlist);
            if (labreq == null)
            {
                // If no existing laboratory request exists, create a new one
                labreq = new LaboratoryRequests
                {
                    PatientId = DTO.PatientId,
                    Chemistry = chemistry // Assign Hematology to the new lab request
                };

                _context.LaboratoryRequests.Add(labreq); // Add the new lab request to the context
            }
            else
            {
                // Update the existing lab request
                labreq.Chemistry = chemistry;
                labreq.Patient = patient;

                labreq.ReportedById = DTO.ReportedById;
                labreq.ReportedBy = reportedBy;
                labreq.RequestedBy = requestedBy;
                labreq.RequestedById = DTO.RequestedById;
                _context.LaboratoryRequests.Update(labreq); // Update the existing lab request in the context
            }

            await _context.SaveChangesAsync();

            return chemistry;
        }


        public async Task<Bacterology> AddBacterology(AddBacterologyDTO DTO)
        {
            var bact = new Bacterology
            {
                
                Sample = DTO.Sample,
                Koh = DTO.Koh,
                GramStain = DTO.GramStain,
                WetFilm = DTO.WetFilm,
                Culture = DTO.Culture,
                AFB = new AFB
                {
                    One = DTO.AFBOne,
                    Two = DTO.AFBTwo,
                    Three = DTO.AFBThree
                }
                
            };
            Patient? patient = await _context.Patients.FindAsync(DTO.PatientId);
            if (patient == null)
            {
                return null; // Return null if the patient is not found
            }

            Employee? requestedBy = await _context.Employees.FindAsync(DTO.RequestedById);
            if (requestedBy == null)
            {
                return null; // Return null if the requestedBy employee is not found
            }

            Employee? reportedBy = await _context.Employees.FindAsync(DTO.ReportedById); // Correct ID check for ReportedById
            if (reportedBy == null)
            {
                return null; // Return null if the reportedBy employee is not found
            }

            // Retrieve the existing LaboratoryRequest for the patient
            var labreq = await _context.LaboratoryRequests.FirstOrDefaultAsync(x => x.PatientId == DTO.PatientId);
            var labreqlist = await _context.LaboratoryRequestLists.FirstOrDefaultAsync(lr => lr.Id == DTO.LabReqListId);
            labreq.isBacterology = true;

            labreqlist.Status = "Complete";

            _context.LaboratoryRequestLists.Update(labreqlist);
            if (labreq == null)
            {
                // If no existing laboratory request exists, create a new one
                labreq = new LaboratoryRequests
                {
                    PatientId = DTO.PatientId,
                    Bacterology = bact // Assign Hematology to the new lab request
                };

                _context.LaboratoryRequests.Add(labreq); // Add the new lab request to the context
            }
            else
            {
                // Update the existing lab request
                labreq.Bacterology = bact;
                labreq.PatientId = DTO.PatientId;
                labreq.Patient = patient;
                labreq.ReportedById = DTO.ReportedById;
                labreq.ReportedBy = reportedBy;
                labreq.RequestedBy = requestedBy;
                labreq.RequestedById = DTO.RequestedById;

                _context.LaboratoryRequests.Update(labreq); // Update the existing lab request in the context
            }

            await _context.SaveChangesAsync();

            return bact;
        }

        public async Task<LaboratoryRequests?> CreateLaboratoryRequests(AddLaboratoryRequestsDTO DTO)
        {
            // Build entities based on DTO values
            var dd = new Diff
            {
                N = DTO.HemaN,
                E = DTO.HemaE,
                B = DTO.HemaB,
                L = DTO.HemaL,
                M = DTO.HemaM,
            };

            var Hema = new Hematology
            {
                Wbc = DTO.Wbc,
                Hgb = DTO.Hgb,
                Hct = DTO.Hct,
                Esr = DTO.Esr,
                Platletes = DTO.Platletes,
                BloodFilm = DTO.BloodFilm,
                BloodGroup = DTO.BloodGroup,
                Rh = DTO.Rh,
                Diff = dd // Assign the Diff entity
            };

            var uri = new Urinalysis
            {
                Color = DTO.Color,
                Appearance = DTO.Appearance,
                Ph = DTO.Ph,
                Sg = DTO.Sg,
                Protein = DTO.Protein,
                Glucose = DTO.Glucose,
                Leukocyte = DTO.Leukocyte,
                Ketone = DTO.Ketone,
                Bilirubin = DTO.Bilirubin,
                Urobilingen = DTO.Urobilingen,
                Blood = DTO.Blood,
            };

            var ser = new Serology
            {
                Vdlr = DTO.Vdlr,
                WidalH = DTO.WidalH,
                WeilFelix = DTO.WeilFelix,
                HbsAg = DTO.HbsAg,
                HcvAb = DTO.HcvAb,
                Aso = DTO.Aso,
                Rf = DTO.Rf,
                HPyloryAb = DTO.HPyloryAb,
                HPyloryAg = DTO.HPyloryAg,
            };

            var stool = new StoolExamination
            {
                Consistency = DTO.Consistency,
                OP = DTO.OP,
                Concentration = DTO.Concentration,
                OccultBlood = DTO.OccultBlood,
            };

            var micro = new Microscopy
            {
                EpitCells = DTO.EpitCells,
                Wbc = DTO.MWbc,
                Rbc = DTO.Rbc,
                casts = DTO.casts,
                crystals = DTO.crystals,
                Bacteria = DTO.Bacteria,
                Hcg = DTO.Hcg,
            };

            var chemistry = new Chemistry
            {
                FbsRbs = DTO.FbsRbs,
                Sgot = DTO.Sgot,
                Sgpt = DTO.Sgpt,
                AlkalinePhosphates = DTO.AlkalinePhosphates,
                BilirubinDirect = DTO.BilirubinDirect,
                BilirubinTotal = DTO.BilirubinTotal,
                Urea = DTO.Urea,
                Bun = DTO.Bun,
                Creatine = DTO.Creatine,
                UricAcid = DTO.UricAcid,
                TotalAcid = DTO.TotalAcid,
                TotalProtein = DTO.TotalProtein,
                Triglycerides = DTO.Triglycerides,
                cholesterol = DTO.cholesterol,
                Hdl = DTO.Hdl,
                Ldl = DTO.Ldl,
            };

            var bact = new Bacterology
            {
                Sample = DTO.Sample,
                Koh = DTO.Koh,
                GramStain = DTO.GramStain,
                WetFilm = DTO.WetFilm,
                Culture = DTO.Culture,
                AFB = new AFB
                {
                    One = DTO.AFBOne,
                    Two = DTO.AFBTwo,
                    Three = DTO.AFBThree
                }
            };

            // Null checks for related entities
            Patient? patient = await _context.Patients.FindAsync(DTO.PatientId);
            if (patient == null)
            {
                return null; // Return null if the patient is not found
            }

            Employee? requestedBy = await _context.Employees.FindAsync(DTO.RequestedById);
            if (requestedBy == null)
            {
                return null; // Return null if the requestedBy employee is not found
            }

            Employee? reportedBy = await _context.Employees.FindAsync(DTO.ReportedById); // Correct ID check for ReportedById
            if (reportedBy == null)
            {
                return null; // Return null if the reportedBy employee is not found
            }

            // Create LaboratoryRequest entity
            var lab = new LaboratoryRequests
            {
                ReportedBy = reportedBy,
                RequestedBy = requestedBy,
                Patient = patient,
                Bacterology = bact,
                Chemistry = chemistry,
                Microscopy = micro,
                Hematology = Hema,
                Serology = ser,
                Urinalysis = uri,
                StoolExamination = stool,
            };

            // Add and save
            _context.LaboratoryRequests.Add(lab);
            await _context.SaveChangesAsync();

            return lab; // Return the created entity
        }

        public async Task<LaboratoryRequests?> UpdateLabReport(UpdateLaboratoryRequestDTO DTO)
        {
            // Fetch the laboratory request by the given ID
            LaboratoryRequests? req = await _context.LaboratoryRequests.FindAsync(DTO.LabReportId);

            // Check if the request exists
            if (req == null)
            {
                return null; // Return null if not found
            }

            // Update Hematology data

            // Check and update Hematology properties
            if (!string.IsNullOrEmpty(DTO.Wbc))
            {
                if (req.Hematology == null)
                {
                    req.Hematology = new Hematology();
                }
                req.Hematology.Wbc = DTO.Wbc;
            }

            // Ensure Hematology is initialized once
            if (req.Hematology.Diff == null)
            {
                req.Hematology.Diff = new Diff();

            }

            // Update Hematology Diff properties
            if (!string.IsNullOrEmpty(DTO.HemaN))
            {
                req.Hematology.Diff.N = DTO.HemaN;
            }

            if (!string.IsNullOrEmpty(DTO.HemaE))
            {
                req.Hematology.Diff.E = DTO.HemaE;
            }

            if (!string.IsNullOrEmpty(DTO.HemaB))
            {
                req.Hematology.Diff.B = DTO.HemaB;
            }

            if (!string.IsNullOrEmpty(DTO.HemaL))
            {
                req.Hematology.Diff.L = DTO.HemaL;
            }

            if (!string.IsNullOrEmpty(DTO.HemaM))
            {
                req.Hematology.Diff.M = DTO.HemaM;
            }


            if (!string.IsNullOrEmpty(DTO.Hgb))
            {
                if (req.Hematology == null)
                {
                    req.Hematology = new Hematology();
                }
                req.Hematology.Hgb = DTO.Hgb;
            }

            if (!string.IsNullOrEmpty(DTO.Hct))
            {
                if (req.Hematology == null)
                {
                    req.Hematology = new Hematology();
                }
                req.Hematology.Hct = DTO.Hct;
            }

            if (!string.IsNullOrEmpty(DTO.Esr))
            {
                if (req.Hematology == null)
                {
                    req.Hematology = new Hematology();
                }
                req.Hematology.Esr = DTO.Esr;
            }

            if (!string.IsNullOrEmpty(DTO.Platletes))
            {
                if (req.Hematology == null)
                {
                    req.Hematology = new Hematology();
                }
                req.Hematology.Platletes = DTO.Platletes;
            }

            if (!string.IsNullOrEmpty(DTO.BloodGroup))
            {
                if (req.Hematology == null)
                {
                    req.Hematology = new Hematology();
                }
                req.Hematology.BloodGroup = DTO.BloodGroup;
            }

            if (!string.IsNullOrEmpty(DTO.Rh))
            {
                if (req.Hematology == null)
                {
                    req.Hematology = new Hematology();
                }
                req.Hematology.Rh = DTO.Rh;
            }

            if (!string.IsNullOrEmpty(DTO.BloodFilm))
            {
                if (req.Hematology == null)
                {
                    req.Hematology = new Hematology();
                }
                req.Hematology.BloodFilm = DTO.BloodFilm;
            }

            // Update Urinalysis data
            // Check and update Urinalysis properties
            if (req.Urinalysis == null)
            {
                req.Urinalysis = new Urinalysis();
            }

            if (!string.IsNullOrEmpty(DTO.Color)) req.Urinalysis.Color = DTO.Color;
            if (!string.IsNullOrEmpty(DTO.Appearance)) req.Urinalysis.Appearance = DTO.Appearance;
            if (!string.IsNullOrEmpty(DTO.Ph)) req.Urinalysis.Ph = DTO.Ph;
            if (!string.IsNullOrEmpty(DTO.Sg)) req.Urinalysis.Sg = DTO.Sg;
            if (!string.IsNullOrEmpty(DTO.Protein)) req.Urinalysis.Protein = DTO.Protein;
            if (!string.IsNullOrEmpty(DTO.Glucose)) req.Urinalysis.Glucose = DTO.Glucose;
            if (!string.IsNullOrEmpty(DTO.Leukocyte)) req.Urinalysis.Leukocyte = DTO.Leukocyte;
            if (!string.IsNullOrEmpty(DTO.Ketone)) req.Urinalysis.Ketone = DTO.Ketone;
            if (!string.IsNullOrEmpty(DTO.Bilirubin)) req.Urinalysis.Bilirubin = DTO.Bilirubin;
            if (!string.IsNullOrEmpty(DTO.Urobilingen)) req.Urinalysis.Urobilingen = DTO.Urobilingen;
            if (!string.IsNullOrEmpty(DTO.Blood)) req.Urinalysis.Blood = DTO.Blood;

            if (req.Serology == null)
            {
                req.Serology = new Serology();
            }
            // Update Serology data
            if (!string.IsNullOrEmpty(DTO.Vdlr)) req.Serology.Vdlr = DTO.Vdlr;
            if (!string.IsNullOrEmpty(DTO.WidalH)) req.Serology.WidalH = DTO.WidalH;
            if (!string.IsNullOrEmpty(DTO.WeilFelix)) req.Serology.WeilFelix = DTO.WeilFelix;
            if (!string.IsNullOrEmpty(DTO.HbsAg)) req.Serology.HbsAg = DTO.HbsAg;
            if (!string.IsNullOrEmpty(DTO.HcvAb)) req.Serology.HcvAb = DTO.HcvAb;
            if (!string.IsNullOrEmpty(DTO.Aso)) req.Serology.Aso = DTO.Aso;
            if (!string.IsNullOrEmpty(DTO.Rf)) req.Serology.Rf = DTO.Rf;
            if (!string.IsNullOrEmpty(DTO.HPyloryAb)) req.Serology.HPyloryAb = DTO.HPyloryAb;
            if (!string.IsNullOrEmpty(DTO.HPyloryAg)) req.Serology.HPyloryAg = DTO.HPyloryAg;

            // Update Stool Examination data

            if (req.StoolExamination == null)
            {
                req.StoolExamination = new StoolExamination();
            }
            if (!string.IsNullOrEmpty(DTO.Consistency)) req.StoolExamination.Consistency = DTO.Consistency;
            if (!string.IsNullOrEmpty(DTO.OP)) req.StoolExamination.OP = DTO.OP;
            if (!string.IsNullOrEmpty(DTO.Concentration)) req.StoolExamination.Concentration = DTO.Concentration;
            if (!string.IsNullOrEmpty(DTO.OccultBlood)) req.StoolExamination.OccultBlood = DTO.OccultBlood;

            // Update Chemistry data

            if (req.Chemistry == null)
            {
                req.Chemistry = new Chemistry();
            }
            if (!string.IsNullOrEmpty(DTO.FbsRbs)) req.Chemistry.FbsRbs = DTO.FbsRbs;
            if (!string.IsNullOrEmpty(DTO.Sgot)) req.Chemistry.Sgot = DTO.Sgot;
            if (!string.IsNullOrEmpty(DTO.Sgpt)) req.Chemistry.Sgpt = DTO.Sgpt;
            if (!string.IsNullOrEmpty(DTO.AlkalinePhosphates)) req.Chemistry.AlkalinePhosphates = DTO.AlkalinePhosphates;
            if (!string.IsNullOrEmpty(DTO.BilirubinTotal)) req.Chemistry.BilirubinTotal = DTO.BilirubinTotal;
            if (!string.IsNullOrEmpty(DTO.BilirubinDirect)) req.Chemistry.BilirubinDirect = DTO.BilirubinDirect;
            if (!string.IsNullOrEmpty(DTO.Urea)) req.Chemistry.Urea = DTO.Urea;
            if (!string.IsNullOrEmpty(DTO.Bun)) req.Chemistry.Bun = DTO.Bun;
            if (!string.IsNullOrEmpty(DTO.Creatine)) req.Chemistry.Creatine = DTO.Creatine;
            if (!string.IsNullOrEmpty(DTO.UricAcid)) req.Chemistry.UricAcid = DTO.UricAcid;
            if (!string.IsNullOrEmpty(DTO.TotalAcid)) req.Chemistry.TotalAcid = DTO.TotalAcid;
            if (!string.IsNullOrEmpty(DTO.TotalProtein)) req.Chemistry.TotalProtein = DTO.TotalProtein;
            if (!string.IsNullOrEmpty(DTO.Triglycerides)) req.Chemistry.Triglycerides = DTO.Triglycerides;
            if (!string.IsNullOrEmpty(DTO.cholesterol)) req.Chemistry.cholesterol = DTO.cholesterol;
            if (!string.IsNullOrEmpty(DTO.Hdl)) req.Chemistry.Hdl = DTO.Hdl;
            if (!string.IsNullOrEmpty(DTO.Ldl)) req.Chemistry.Ldl = DTO.Ldl;

            // Update Microscopy data
            if (req.Microscopy == null)
            {
                req.Microscopy = new Microscopy();
            }
            if (!string.IsNullOrEmpty(DTO.EpitCells)) req.Microscopy.EpitCells = DTO.EpitCells;
            if (!string.IsNullOrEmpty(DTO.MWbc)) req.Microscopy.Wbc = DTO.MWbc;
            if (!string.IsNullOrEmpty(DTO.Rbc)) req.Microscopy.Rbc = DTO.Rbc;
            if (!string.IsNullOrEmpty(DTO.casts)) req.Microscopy.casts = DTO.casts;
            if (!string.IsNullOrEmpty(DTO.crystals)) req.Microscopy.crystals = DTO.crystals;
            if (!string.IsNullOrEmpty(DTO.Bacteria)) req.Microscopy.Bacteria = DTO.Bacteria;
            if (!string.IsNullOrEmpty(DTO.Hcg)) req.Microscopy.Hcg = DTO.Hcg;

            // Update Bacterology data
            if (req.Bacterology == null)
            {
                req.Bacterology = new Bacterology();
            }
            if (!string.IsNullOrEmpty(DTO.Sample)) req.Bacterology.Sample = DTO.Sample;
            if (!string.IsNullOrEmpty(DTO.Koh)) req.Bacterology.Koh = DTO.Koh;
            if (!string.IsNullOrEmpty(DTO.GramStain)) req.Bacterology.GramStain = DTO.GramStain;
            if (!string.IsNullOrEmpty(DTO.WetFilm)) req.Bacterology.WetFilm = DTO.WetFilm;
            if (!string.IsNullOrEmpty(DTO.Culture)) req.Bacterology.Culture = DTO.Culture;

            // Update AFB data (nested inside Bacterology)
            if (req.Bacterology.AFB != null && DTO.AFB != null)
            {
                if (!string.IsNullOrEmpty(DTO.AFBOne)) req.Bacterology.AFB.One = DTO.AFBOne;
                if (!string.IsNullOrEmpty(DTO.AFBTwo)) req.Bacterology.AFB.Two = DTO.AFBTwo;
                if (!string.IsNullOrEmpty(DTO.AFBThree)) req.Bacterology.AFB.Three = DTO.AFBThree;
            }

            // Save the changes to the LaboratoryRequests
            _context.LaboratoryRequests.Update(req);

            return req;
        }

        public async Task<List<LaboratoryRequests>> GetLaboratoryReportedBy(int employeeId)
        {
            var labReport = await _context.LaboratoryRequests
                .Include(mc => mc.Bacterology)
                    .ThenInclude(bc => bc.AFB)
                .Include(mc => mc.Microscopy)
                .Include(mc => mc.Urinalysis)
                .Include(mc => mc.Chemistry)
                .Include(mc => mc.Hematology)
                    .ThenInclude(hm => hm.Diff)
                .Include(mc => mc.Bacterology)
                .Include(mc => mc.Serology)
                .Include(mc => mc.StoolExamination)




                .Include(mc => mc.RequestedBy)
                .Include(mc => mc.ReportedBy)
                .Include(p => p.Patient)
                .Where(mc => mc.ReportedBy != null && mc.ReportedBy.EmployeeId == employeeId)
                .ToListAsync();

            return labReport;
        }

        public async Task<List<LaboratoryRequests>> GetLaboratoryRequestedBy(int employeeId)
        {
            var labReport = await _context.LaboratoryRequests
                .Include(mc => mc.Bacterology)
                    .ThenInclude(bc => bc.AFB)
                .Include(mc => mc.Microscopy)
                .Include(mc => mc.Urinalysis)
                .Include(mc => mc.Chemistry)
                .Include(mc => mc.Hematology)
                    .ThenInclude(hm => hm.Diff)
                .Include(mc => mc.Bacterology)
                .Include(mc => mc.Serology)
                .Include(mc => mc.StoolExamination)

                .Include(mc => mc.RequestedBy)
                .Include(mc => mc.ReportedBy)
                .Include(p => p.Patient)
                .Where(mc => mc.RequestedBy != null && mc.RequestedBy.EmployeeId == employeeId)
                .ToListAsync();

            return labReport;
        }

        public async Task<List<LaboratoryRequests>> GetPatientLabReports(int patientID)
        {
            var labReport = await _context.LaboratoryRequests
                .Include(mc => mc.Bacterology)
                    .ThenInclude(bc => bc.AFB)
                .Include(mc => mc.Microscopy)
                .Include(mc => mc.Urinalysis)
                .Include(mc => mc.Chemistry)
                .Include(mc => mc.Hematology)
                    .ThenInclude(hm => hm.Diff)
                .Include(mc => mc.Bacterology)
                .Include(mc => mc.Serology)
                .Include(mc => mc.StoolExamination)
                .Include(mc => mc.RequestedBy)
                .Include(mc => mc.ReportedBy)
                .Include(p => p.Patient)
                .Where(mc => mc.RequestedBy != null && mc.Patient.PatientId == patientID)
                .ToListAsync();

            return labReport;
        }


        public async Task<List<LaboratoryRequests>> GetLaboratoryRequests()
        {
            return await _context.LaboratoryRequests
                .Include(mc => mc.Bacterology)
                    .ThenInclude(bc => bc.AFB)
                .Include(mc => mc.Microscopy)
                .Include(mc => mc.Urinalysis)
                .Include(mc => mc.Chemistry)
                .Include(mc => mc.Hematology)
                    .ThenInclude(hm => hm.Diff)
                .Include(mc => mc.Bacterology)
                .Include(mc => mc.Serology)
                .Include(mc => mc.StoolExamination)
                .Include(p => p.ReportedBy)
                .Include(p => p.Patient)
                .Include(p => p.RequestedBy)
                .ToListAsync();  // Return List<LaboratoryRequests>
        }

        public async Task<LaboratoryRequests> GetSpecificLabRequest(int id)
        {
            return await _context.LaboratoryRequests
                .Include(mc => mc.Bacterology)
                    .ThenInclude(bc => bc.AFB)
                .Include(mc => mc.Microscopy)
                .Include(mc => mc.Urinalysis)
                .Include(mc => mc.Chemistry)
                .Include(mc => mc.Hematology)
                    .ThenInclude(hm => hm.Diff)
                .Include(mc => mc.Bacterology)
                .Include(mc => mc.Serology)
                .Include(mc => mc.StoolExamination)
                .Include(p => p.ReportedBy)
                .Include(p => p.Patient)
                .Include(p => p.RequestedBy)
                .FirstOrDefaultAsync(p => p.Id == id);

        }

        public async Task<bool> DeleteLabRequest(int id)
        {
            var med = await _context.LaboratoryRequests.FindAsync(id);
            if (med == null)
            {
                return false; // Prescription not found
            }

            _context.LaboratoryRequests.Remove(med);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
