using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMPilkarze.ViewModel
{
    using BaseClass;
    //using MVVMPilkarze.Model;

    class Wyswietlanie : ViewModelBase
    {
        //Metoda odpowiadająca za wyświetlenie piłkarzy z listy
        public static List<string> wyswietlPilkarzy(List<Pilkarz> pilkarze)
        {
            List<string> lista = new List<string>();
            for (int i=0; i<pilkarze.Count; i++)
            {
                lista.Add(pilkarze[i].ToString());
            }
            return lista;
        }
    }
}
