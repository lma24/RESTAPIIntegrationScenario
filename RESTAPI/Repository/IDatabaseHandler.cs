using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RESTAPI.Models;
using RESTAPI.ViewModel;
namespace RESTAPI.Repository
{
    public interface IDatabaseHandler
    {
        Task<int> AddCity(City city);

        Task<int> AddCityWeather(CityWeather cityWeather);

        Task UpdateCity(City city);
        Task<int> DeleteCity(int? cityId);
        Task<List<CityViewModel>> SearchCity(String strCity);

    }
}
