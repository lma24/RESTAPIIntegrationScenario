using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RESTAPI.Models;
using RESTAPI.ViewModel;
namespace RESTAPI.Repository
{
    public class DatabaseHandler : IDatabaseHandler
    {
        WeatherServiceContext db;
        public DatabaseHandler(WeatherServiceContext _db)
        {
            db = _db;
        }

        public async Task<int> AddCity(City city)
        {
            if (db != null)
            {
                await db.Cities.AddAsync(city);
                await db.SaveChangesAsync();

                return city.CityId;
            }

            return 0;
        }

        public async Task<int> AddCityWeather(CityWeather cityWeather)
        {
            if (db != null)
            {
                await db.CityWeathers.AddAsync(cityWeather);
                await db.SaveChangesAsync();

                return cityWeather.CityId;
            }

            return 0;
        }
        public async Task UpdateCity(City city)
        {
            if (db != null)
            {
                var update = db.Cities.FirstOrDefault(u => u.CityId == city.CityId);
                update.TouristRating = city.TouristRating;
                update.EstablishedDate = city.EstablishedDate;
                update.EstimatedPopulation = city.EstimatedPopulation;


                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }

        public async Task<int> DeleteCity(int? cityId)
        {
            int result = 0;

            if (db != null)
            {
                var city = await db.Cities.FirstOrDefaultAsync(x => x.CityId == cityId);

                if (city != null)
                {
                    db.Cities.Remove(city);

                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }

        public async Task<List<CityViewModel>> SearchCity(String strCity)
        {
            if (db != null)
            {

                return await (from p in db.Cities.Where(x => !string.IsNullOrEmpty(x.CityName) && x.CityName.Contains(strCity))
                              join c in db.CityWeathers on p.CityId equals c.CityId
                              join s in db.StateRegions on p.RegionId equals s.RegionId
                              join country in db.Countries on p.CountryId equals country.CountryId
                              orderby p.CityId ascending
                              select new CityViewModel
                              {
                                  CityId = p.CityId,
                                  CityName = p.CityName,
                                  State = s.StateRegion1,
                                  Country = country.CountryName,
                                  TouristRating = p.TouristRating,
                                  DateEstablished = p.EstablishedDate,
                                  EstimatedPopulation = p.EstimatedPopulation,
                                  TwoDigitCountryCode = country.CountryCode.Substring(0, 2),
                                  ThreeDigitCountryCode = country.CountryCode.Substring(0, 3),
                                  CurrencyCode = country.CurrencyCode,
                                  Weather = c.Temperature
                              }
                              ).ToListAsync();

            }

            return null;

        }


    }
}
