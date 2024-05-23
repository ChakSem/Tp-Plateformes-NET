using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int Index = 0; Index < args.Length; Index++)
            {
                Console.Out.WriteLine("\nFichier {0} :", Index);

                // Est ce qu'un paramètre a été passé à rapplication ?
                if (args.Length > 0 && File.Exists(args[Index]))
                {
                    // Ouvrons le fichier
                    /*StreamReader Sr = File.OpenText(args[0]);

                    string Ligne;
                    while ((Ligne = Sr.ReadLine()) != null)
                    {
                        // Affichons dans notre console, le contenue du fichier
                        Console.Out.WriteLine(Ligne);
                    }

                    Sr.Close(); // Fermons le fichier
                    Sr.Dispose(); // Assurons nous que toutes les ressources sont libérées
                    */

                    using (StreamReader Sr = File.OpenText(args[Index]))
                    { // Equivalent à try, rien à voir avec le using au dessus
                        string Ligne;
                        while ((Ligne = Sr.ReadLine()) != null)
                        {
                            // Affichons dans notre console, le contenue du fichier
                            Console.Out.WriteLine(Ligne);
                        }
                    }
                } else {
                    Console.Out.WriteLine("Probleme");
                }
            }

            try
            {
                using (StreamWriter Sr = File.AppendText(args[0]))
                {
                    // Petit exercice de découverte

                    Demander_Et_Ecrire(Sr);

                }
                
            }
            catch (ArgumentNullException)
            {
                // Si on arrive ici, c'est qu 'un argument vaut NULL
                // et que cela a généré une exception !
            }
            catch (Exception Err)
            {
                // Ici une autre exception a été générée : /
            }


            Console.Out.WriteLine("Appuyez sur une touche pour quitter...");
            Console.In.Read();
        }

        /// <summary>
        /// Demande à l'utilisateur de saisir du texte pour l'écrire dans le fichier.
        /// </summary>
        /// <param name="Sw">Objet <b>StreamWriter</b> permettant l'ecriture.</param>
        /// <exception cref="ArgumentNullException">Sw est null</exception>
        static void Demander_Et_Ecrire(StreamWriter param)
        {
            // Est-ce que Sw est renseigné ?
            if (param == null)
                throw new ArgumentNullException("Sw", "Sw vaut null !");

            Console.Out.WriteLine("Saisissez votre texte puis appuyez sur ‘ENTER’ (‘exit’ pour sortir).");

            string ligne;
            do
            {
                ligne = Console.In.ReadLine();
                param.Write(ligne);
            } while (ligne.ToLower() != "exit");
        }
    }

    /*internal class Program {
        static void Main(string[] args)
        {
            string str = "Hello";
            for (int Index = 0; Index < args.Length; Index++)
            {
                Debug.WriteLine(string.Format("{0}: {1} {0}", Index, args[Index]));
            }

            Debug.WriteLine("Appuyez sur une touche pour quitter...");
            Console.In.Read() ;
        }
    }*/
}
