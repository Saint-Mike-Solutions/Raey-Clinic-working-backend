using DentalClinic.DTOs.MobileBankingDTO;
using DentalClinic.Models;

namespace DentalClinic.Services.MobileBankingService
{
    public interface IMobileBankingService
    {
        Task<MobileBanking> AddMobileBanking(AddMobileBankingDTO DTO);
        Task<List<MobileBanking>> GetAllMobileBankings();
        Task<MobileBanking> RemoveMobileBanking(RemoveMobileBankingDTO DTO);
        Task<MobileBanking> UpdateMobileBanking(UpdateMobileBankingDTO DTO);
    }
}