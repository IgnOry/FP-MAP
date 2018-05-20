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

		
        public void insertaFin(int e)
        {
            Nodo aux = pri;

            if (aux == null)
                InsertaItem(e);
            else
            {
                while (aux.sig != null)
                {
                    aux = aux.sig;
                }

                aux.sig = new Nodo(e);
            }

        }

        public bool BorraElto(int e)
        {
            Nodo aux = pri;
            bool borrado = false;

            if (pri != null)
            {
                if (aux.dato == e)
                {
                    pri = aux.sig;
                    borrado = true;
                }
                else
                {
                    while (aux != null && aux.sig != null && aux.sig.dato != e)
                        aux = aux.sig;

                    if (aux.sig != null && aux.sig.dato == e) 
                    {
                        aux.sig = aux.sig.sig;
                        borrado = true;
                    }
                }
            }

            return borrado;
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

        public bool BuscaItem (int e)
        {
            bool encontrado = false;

            if (pri == null)
                throw new Exception("Lista vacia");

            Nodo aux = pri;

            int total = ItemsLista();

            for (int i = 0; i < total; i++)
            {
                if (aux.dato == e)
                    encontrado = true;
                aux = aux.sig;
            }

            return encontrado;

        }

        public void EliminaItem(int nItem)
        {
            if (pri == null || nItem < 0 || nItem >= ItemsLista())
                throw new Exception("No existe");

            Nodo aux = pri;

            //si hay sólo 1 elemento
            if (aux.sig == null || nItem == 0)
                pri = aux.sig;
           
            else
            {
                Nodo copia = aux.sig;

                for (int i = 1; i < nItem; i++)
                {
                    aux = aux.sig;
                    copia = copia.sig;
                }
                aux.sig = copia.sig;
            }

        }


        public void InsertaItem(int nItem) //inserta al principio
		{
			Nodo Item = new Nodo(nItem);

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
