using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business.Implementation;
using Nu34life.Models;
using Data;
using Moq;
namespace Nu34lifeTest
{
    [TestClass]
    public class PatientServiceTest
    {

        private List<Patient> users = null;
        private List<Nutritionist> nutritionists = null;
        [TestInitialize]
        public void Setup()
        {
            this.users = new List<Patient>();
            users.Add(new Patient
            {
                Id = 9,
                Name = "Diego",
                Last_name = "Narrea",
                Email = "pedro@pedro.com",
                Password = "4334",
                Nutritionist_Id = 1
            });

            this.nutritionists = new List<Nutritionist>();
            nutritionists.Add(new Nutritionist
            {
                Id = 12,
                Name = "nutri1",
                LastName = "nutri1_Last",
                Email = "nutri1@pedro.com",
                Password = "4334",
                Validate = true
            });



        }

        [TestMethod]
        public void EmailPatientTest()
        {
            Mock<IPatientRepository> patientRepository = new Mock<IPatientRepository>();
            patientRepository.Setup(u => u.Listar()).Returns(this.users);

            var servicio = new PatientService();
            servicio.setPatient(patientRepository.Object);

            var paciente = new Patient() {
                Id = 10,
                Name = "Diego",
                Last_name = "Narrea",
                Email = "pedro@pedro.com",
                Password = "4334",
                Nutritionist_Id = 1
            };
            var resultado = servicio.Insertar(paciente);
            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void EmailNutritionistTest()
        {
            Mock<INutritionistRepository> nutritionistRepository = new Mock<INutritionistRepository>();
            nutritionistRepository.Setup(u => u.Listar()).Returns(this.nutritionists);

            var servicio = new NutritionistService();
            servicio.setNutritionist(nutritionistRepository.Object);

            var nutritionist = new Nutritionist()
            {
                Id = 5,
                Name = "nutri4",
                LastName = "nutri445_Last",
                Email = "nutri1@pedro.com",
                Password = "433664",
                Validate = true
            };
            var resultado = servicio.Insertar(nutritionist);
            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void State_PlanTest()
        {
            Mock<IPlanRepository> planRepository = new Mock<IPlanRepository>();
            planRepository.Setup(m => m.Insertar(It.IsAny<Plan>()));



            var servicio = new PlanService();
            servicio.setPlan(planRepository.Object);

            var statePrueba = new State()
            {
                Id = 3,
                Weighr = 45,
                Height = 50,
                Glucose = 34,
                Affiliate = true
            };

            var Plan = new Plan()
            {
                Id = 5,
                State = statePrueba,
                State_Id = statePrueba.Id,
                Description = 2
            };
            var resultado = servicio.Insertar(Plan);
            Assert.IsTrue(resultado);
        }



        [TestMethod]
        public void Editar_PerfilTest()
        {
            Mock<INutritionistRepository> nutritionistRepository = new Mock<INutritionistRepository>();
            nutritionistRepository.Setup(u => u.Listar()).Returns(this.nutritionists);

            var servicio = new NutritionistService();
            servicio.setNutritionist(nutritionistRepository.Object);

            var nutritionist = new Nutritionist()
            {
                Id = 12,
                Name = "nutri1",
                LastName = "nutri1_Last",
                Email = "nutri1@pedro.com",
                Password = "433644",
                Validate = true
            };
            var resultado = servicio.letModificarPerfil(nutritionist, "4334");
            Assert.IsTrue(resultado);

        }



        [TestMethod]
        public void Editar_CorreoNutriTest()
        {
            Mock<INutritionistRepository> nutritionistRepository = new Mock<INutritionistRepository>();
            nutritionistRepository.Setup(u => u.Listar()).Returns(this.nutritionists);

            var servicio = new NutritionistService();
            servicio.setNutritionist(nutritionistRepository.Object);

            var nutritionist = new Nutritionist()
            {
                Id = 12,
                Name = "nutri1",
                LastName = "nutri1_Last",
                Email = "nutri1@pedro.com",
                Password = "433644",
                Validate = true
            };
            var resultado = servicio.Actualizar(nutritionist);
            Assert.IsTrue(resultado);

        }
    }
}
