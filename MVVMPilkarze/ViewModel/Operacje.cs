using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Input;
using System.Windows;

namespace MVVMPilkarze.ViewModel
{
    //using Model;
    using BaseClass;

    internal class Operacje : ViewModelBase
    {
        private Druzyna druzyna = new Druzyna();
        public List<string> PilkarzeLista
        {
            get => Wyswietlanie.wyswietlPilkarzy(druzyna.zwrocPilkarza);
        }

        public string obecneImie { get; set; }
        public string obecneNazwisko { get; set; }
        public uint obecnyWiek { get; set; } = 5;
        public uint obecnaWaga { get; set; } = 10;
        public int obecnyIndeks { get; set; } = -1;

        private ICommand _dodajPilkarza = null;
        private ICommand _edytujPilkarza = null;
        private ICommand _usunPilkarza = null;
        private ICommand _zapiszPilkarzy = null;
        private ICommand _kopiujPilkarza = null;

        //Polecenie dodające nowego piłkarza
        public ICommand dodajPilkarza
        {
            get
            {
                if (_dodajPilkarza == null)
                {
                    _dodajPilkarza = new RelayCommand(

                        arg =>
                        {
                            druzyna.dodajPilkarza(new Pilkarz(obecneImie, obecneNazwisko, obecnyWiek, obecnaWaga));
                            onPropertyChanged(nameof(PilkarzeLista));
                        },

                        arg => (!string.IsNullOrEmpty(obecneImie)) && (!string.IsNullOrEmpty(obecneNazwisko))
                        && (obecneImie != null) && (obecneNazwisko != null)
                        );

                }
                return _dodajPilkarza;
            }
        }

        //Polecenie edytujące istniejącego piłkarza
        public ICommand edytujPilkarza
        {
            get
            {
                if (_edytujPilkarza == null)
                {
                    _edytujPilkarza = new RelayCommand(

                        arg =>
                        {
                            var dialogResult = MessageBox.Show($"Czy na pewno chcesz zmienić dane piłkarza?", 
                                "Edycja", MessageBoxButton.YesNo);


                            if (dialogResult == MessageBoxResult.Yes)
                            {
                                druzyna.edytujPilkarza(new Pilkarz(obecneImie, obecneNazwisko,
                                obecnyWiek, obecnaWaga), obecnyIndeks);
                                onPropertyChanged(nameof(PilkarzeLista));
                            }
                            
                        },

                        arg => obecnyIndeks != -1 && (!string.IsNullOrEmpty(obecneImie)) && (!string.IsNullOrEmpty(obecneNazwisko))
                        && (obecneImie != null) && (obecneNazwisko != null)
                        );

                }
                return _edytujPilkarza;
            }
        }

        //Polecenie usuwające piłkarza
        public ICommand usunPilkarza
        {
            get
            {
                if (_usunPilkarza == null)
                {
                    _usunPilkarza = new RelayCommand(

                        arg =>
                        {
                            var dialogResult = MessageBox.Show($"Czy na pewno chcesz usunąć piłkarza?",
                                "Edycja", MessageBoxButton.YesNo);


                            if (dialogResult == MessageBoxResult.Yes)
                            {
                                druzyna.usunPilkarza(obecnyIndeks);
                                onPropertyChanged(nameof(PilkarzeLista));
                            }

                        },

                        arg => obecnyIndeks != -1
                        );

                }
                return _usunPilkarza;
            }
        }

        //Polecenie zapisujące piłkarzy do pliku
        public ICommand zapiszPilkarzy
        {
            get
            {
                if (_zapiszPilkarzy == null)
                {
                    _zapiszPilkarzy = new RelayCommand(arg => druzyna.zapiszPilkarzy(@"Pilkarze.json"), 
                        arg => true);
                }
                return _zapiszPilkarzy;
            }
        }

        //Polecenie odpowiadające za wybranie piłkarza z listy
        public ICommand kopiujPilkarza
        {
            get
            {
                if (_kopiujPilkarza == null)
                {
                    _kopiujPilkarza = new RelayCommand(

                        arg =>
                        {
                            Pilkarz pilkarz = druzyna.zwrocPilkarza[obecnyIndeks];
                            obecneImie = pilkarz.Imie;
                            obecneNazwisko = pilkarz.Nazwisko;
                            obecnyWiek = pilkarz.Wiek;
                            obecnaWaga = pilkarz.Waga;

                            onPropertyChanged(nameof(obecneImie), nameof(obecneNazwisko),
                                nameof(obecnyWiek), nameof(obecnaWaga));
                        },

                        arg => obecnyIndeks != -1
                        );
                }
                return _kopiujPilkarza;
            }
        }
    }
}
