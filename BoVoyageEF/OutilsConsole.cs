using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoVoyageEF
{
	public class OutilsConsole
	{
		public static void SerparateurMenu()
		{
			Console.WriteLine(new string('=', Console.WindowWidth));
		}

		public static void Commentaire(string text)
		{
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine(text);
			Console.ResetColor();
		}
		public static void CentrerTexte(string texte)
		{
			int winWidth = (Console.WindowWidth / 2 - 15);
			Console.WriteLine(new string(' ', winWidth) + $"{texte.PadRight(30)}\n");

		}
		public static void CentrerTexte(string text, ConsoleColor couleur)
		{
			Console.ForegroundColor = couleur;
			int winWidth = (Console.WindowWidth / 2 - 15);
			Console.WriteLine(new string(' ', winWidth) + $"{text.PadRight(30)}\n");
			Console.ResetColor();
		}
	}
}
