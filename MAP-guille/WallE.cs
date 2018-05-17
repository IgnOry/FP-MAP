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

		public void Move(Map m, Direction dir)
		{
			pos = m.Move(pos, dir);
		}

		public void PickItem(Map m, int it)
		{
			bag.InsertaItem2(it);
			m.PickItemPlace(pos, it);
		}

		public void DropItem(Map m, int it)
		{
			m.DropItemPlace(pos, it);
			bag.EliminaItem(it);
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