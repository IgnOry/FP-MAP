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

        [TestMethod]

        public void GetMovesSinConexion()
        {
            //Arrange
            Map mapa = new Map(1, 1);
            mapa.GeneraConexionesAuxiliar(mapa, 0);

            //Act
            string resultado;
            resultado = mapa.GetMoves(0);

            //Assert
            Assert.AreEqual(" ", resultado, "El lugar no tiene conexiones");

        }

        [TestMethod]

        public void GetMovesVacio()
        {
            //Arrange
            Map mapa = new Map(0, 0);
           
            //Act
            try
            {
                string resultado;
                resultado = mapa.GetMoves(0);
                Assert.Fail("FALLO: No lanza una excepción cuando debería lanzarla");
            }
            catch (AssertFailedException) { throw; }
            catch (Exception) { }
            
        }

        [TestMethod]

        public void GetMovesUnoDeCada() //No va 
        {
            //Arrange
            Map mapa = new Map(1, 1);
            mapa.GeneraConexionesAuxiliar2(mapa, 0);

            //Act
            string resultado;
            resultado = mapa.GetMoves(0);

            //Assert
            Assert.AreEqual(" ", resultado, "El lugar no tiene conexiones");

        }

        [TestMethod]

        public void GetMovesTodosIguales() //No va
        {
            //Arrange
            Map mapa = new Map(1, 1);
            mapa.GeneraConexionesAuxiliar3(mapa, 0);

            //Act
            string resultado;
            resultado = mapa.GetMoves(0);

            //Assert
            Assert.AreEqual(" ", resultado, "El lugar no tiene conexiones");

        }

        [TestMethod]

        public void GetNumItemsVacio()
        {
            //Arrange
            Map mapa = new Map(0, 0);
            
            //Act
            try
            {
                int resultado;
                resultado = mapa.GetNumItems(0);
                Assert.Fail("FALLO: No lanza una excepción cuando debería lanzarla");
            }
            catch (AssertFailedException) { throw; }
            catch (Exception) { }

        }

        [TestMethod]

        public void GetNumItems0() //Por terminar
        {
            //Arrange
            Map mapa = new Map(3, 0);
         
            //Act
            bool resultado = true;
            for (int i = 0; i < mapa.places.Length; i++)
                resultado = mapa.isSpaceShip(i);

            //Assert
            Assert.AreEqual(false, resultado, "Ningun lugar es Spaceship");

        }

        public void GetNumItemsNormal() //Por terminar
        {
            //Arrange
            Map mapa = new Map(3, 1);
           
            //Act
            bool resultado = true;
            for (int i = 0; i < mapa.places.Length; i++)
                resultado = mapa.isSpaceShip(i);

            //Assert
            Assert.AreEqual(false, resultado, "Ningun lugar es Spaceship");

        }

        [TestMethod]

        public void GetItemInfoGeneral()
        {
            //Arrange
            Map mapa = new Map(1, 1);
            mapa.items[0].name = "Newspapers1";
            mapa.items[0].description = "News";
            //Act
            string resultado;
            resultado = mapa.GetItemInfo(0);

            //Assert
            Assert.AreEqual("0: Newspapers1 News", resultado, "La descripción del item no coincide con la esperada");

        }

        [TestMethod]

        public void GetItemInfoNoItem()
        {
            //Arrange
            Map mapa = new Map(1,0);
            
            //Act
            try
            {
                string resultado;
                resultado = mapa.GetItemInfo(0);
                Assert.Fail("FALLO: No lanza una excepción cuando debería lanzarla");
            }
            catch (AssertFailedException) { throw; }
            catch (Exception) { }
        }

        [TestMethod]

        public void GetItemsPlaceGeneral() 
        {
            //Arrange
            Map mapa = new Map(1, 1);
            mapa.items[0].name = "Newspapers1";
            mapa.items[0].description = "News";
            //Act

            string resultado;
            resultado = mapa.GetItemInfo(0);

            //Assert
            Assert.AreEqual("0: Newspapers1 News", resultado, "La descripción del item no coincide con la esperada");

        }

        [TestMethod]

        public void GetItemPlaceNoItem() 
        {
            //Arrange
            Map mapa = new Map(1, 0);

            //Act
            try
            {
                string resultado;
                resultado = mapa.GetItemInfo(0);
                Assert.Fail("FALLO: No lanza una excepción cuando debería lanzarla");
            }
            catch (AssertFailedException) { throw; }
            catch (Exception) { }
        }

        [TestMethod]

        public void PickItemPlaceGeneral()
        {
            //Arrange
            Map mapa = new Map(1, 1);
            mapa.places[0].itemsInPlace = new Lista();
            mapa.places[0].itemsInPlace.InsertaItem(0);

            //Act
            
                int resultado;
                mapa.PickItemPlace(0, 0);
                resultado = mapa.GetNumItems(0);

            //Assert
            Assert.AreEqual(0, resultado, "No hay items en el lugar");

        }

        [TestMethod]

        public void PickItemPlaceNoLugar()
        {
            //Arrange
            Map mapa = new Map(0, 1);
           
            //Act
            try
            {
                mapa.places[0].itemsInPlace = new Lista();
                mapa.places[0].itemsInPlace.InsertaItem(0);
                int resultado;
                mapa.PickItemPlace(0, 0);
                Assert.Fail("FALLO: No lanza una excepción cuando debería lanzarla");
                resultado = mapa.GetNumItems(0);
            }
            catch (AssertFailedException) { throw; }
            catch (Exception) { }
        }


        [TestMethod]

        public void PickItemPlaceNoItems()
        {
            //Arrange
            Map mapa = new Map(1, 0);
            mapa.places[0].itemsInPlace = new Lista();

            //Act
            try
                {
                int resultado;
                mapa.PickItemPlace(0, 0);
                resultado = mapa.GetNumItems(0);
                Assert.Fail("FALLO: No lanza una excepción cuando debería lanzarla");
                }
            catch (AssertFailedException) { throw; }
            catch (Exception) { }
        }

        [TestMethod]

        public void DropItemPlaceGeneral()
        {
            //Arrange
            Map mapa = new Map(1, 1);
            mapa.places[0].itemsInPlace = new Lista();

            //Act

            int resultado;
            mapa.places[0].itemsInPlace.InsertaItem(0);
            resultado = mapa.GetNumItems(0);

            //Assert
            Assert.AreEqual(1, resultado, "No hay items en el lugar");

        }

        [TestMethod]

        public void DropItemPlaceNoPlace()
        {
            //Arrange
            Map mapa = new Map(0, 1);


            //Act
            try
            {
                mapa.places[0].itemsInPlace = new Lista();
                Assert.Fail("FALLO: No lanza una excepción cuando debería lanzarla");
                mapa.places[0].itemsInPlace.InsertaItem(0);
                int resultado;
                mapa.places[0].itemsInPlace.InsertaItem(0);
                resultado = mapa.GetNumItems(0);
            }
            catch (AssertFailedException) { throw; }
            catch (Exception) { }
        }

        [TestMethod]

        public void MoveGeneral() //No se como poner el assert para que pille los valores del array
        {
            //Arrange
            Map mapa = new Map(2, 1);
            mapa.GeneraConexionesAuxiliar2(mapa, 0);

            //Act

            int[] resultados = new int[4];
            resultados[0]=mapa.Move(0, Direction.North);
            resultados[1] = mapa.Move(0, Direction.West);
            resultados[2] = mapa.Move(0, Direction.South);
            resultados[3] = mapa.Move(0, Direction.East);

            //Assert
            Assert.AreEqual(1, resultados, "Las direcciones no corresponden");
        }

        [TestMethod]

        public void MoveNoPlace() 
        {
            //Arrange
            Map mapa = new Map(0, 1);

            //Act
            try
            {
                mapa.GeneraConexionesAuxiliar2(mapa, 0);
                Assert.Fail("FALLO: No lanza una excepción cuando debería lanzarla");
            }
            catch (AssertFailedException) { throw; }
            catch (Exception) { }
        }

        [TestMethod]


        public void MoveSinSalida() //Lo mismo con el array
        {
            //Arrange
            Map mapa = new Map(1, 1);

            //Act

            int[] resultados = new int[4];
            mapa.GeneraConexionesAuxiliar(mapa, 0);
            resultados[0] = mapa.Move(0, Direction.North);
            resultados[1] = mapa.Move(0, Direction.West);
            resultados[2] = mapa.Move(0, Direction.South);
            resultados[3] = mapa.Move(0, Direction.East);

            //Assert
            Assert.AreEqual(1, resultados, "Las direcciones no corresponden");
        }

        [TestMethod]

        public void isSpaceShipSi() 
        {
            //Arrange
            Map mapa = new Map(1, 1);
            mapa.places[0].spaceShip = true;

            //Act
            bool resultado;
            resultado = mapa.isSpaceShip(0);

            //Assert
            Assert.AreEqual(true, resultado, "El lugar es SpaceShip");

        }

        [TestMethod]

        public void isSpaceShipNo() 
        {
            //Arrange
            Map mapa = new Map(1, 1);
            mapa.places[0].spaceShip = false;

            //Act
            bool resultado;
            resultado = mapa.isSpaceShip(0);

            //Assert
            Assert.AreEqual(false, resultado, "El lugar no es SpaceShip");

        }

        [TestMethod]

        public void isSpaceShipVacio() 
        {
            //Arrange
            Map mapa = new Map(0, 0);

            //Act
            try
            {
                bool resultado;
                resultado = mapa.isSpaceShip(0);
                Assert.Fail("FALLO: No lanza una excepción cuando debería lanzarla");
            }
            catch (AssertFailedException) { throw; }
            catch (Exception) { }
                   
        }

        [TestMethod]

        public void isSpaceShipVariosSi() 
        {
            //Arrange
            Map mapa = new Map(3, 1);
            mapa.places[0].spaceShip = false;
            mapa.places[1].spaceShip = false;
            mapa.places[2].spaceShip = true;


            //Act
            bool resultado = false;
            for (int i = 0; i < mapa.places.Length; i++)
                resultado = mapa.isSpaceShip(i);

            //Assert
            Assert.AreEqual(true, resultado, "El lugar final es Spaceship");

        }

        [TestMethod]

        public void isSpaceShipVariosNo()
        {
            //Arrange
            Map mapa = new Map(3, 1);
            mapa.places[0].spaceShip = false;
            mapa.places[1].spaceShip = false;
            mapa.places[2].spaceShip = false;


            //Act
            bool resultado = true;
            for (int i = 0; i < mapa.places.Length; i++)
                resultado = mapa.isSpaceShip(i);

            //Assert
            Assert.AreEqual(false, resultado, "Ningun lugar es Spaceship");

        }

        [TestMethod]

        public void CreatePlace() //Hay que hacerlos
        {
            //Arrange
            Map mapa = new Map(3, 1);
            mapa.places[0].spaceShip = false;
            mapa.places[1].spaceShip = false;
            mapa.places[2].spaceShip = false;


            //Act
            bool resultado = true;
            for (int i = 0; i < mapa.places.Length; i++)
                resultado = mapa.isSpaceShip(i);

            //Assert
            Assert.AreEqual(false, resultado, "Ningun lugar es Spaceship");

        }

        [TestMethod]

        public void CreateItem() //Hay que hacerlos
        {
            //Arrange
            Map mapa = new Map(3, 1);
            mapa.places[0].spaceShip = false;
            mapa.places[1].spaceShip = false;
            mapa.places[2].spaceShip = false;


            //Act
            bool resultado = true;
            for (int i = 0; i < mapa.places.Length; i++)
                resultado = mapa.isSpaceShip(i);

            //Assert
            Assert.AreEqual(false, resultado, "Ningun lugar es Spaceship");

        }

        //Tests Walle

        [TestMethod]

        public void Move() //Hay que hacerlos
        {
            //Arrange
            Map mapa = new Map(3, 1);
            mapa.places[0].spaceShip = false;
            mapa.places[1].spaceShip = false;
            mapa.places[2].spaceShip = false;


            //Act
            bool resultado = true;
            for (int i = 0; i < mapa.places.Length; i++)
                resultado = mapa.isSpaceShip(i);

            //Assert
            Assert.AreEqual(false, resultado, "Ningun lugar es Spaceship");

        }

        [TestMethod]

        public void CreatePlaceManual() //
        {
            //Arrange
            Map mapa = new Map(2, 1);
            mapa.places[0].name = "PlazaMayor";
            mapa.places[0].spaceShip = false;
            mapa.places[0].description = "Descripción descripción2";


            //Act
            //mapa.CreatePlace(new string[] { "place", "0", "PlazaMayor", "noSpaceShip" } );   //PROBLEMA, LE PASAMOS EL STREAMREADER ENTRADA

            //Assert
            //Assert.AreEqual("PlazaMayor", resultado, "Ningun lugar es Spaceship");
            //Assert.AreEqual(false, resultado, "Ningun lugar es Spaceship");

        }

        [TestMethod]

        public void CreateStreetNorte()
        {
            //Arrange
            Map mapa = new Map(2, 1);
            string [] texto = { "street", "0", "place", "0", "north", "place", "3" };

            //Act
            mapa.CreateStreet(texto);

            //Assert
            Assert.AreEqual(3, mapa.places[0].connections[0], "La conexión norte del lugar 0 es el 3");
            
        }

        [TestMethod]

        public void CreateStreetSur()
        {
            //Arrange
            Map mapa = new Map(1, 1);
            string[] texto = { "street", "0", "place", "0", "south", "place", "5" };

            //Act
            mapa.CreateStreet(texto);

            //Assert
            Assert.AreEqual(0, mapa.places[0].connections[0], "La conexión sur del lugar 0 es el 0");

        }

        [TestMethod]

        public void CreateItemTest()  //no funciona porque usa métodos de las listas
        {
            //Arrange
            Map mapa = new Map(1, 1);
            string[] texto = { "garbage", "0", "Newpapers1", "place", "0", "\"News\"" };

            //Act
            mapa.CreateItem(texto);

            //Assert

            // Nombre
            Assert.AreEqual("Newpapers1", mapa.items[0].name, "Nobre del item erróneo");
            // Descripción
            Assert.AreEqual("\"News\"", mapa.items[0].description, "Descripción del item errónea");

        }

        // MÉTODOS DE WALLE - - - - - HAY QUE HACER UNA CONSTRUCTORA DE MAPA (con lugares del 0 al 3)

        [TestMethod]

        public void WallEMove10()  //no funciona porque usa métodos de las listas
        {
            //Arrange
            Map mapa = new Map(2, 1);
            WallE.WallE w = new WallE.WallE();
            w.pos = 1;
            mapa.GeneraConexionesAuxiliar2(mapa, 0);

            //Act
            w.Move(mapa,Direction.North);

            //Assert
            Assert.AreEqual(0, w.GetPosition(), "WallE no se ha movido a la posicion 3");
        }

        [TestMethod]

        public void WallEMove31()  //no funciona porque usa métodos de las listas
        {
            //Arrange
            Map mapa = new Map(4, 1);
            WallE.WallE w = new WallE.WallE();
            w.pos = 3;
            mapa.GeneraConexionesAuxiliar2(mapa, 2);


            //Act
            w.Move(mapa, Direction.West);

            //Assert
            Assert.AreEqual(0, w.GetPosition(), "WallE no se ha movido a la posicion 1");
        }

        [TestMethod]

        public void WallEMove31NoPlace()  
        {
            //Arrange
            Map mapa = new Map(1, 1);
            WallE.WallE w = new WallE.WallE();
            w.pos = 3;

            //Act-Assert
            try
            {
                w.Move(mapa, Direction.West);
                Assert.Fail("FALLO: No lanza una excepción cuando debería lanzarla");
            }
            catch (AssertFailedException) { throw; }
            catch (Exception) { }

        }

        [TestMethod]

        public void PickItemGeneral()
        {
            //Arrange
            Map mapa = new Map(1, 1);
            WallE.WallE w = new WallE.WallE();

            //Act
            mapa.places[0].itemsInPlace = new Lista();
            mapa.places[0].itemsInPlace.InsertaItem(0);
            w.PickItem(mapa, 0);
            int resultado = w.bag.ItemsLista();

            //Assert
            Assert.AreEqual(1, resultado, "Hay 1 objeto en Bag");
        }

        [TestMethod]

        public void PickItemNoItem()
        {
            //Arrange
            Map mapa = new Map(1, 0);
            WallE.WallE w = new WallE.WallE();
            w.bag = new Lista();

            //Act-Assert
            try
            {
                w.PickItem(mapa, 0);
                w.bag.ItemsLista();
                Assert.Fail("FALLO: No lanza una excepción cuando debería lanzarla");
            }
            catch (AssertFailedException) { throw; }
            catch (Exception) { }
                      
        }

        [TestMethod]

        public void DropItemGeneral()
        {
            //Arrange
            Map mapa = new Map(1, 1);
            WallE.WallE w = new WallE.WallE();

            //Act
            mapa.places[0].itemsInPlace = new Lista();
            mapa.places[0].itemsInPlace.InsertaItem(0);
            w.PickItem(mapa, 0);
            int resultado = w.bag.ItemsLista();

            //Assert
            Assert.AreEqual(1, resultado, "Hay 1 objeto en Bag");
        }

        [TestMethod]

        public void DropItemNoItem()
        {
            //Arrange
            Map mapa = new Map(1, 1);
            WallE.WallE w = new WallE.WallE();

            //Act
            w.bag.InsertaItem(0);
            mapa.places[0].itemsInPlace = new Lista();
            w.DropItem(mapa, 0);
            int resultado = mapa.places[0].itemsInPlace.ItemsLista();

            //Assert
            Assert.AreEqual(1, resultado, "Hay 1 objeto en el mapa");
        }

        [TestMethod]

        public void BagVacia()
        {
            //Arrange
            Map mapa = new Map(1, 1);
            WallE.WallE w = new WallE.WallE();

            //Act
            string resultado = w.Bag(mapa);

            //Assert
            Assert.AreEqual("Empty bag...", resultado, "No hay objeto en Bag");
        }

        [TestMethod]

        public void Bag() //Hay que hacerlo
        {
            //Arrange
            Map mapa = new Map(1, 1);
            WallE.WallE w = new WallE.WallE();

            //Act
            string resultado = w.Bag(mapa);

            //Assert
            Assert.AreEqual("Empty bag...", resultado, "No hay objeto en Bag");
        }

        [TestMethod]

        public void atSpaceShip()
        {
            //Arrange
            WallE.WallE w = new WallE.WallE();
            Map mapa = new Map(1, 1);
            mapa.places[0].spaceShip = true;

            //Assert
            Assert.AreEqual(true, w.atSpaceShip(mapa), "Está en Spaceship");

        }

        [TestMethod]

        public void atSpaceShipNoPlace()
        {
            //Arrange
            WallE.WallE w = new WallE.WallE();
            Map mapa = new Map(0, 1);

            try
            {
                mapa.places[0].spaceShip = true;
                Assert.Fail("FALLO: No lanza una excepción cuando debería lanzarla");
            }
            catch (AssertFailedException) { throw; }
            catch (Exception) { }
        }
    }
}
