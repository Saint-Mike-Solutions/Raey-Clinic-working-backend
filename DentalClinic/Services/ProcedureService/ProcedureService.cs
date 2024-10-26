using AutoMapper;
using DentalClinic.Context;
using DentalClinic.DTOs.ProcedureDTO;
using DentalClinic.DTOs.RoleDTO;
using DentalClinic.Models;
using Microsoft.EntityFrameworkCore;

namespace DentalClinic.Services.ProcedureService
{
    public class ProcedureService : IProcedureService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ProcedureService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Procedure> AddProcedure(AddProcedureDTO procedureDTO)
        {
            var PricingReason = await _context.pricingReasons
            .FirstOrDefaultAsync(pr => pr.PricingReasonName == procedureDTO.pricingReason);
            var PricingDescription = await _context.pricingDescriptions
            .FirstOrDefaultAsync(pd => pd.pricingDescription == procedureDTO.pricingDescription);
            if (PricingDescription == null || PricingReason == null)
            {
                // Handle the case where the role does not exist
                throw new ApplicationException("Pricing not found.");
            }
            Procedure procedure = new Procedure
            {
                ProcedureName = procedureDTO.ProcedureName,
                Price = procedureDTO.Price,
                PricingReasonID = PricingReason.PricingReasonID,
                PricingDescriptionID = PricingDescription.PricingDescriptionId
            };


            //procedure.PricingDescriptionID = PricingDescription.PricingDescriptionId;
            //procedure.PricingReasonID = PricingReason.PricingReasonID;
            //procedure.PricingDescription = PricingDescription;
            //procedure.PricingReason = PricingReason;

            _context.Procedures.Add(procedure);
            await _context.SaveChangesAsync();
            return procedure;

        }
        public async Task<Procedure> UpdateProcedure(UpdateProcedureDTO procedureDTO)
        {
            var procedure = await _context.Procedures
                                    .Where(p=> p.ProcedureID == procedureDTO.ID)
                                    .FirstOrDefaultAsync()?? throw new KeyNotFoundException("Procedure Not Found");
            procedure = _mapper.Map(procedureDTO, procedure);
            procedure.PricingDescription = await _context.pricingDescriptions.FirstOrDefaultAsync(p => p.pricingDescription == procedureDTO.pricingDescriptionUpdate);
            procedure.PricingReason = await _context.pricingReasons.FirstOrDefaultAsync(p => p.PricingReasonName == procedureDTO.pricingReasonUpdate);
            _context.Procedures.Update(procedure);
            await _context.SaveChangesAsync();
            return procedure;
        }
        public async Task<List<Procedure>> GetProcedures()
        {
            var procedures = await _context.Procedures
                .Include(p=>p.PricingReason)
                .Include(p=>p.PricingDescription)
                .ToListAsync();
            return procedures ;
        }

        public async Task<Procedure> DeleteProcedure(string procedureName)
        {
            var procedure = await _context.Procedures
                    .Where(pr => pr.ProcedureName == procedureName)
                    .FirstOrDefaultAsync();

            if (procedure == null) throw new KeyNotFoundException("Procedure Not Found");

            _context.Procedures.Remove(procedure);
            await _context.SaveChangesAsync();

            return procedure;
        }

        //Task<List<Procedure>> IProcedureService.GetProcedures()
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<Role> UpdateProcedure(UpdateRoleDTO roleDTO)
        //{
        //    var role = await _context.Roles
        //            .Where(ro => ro.RoleID == roleDTO.RoleId)
        //            .FirstOrDefaultAsync();
        //    if (role == null) throw new KeyNotFoundException("Role Not Found");
        //    role = _mapper.Map(roleDTO, role);

        //    _context.Roles.Update(role);
        //    await _context.SaveChangesAsync();
        //    return role;

        //}
    }
}
