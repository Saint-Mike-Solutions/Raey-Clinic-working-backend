using DentalClinic.DTOs.Pricing;
using DentalClinic.Models;

namespace DentalClinic.Services.PricingService
{
    public interface IPricingService
    {
        Task<PricingDescription> AddPricingDescription(AddPricingDescriptionDTO pricingDescriptionDTO);
        Task<PricingReason> AddPricingReason(AddPricingReasonDTO pricingReasonDTO);
        Task<PricingDescription> DeletePricingDescription(int id);
        Task<PricingReason> DeletePricingReason(int id);
        Task<List<PricingDescription>> GetPricingDescriptions();
        Task<List<PricingReason>> GetPricingReasonsList();
        Task<PricingDescription> UpdatePricingDescription(UpdatePricingDescriptionDTO DTO);
        Task<PricingReason> UpdatePricingReason(UpdatePricingReasonDTO DTO);
    }
}