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
        private List<Allergy> allergies = null;
        private List<Ingredient> ingredients = null;
        private List<Recipe_Details> recipe_Details = null;
        private List<Recipe> recipes = null;
        private List<Recipe> recipesFiltradas = null;
        private State estadoG = new State();
        private Plan plan = new Plan();

        List<Recipe_Details> icollection = new List<Recipe_Details>();
        List<Plans_Recipes> iplanrecipe = new List<Plans_Recipes>();
        List<Recipe_Details> icollection2 = new List<Recipe_Details>();
        [TestInitialize]
        public void Setup()
        {


            estadoG.setPatient_ID(1);
            estadoG.setNutritionist_ID(1);
            this.users = new List<Patient>();
            users.Add(new Patient
            {
                Id = 1,
                Name = "Diego",
                Last_name = "Narrea",
                Email = "pedro@pedro.com",
                Password = "4334",
                Nutritionist_Id = 1
            });

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

            this.recipesFiltradas = new List<Recipe>();

            this.ingredients = new List<Ingredient>();
            ingredients.Add(new Ingredient
            {
                Id = 1,
                Name = "zanahoria",
                Description = "Verdura",
                Carbohydrates = 10,
                Fat=0
            });
            ingredients.Add(new Ingredient
            {
                Id = 2,
                Name = "pera",
                Description = "Fruta",
                Carbohydrates = 10,
                Fat = 0
            });
            ingredients.Add(new Ingredient
            {
                Id = 3,
                Name = "lechuga",
                Description = "Verdura",
                Carbohydrates = 1,
                Fat = 0
            });

            this.allergies = new List<Allergy>();
            allergies.Add(new Allergy
            {
                Patient_Id = 1,
                Ingredient_Id = 1
            });

            //Receta 1 con ingredientes 1-2

            this.recipe_Details = new List<Recipe_Details>();
            recipe_Details.Add(new Recipe_Details
            {
                Recipe_Id = 1,
                Ingredient_Id = 1
            });

           


            recipe_Details.Add(new Recipe_Details
            {
                Recipe_Id = 1,
                Ingredient_Id = 2
            });
            //Receta  2 con ingredientes 2-3
            recipe_Details.Add(new Recipe_Details
            {
                Recipe_Id = 2,
                Ingredient_Id = 2
            });
            recipe_Details.Add(new Recipe_Details
            {
                Recipe_Id = 2,
                Ingredient_Id = 3
            });

  

            icollection.Add(recipe_Details[0]);

            icollection.Add(recipe_Details[1]);



            this.recipes = new List<Recipe>();
            recipes.Add(new Recipe
            {
                Id = 1,
                Recipe_Details=icollection
            });


            icollection2.Add(recipe_Details[2]);

            icollection2.Add(recipe_Details[3]);

            recipes.Add(new Recipe
            {
                Id = 2,
                Recipe_Details = icollection2
            });

            this.iplanrecipe.Add(new Plans_Recipes
            {
                Id = 1,
                Plan_Id = 1,
                Recipe_Id = 2
            });

            recipesFiltradas.Add(recipes[1]);
            plan.setPlanRecipe(iplanrecipe);

        }

        [TestMethod]
        public void EmailPatientTest()
        {
            Mock<IPatientRepository> patientRepository = new Mock<IPatientRepository>();
            patientRepository.Setup(u => u.Listar()).Returns(this.users);

            var servicio = new PatientService();
            servicio.setPatient(patientRepository.Object);

            var paciente = new Patient() {
                Id = 2,
                Name = "Diego",
                Last_name = "Narrea",
                Email = "pedro1@pedro.com",
                Password = "4334",
                Nutritionist_Id = 1
            };
            var resultado = servicio.Insertar(paciente);
            Assert.IsTrue(resultado);
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
                Id = 2,
                Name = "nutri4",
                LastName = "nutri445_Last",
                Email = "nutri12@pedro.com",
                Password = "433664",
                Validate = true
            };
            var resultado = servicio.Insertar(nutritionist);
            Assert.IsTrue(resultado);
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
                Id = 1,
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
        public void cantidadPlatosTest()
        {
            Mock<INutritionistRepository> nutritionistRepository = new Mock<INutritionistRepository>();
            nutritionistRepository.Setup(u => u.Listar()).Returns(this.nutritionists);

            var servicio = new NutritionistService();
            servicio.setNutritionist(nutritionistRepository.Object);
            var respuesta = servicio.cantidadPlatosPermi(plan);
            Assert.IsTrue(respuesta);
        }


        [TestMethod]
        public void Allergie_Recipes()
        {
            Mock<IRecipeRepository> recipeRepository = new Mock<IRecipeRepository>();
            recipeRepository.Setup(u => u.Listar()).Returns(this.recipes);


            Mock<IAllergyRepository> allergyRepository = new Mock<IAllergyRepository>();
            allergyRepository.Setup(u => u.Listar()).Returns(this.allergies);

            var servicio = new RecipeService();
            servicio.setRecipeRepo(recipeRepository.Object);
            servicio.setAllergyRepo(allergyRepository.Object);
            
            List<Recipe> resultado = servicio.ListarbyFiltro(users[0]);
            Assert.AreNotEqual(recipesFiltradas,resultado);
        }


        [TestMethod]
        public void actualizarEstado()
        {
            Mock<INutritionistRepository> nutritionistRepository = new Mock<INutritionistRepository>();
            nutritionistRepository.Setup(u => u.Listar()).Returns(this.nutritionists);


            Mock<IStateRepository> stateRepository = new Mock<IStateRepository>();
            stateRepository.Setup(m => m.Insertar(It.IsAny<State>()));

            var servicio = new NutritionistService();
            servicio.setNutritionist(nutritionistRepository.Object);
            servicio.setState(stateRepository.Object);

            var resultado = servicio.actualizarEstado(users[0],estadoG, plan);
            Assert.IsTrue( resultado);
        }









    }
}
