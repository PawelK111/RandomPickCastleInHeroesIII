using System;
using System.Collections.Generic;
using System.Threading;
using Newtonsoft.Json;
using System.IO;

namespace RandomPickCastleHeroesIII
{
    public class FileOfList
    {
        string path = string.Format(@"{0}\Save\ListOfCastles.json", AppContext.BaseDirectory);
        public FileOfList(List<string> usedCastles)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(usedCastles));
            using (StreamWriter file = File.CreateText(path))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, usedCastles);
            }
            Console.WriteLine("Lista została pomyślnie zapisana!");
        }

        public FileOfList(ref List<string> usedCastles)
        {
            try
            {
                if (!File.Exists(path))
                    throw new JSONNotFoundException("Zapisana lista nie została odnaleziona!");

                using (StreamReader file = File.OpenText(path))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    usedCastles = (List<string>)serializer.Deserialize(file, typeof(List<string>));
                    Console.WriteLine("Pomyślnie wczytano ustawienia!");
                }
            }
            catch (JSONNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
