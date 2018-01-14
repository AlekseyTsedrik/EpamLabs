using NUnit.Framework;
using System;
using System.Threading;

namespace ArrivoTest
{
    [TestFixture]
    public class Tests
    {
        Steps.Steps steps = new Steps.Steps();
        private const string username = "ups1221@yandex.by";
        private const string password = "defender1234";
        private const string departureCity = "Минск";
        private const string arrivalCity = "Москва";
        private const string city = "Ибица";

        [SetUp]
        public void Init()
        {
            steps.InitBrowser();
        }

        [TearDown]
        public void Cleanup()
        {
            steps.CloseBrowser();
        }

        [Test]
        public void TestLoginArrivo()
        {
            steps.LoginArrivo(username, password);
            Assert.True(steps.IsLoggedIn());
        }

        [Test]
        public void TestSearchRoute()
        {
            steps.SearchRoute(departureCity, arrivalCity, DateTime.Now.Day, DateTime.Now.Day + 1);
            Thread.Sleep(20000);
            Assert.True(steps.IsSubmit() && !steps.IsErrorDepartureCity() && !steps.IsErrorArrivalCity());
        }

        [Test]
        public void TestSearchRouteWithoutDepartureCity()
        {
            steps.SearchRouteWithoutDepartureCity(arrivalCity, DateTime.Now.Day, DateTime.Now.Day + 1);
            Thread.Sleep(2000);
            Assert.True(steps.IsErrorDepartureCity());
        }

        [Test]
        public void TestSearchRouteWithoutArrivalCity()
        {
            steps.SearchRouteWithoutArrivalCity(departureCity, DateTime.Now.Day, DateTime.Now.Day + 1);
            Thread.Sleep(2000);
            Assert.True(steps.IsErrorArrivalCity());
        }

        [Test]
        public void TestSearchRouteWithoutCities()
        {
            steps.SearchRouteWithoutCities(DateTime.Now.Day, DateTime.Now.Day + 1);
            Thread.Sleep(2000);
            Assert.True(steps.IsErrorDepartureCity() && steps.IsErrorArrivalCity());
        }

        [Test]
        public void TestSearchRouteWithDayDeparture()
        {
            steps.SearchRouteWithDayDeparture(departureCity, arrivalCity, DateTime.Now.Day);
            Thread.Sleep(5000);
            Assert.True(steps.IsSubmit() && !steps.IsErrorDepartureCity() && !steps.IsErrorArrivalCity());
        }

        [Test]
        public void TestSearchRouteWithDayArrival()
        {
            steps.SearchRouteWithDayArrival(departureCity, arrivalCity, 29);
            Thread.Sleep(5000);
            Assert.True(steps.IsSubmit() && !steps.IsErrorDepartureCity() && !steps.IsErrorArrivalCity());
        }

        [Test]
        public void TestSearchHotel()
        {
            steps.SearchHotel(city, 29, 30);
            Thread.Sleep(5000);
            Assert.True(steps.IsSubmit() && !steps.IsErrorCityHotel());
        }
        
        [Test]
        public void TestSearchHotelWithErrorCity()
        {
            steps.SearchHotel("Мазила", 29, 30);
            Thread.Sleep(2000);
            Assert.True(steps.IsErrorCityHotel());
        }

        [Test]
        public void TestSearchHotelWithoutCity()
        {
            steps.SearchHotelWithoutCity(29, 30);
            Thread.Sleep(2000);
            Assert.True(steps.IsErrorCityHotel());
        }
    }
}
