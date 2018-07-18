using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestInstancia()
        {
            Correo correo = new Correo();
            Assert.IsNotNull(correo.Paquetes);
        }

        [TestMethod]
        public void TestPaqueteDuplicado()
        {
            Correo correo = new Correo();
            Paquete p1 = new Paquete("Corrientes", "930");
            Paquete p2 = new Paquete("Corrientes", "930");

            correo += p1;
            int i = 0;
            try
            {
                correo += p2;
                
            }
            catch (Exception e)
            {
                i = 1;
            }

            if (i != 1)
                Assert.Fail();
        }
    }
}
