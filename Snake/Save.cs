using System.IO;

namespace Snake
{
    class Save : Game
    {
        static string path = @"./salvataggio.txt";
        public static void CreaCartella()
        {
            if (!File
                .Exists(@"./snake"))
            {
                FileStream save = File.Create(@"./snake");
                save.Close();
                save.Dispose();
            }
        }
        public static void CreaFile()
        {
            if (!File.Exists(path))
            {
                FileStream save = File.Create(path);
                save.Close();
                save.Dispose();
                File.WriteAllText(path, "0");
            }
        }
        public static void Salva()
        {
            int record = int.Parse(File.ReadAllText(path));
            if (record < punteggio)
            {
                File.WriteAllText(path, $"{punteggio}");
            }
        }

        public static bool IsNuovoRecord()
        {
            int record = int.Parse(File.ReadAllText(path));
            if (record < punteggio)
            {
                return true;
            }
            return false;
        }
    }
}
