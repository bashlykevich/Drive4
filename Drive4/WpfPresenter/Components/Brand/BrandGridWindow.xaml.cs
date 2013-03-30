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
using System.Windows.Shapes;
using Drive4.Toolkit.UserControls.DataGrid;
using Drive4.Core;
using Drive4.Toolkit.Interfaces;

namespace Drive4.WpfPresenter.Components.Brand
{
    /// <summary>
    /// Interaction logic for BrandGridWindow.xaml
    /// </summary>
    public partial class BrandGridWindow : Window
    {        
        DataManager manager = DriveController.Instance.DataConnector.Brands;
        public BrandGridWindow()
        {            
            InitializeComponent();
            this.Title = manager.Name;
            grMain.Children.Add(new DataGridPro(manager));
        }
    }
}
