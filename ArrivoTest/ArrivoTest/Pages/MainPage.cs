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

        [FindsBy(How = How.Id, Using = "tickets-fly-out-city")]
        private IWebElement inputDepartureCity;

        [FindsBy(How = How.Id, Using = "tickets-fly-in-city")]
        private IWebElement inputArrivalCity;

        [FindsBy(How = How.Id, Using = "tickets-fly-out-date")]
        private IWebElement inputDateDeparture;

        [FindsBy(How = How.Id, Using = "tickets-fly-in-date")]
        private IWebElement inputDateDepartureBack;

        [FindsBy(How = How.Id, Using = "peopleAmountAdult")]
        private IWebElement inputPassengerInfo;

        [FindsBy(How = How.Id, Using = "ui-datepicker-div")]
        private IWebElement dateBlock;

        [FindsBy(How = How.Id, Using = "mainFormTicketsBut")]
        private IWebElement withoutTicketButton;

        [FindsBy(How = How.XPath, Using = "/html/body/div[7]/div/a[2]")]
        private IWebElement nextYearButton;

        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div/div/div/div/div/div/div[2]/div/div[5]/div/div[1]/div/i[2]")]
        private IWebElement addAdultPassenger;

        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div/div/div/div/div/div/div[2]/div/div[5]/div/div[2]/div[1]/div/i[2]")]
        private IWebElement addClildPassenger;

        [FindsBy(How = How.Id, Using = "tickets-send")]
        private IWebElement buttonSearchTickets;

        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div/div/div/div/div/div/div[1]/a[2]/span[2]")]
        private IWebElement buttonHotels;

        [FindsBy(How = How.Id, Using = "hotels-fly-out-city")]
        private IWebElement nameCity;

        [FindsBy(How = How.Id, Using = "hotels-fly-out-city")]
        private IWebElement dateArrival;

        [FindsBy(How = How.Id, Using = "hotels-fly-in-date")]
        private IWebElement dateDeparture;

        [FindsBy(How = How.Id, Using = "hotelsPeopleAmount")]
        private IWebElement numGuests;

        [FindsBy(How = How.Id, Using = "hotelsAdultPlus")]
        private IWebElement addGuests;

        [FindsBy(How = How.Id, Using = "hotels-send")]
        private IWebElement buttonSearchHotels;

        [FindsBy(How = How.XPath, Using = "/html/body/div[8]/div/a[2]")]
        private IWebElement nextYearHotel;

        private bool dateDepartureEnabled = false;
        private bool dateDepartureBackEnabled = false;
        private bool passengerInfoEnabled = false;
        private bool numGuestEnabled = false;
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

        public void SearchTickets()
        {
            buttonSearchTickets.Click();
        }

        public void setDepartureCity(string departureCity)
        {
            inputDepartureCity.SendKeys(departureCity);
        }

        public void setArrivalCity(string arrivalCity)
        {
            inputArrivalCity.SendKeys(arrivalCity);
        }

        public void setYearDeparture(int year)
        {
            if (!dateDepartureEnabled)
            {
                inputDateDeparture.Click();
                IWebElement currentYear = dateBlock.FindElement(By.XPath("/html/body/div[7]/div/div/span[2]"));
                int yearr = Convert.ToInt32(currentYear.Text);
                for (int i = 0; i < (year - yearr); i++)
                {
                    nextYearButton.Click();
                }
            }
            else if (dateDepartureEnabled)
            {
                IWebElement currentYear = dateBlock.FindElement(By.XPath("/html/body/div[7]/div/div/span[2]"));
                int yearr = Convert.ToInt32(currentYear.Text);
                for (int i = 0; i < (year - yearr); i++)
                {
                    nextYearButton.Click();
                }
            }
        }

        public void setDayDeparture(int day)
        {
            if(!dateDepartureEnabled)
            {
                inputDateDeparture.Click();
                IWebElement date = dateBlock.FindElement(By.LinkText(day.ToString()));
                date.Click();
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
            }
            else if (dateDepartureBackEnabled)
            {
                IWebElement date = dateBlock.FindElement(By.LinkText(day.ToString()));
                date.Click();
            }
            
        }

        public void setYearArrival(int year)
        {
            if (!dateDepartureBackEnabled)
            {
                inputDateDepartureBack.Click();
                IWebElement currentYear = dateBlock.FindElement(By.XPath("/html/body/div[7]/div/div/span[2]"));
                int yearr = Convert.ToInt32(currentYear.Text);
                for (int i = 0; i < (year - yearr); i++)
                {
                    nextYearButton.Click();
                }
            }
            else if (dateDepartureBackEnabled)
            {
                IWebElement currentYear = dateBlock.FindElement(By.XPath("/html/body/div[7]/div/div/span[2]"));
                int yearr = Convert.ToInt32(currentYear.Text);
                for (int i = 0; i < (year - yearr); i++)
                {
                    nextYearButton.Click();
                }
            }
            
        }

        public void setWithoutTicket(bool withoutTicket)
        {
            if(!dateDepartureBackEnabled)
            {
                inputDateDepartureBack.Click();
                if (withoutTicket)
                    withoutTicketButton.Click();
            }
            if(dateDepartureBackEnabled)
            {
                if (withoutTicket)
                    withoutTicketButton.Click();
            }
            
        }

        public void setAdultCount(int count)
        {
            if(!passengerInfoEnabled)
            {
                inputPassengerInfo.Click();
                for (int i = 0; i < count; i++)
                {
                    addAdultPassenger.Click();
                }
            }
            else if (passengerInfoEnabled)
            {
                for (int i = 0; i < count; i++)
                {
                    addAdultPassenger.Click();
                }
            }
            
        }

        public void setChildrenCount(int count)
        {
            if(!passengerInfoEnabled)
            {
                inputPassengerInfo.Click();
                for (int i = 0; i < count; i++)
                {
                    addClildPassenger.Click();
                }
            }
            else if (passengerInfoEnabled)
            {
                for (int i = 0; i < count; i++)
                {
                    addClildPassenger.Click();
                }
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
        }

        public void setNumGuest(int numGuest)
        {
            if(!numGuestEnabled)
            {
                this.numGuests.Click();
                for (int i = 0; i < numGuest; i++)
                    addGuests.Click();
            }
            else if (numGuestEnabled)
            {
                for (int i = 0; i < numGuest; i++)
                    addGuests.Click();
            }
        }

        public void setDayArrivalInHotel(int day)
        {
            if(!dateArrivalHotel)
            {
                dateArrival.Click();
                IWebElement date = dateBlock.FindElement(By.LinkText(day.ToString()));
                date.Click();
            }
            else if(dateArrivalHotel)
            {
                IWebElement date = dateBlock.FindElement(By.LinkText(day.ToString()));
                date.Click();
            }
        }

        public void setDayDepartureHotel(int day)
        {
            if(!dateDepartureHotel)
            {
                dateDeparture.Click();
                IWebElement date = dateBlock.FindElement(By.LinkText(day.ToString()));
                date.Click();
            }
            else if(dateDepartureHotel)
            {
                IWebElement date = dateBlock.FindElement(By.LinkText(day.ToString()));
                date.Click();
            }
        }

        public void setYearArrivalInHotel(int year)
        {
            if (!dateArrivalHotel)
            {
                dateArrival.Click();
                IWebElement currentYear = dateBlock.FindElement(By.XPath("/html/body/div[8]/div/div/span[2]"));
                int yearr = Convert.ToInt32(currentYear.Text);
                for (int i = 0; i < (year - yearr); i++)
                {
                    nextYearHotel.Click();
                }
            }
            else if (dateArrivalHotel)
            {
                IWebElement currentYear = dateBlock.FindElement(By.XPath("/html/body/div[8]/div/div/span[2]"));
                int yearr = Convert.ToInt32(currentYear.Text);
                for (int i = 0; i < (year - yearr); i++)
                {
                    nextYearHotel.Click();
                }
            }
        }

        public void setYearDepartureHotel(int year)
        {
            if (!dateDepartureHotel)
            {
                dateDeparture.Click();
                IWebElement currentYear = dateBlock.FindElement(By.XPath("/html/body/div[8]/div/div/span[2]"));
                int yearr = Convert.ToInt32(currentYear.Text);
                for (int i = 0; i < (year - yearr); i++)
                {
                    nextYearHotel.Click();
                }
            }
            else if (dateDepartureHotel)
            {
                IWebElement currentYear = dateBlock.FindElement(By.XPath("/html/body/div[8]/div/div/span[2]"));
                int yearr = Convert.ToInt32(currentYear.Text);
                for (int i = 0; i < (year - yearr); i++)
                {
                    nextYearHotel.Click();
                }
            }
        }
    }
}
