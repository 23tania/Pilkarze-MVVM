using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMPilkarze
{
    class Pilkarz
    {
        //Properties
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public uint Wiek { get; set; }
        public uint Waga { get; set; }

        //Konstruktory
        public Pilkarz(string imie, string nazwisko, uint wiek, uint waga)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Wiek = wiek;
            Waga = waga;
        }

        public Pilkarz(Pilkarz player)
        {
            Imie = player.Imie;
            Nazwisko = player.Nazwisko;
            Wiek = player.Wiek;
            Waga = player.Waga;
        }

        public Pilkarz() { }

        public override string ToString()
        {
            return $"{Nazwisko} {Imie} lat: {Wiek} waga: {Waga} kg";
        }
    }
}
