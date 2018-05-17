//David Carmona Fauste
//Ignacio Ory Alonso
using System;
using System.IO;
using Listas;

namespace WallE
{
	// posibles direcciones 
	public enum Direction { North, South, East, West };

    #region Tests Map
    public class Map
	{ // items basura
		public struct Item
		{
			public string name, description;
		}
		// lugares del mapa 
		public struct Place
		{
			public string name, description;
			public bool spaceShip;
			public int[] connections;  // vector de 4 componentes
									   // con el lugar al norte, sur, este y oeste 
									   // -1 si no hay conexion
			public Listas.Lista itemsInPlace; // lista de enteros, indices al vector de items 
		}
		public Place[] places; // vector de lugares del mapa 
		public Item[] items; // vector de items del juego 
		int nPlaces, nItems; // numero de lugares y numero de items del mapa

		public Map(int numPlaces, int numItems)
		{
			items = new Item[numItems];
			places = new Place[numPlaces];

            nPlaces = numPlaces;
            nItems = numItems;

            for (int i = 0; i < numPlaces; i++)
            {
                places[i].connections = new int[4];
            }
		}

		public void ReadMap(string file)
		{
			StreamReader Mapa;
			Mapa = new StreamReader(file);
			string lectura;
			string[] lecturaS;

			while (!Mapa.EndOfStream)
			{
				lectura = Mapa.ReadLine();

				lecturaS = lectura.Split(' ');

				switch (lecturaS[0])
				{
					case ("place"):
						CreatePlace(lecturaS, Mapa);
						break;
					case ("street"):
						CreateStreet(lecturaS);
						break;
					case ("garbage"):
						CreateItem(lecturaS);
						break;
					default:
						break;
				}
			}
		}

		public void CreatePlace(string[] lectura, StreamReader entrada)
		{
			places[int.Parse(lectura[1])].name = lectura[2];

			if (lectura[3] == "noSpaceShip")
				places[int.Parse(lectura[1])].spaceShip = false;
			else
				places[int.Parse(lectura[1])].spaceShip = true;

			places[int.Parse(lectura[1])].connections = new int[] { -1, -1, -1, -1 };

			places[int.Parse(lectura[1])].description = ReadDescription(entrada);

			places[int.Parse(lectura[1])].itemsInPlace = new Lista();
		}

		public void CreateStreet(string[] lectura)
		{
			switch (lectura[4])
			{
				case "north":
					places[int.Parse(lectura[3])].connections[0] = int.Parse(lectura[6]);
					places[int.Parse(lectura[6])].connections[1] = int.Parse(lectura[3]);
					break;
				case "south":
					places[int.Parse(lectura[3])].connections[1] = int.Parse(lectura[6]);
					places[int.Parse(lectura[6])].connections[0] = int.Parse(lectura[3]);

					break;
				case "east":
					places[int.Parse(lectura[3])].connections[2] = int.Parse(lectura[6]);
					places[int.Parse(lectura[6])].connections[3] = int.Parse(lectura[3]);

					break;
				case "west":
					places[int.Parse(lectura[3])].connections[3] = int.Parse(lectura[6]);
					places[int.Parse(lectura[6])].connections[2] = int.Parse(lectura[3]);

					break;
			}
		}

		public void CreateItem(string[] lectura)
		{
			items[int.Parse(lectura[1])].name = lectura[2];
            for(int i = 5; i <  lectura.Length; i++)
                items[int.Parse(lectura[1])].description += lectura[i];

			places[int.Parse(lectura[4])].itemsInPlace.InsertaItem(int.Parse(lectura[1]));
		}

		private string ReadDescription(StreamReader f)
		{
			string descripcion = "";
			string lectura;

			do
			{
				lectura = f.ReadLine();

				descripcion = descripcion + "\n " + lectura;
			}
			while (lectura[lectura.Length - 1] != '\"');

			//quita comillas
			descripcion = descripcion.Substring (3,  descripcion.Length - 4);

			return descripcion;
		}

		public string GetPlaceInfo(int pl)
		{
			return places[pl].description;
		}

		public string GetMoves(int pl)
		{
			string devolver = (" ");

			for (int i = 0; i < 4; i++)
			{
				if (places[pl].connections[i] != -1)
				{
					switch (i)
					{
						case (0):
                            devolver = devolver + ("North: " + places[places[pl].connections[i]].name);
							break;
						case (1):
							devolver = devolver + ("South: " + places[places[pl].connections[i]].name);
							break;
						case (2):
							devolver = devolver + ("East: " + places[places[pl].connections[i]].name);
							break;
						case (3):
							devolver = devolver + ("West: " + places[places[pl].connections[i]].name);
							break;
					}
				}
			}
			return devolver;
		}

		public int GetNumItems(int pl)
		{
			return places[pl].itemsInPlace.ItemsLista(); //metodo auxiliar de lista
		}

		public string GetItemInfo(int it)
		{
			return (it + ": " + items[it].name + " " + items[it].description);
		}

		public string GetItemsPlace(int pl)
		{
			string devolver = "";
			int total = places[pl].itemsInPlace.ItemsLista();
			int it;

			for (int i = 0; i < total; i++)
			{
				it = places[pl].itemsInPlace.BuscaItemEnPos(i);
				devolver = devolver + "\n" + i + " " + items[it].name + " " + items[it].description;
			}
			return devolver;
		}

		public void PickItemPlace(int pl, int it)
		{
            //try
            //{
                places[pl].itemsInPlace.EliminaItem(it); //a este se le llama luego desde otro metodo
            //}
           // catch
            //{ throw new Exception("El objeto no está en este lugar"); }
		}

		public void DropItemPlace(int pl, int it)
		{
			places[pl].itemsInPlace.InsertaItem(it);
		}

		public int Move(int pl, Direction dir)     
		{
			int devolver = -1;

			switch (dir)
			{
				case Direction.North:
					devolver = places[pl].connections[0];
					break;
				case Direction.South:
					devolver = places[pl].connections[1];
					break;
				case Direction.East:
					devolver = places[pl].connections[2];
					break;
				case Direction.West:
					devolver = places[pl].connections[3];
					break;
			}

			return devolver;
		}

		public bool isSpaceShip(int pl)
		{
			return (places[pl].spaceShip);
		}

        public void GeneraConexionesAuxiliar(Map map, int i) //Para MAP
        {
            map.places[i].connections[0] = -1;
            map.places[i].connections[1] = -1;
            map.places[i].connections[2] = -1;
            map.places[i].connections[3] = -1;
        }

        public void GeneraConexionesAuxiliar2 (Map map, int i) //Para MAP
        {
            map.places[i].connections[0] = 0;
            map.places[i].connections[1] = 1;
            map.places[i].connections[2] = 2;
            map.places[i].connections[3] = 3;
        }

        public void GeneraConexionesAuxiliar3(Map map, int i) //Para MAP
        {
            map.places[i].connections[0] = 1;
            map.places[i].connections[1] = 1;
            map.places[i].connections[2] = 1;
            map.places[i].connections[3] = 1;
        }



        public void CreatePlaceManual (string[] lectura) //Para MAP
        {
            places[int.Parse(lectura[1])].name = lectura[2];

            if (lectura[3] == "noSpaceShip")
                places[int.Parse(lectura[1])].spaceShip = false;
            else
                places[int.Parse(lectura[1])].spaceShip = true;

            places[int.Parse(lectura[1])].connections = new int[] { -1, -1, -1, -1 };

            places[int.Parse(lectura[1])].itemsInPlace = new Lista();
        }
        #endregion
    }
}