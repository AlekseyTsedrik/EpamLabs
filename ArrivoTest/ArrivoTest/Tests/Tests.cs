using NUnit.Framework;
using System;

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
        }

        [Test]
        public void TestSearchRouteWithoutDepartureCity()
        {
            steps.SearchRouteWithoutDepartureCity(arrivalCity, DateTime.Now.Day, DateTime.Now.Day + 1);
        }

        [Test]
        public void TestSearchRouteWithoutArrivalCity()
        {
            steps.SearchRouteWithoutArrivalCity(departureCity, DateTime.Now.Day, DateTime.Now.Day + 1);
        }

        [Test]
        public void TestSearchRouteWithoutCities()
        {
            steps.SearchRouteWithoutCities(DateTime.Now.Day, DateTime.Now.Day + 1);
        }

        [Test]
        public void TestSearchRouteWithDayDeparture()
        {
            steps.SearchRouteWithDayDeparture(departureCity, arrivalCity, 30);
        }

        [Test]
        public void TestSearchRouteWithDayArrival()
        {
            steps.SearchRouteWithDayArrival(departureCity, arrivalCity, 30);
        }

        [Test]
        public void TestSearchHotel()
        {
            steps.SearchHotel(city, 29, 30);
        }

        [Test]
        public void TestSearchHotelWithErrorCity()
        {
            steps.SearchHotel("Мазила", 29, 30);
        }

        [Test]
        public void TestSearchHotelWithoutCity()
        {
            steps.SearchHotelWithoutCity(29, 30);
        }
    }
}
