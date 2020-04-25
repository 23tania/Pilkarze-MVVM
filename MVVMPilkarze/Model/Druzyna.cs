using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using Newtonsoft.Json;

namespace MVVMPilkarze
{
    class Druzyna
    {
        List<Pilkarz> pilkarze = wczytaniePilkarzyZPliku(@"Pilkarze.json");

        //Metody odpowiadające za dodanie, usunięcie i zmienienie listy
        //reprezentującej piłkarzy
        public void dodajPilkarza(Pilkarz pilkarz)
        {
            pilkarze.Add(pilkarz);
        }

        public void edytujPilkarza(Pilkarz pilkarz, int numerPilkarza)
        {
            pilkarze[numerPilkarza] = pilkarz;
        }

        public void usunPilkarza(int numerPilkarza)
        {
            pilkarze.RemoveAt(numerPilkarza);
        }

        public List<Pilkarz> zwrocPilkarza
        {
            get => pilkarze;
        }

        //Wczytywanie z pliku json
        public static List<Pilkarz> wczytaniePilkarzyZPliku(string plik)
        {
            List<Pilkarz> pilkarzeZPliku = new List<Pilkarz>();

            if (File.Exists(plik))
            {
                pilkarzeZPliku = JsonConvert.DeserializeObject<List<Pilkarz>>(File.ReadAllText(plik));
            }

            return pilkarzeZPliku;
        }

        //Zapis do pliku json
        public void zapiszPilkarzy(string plik)
        {
            string tekst = JsonConvert.SerializeObject(pilkarze);
            File.WriteAllText(plik, tekst);
        }
    }
}
