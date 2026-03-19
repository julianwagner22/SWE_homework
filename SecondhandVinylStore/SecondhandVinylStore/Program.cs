

/*Struktur: Alben
 * Interpret
 * Titel
 * VÖ-Jahr
 * Zustand
 * 
 * Funktionen: 
 * erstellen eines neuen Albums
 * anzeigen
 * nach Interpreten suchen
 * nach Titeln suchen
 * nach Alben suchen die vor oder nach einem Jahr erschienen sind
 * beenden
 * 
 * 
 */
 
            
using System;
using System.Collections.Generic;

namespace SecondhandVinylStore
{
    internal class Program
    {

        static List<Album> regal = new List<Album>();       //static = überall zugriff
                                                            //erstellt eine leere Liste, die Album-Objekte speicher
            static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine();
                Console.WriteLine("[1] Album hinzufügen");
                Console.WriteLine("[2] Alle Alben anzeigen");
                Console.WriteLine("[3] Nach Interpret suchen");
                Console.WriteLine("[4] Nach Titel suchen");
                Console.WriteLine("[5] Nach Jahr suchen");
                Console.WriteLine("[0] Beenden");

                string eingabe = Console.ReadLine();

                switch (eingabe)
                {
                    case "1":
                        Album neuesAlbum = ErstelleAlbum();
                        regal.Add(neuesAlbum);
                        Console.WriteLine("Album wurde hinzugefügt.");
                        break;

                    case "2":
                        AlleAlbenAusgeben();
                        break;

                    case "3":
                        SucheNachInterpret();
                        break;

                    case "4":
                        SucheNachTitel();
                        break;

                    case "5":
                        SucheNachJahr();
                        break;

                    case "0":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Ungültige Eingabe.");
                        break;
                }
            }
        }

        static Album ErstelleAlbum()            //ErstelleAlbum = Name der Funktion, Funktion gibt ein Album zurück
            {
            Album neuesAlbum;

            Console.Write("Interpret: ");
            neuesAlbum.Interpret = Console.ReadLine();

            Console.Write("Titel: ");
            neuesAlbum.Titel = Console.ReadLine();

            Console.Write("Veröffentlichungsjahr: ");
            neuesAlbum.Veroeffentlichungsjahr = int.Parse(Console.ReadLine());      //int.Parse macht aus Text eine Zahl, ohne int.Parse kein rechnen/vergleichen

                Console.Write("Zustand: ");
            neuesAlbum.Zustand = int.Parse(Console.ReadLine());

            return neuesAlbum;
        }

        static void AlleAlbenAusgeben()         //void muss verwendet werden, sofern nichts zurückgegeben wird
            {
            if (regal.Count == 0)
            {
                Console.WriteLine("Keine Alben vorhanden.");
                return;
            }

            foreach (Album album in regal)
            {
                Console.WriteLine("Titel: " + album.Titel +
                                  ", Interpret: " + album.Interpret +
                                  ", Jahr: " + album.Veroeffentlichungsjahr +
                                  ", Zustand: " + album.Zustand);
            }
        }

        static void SucheNachInterpret()
        {
            Console.Write("Gesuchter Interpret: ");
            string interpretGesucht = Console.ReadLine();

            bool gefunden = false;

            foreach (Album album in regal)
            {
                if (album.Interpret.ToLower() == interpretGesucht.ToLower())
                {
                    Console.WriteLine("Titel: " + album.Titel +
                                      ", Interpret: " + album.Interpret +
                                      ", Jahr: " + album.Veroeffentlichungsjahr +
                                      ", Zustand: " + album.Zustand);
                    gefunden = true;
                }
            }

            if (!gefunden)
            {
                Console.WriteLine("Keine passenden Alben gefunden.");
            }
        }

        static void SucheNachTitel()
        {
            Console.Write("Gesuchter Titel: ");
            string titelGesucht = Console.ReadLine();

            bool gefunden = false;

            foreach (Album album in regal)          //mit foreach wird jedes Album im Regal durchgegangen, "nimm jedes Album aus dem Regal und nenne es album"
            {
                if (album.Titel.ToLower() == titelGesucht.ToLower())
                {
                    Console.WriteLine("Titel: " + album.Titel +
                                      ", Interpret: " + album.Interpret +
                                      ", Jahr: " + album.Veroeffentlichungsjahr +
                                      ", Zustand: " + album.Zustand);
                    gefunden = true;
                }
            }

            if (!gefunden)
            {
                Console.WriteLine("Keine passenden Alben gefunden.");
            }
        }

        static void SucheNachJahr()
        {
            Console.Write("Jahr: ");
            int jahr = int.Parse(Console.ReadLine());

            Console.Write("Vor dem Jahr (1) oder nach dem Jahr (2) suchen? ");
            string wahl = Console.ReadLine();

            bool gefunden = false;

            foreach (Album album in regal)
            {
                if (wahl == "1" && album.Veroeffentlichungsjahr < jahr)
                {
                    Console.WriteLine("Titel: " + album.Titel +
                                      ", Interpret: " + album.Interpret +
                                      ", Jahr: " + album.Veroeffentlichungsjahr +
                                      ", Zustand: " + album.Zustand);
                    gefunden = true;
                }
                else if (wahl == "2" && album.Veroeffentlichungsjahr > jahr)
                {
                    Console.WriteLine("Titel: " + album.Titel +
                                      ", Interpret: " + album.Interpret +
                                      ", Jahr: " + album.Veroeffentlichungsjahr +
                                      ", Zustand: " + album.Zustand);
                    gefunden = true;
                }
            }

            if (!gefunden)
            {
                Console.WriteLine("Keine passenden Alben gefunden.");
            }
        }
    }
}