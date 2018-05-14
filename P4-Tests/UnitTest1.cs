using System;
using Listas;
using WallE;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PracticaMap4
{
    [TestClass]
    public class TestLista
    {
        [TestMethod]
        public void CuentaEltos()
        {
            //Arrange
            Lista L1 = new Lista(3, 2);


            //Act
            int cuenta = L1.ItemsLista();



            //Assert

            Assert.AreEqual(6, cuenta, "No, esta lista tiene 6 elementos");

        }

        [TestMethod]
        public void CuentaEltosVacia()
        {
            //Arrange
            Lista L3 = new Lista(0, 0);

            //Act
            int cuenta3 = L3.ItemsLista();

            //Assert
            Assert.AreEqual(0, cuenta3, "No, esta lista tiene 0 elementos");
        }

        [TestMethod]
        public void InsertaFin()
        {
            //Arrange
            Lista L3 = new Lista(3, 2);

            //Act
            L3.InsertaItem(3);
            int busca = L3.BuscaItemEnPos(6);

            //Assert
            Assert.AreEqual(3, busca, "No, el último elemento es el 3");
        }

        [TestMethod]
        public void InsertaFinVacio()
        {
            //Arrange
            Lista L3 = new Lista(0, 0);

            //Act
            L3.InsertaItem(3);
            int cuenta3 = L3.BuscaItemEnPos(0);

            //Assert
            Assert.AreEqual(3, cuenta3, "No, el ultimo elemento es 3");
        }

        [TestMethod]
        public void BorraElto()
        {
            //Arrange
            Lista L3 = new Lista(3, 2);

            //Act
            L3.EliminaItem(1);
            int cuenta = L3.ItemsLista();
            string conteo = L3.Cadena();

            //Assert
            Assert.AreEqual(5, cuenta, "La nueva lista tiene tamaño 5");
            Assert.AreEqual("1:2:1:2:3", conteo, "La nueva lista es 1:2:1:2:3");
        }

        [TestMethod]

        public void BorraEltoVacio()
        {
            //Arrange
            Lista L3 = new Lista(0, 0);

            //Act
            try
            {
                L3.EliminaItem(3);
                int cuenta3 = L3.BuscaItemEnPos(0);
                Assert.Fail("FALLO: No lanza una excepción cuando debería lanzarla");
            }

            catch (AssertFailedException) { throw; }
            catch (Exception) { }

            //Assert
            
        }

        [TestMethod]

        public void BorraEltoPrimero()
        {
            //Arrange
            Lista L3 = new Lista(3, 1);

            //Act
            L3.EliminaItem(0);
            int cuenta3 = L3.BuscaItemEnPos(0);

            //Assert
            Assert.AreEqual(2, cuenta3, "El primer elemento no es 1, es 2");
        }

        [TestMethod]

        public void BorraEltoUltimo()
        {
            //Arrange
            Lista L3 = new Lista(3, 1);

            //Act
            L3.EliminaItem(1);
            int cuenta3 = L3.BuscaItemEnPos(1);
            string conteo = L3.Cadena();

            //Assert
            Assert.AreEqual(2, cuenta3, "El último elemento es 2");
            Assert.AreEqual("1:2", conteo, "La nueva lista es 1:2");

        }

        [TestMethod]

        public void nEsimo ()
        {
            //Arrange
            Lista L3 = new Lista(3,2);

            //Act
            int cuenta3 = L3.BuscaItemEnPos(2);

            //Assert
            Assert.AreEqual(3, cuenta3, "El tecer elemetno e el 3");

        }

        [TestMethod]

        public void nEsimoVacia()
        {
            //Arrange
            Lista L3 = new Lista(0, 0);

            //Act
            try
            {
                int cuenta3 = L3.BuscaItemEnPos(3);
                Assert.Fail("FALLO: No lanza una excepción cuando debería lanzarla");
            }
            catch (AssertFailedException) { throw; }
            catch (Exception) {}
            //Assert
           //Assert.AreEqual(excepcion, "El tecer elemetno e el 3");
        }

        [TestMethod]
        public void TestnEsimoNegativo()
        {
            // Arrange
            Lista l = new Lista(3, 2);
            //Act
            Assert.AreEqual(1, 1);
            try
            {
                int n = l.BuscaItemEnPos(-3);
                Assert.Fail("FALLO: No lanza una excepción cuando debería lanzarla");
            }
            catch (AssertFailedException) { throw; }
            catch (Exception) { }
        }

        [TestMethod]

        public void nEsimoPrimero()
        {
            //Arrange
            Lista L3 = new Lista(3, 2);

            //Act
            int cuenta3 = L3.BuscaItemEnPos(0);

            //Assert
            Assert.AreEqual(1, cuenta3, "El primer elemento es el 1");

        }


        [TestMethod]

        public void nEsimoUltimo()
        {
            //Arrange
            Lista L3 = new Lista(3, 2);

            //Act
            int cuenta3 = L3.BuscaItemEnPos(5);

            //Assert
            Assert.AreEqual(3, cuenta3, "El tecer elemetno e el 3");

        }
    }
}
