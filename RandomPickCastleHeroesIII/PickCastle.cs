using System;
using System.Collections.Generic;

namespace RandomPickCastleHeroesIII
{
    enum Castles
    {
        Castle,
        Rampart,
        Tower,
        Inferno,
        Necropolis,
        Dungeon,
        Stronghold,
        Fortress,
        Conflux
    }
    public static class PickCastle
    {
        static private ConsoleKeyInfo chooseKey;
        static private string nameOfCastle;

        private static string RandomCastle(List<string> usedCastles)
        {
            int numberOfCastles = Enum.GetValues(typeof(Castles)).Length;
            Random rnd = new Random();
            do
            {
                nameOfCastle = NameOfCastle(rnd.Next(0, numberOfCastles));
                if (usedCastles.Count >= numberOfCastles)
                {
                    Console.WriteLine("Wygląda na to, że wykorzystałeś już wszystkie zamki. Czy chcesz zresetować listę? [T/N]");
                    chooseKey = Console.ReadKey();

                    if (chooseKey.Key.ToString() == "T") usedCastles.Clear();
                    else
                        break;
                }
            } while (usedCastles.Contains(nameOfCastle));
            return nameOfCastle;
        }
        private static string NameOfCastle(int number) => Enum.GetName(typeof(Castles), number);

        public static void ChooseCastle(ref List<string> usedCastles)
        {
            for (;;)
            {
                nameOfCastle = RandomCastle(usedCastles);
                Console.WriteLine($"{nameOfCastle} - może być taki zamek [T/N]?");
                chooseKey = Console.ReadKey();

                if (chooseKey.Key.ToString() == "T")
                {
                    usedCastles.Add(nameOfCastle);
                    Console.WriteLine("Dokonałeś dobrego wyboru mój Panie!");
                    break;
                }
            }
        }

    }
}
