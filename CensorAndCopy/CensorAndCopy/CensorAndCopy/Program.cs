/*Erstellen Sie ein Konsolenprogramm CensorAndCopy, das Benutzer*innen nach dem (absoluten
oder relativen) Pfad von zwei Textdateien und einem Character fragt. Der Inhalt der ersten Datei soll in
die zweite kopiert werden. Alle Vorkommen des übergebenen Characters sollen allerdings durch ein *
erstetzt werden. Die Anzahl der Ersetzungen soll nach dem Kopiervorgang ausgegeben werden.*/



namespace CensorAndCopy;

class CensorAndCopy
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
        
        Console.WriteLine("Geben Sie den Pfad zur zweiten Textdatei ein (absolut/ relativ):");
        string path2 = Console.ReadLine();
        
        Console.WriteLine("Welcher Character soll zensiert werden?");
        char censor = (char)Console.Read();
        
        int count = 0;
        
        using (var sr = new StreamReader(path1))
        using (var sw = new StreamWriter(path2))    
        {
            int c;
            while ((c = sr.Read()) != -1)
            {
                char curr = (char)c;

                if (curr == censor)
                {
                    curr = '*';
                    count++;
                }

                sw.Write(curr);
            }
        }
        Console.WriteLine("Anzahl der Ersetzungen: " + count);
    }
}