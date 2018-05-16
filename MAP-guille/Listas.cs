//David Carmona Fauste
//Ignacio Ory Alonso
using System;

namespace Listas
{
	public class Lista
	{
		private class Nodo
		{
			public int dato;
			public Nodo sig;

			public Nodo(int e)
			{
				dato = e;
			}
		}

		Nodo pri;

		public Lista()
		{
			pri = null;
		}

		public Lista(int limite, int rep)
		{
			pri = null;
			Nodo aux = pri;

			for (int aux1 = 0; aux1 < rep; aux1++)
			{
				for (int aux2 = 1; aux2 <= limite; aux2++)
				{
					Nodo nodo = new Nodo(aux2);
					if (aux2 == 1 && aux1 == 0)
						pri = nodo;
					else
						aux.sig = nodo;

					aux = nodo;
				}
			}
		}


		private Nodo buscaNodo()
		{
			Nodo aux = pri;
			while (aux.sig != null)
				aux = aux.sig;

			return aux;
		}

		public void InsertaItem(int e)
		{
			Nodo nuevo = new Nodo(e);

			if (pri == null)
			{
				pri = nuevo;
				nuevo.sig = null;
			}

			else
			{
				Nodo aux = buscaNodo();

				aux.sig = nuevo;
				nuevo.sig = null;
			}
		}

		public int ItemsLista()
		{
			Nodo aux = pri;
			int total = 0;

			while (aux != null)
			{
				aux = aux.sig;
				total++;
			}

			return total;
		}

		public int BuscaItemEnPos(int pos)
		{
            if (pos < 0)
                throw new Exception("Lista vacia");
      
                Nodo aux = pri;

                for (int i = 0; i < pos; i++)
                    aux = aux.sig;

                return aux.dato;
                       
		}

		public void EliminaItem(int nItem)
        {
            if (pri == null)
                throw new Exception("No existe");

			Nodo aux = pri;
			Nodo copia = aux;
			int i = 0;

			if (copia != null && nItem <= ItemsLista())
			{
				for (i = 0; i < nItem; i++)
				{
					aux = aux.sig;
					copia = aux.sig;
				}
			}

			if (i == 0)
				pri = copia.sig;

			else
				aux.sig = copia.sig;
		}

		public void InsertaItem2(int nItem) //inserta al principio
		{
			Nodo Item = new Nodo(nItem);

			Item.sig = pri;
			pri = Item;
		}

		public string Cadena()
		{
			string devolver = ("");

			Nodo aux = pri;

			while (aux != null)
			{
				devolver = devolver + aux.dato;
				if (aux.sig != null)
					devolver = devolver + ":";

				aux = aux.sig;
			}

			return devolver;
		}

    }

}
