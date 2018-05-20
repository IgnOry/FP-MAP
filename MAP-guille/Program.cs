//David Carmona Fauste
//Ignacio Ory Alonso
using System;
using System.IO;
using Listas;
using WallE;

namespace WallE
{
	class MainClass
	{
		static bool quit = false;

		const int NITEMS = 3, NPLACES = 10;

		static void ProcesaInput(string com, WallE w, Map m)
		{
			string[] coms;
			coms = com.Split(' ');

			switch (coms[0])
			{
				case ("go"):
					//convertidor a direcciones
					switch (coms[1])
					{
						case "north":
							w.Move(m, Direction.North);
							break;
						case "south":
							w.Move(m, Direction.South);
							break;
						case "east":
							w.Move(m, Direction.East);
							break;
						case "west":
							w.Move(m, Direction.West);
							break;
						default:
							throw new Exception ("Dirección no reconocida");
					}
					break;
				case ("pick"):
					w.PickItem(m, int.Parse(coms[1]));
					break;
				case ("drop"):
					w.DropItem(m, int.Parse(coms[1]));
					break;
				case ("items"):
					Console.WriteLine(m.GetItemsPlace(w.GetPosition()));
					break;
				case ("info"):
					Console.WriteLine(m.GetPlaceInfo(w.GetPosition()));
					break;
				case ("bag"):
					Console.WriteLine(w.Bag(m));
					break;
				case ("quit"):
					quit = true;
					break;
			default:
				throw new Exception ("Comando no reconocido");
			}
		}

		static void Main()
		{
			Map m = new Map(NPLACES, NITEMS);

			WallE w = new WallE();
		
			m.ReadMap("madrid.map");

			//StreamReader
			SelectorCarga (w, m); 

			MuestraComandos ();
            //StreamWriter
            StreamWriter archivo = new StreamWriter ("partida guardada.txt");

			while (!quit && !w.atSpaceShip (m))
			{
				string input = LeeInput();
				try{
				ProcesaInput(input, w, m);
				}
				catch (Exception e) 
				{
					Console.WriteLine(e.Message);
				}

				if (input != "quit")
					GuardaComandos(input, archivo);
			}
			archivo.Close();
		}

		// Método auxiliar para leer el input, devuelve el input en string
		static string LeeInput()
		{
			string input;
			Console.Write(">");
			input = Console.ReadLine();
			return input;
		}


		static void MuestraComandos()
		{
			Console.WriteLine("\n Este juego reconoce los siguientes comandos:");
			Console.WriteLine("\t-\"go\" seguido de una dirección (\"north\", \"south\", \"east\", \"west\")");
			Console.WriteLine("\t-\"pick\" seguido de un número");
			Console.WriteLine("\t-\"drop\" seguido de un número");
			Console.WriteLine("\t-\"info\"");
            Console.WriteLine("\t-\"items\"");
            Console.WriteLine("\t-\"bag\"");
			Console.WriteLine("\t-\"quit\"");
		}

		//Lee y ejecuta los comandos de un archivo de texto llamado "comandos"
		static void LeeComandos(WallE w, Map m, string txt, StreamReader archivo)
		{
			string comando;

			while ((comando = archivo.ReadLine()) != null)
			{
				ProcesaInput(comando, w, m);
			}
			archivo.Close();
		}

		//guarda los comandos que vamos ejecutando para poder recuperar después la partida (ejecutándolos)
		static void GuardaComandos(string comando, StreamWriter archivo)
		{
			archivo.WriteLine(comando);
		}

		static void SelectorCarga(WallE w, Map m)
		{
			string respuesta ="";
			bool control = false;

			while (!control)
			{
				control = CargaPartida (w, m, out respuesta);
			}

			if (respuesta == "no") 
			{
				control = false;

				while (!control)
				{
					control = CargaComandos (w, m);
				}			
			}
		}

		static bool CargaPartida(WallE w, Map m, out string respuesta)
		{
			Console.WriteLine ("Cargar partida guardada (si/no)");
			respuesta = Console.ReadLine ();

			if (respuesta == "si") 
			{
				if (!File.Exists ("partida guardada.txt")) {

					// crea el archivo con los comandos ejecutados

					StreamWriter comandosTxt = new StreamWriter ("partida guardada.txt");
					comandosTxt.Close ();
				}

				StreamReader txt = new StreamReader ("partida guardada.txt");
				LeeComandos (w, m, "partida guardada.txt", txt);
				txt.Close ();
				Console.Clear ();
				return true;
			}

			else if (respuesta == "no") {
					return true;
				} 

				else 
				{
					Console.WriteLine ("Comando desconocido");
					return false;
				}
			} 

		static bool CargaComandos(WallE w, Map m)
		{
			Console.WriteLine ("Cargar un archivo de instrucciones (si/no)");
			string respuesta = Console.ReadLine ();
			if (respuesta == "si")
			{
				StreamReader txt = new StreamReader("comandos.txt");
				LeeComandos(w, m, "comandos.txt", txt);
				txt.Close();
				return true;
			}
			else if (respuesta == "no")
				return true;
			else
			{
				Console.WriteLine("Comando desconocido");
				return false;
			}
		}
	}
}