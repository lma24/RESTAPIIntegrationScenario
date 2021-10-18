using RESTAPI.Controllers;
using System;
using Xunit;
using RESTAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using RESTAPI.Models;
using Microsoft.EntityFrameworkCore;
using FluentAssertions;

namespace UnitTest
{
    public class CityUnitTestController
    {
        private DatabaseHandler repository;
        
        public static DbContextOptions<WeatherServiceContext> dbContextOptions { get; }
        //for testing added connectionString
        //public static string connectionString = "Data Source=.;Integrated Security=true;Initial Catalog=WeatherService";
        public static string connectionString = "";

        static CityUnitTestController()
        {
            
            dbContextOptions = new DbContextOptionsBuilder<WeatherServiceContext>()
                .UseSqlServer(connectionString)
                .Options;
        }

        public CityUnitTestController()
        {
            var context = new WeatherServiceContext(dbContextOptions);
            repository = new DatabaseHandler(context);

        }



        #region Add New City

        [Fact]
        public async void Task_Add_ValidData_Return_OkResult()
        {
            //Arrange
            var controller = new CityController(repository);
            var city = new City() { CityName = "Mumbai", RegionId = 2, CountryId = 1,TouristRating = 4,EstablishedDate = Convert.ToDateTime("1986-07-11"),EstimatedPopulation= 173343821, IsActive=true,CreatedBy= "1234", CreatedDate = DateTime.Now };

            //Act
            var data = await controller.AddCity(city);

            //Assert
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public async void Task_Add_InvalidData_Return_BadRequest()
        {
            //Arrange
            var controller = new CityController(repository);
            City city = new City() { CityName = "Test CityName More Than 50 Characters xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx", RegionId = 2, CountryId = 1, TouristRating = 6, EstablishedDate = Convert.ToDateTime("1986-07-11"), EstimatedPopulation = 200, IsActive = true, CreatedBy = "1234", CreatedDate = DateTime.Now };

            //Act            
            var data = await controller.AddCity(city);

            //Assert
            Assert.IsType<BadRequestResult>(data);
        }

     

        #endregion
    }
}
