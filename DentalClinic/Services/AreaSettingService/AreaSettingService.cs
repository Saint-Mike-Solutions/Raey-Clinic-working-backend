using AutoMapper;
using DentalClinic.Context;
using DentalClinic.DTOs.AreaSettingDTO;
using DentalClinic.Models;
using Microsoft.EntityFrameworkCore;

namespace DentalClinic.Services.AreaSettingService
{
    public class AreaSettingService : IAreaSettingService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public AreaSettingService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Country> SetCountry(AddCountryDTO countryDTO)
        {
            var country = new Country
            {
                CountryName = countryDTO.Country
            };
            await _context.Countries.AddAsync(country);
            await _context.SaveChangesAsync();
            return country;
        }
        public async Task<Country> RemoveCountry(int CN)
        {
            var country = await _context.Countries
                                        .Where(c => c.CountryID == CN)
                                        .FirstOrDefaultAsync() ?? throw new KeyNotFoundException("Country Not Found!");
            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();
            return country;
        }
        public async Task<List<Country>> GetCountries()
        {
            var LiofCountries = await _context.Countries
                                        .OrderByDescending(c => c.CountryName)
                                        .ToListAsync();
            return LiofCountries;
        }
        public async Task<Country> UpdateCountry(UpdateAreaSettingDTO DTO)
        {
            var country = await _context.Countries.Where(c=> c.CountryID == DTO.AreaID).FirstOrDefaultAsync()?? throw new KeyNotFoundException("Country Not Found");
            country.CountryName = DTO.AreaName;
            _context.Countries.Update(country);
            await _context.SaveChangesAsync();
            return country;
        }
        public async Task<City> SetCity(AddCityDTO cityDTO)
        {

            var city = new City
            {
                CityName = cityDTO.City
            };
            await _context.Cities.AddAsync(city);
            await _context.SaveChangesAsync();
            return city;
        }
        public async Task<List<City>> GetCities()
        {
            var Cities = await _context.Cities
                                        .OrderByDescending(c => c.CityName)
                                        .ToListAsync() ?? throw new KeyNotFoundException("Cities Not Found");
            return Cities;
        }
        public async Task<City> RemoveCity(int cityID)
        {
            var city = await _context.Cities
                            .Where(c => c.CityId == cityID)
                            .FirstOrDefaultAsync() ?? throw new KeyNotFoundException("Country Not Found!");
            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();
            return city;
        }
        public async Task<City> UpdateCity(UpdateAreaSettingDTO DTO)
        {
            var city = await _context.Cities.Where(c => c.CityId == DTO.AreaID).FirstOrDefaultAsync() ?? throw new KeyNotFoundException("City Not Found");
            city.CityName = DTO.AreaName;
            _context.Cities.Update(city);
            await _context.SaveChangesAsync();
            return city;
        }
        public async Task<SubCity> SetSubCity(AddSubCityDTO subCityDTO)
        {

            var subCity = new SubCity
            {
                SubCityName = subCityDTO.SubCity,
            };
            await _context.SubCities.AddAsync(subCity);
            await _context.SaveChangesAsync();
            return subCity;

        }
        public async Task<SubCity> RemoveSubCity(int subCityID)
        {
            var city = await _context.SubCities
                .Where(c => c.SubCityID == subCityID)
                .FirstOrDefaultAsync() ?? throw new KeyNotFoundException("Country Not Found!");
            _context.SubCities.Remove(city);
            await _context.SaveChangesAsync();
            return city;

        }
        public async Task<List<SubCity>> GetSubCities()
        {
            var subcity = await _context.SubCities
                                        .OrderByDescending(c => c.SubCityName)
                                        .ToListAsync();
            return subcity;

        }
        public async Task<SubCity> UpdateSubCity(UpdateAreaSettingDTO DTO)
        {
            var subCity = await _context.SubCities.Where(c => c.SubCityID == DTO.AreaID).FirstOrDefaultAsync() ?? throw new KeyNotFoundException("City Not Found");
            subCity.SubCityName = DTO.AreaName;
            _context.SubCities.Update(subCity);
            await _context.SaveChangesAsync();
            return subCity;
        }


    }
}
