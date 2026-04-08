/*Erstellen Sie ein Konsolenprogramm TextFileStatistic, das Benutzer*innen nach dem (absoluten oder
    relativen) Pfad zu einer Textdatei fragt, diese Datei öffnet und ausgibt, wie viele Zeichen, Wörter und
Zeilen in der Datei enthalten sind. Ein Wort ist jede durch Leerzeichen getrennte Zeichenkette. Eine
    neue Zeile wird durch einen Zeilenumbruch \n angegeben.
    Zusätzlich soll ausgegeben werden, welcher Character (exkl. Leerzeichen) der häufigste ist.*/



using System;

namespace TextFileStatistic;
    class TextFileStatistic
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Geben Sie den Pfad zur ersten Textdatei ein (absolut/ relativ):");
            string path1 = Console.ReadLine();
        
            if (!File.Exists(path1))
            {
                Console.WriteLine("Eingabedatei existiert nicht!");
                return;
            }
            
            Dictionary<char, int> charFrequency = new Dictionary<char, int>();
            int charCount = 0;
            int wordCount = 0;
            int rowCount = 0;
            bool inWord = false;
            bool isWhiteSpace;
            
            using (var sr = new StreamReader(path1))
            {
                int c;
                while ((c = sr.Read()) != -1)
                {
                    char curr = char.ToLower((char)c); 

                    isWhiteSpace = (curr == ' ' || curr == '\n' || curr == '\r'); // Bei 'e' false // In Word true, whitespace false
                    
                    if(!inWord && !isWhiteSpace) wordCount++; // neues Wort beginnt
                    inWord = !isWhiteSpace; // schauen, ob in einem Wort
                    if(curr != '\r') charCount++;
                    
                    if(curr != ' ' && curr != '\n' && curr !='\r'){
                        if(charFrequency.ContainsKey(curr)) charFrequency[curr]++;
                        else charFrequency.Add(curr, 1);
                    }
                    
                    if (curr == '\n') rowCount++;
                    
                    
                }
            }
            
            Console.WriteLine("Zeichen (inkl. Leerzeichen): " + charCount);
            Console.WriteLine("Wörter: " + wordCount);
            Console.WriteLine("Zeilen: " + rowCount);
            
            if(charFrequency.Count > 0){ //Wichtig, sonst crash bei leerem Dictionary
                var maxEintrag = charFrequency
                    .OrderByDescending(x => x.Value) // Nimmt alle einträge und sortiert nach value (häufigkeit)
                    .First(); // Nimmt das erste Element (nach sortieren das Häufigste)
                Console.WriteLine($"Häufigstes Zeichen: '{maxEintrag.Key}' kommt {maxEintrag.Value} mal vor.");
            }
        }
    }

      