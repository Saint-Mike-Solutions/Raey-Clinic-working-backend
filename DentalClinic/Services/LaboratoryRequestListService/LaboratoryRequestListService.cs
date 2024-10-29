using AutoMapper;
using DentalClinic.Context;
using DentalClinic.DTOs.LaboratoryRequestListDTO;
using DentalClinic.Models;
using Microsoft.EntityFrameworkCore;

namespace DentalClinic.Services.LaboratoryRequestListService
{
    public class LaboratoryRequestListService : ILaboratoryRequestListService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public LaboratoryRequestListService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<LaboratoryRequestList> AddLaboratoryRequestList(AddLaboratoryRequestListDTO DTO)
        {

            var patient = await _context.Patients.Where(p => p.PatientId == DTO.PatientId).FirstOrDefaultAsync();
            //int id = patient.LaboratoryRequests.Id;
            //var labReq = await _context.LaboratoryRequests.Where(lr => lr.Id == id).FirstOrDefaultAsync();
            var Requester = await _context.Employees.Where(e => e.EmployeeId == DTO.EmployeeId).FirstOrDefaultAsync();
            LaboratoryRequestList lab = new LaboratoryRequestList
            {
                Hematology = DTO.Hematology,
                Serology = DTO.Serology,
                Microscopy = DTO.Microscopy,

                Bacterology = DTO.Bacterology,
                Urinalysis = DTO.Urinalysis,
                Chemistry = DTO.Chemistry,
                StoolExamination = DTO.StoolExamination,
                Status = DTO.Status,
                PatientId = DTO.PatientId,
                EmployeeId = DTO.EmployeeId,
            };

            //lab.labratoryRequest = labReq;
            //lab.laboratoryrequestId = id;

            lab.Requester = Requester;
            lab.Patient = patient;

            await _context.LaboratoryRequestLists.AddAsync(lab);
            await _context.SaveChangesAsync();



            return lab;

        }

        public async Task<LaboratoryRequestList> UpdateLabRequestList(UpdateLaboratoryRequestListDTO DTO)
        {

            var lab = await _context.LaboratoryRequestLists.Where(l => l.Id == DTO.id).FirstOrDefaultAsync();
            var patient = await _context.Patients.Where(p => p.PatientId == DTO.PatientId).FirstOrDefaultAsync();
            var Requester = await _context.Employees.Where(e => e.EmployeeId == DTO.EmployeeId).FirstOrDefaultAsync();

            lab.Status = DTO.Status;
            lab.Hematology = DTO.Hematology;
            lab.Serology = DTO.Serology;
            lab.Microscopy = DTO.Microscopy;
            lab.Urinalysis = DTO.Urinalysis;
            lab.Bacterology = DTO.Bacterology;
            lab.StoolExamination = DTO.StoolExamination;
            lab.Chemistry = DTO.Chemistry;
            lab.Patient = patient;
            lab.Requester = Requester;

            _context.LaboratoryRequestLists.Update(lab);
            await _context.SaveChangesAsync();
            return lab;
        }

        public async Task<LaboratoryRequestList> DeleteLabRequestList(int id)
        {

            var lab = await _context.LaboratoryRequestLists.Where(l => l.Id == id).FirstOrDefaultAsync();
            if (lab == null)
            {
                return null;
            }

            _context.LaboratoryRequestLists.Remove(lab);
            await _context.SaveChangesAsync();

            return lab;
        }


        public async Task<List<LaboratoryRequestList>> GetAllLaboratoryRequestLists()
        {

            var lab = await _context.LaboratoryRequestLists
                .Include(l => l.Patient)
                .Include(l => l.Requester)
                .ToListAsync();
            if (lab == null)
            {
                return null;
            }

            return lab;


        }

        public async Task<LaboratoryRequestList> GetLabReqListById(int id)
        {
            var lab = await _context.LaboratoryRequestLists.Where(l => l.Id == id)
                .Include(l => l.Patient)
                .Include(l => l.Requester)
                .FirstOrDefaultAsync();
            return lab;
        }

    }
}
