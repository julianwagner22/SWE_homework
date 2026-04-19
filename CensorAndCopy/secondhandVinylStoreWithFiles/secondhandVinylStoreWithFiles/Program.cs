using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace secondhandVinylStoreWithFiles
{
    struct Album
    {
        public string Interpret; //public das es auch von anderen Funktionen verwendet werden kann
        public string Titel;
        public int Jahr;
        public int Zustand;
    }

    class Program
    {
        static void Main()
        {
            string datei = "alben.txt";
            List<Album> regal = LadeAlbenAusDatei(datei);

            while (true) //führt so lange aus bis choice = 0
            {
                Console.WriteLine("\nWas möchtest du tun?");
                Console.WriteLine("[1] Album hinzufügen");
                Console.WriteLine("[2] Alle verfügbaren anzeigen");
                Console.WriteLine("[3] Nach Interpret suchen"); //Tippfehler "Interpet"
                Console.WriteLine("[4] Nach Titel suchen");
                Console.WriteLine("[5] Nach Jahr suchen");
                Console.WriteLine("[0] Beenden");

                int choice = int.Parse(Console.ReadLine());

                if (choice == 0)
                    break;

                switch (choice)
                {
                    case 1:
                        regal.Add(ErstelleAlbum());
                        SpeichereAlbenInDatei(regal, datei);
                        break;

                    case 2:
                        AlleAnzeigen(regal);
                        break;

                    case 3:
                        SucheNachInterpret(regal);
                        break;

                    case 4:
                        SucheNachTitel(regal);
                        break;

                    case 5:
                        SucheJahr(regal);
                        break;

                    default:
                        Console.WriteLine("Ungültige Eingabe!");
                        break;
                }
            }
            
        }

        static Album ErstelleAlbum() //Liest alle Infos ein
        {
            Album album = new Album(); //Vorher Album album (unsicher)

            Console.Write("Interpret: ");
            album.Interpret = Console.ReadLine();

            Console.Write("Titel: ");
            album.Titel = Console.ReadLine();

            Console.Write("Erscheinungsjahr: ");
            album.Jahr = Convert.ToInt32(Console.ReadLine()); //um einen string in ein int umzuwandeln

            Console.Write("Zustand: ");
            album.Zustand = Convert.ToInt32(Console.ReadLine());

            return album;
        }

        static void AlleAnzeigen(List<Album> regal)
        {
            // Unsauber da bei leerer List "Alle Alben:" alleine gezeigt wurde
            Console.WriteLine("\nAlle Alben:");
            if (regal.Count == 0)
            {
                Console.WriteLine("Keine Alben vorhanden.");
                return;
            }
            
            foreach (Album album in regal) //geht alle Alben durch und gibt alle aus
            {
                Console.WriteLine("Album: {0}, Interpret: {1}, Erscheinungsjahr: {2}, Zustand: {3}", album.Titel, album.Interpret, album.Jahr, album.Zustand);
            }
        }

        static void SucheNachInterpret(List<Album> regal)
        {
            Console.Write("\nInterpret: ");
            string input = Console.ReadLine();

            Console.WriteLine("Verfügbare Alben mit dem Interpreten "+ input + ":");

            foreach (Album album in regal)
            {
                if (album.Interpret == input) //überprüft nach dem Input
                {
                    Console.WriteLine("Album: {0}, Interpret: {1}, Erscheinungsjahr: {2}, Zustand: {3}",album.Titel, album.Interpret, album.Jahr, album.Zustand);
                }
            }
        }

        static void SucheNachTitel(List<Album> regal)
        {
            Console.Write("\nTitel: ");
            string input = Console.ReadLine();

            Console.WriteLine("Verfügbare Alben mit dem Titel " + input + ":");

            foreach (Album album in regal)
            {
                if (album.Titel == input) //Überprüft wieder nach Input
                {
                    Console.WriteLine("Album: {0}, Interpret: {1}, Erscheinungsjahr: {2}, Zustand: {3}", album.Titel, album.Interpret, album.Jahr, album.Zustand);
                }
            }
        }

        static void SucheJahr(List<Album> regal)
        {
            Console.Write("\nJahr: ");
            int jahr = Convert.ToInt32(Console.ReadLine());

            Console.Write("Vor (1) oder nach (2) diesem Jahr suchen: ");
            int option = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Verfügbare Alben:");

            foreach (Album album in regal)
            {
                if ((option == 1 && album.Jahr < jahr) || //Unterscheidet zwischen den Auswahlmöglichkeiten und dem Jahr
                    (option == 2 && album.Jahr > jahr))
                {
                    Console.WriteLine("Album: {0}, Interpret: {1}, Erscheinungsjahr: {2}, Zustand: {3}", album.Titel, album.Interpret, album.Jahr, album.Zustand);
                }
            }
        }

        static List<Album> LadeAlbenAusDatei(string datei)
        {
            List<Album> regal = new List<Album>();

            if (!File.Exists(datei))
            {
                Console.WriteLine("Datei nicht gefunden. Es wird mit einer leeren Liste gestartet.");
                return regal;
            }
            string[] lines = File.ReadAllLines(datei);

            foreach (string line in lines)
            {
                string[] split = line.Split(';');
                if (split.Length == 4)
                {
                    Album album = new Album();
                    album.Interpret = split[0];
                    album.Titel = split[1];
                    album.Jahr = Convert.ToInt32(split[2]);
                    album.Zustand = Convert.ToInt32(split[3]);
                    
                    regal.Add(album);
                }
            }

            return regal;
        }

        static void SpeichereAlbenInDatei(List<Album> regal, string datei)
        {
            List<string> zeilen = new List<string>();

            foreach (Album album in regal)
            {
                zeilen.Add(album.Interpret + ";" +  album.Titel + ";" + album.Jahr + ";" + album.Zustand);
            }
            
            File.WriteAllLines(datei, zeilen);
        }
    }
}