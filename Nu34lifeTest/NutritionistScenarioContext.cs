using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using TechTalk.SpecFlow;
using Nu34life.Models;
using Nu34life.Controllers;
using System.Web;


namespace Nu34lifeTest
{
    class NutritionistScenarioContext
    {
        [Binding]
        public class RegisterNutritionistSteps
        {
            NutritionistController controller;

            Mock<INutritionistRepository> nutritionistRepository = new Mock<INutritionistRepository>();
            nutritionistRepository.Setup(u => u.Listar()).Returns(this.nutritionists);

            var servicio = new NutritionistService();
            servicio.setNutritionist(nutritionistRepository.Object);
        }
    }
}
