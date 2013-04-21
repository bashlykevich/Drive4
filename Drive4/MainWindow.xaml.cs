using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Drive4.WpfPresenter.Components.Unit;
using Drive4.WpfPresenter.Components.Brand;
using Drive4.WpfPresenter.Components.Spare;

namespace Drive4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();            
        }

        private void miUnits_Click(object sender, RoutedEventArgs e)
        {
            GoToDictionaryUnit();
        }
        void GoToDictionaryBrand()
        {
            BrandGridWindow w = new BrandGridWindow();
            w.Show();
        }
        void GoToDictionaryUnit()
        {
            UnitGridWindow w = new UnitGridWindow();
            w.Show();
        }
        void GoToDictionarySpare()
        {
            SpareGridWindow w = new SpareGridWindow();
            w.Show();
        }
        private void miBrands_Click(object sender, RoutedEventArgs e)
        {
            GoToDictionaryBrand();
        }

        private void miSpares_Click(object sender, RoutedEventArgs e)
        {
            GoToDictionarySpare();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {            
        }
    }
}
