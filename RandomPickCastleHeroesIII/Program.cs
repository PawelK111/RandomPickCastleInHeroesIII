using System;
using System.Collections.Generic;
using System.Threading;

namespace RandomPickCastleHeroesIII
{

    class Program
    {
        static ConsoleKeyInfo choose;
        static void Main(string[] args)
        {


            List<string> usedCastles = new List<string>();
            FileOfList fileOfList;
            for (; ; )
            {
                Console.WriteLine("---Random Pick Castle In Heroes III---\n\n" +
                    "MENU GŁÓWNE:\n" +
                    "---------------------\n" +
                    "1. Rozpocznij losowanie\n" +
                    "2. Zapisz wylosowane zamki\n" +
                    "3. Wczytaj wylosowane zamki\n" +
                    "---------------------\n" +
                    "9. Wyjście\n");
                choose = Console.ReadKey();
                switch(choose.Key.ToString())
                {
                    case "D1":
                        PickCastle.ChooseCastle(ref usedCastles);
                        break;
                    case "D2":
                        fileOfList = new FileOfList(usedCastles);
                        break;
                    case "D3":
                        fileOfList = new FileOfList(ref usedCastles);

                        break;
                    case "D9":
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
                Thread.Sleep(1000);
                fileOfList = null;
                Console.Clear();
            }

        }
    }
}
