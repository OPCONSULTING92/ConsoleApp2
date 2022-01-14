using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenue dans le jeu du plus ou moins.");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Un nombre va être généré aléatoirement, et votre objectif est de le trouver.");
            Console.WriteLine("Le programme vous renverra + ou - en fonction de votre réponse.");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("voulez vous commencer le jeu ? (o/n)");
            String startReponse = Console.ReadLine();
            bool nombreTrouve= false;
            if (startReponse == "o")
            {
                int nombreAleatoire = NombreAleatoire();
                int number;
                while (nombreTrouve != true)
                {
                    Console.WriteLine("devinez le nombre");
                    String reponseUtilisateur = Console.ReadLine().ToString();
                    bool success = int.TryParse(reponseUtilisateur, out number);

                    if (success)
                    {
                        nombreTrouve = AnalyseEntier(nombreAleatoire, number);

                    }
                    else
                    {
                        Console.WriteLine($"Attempted conversion of '{reponseUtilisateur ?? "<null>"}' failed.");
                    }
                }
                Console.ReadKey();
     
            } else if (startReponse == "n")
            {
                Console.WriteLine("Le jeu ne commence pas encore, appuyez sur o pour commencer");
                startReponse = Console.ReadKey().ToString();
            } else
            {
                // thow exception;
            }

        }

        private static bool AnalyseEntier(int nombreAleatoire,int number)
        {

            String retourMethode = "";
            if (nombreAleatoire < number)
            {
                //Console.WriteLine("nombre {0} est trop haut", number.ToString());
                retourMethode = "+";
            } else if (nombreAleatoire > number)
            {
                retourMethode = "-";
            } else
            {
                retourMethode = "=";
            }
            switch (retourMethode)
            {
                case "+":
                    Console.WriteLine("nombre {0} est trop haut", number.ToString());
                    return false;
                case "-":
                    Console.WriteLine("nombre {0} est trop bas", number.ToString());
                    return false;
                case "=":
                    Console.WriteLine("Bien joué le nombre était : {0}", number.ToString());
                    return true;
            }
            return false;


        }

        private static int NombreAleatoire()
        {
            Random aleatoire = new Random();
            int entier = aleatoire.Next(1,1000);
            return entier;
        }
    }
}
