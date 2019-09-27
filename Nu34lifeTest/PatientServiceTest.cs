using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business.Implementation;
using Nu34life.Models;
namespace Nu34lifeTest
{
    [TestClass]
    public class PatientServiceTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var servicio = new PatientService();
            var paciente = new Patient() {
                Id = 10,
                Name = "Diego",
                Last_name = "Narrea",
                Email = "pedro@pedro.com",
                Password = "4334",
                Nutritionist_Id = 1
            };
            var resultado = servicio.Insertar(paciente);
            Assert.IsFalse(false);
        }
    }
}
