using OpenQA.Selenium;

namespace ArrivoTest.Steps
{
    public class Steps
    {
        IWebDriver driver;

        public void InitBrowser()
        {
            driver = Driver.DriverInstance.GetInstance();
        }

        public void CloseBrowser()
        {
            Driver.DriverInstance.CloseBrowser();
        }

        public void LoginArrivo(string username, string password)
        {
            Pages.MainPage page = new Pages.MainPage(driver);
            page.OpenPage();
            page.ClickLogin();
            page.Login(username, password);
        }

        public bool IsLoggedIn()
        {
            Pages.MainPage page = new Pages.MainPage(driver);
            return page.PresenceImageUser();
        }

        public void SearchRoute(string departure, string arrival, int dayDeparture, int dayArrival)
        {
            Pages.MainPage page = new Pages.MainPage(driver);
            page.OpenPage();
            page.setDepartureCity(departure);
            page.setArrivalCity(arrival);
            page.setDayDeparture(dayDeparture);
            page.setDayArrival(dayArrival);
            page.SearchTickets();
        }

        public void SearchRouteWithDayDeparture(string departure, string arrival, int dayDeparture)
        {
            Pages.MainPage page = new Pages.MainPage(driver);
            page.OpenPage();
            page.setDepartureCity(departure);
            page.setArrivalCity(arrival);
            page.setDayDeparture(dayDeparture);
            page.SearchTickets();
        }

        public void SearchRouteWithDayArrival(string departure, string arrival, int dayArrival)
        {
            Pages.MainPage page = new Pages.MainPage(driver);
            page.OpenPage();
            page.setDepartureCity(departure);
            page.setArrivalCity(arrival);
            page.setDayArrival(dayArrival);
            page.SearchTickets();
        }

        public void SearchRouteWithoutArrivalCity(string departure, int dayDeparture, int dayArrival)
        {
            Pages.MainPage page = new Pages.MainPage(driver);
            page.OpenPage();
            page.setDepartureCity(departure);
            page.setDayDeparture(dayDeparture);
            page.setDayArrival(dayArrival);
            page.SearchTickets();
        }

        public void SearchRouteWithoutDepartureCity(string arrival, int dayDeparture, int dayArrival)
        {
            Pages.MainPage page = new Pages.MainPage(driver);
            page.OpenPage();
            page.setArrivalCity(arrival);
            page.setDayDeparture(dayDeparture);
            page.setDayArrival(dayArrival);
            page.SearchTickets();
        }

        public void SearchRouteWithoutCities(int dayDeparture, int dayArrival)
        {
            Pages.MainPage page = new Pages.MainPage(driver);
            page.OpenPage();
            page.setDayDeparture(dayDeparture);
            page.setDayArrival(dayArrival);
            page.SearchTickets();
        }

        public bool IsTargetSite(string url)
        {
            return driver.Url.Equals(url); 
        }

        public void SearchHotel(string city, int dayDepartureHotel, int dayArrivalHotel)
        {
            Pages.MainPage page = new Pages.MainPage(driver);
            page.OpenPage();
            page.chooseHotel();
            page.setNameCity(city);
            page.setDayDepartureHotel(dayDepartureHotel);
            page.setDayArrivalInHotel(dayArrivalHotel);
            page.searchHotel();
        }

        public void SearchHotelWithoutCity(int dayDepartureHotel, int dayArrivalHotel)
        {
            Pages.MainPage page = new Pages.MainPage(driver);
            page.OpenPage();
            page.chooseHotel();
            page.setDayDepartureHotel(dayDepartureHotel);
            page.setDayArrivalInHotel(dayArrivalHotel);
            page.searchHotel();
        }
    }
}
