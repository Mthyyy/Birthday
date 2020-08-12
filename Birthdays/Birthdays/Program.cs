using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Birthdays
{
    class Program
    {
        void BindToRunningProcesses()
        {
            Process currentProcess = Process.GetCurrentProcess();
        }
        static void Main(string[] args)
        {
            List<string> dates = new List<string>();
            string choix;
            string fullPath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @"\DatesDeFetes.txt";
            Console.WriteLine(fullPath);

            if(File.Exists(fullPath))
            {
                using (StreamReader fileR = new StreamReader(fullPath))
                {
                    string ln;

                    while((ln = fileR.ReadLine()) != null)
                    {
                        dates.Add(ln);
                    }

                    fileR.Close();
                }
            }

            else
            {
                Console.WriteLine("allo");
            }
            

            Console.WriteLine("Voici les dates de fetes existantes:\n" + "(Si vous voulez ajouter une date appuez sur N, si vous voulez quitter appuyez sur une autre touche)");

            for (int i = 0; i < dates.Count; i++)
            {
                Console.WriteLine(dates[i]);
            }

            choix = Console.ReadLine().ToUpper();
            Console.WriteLine("\n");

            if (choix == "N")
            {
                dates.Add(Compiler());
                Console.WriteLine("La date a ete ajoutee!");
            }

            if(File.Exists(fullPath))
            {
                using(StreamWriter fileW = new StreamWriter(fullPath))
                {
                    for(int i = 0; i < dates.Count; i++)
                    {
                        fileW.WriteLine(dates[i]);
                    }

                    fileW.Close();
                }
  
            }

            
        }

        static string Compiler()
        {
            Console.WriteLine("Entrez le nom");
            string nom = Console.ReadLine() + DateFete();

            return nom.ToUpper();
        }

        static string DateFete()
        {
            var rand = new Random();
            int mois = rand.Next(1, 12);
            int jour = rand.Next(1, 31);
            string moisS;
            string jourS;

            if(mois < 10)
            {
               moisS = "0" + mois.ToString();
            }

            else
            {
                moisS = mois.ToString();
            }

            if (jour < 10)
            {
                jourS = "0" + jour.ToString();
            }

            else
            {
                jourS = jour.ToString();
            }
            string fete = moisS + "/" + jourS;

            Console.WriteLine(fete);

            Console.ReadKey();

            return fete; 
        }

    }
}
