using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;

namespace ArrivoTest.Pages
{
    public class MainPage
    {
        private IWebDriver driver;

        private const string URL = "http://www.arrivo.ru/";

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/div/div[1]/ul/li[8]/a")]
        private IWebElement buttonLogin;

        [FindsBy(How = How.Id, Using = "LoginUser_email")]
        private IWebElement inputLogin;

        [FindsBy(How = How.Id, Using = "LoginUser_pass")]
        private IWebElement inputPassword;

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/div/div[1]/ul/li[8]/a/img")]
        private IWebElement imageUser;

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/div/div[2]/div[2]/div[2]/form/button")]
        private IWebElement buttonEnter;

        [FindsBy(How = How.Id, Using = "tickets-fly-out-city")]
        private IWebElement inputDepartureCity;

        [FindsBy(How = How.Id, Using = "tickets-fly-in-city")]
        private IWebElement inputArrivalCity;

        [FindsBy(How = How.Id, Using = "tickets-fly-out-date")]
        private IWebElement inputDateDeparture;

        [FindsBy(How = How.Id, Using = "tickets-fly-in-date")]
        private IWebElement inputDateDepartureBack;

        [FindsBy(How = How.Id, Using = "ui-datepicker-div")]
        private IWebElement dateBlock;

        [FindsBy(How = How.Id, Using = "tickets-send")]
        private IWebElement buttonSearchTickets;

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div/div/div/div/div/div[1]/a[2]/span[2]")]
        private IWebElement buttonHotels;

        [FindsBy(How = How.Id, Using = "hotels-fly-out-city")]
        private IWebElement nameCity;

        [FindsBy(How = How.Id, Using = "hotels-fly-in-date")]
        private IWebElement dateArrival;

        [FindsBy(How = How.Id, Using = "hotels-fly-out-date")]
        private IWebElement dateDeparture;

        [FindsBy(How = How.Id, Using = "hotels-send")]
        private IWebElement buttonSearchHotels;

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div/div/div/div/div/div[3]/div/div[1]/span[2]")]
        private IWebElement errorLabelHotel;

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div/div/div/div/div/div[2]/div/div[1]/span[2]")]
        private IWebElement errorLabelDepartureCity;

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div/div/div/div/div/div[2]/div/div[2]/span[2]")]
        private IWebElement errorLabelArrivalCity;

        private bool dateDepartureEnabled = false;
        private bool dateDepartureBackEnabled = false;
        private bool dateDepartureHotel = false;
        private bool dateArrivalHotel = false;

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(URL);
        }

        public void ClickLogin()
        {
            buttonLogin.Click();
        }

        public bool PresenceImageUser()
        {
            return imageUser.Displayed;
        }

        public void Login(string email, string password)
        {
            inputLogin.SendKeys(email);
            inputPassword.SendKeys(password);
            buttonEnter.Click();
        }

        public bool IsSubmitEnabled()
        {
            return buttonSearchTickets.Enabled;
        }

        public void SearchTickets()
        {
            buttonSearchTickets.Click();
            dateDepartureEnabled = false;
            dateDepartureBackEnabled = false;
        }

        public void setDepartureCity(string departureCity)
        {
            inputDepartureCity.SendKeys(departureCity);
            inputDepartureCity.SendKeys(OpenQA.Selenium.Keys.Enter);
            dateDepartureEnabled = false;
            dateDepartureBackEnabled = false;
        }

        public void setArrivalCity(string arrivalCity)
        {
            inputArrivalCity.SendKeys(arrivalCity);
            inputArrivalCity.SendKeys(OpenQA.Selenium.Keys.Enter);
            dateDepartureEnabled = false;
            dateDepartureBackEnabled = false;
        }

        public void setDayDeparture(int day)
        {
            if (!dateDepartureEnabled)
            {
                inputDateDeparture.Click();
                IWebElement date = dateBlock.FindElement(By.LinkText(day.ToString()));
                date.Click();
                dateDepartureEnabled = true;
            }
            else if (dateDepartureEnabled)
            {
                IWebElement date = dateBlock.FindElement(By.LinkText(day.ToString()));
                date.Click();
            }
        }

        public void setDayArrival(int day)
        {
            if (!dateDepartureBackEnabled)
            {
                inputDateDepartureBack.Click();
                IWebElement date = dateBlock.FindElement(By.LinkText(day.ToString()));
                date.Click();
                dateDepartureBackEnabled = true;
            }
            else if (dateDepartureBackEnabled)
            {
                IWebElement date = dateBlock.FindElement(By.LinkText(day.ToString()));
                date.Click();
            }
        }

        public void chooseHotel()
        {
            buttonHotels.Click();
        }

        public void searchHotel()
        {
            buttonSearchHotels.Click();
        }

        public void setNameCity(string name)
        {
            this.nameCity.SendKeys(name);
            this.nameCity.SendKeys(OpenQA.Selenium.Keys.Enter);
            dateDepartureHotel = false;
            dateArrivalHotel = false;
        }

        public void setDayArrivalInHotel(int day)
        {
            if (!dateArrivalHotel)
            {
                dateArrival.Click();
                IWebElement date = dateBlock.FindElement(By.LinkText(day.ToString()));
                date.Click();
                dateArrivalHotel = true;
            }
            else if (dateArrivalHotel)
            {
                IWebElement date = dateBlock.FindElement(By.LinkText(day.ToString()));
                date.Click();
            }
        }

        public void setDayDepartureHotel(int day)
        {
            if (!dateDepartureHotel)
            {
                dateDeparture.Click();
                IWebElement date = dateBlock.FindElement(By.LinkText(day.ToString()));
                date.Click();
                dateDepartureHotel = true;
            }
            else if (dateDepartureHotel)
            {
                IWebElement date = dateBlock.FindElement(By.LinkText(day.ToString()));
                date.Click();
            }
        }

        public bool ErrorLabelEnabled()
        {
            return errorLabelHotel.Displayed;
        }

        public bool ErrorLabelDepartureCity()
        {
            return errorLabelDepartureCity.Displayed;
        }

        public bool ErrorLabelArrivalCity()
        {
            return errorLabelArrivalCity.Displayed;
        }
    }
}