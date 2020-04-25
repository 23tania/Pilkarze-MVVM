using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Globalization;

namespace MVVMPilkarze
{
    /// <summary>
    /// Logika interakcji dla klasy TextBoxWithErrorProvider.xaml
    /// </summary>
    public partial class TextBoxWithErrorProvider : UserControl
    {
        public TextBoxWithErrorProvider()
        {
            InitializeComponent();
        }


        #region Zdarzenie własne
        //Rejestracja zdarzenia tak, żeby możliwe było jego bindowanie
        public static readonly RoutedEvent TextChangedEvent =
        EventManager.RegisterRoutedEvent("TabItemSelected",
                     RoutingStrategy.Bubble, typeof(RoutedEventHandler),
                     typeof(TextBoxWithErrorProvider));

        //Definicja zdarzenia TextChanged
        public event RoutedEventHandler TextChanged
        {
            add { AddHandler(TextChangedEvent, value); }
            remove { RemoveHandler(TextChangedEvent, value); }
        }

        //Metoda pomocnicza wywołująca zdarzenie
        void RaiseTextChanged()
        {
            RoutedEventArgs newEventArgs =
                    new RoutedEventArgs(TextBoxWithErrorProvider.TextChangedEvent);
            RaiseEvent(newEventArgs);
        }
        #endregion

        #region Własność zależna

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(
                "Text",
                typeof(string),
                typeof(TextBoxWithErrorProvider),
                new FrameworkPropertyMetadata(null)
            );

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        #endregion

        #region Metody


        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!(sender is TextBox))
                return;

            TextBox box = (TextBox)sender;

            if (box.Text == "")
            {
                box.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else
            {
                box.BorderBrush = System.Windows.Media.Brushes.Black;
            }
            RaiseTextChanged();
        }

        

        #endregion
    }
}
