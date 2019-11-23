using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using OpenQA.Selenium.Support.UI;
using System.Linq;

namespace Nu34lifeTest
{
    public class AutomatedUITests : IDisposable
    {
        private readonly IWebDriver _driver;
        public AutomatedUITests()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
        }

        [Fact]
        public void CreatePatient()
        {
            _driver.Navigate()
               .GoToUrl("http://localhost:55759");
            _driver.FindElement(By.Name("Email"))
               .SendKeys("pedro@gmail.com");

            _driver.FindElement(By.Name("Password"))
               .SendKeys("12345");

            _driver.FindElement(By.Id("btn_IniciarSesion"))
      .Click();

            _driver.Navigate()
                .GoToUrl("http://localhost:55759/Patient/Create");

            _driver.FindElement(By.Name("Name"))
                .SendKeys("Fernando");

            _driver.FindElement(By.Name("Last_name"))
                 .SendKeys("Cabrera");

            _driver.FindElement(By.Name("Birthday"))
                .SendKeys("1999-01-02");

            _driver.FindElement(By.Name("Email"))
                .SendKeys("fernandocabrera@gmail.com");
            _driver.FindElement(By.Name("Password"))
                .SendKeys("123456");



            _driver.FindElement(By.Id("CreatePatientbutton"))
                .Click();

            IList<IWebElement> links = _driver.FindElements(By.TagName("td"));
            String a = links.First(element => element.Text == "Fernando").Text;

            Assert.Equal("Fernando", a);

        }

        [Fact]
        public void CreateNutritionist()
        {

            _driver.Navigate()
               .GoToUrl("http://localhost:55759");
            _driver.FindElement(By.Name("Email"))
               .SendKeys("pedro@gmail.com");

            _driver.FindElement(By.Name("Password"))
               .SendKeys("12345");

            _driver.FindElement(By.Id("btn_IniciarSesion"))
      .Click();


            _driver.Navigate()
                .GoToUrl("http://localhost:55759/Nutritionist/Create");

            _driver.FindElement(By.Name("Name"))
                .SendKeys("Lucho");

            _driver.FindElement(By.Name("LastName"))
                 .SendKeys("Perez");

            _driver.FindElement(By.Name("Birthday"))
                .SendKeys("1999-01-02");

            _driver.FindElement(By.Name("Email"))
                .SendKeys("luchoPerez@gmail.com");
            _driver.FindElement(By.Name("Password"))
                .SendKeys("123456");

            _driver.FindElement(By.Name("Validate"))
             .Click();


            _driver.FindElement(By.Id("bnt_AddNutritionist"))
                .Click();

            IList<IWebElement> links = _driver.FindElements(By.TagName("td"));
            String a = links.First(element => element.Text == "Lucho").Text;

            Assert.Equal("Lucho", a);
        }


        [Fact]
        public void createState()
        {
            _driver.Navigate()
               .GoToUrl("http://localhost:55759");
            _driver.FindElement(By.Name("Email"))
               .SendKeys("pedro@gmail.com");

            _driver.FindElement(By.Name("Password"))
               .SendKeys("12345");

            _driver.FindElement(By.Id("btn_IniciarSesion"))
      .Click();


            _driver.Navigate()
                .GoToUrl("http://localhost:55759/Patient/InsertState");

            var a = _driver.FindElement(By.Name("Id"));
            var selectElement = new SelectElement(a);
            selectElement.SelectByIndex(3);


            _driver.FindElement(By.Id("btn_GoPatient"))
                .Click();

            IList<IWebElement> links = _driver.FindElements(By.TagName("a"));
            links.First(element => element.Text == "Crear Estado").Click();

            _driver.FindElement(By.Name("Description"))
                .SendKeys("Fitness");

            _driver.FindElement(By.Name("Height"))
                 .SendKeys("179");

            _driver.FindElement(By.Name("Weighr"))
                .SendKeys("84");

            _driver.FindElement(By.Name("Generated_day"))
                .SendKeys("2019-11-22");
            _driver.FindElement(By.Name("Expiration"))
                .SendKeys("2019-11-29");

            _driver.FindElement(By.Name("Affiliate"))
             .Click();


            _driver.FindElement(By.Id("btn_stateCrear"))
                .Click();


            IList<IWebElement> links2 = _driver.FindElements(By.TagName("td"));
            String a2 = links2.First(element => element.Text == "Fitness").Text;

            Assert.Equal("Fitness", a2);
        }


        [Fact]
        public void CreatePlan_WithRecipe()
        {

            _driver.Navigate()
               .GoToUrl("http://localhost:55759");
            _driver.FindElement(By.Name("Email"))
               .SendKeys("pedro@gmail.com");

            _driver.FindElement(By.Name("Password"))
               .SendKeys("12345");

            _driver.FindElement(By.Id("btn_IniciarSesion"))
      .Click();

            _driver.Navigate()
               .GoToUrl("http://localhost:55759/State/SearchPlan");

            var a = _driver.FindElement(By.Name("Id"));
            var selectElement = new SelectElement(a);
            selectElement.SelectByIndex(3);

            _driver.FindElement(By.Id("btn_PlanAdd"))
                .Click();

            IList<IWebElement> links = _driver.FindElements(By.TagName("a"));
            links.First(element => element.Text == "Crear Plan").Click();

            _driver.FindElement(By.Name("Description"))
               .SendKeys("1");

            _driver.FindElement(By.Id("btn_PlanCreateAdd"))
                .Click();

            _driver.FindElement(By.Name("Turn"))
               .SendKeys("2");

            var a2 = _driver.FindElement(By.Name("Recipe_Id"));
            var selectElement2 = new SelectElement(a2);
            selectElement2.SelectByIndex(2);

            _driver.FindElement(By.Id("btn_CreatePlanReciped"))
             .Click();


            IList<IWebElement> links2 = _driver.FindElements(By.TagName("td"));
            String a3 = links2.First(element => element.Text == "Arroz con Pollo").Text;

            Assert.Equal("Arroz con Pollo", a3);
        }

        [Fact]
        public void AddRecipe()
        {

            _driver.Navigate()
               .GoToUrl("http://localhost:55759");
            _driver.FindElement(By.Name("Email"))
               .SendKeys("pedro@gmail.com");

            _driver.FindElement(By.Name("Password"))
               .SendKeys("12345");

            _driver.FindElement(By.Id("btn_IniciarSesion"))
      .Click();

            _driver.Navigate()
               .GoToUrl("http://localhost:55759/State/SearchPlan");

            var a = _driver.FindElement(By.Name("Id"));
            var selectElement = new SelectElement(a);
            selectElement.SelectByIndex(3);

            _driver.FindElement(By.Id("btn_PlanAdd"))
                .Click();

            IList<IWebElement> links = _driver.FindElements(By.TagName("a"));
            links.First(element => element.Text == "Insertar Alimento").Click();

            _driver.FindElement(By.Name("Turn"))
             .SendKeys("1");

            var a2 = _driver.FindElement(By.Name("Recipe_Id"));
            var selectElement2 = new SelectElement(a2);
            selectElement2.SelectByIndex(1);

            _driver.FindElement(By.Id("btn_CreatePlanReciped"))
             .Click();


            IList<IWebElement> links2 = _driver.FindElements(By.TagName("td"));
            String a3 = links2.First(element => element.Text == "Ensalada Cesar").Text;

            Assert.Equal("Ensalada Cesar", a3);

        }








        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
