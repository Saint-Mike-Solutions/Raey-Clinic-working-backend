using DentalClinic.DTOs.AreaSettingDTO;
using DentalClinic.Models;

namespace DentalClinic.Services.AreaSettingService
{
    public interface IAreaSettingService
    {
        Task<List<City>> GetCities();
        Task<List<Country>> GetCountries();
        Task<List<SubCity>> GetSubCities();
        Task<City> RemoveCity(int cityName);
        Task<Country> RemoveCountry(int CN);
        Task<SubCity> RemoveSubCity(int subCityName);
        Task<City> SetCity(AddCityDTO cityDTO);
        Task<Country> SetCountry(AddCountryDTO countryDTO);
        Task<SubCity> SetSubCity(AddSubCityDTO subCityDTO);
        Task<City> UpdateCity(UpdateAreaSettingDTO DTO);
        Task<Country> UpdateCountry(UpdateAreaSettingDTO DTO);
        Task<SubCity> UpdateSubCity(UpdateAreaSettingDTO DTO);
    }
}