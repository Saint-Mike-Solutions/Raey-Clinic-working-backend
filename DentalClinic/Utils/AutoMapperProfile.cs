using AutoMapper;
using DentalClinic.Context;
using DentalClinic.DTOs.AppointmentDTO;
using DentalClinic.DTOs.AreaSettingDTO;
using DentalClinic.DTOs.EmployeeDTO;
using DentalClinic.DTOs.HealthProgressDTO;
using DentalClinic.DTOs.MedicalRecordDTO;
using DentalClinic.DTOs.PatientDTO;
using DentalClinic.DTOs.Pricing;
using DentalClinic.DTOs.ProcedureDTO;
using DentalClinic.DTOs.RoleDTO;
using DentalClinic.DTOs.SettingsDTO;
using DentalClinic.DTOs.SMSSettingDTO;
using DentalClinic.Models;

namespace Secretary_Job_Mgmt.Utils
{
    public class AutoMapperProfile : Profile
    {
        private readonly IMapper _mapper;

        public AutoMapperProfile(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
        }
        public AutoMapperProfile()
        {
            // BLOG POST
            CreateMap<AddEmployeeDTO, Employee>();
            CreateMap<AddRoleDTO, Role>();
            CreateMap<AddPatientDTO, Patient>();
            CreateMap<AddPricingDescriptionDTO, PricingDescription>();
            CreateMap<AddPricingReasonDTO, PricingReason>();
            CreateMap<AddProcedureDTO, Procedure>();
            CreateMap<AddPatientDTO, PatientProfile>  ();
            CreateMap<AddMedicalRecordDTO, MedicalRecord>();
            CreateMap<AddHealthProgressDTO, HealthProgress>();
            CreateMap<AddAppointmentDTO, Appointment>();
            CreateMap<UpdatePatientDTO, Patient>();
            CreateMap<UpdatePatientDTO, PatientProfile>();
            CreateMap<UpdateProcedureDTO, Procedure>();
            CreateMap<UpdateEmployeeDTO, Employee>();
            CreateMap<UpdateAppointmentDTO, Appointment>();
            CreateMap<UpdateRoleDTO, Role>();
            CreateMap<UpdateCompanySettingDTO, CompanySetting>();
            CreateMap<AddCompanySettingsDTO, CompanySetting>();
            CreateMap<AddCountryDTO, Country>();
            CreateMap<UpdatePricingDescriptionDTO, PricingDescription>();
            CreateMap<UpdatePricingReasonDTO, PricingReason>();
            CreateMap<SMSSettingAddDTO, SMSSetting>();
            CreateMap<SMSSettingUpdateDTO, SMSSetting>();
            CreateMap<UpdateMedicalRecordDTO, MedicalRecord>();
            
            //CreateMap<UpdateBlogPostDTO, BlogPost>();

            //// USER
            //CreateMap<AddUserDTOs, User>();
            //CreateMap<UpdateUserDTO, User>();

            //// REVIEW
            //CreateMap<AddReviewDTO,  Review>();
            //CreateMap<UpdateReviewDTO,  Review>();
        }
    }
}
