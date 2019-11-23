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
    public class StateCreateSteps
    {
        StateController controller;
        ActionResult result;

        Mock<IStateService> stateService = new Mock<IStateService>();

        Patient patient;
        State state;
        [Given(@"I have specified patient selected")]
        public void GivenIHaveSpecifiedPatientSelected()
        {
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
        }
        
        [Given(@"I register all the information needed")]
        public void GivenIRegisterAllTheInformationNeeded()
        {
            stateService.Setup(m => m.Insertar(It.IsAny<State>())).Returns(true);
            string iDate = "2019-03-01";
            DateTime oDate = Convert.ToDateTime(iDate);
            string iDate2 = "2019-03-09";
            DateTime oDate2 = Convert.ToDateTime(iDate2);
            state = new State
            {
                Description = "Paciente se encuentra perfecto",
                Height = 184,
                Weighr = 76,
                Affiliate = true,
                Generated_day = oDate,
                Expiration=oDate2,
                Nutritionist_Id = 1,
                Patient_Id=patient.Id
            };
            controller = new StateController();
            controller.changeService(stateService.Object);
        }
        
        [When(@"I press create state")]
        public void WhenIPressCreateState()
        {
            result = controller.Create(state);
        }
        
        [Then(@"It should be redirected to the state index page")]
        public void ThenItShouldBeRedirectedToTheStateIndexPage()
        {
            var expected = "Index";
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<RedirectToRouteResult>(result);
            var tresults = result as RedirectToRouteResult;

            Assert.AreEqual(expected, tresults.RouteValues["action"]);
        }
    }
}
