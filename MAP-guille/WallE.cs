//David Carmona Fauste
//Ignacio Ory Alonso
using System;
using Listas;

namespace WallE
{
	public class WallE
	{
		public int pos;        // posicion de Wall-e en el mapa  //público para test
		public Lista bag;      // lista de items recogidos por wall-e
						       // (son indices a la lista de items del mapa)

		public WallE()
		{
			pos = 0;
			bag = new Lista();
		}

		public int GetPosition() 
		{
			return pos;
		}

        public void Move(Map m, Direction dir) //Existe direccion
		{
            if (m.places[pos].connections[(int)dir] != -1)
			    pos = m.Move(pos, dir);
            else
                throw new Exception("No existe esa conexión");
		}

		public void PickItem(Map m, int it) //Si existe item
		{
            if (m.places[pos].itemsInPlace.BuscaItem(it))
            {
                m.PickItemPlace(pos, it);
                bag.insertaFin(it);
                
            }
            else
                throw new Exception("El objeto no está en este lugar");
		}

        public void DropItem(Map m, int it) //Si existe item
		{
            if (bag.BorraElto(it))
            {
                m.DropItemPlace(pos, it);
            }
            else
                throw new Exception("El objeto no está en la mochila");
		}

		public string Bag(Map m)
		{
			string devolver = "";
			int totalItems = bag.ItemsLista();
			int aux;
			for (aux = 0; aux < totalItems; aux++)
			{
				devolver = devolver + m.GetItemInfo(bag.BuscaItemEnPos(aux)) + "\n";
			}
			if (aux == 0)
				devolver = "Empty bag...";
			return devolver;
		}

		public bool atSpaceShip(Map map)
		{
			return map.isSpaceShip(pos);
		}
	}
}