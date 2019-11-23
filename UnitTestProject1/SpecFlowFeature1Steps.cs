using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using TechTalk.SpecFlow;
using Nu34life.Models;
using NUnit.Framework;
using Nu34life.Controllers;
using System.Web;
using Business;
using System.Web.Mvc;

namespace UnitTestProject1
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        PatientController controller;

        ActionResult result;

        private List<Nutritionist> nutritionists = null;
        

        Mock<INutritionistService> nutritionistService = new Mock<INutritionistService>();
       
        Mock<IPatientService> patientService = new Mock<IPatientService>();
        Patient patient;
        [Given(@"The nutritionist has entered all the information about the patient")]
        public void GivenTheNutritionistHasEnteredAllTheInformationAboutThePatient()
        {
            this.nutritionists = new List<Nutritionist>();
            nutritionists.Add(new Nutritionist
            {
                Id = 1,
                Name = "nutri1",
                LastName = "nutri1_Last",
                Email = "nutri1@pedro.com",
                Password = "4334",
                Validate = true
            });
            patientService.Setup(m => m.Insertar(It.IsAny<Patient>())).Returns(true);
            nutritionistService.Setup(u => u.Listar()).Returns(this.nutritionists);
            string iDate = "1999-03-01";
            DateTime oDate = Convert.ToDateTime(iDate);
            patient = new Patient
            {
                Name = "Vicente",
                Last_name = "Calderon",
                Birthday = oDate,
                Email = "vicentecalderon@gmail.com",
                Password = "1234567",
                Nutritionist_Id = 1
            };
            controller = new PatientController();
            controller.changeService(patientService.Object, nutritionistService.Object);
        }

        [When(@"He clicks on Register button")]
        public void WhenHeClicksOnRegisterButton()
        {
            result = controller.Create(patient);
        }

        [Then(@"He should be redirected to the patient index page")]
        public void ThenHeShouldBeRedirectedToThePatientIndexPage()
        {
            var expected = "Index";
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<RedirectToRouteResult>(result);
            var tresults = result as RedirectToRouteResult;

            Assert.AreEqual(expected, tresults.RouteValues["action"]);
        }
    }
}
