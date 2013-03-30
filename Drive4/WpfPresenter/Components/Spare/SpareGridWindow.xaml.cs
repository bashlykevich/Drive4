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
using Drive4.Toolkit.Interfaces;
using Drive4.Core;
using Drive4.Toolkit.UserControls.DataGrid;

namespace Drive4.WpfPresenter.Components.Spare
{
    /// <summary>
    /// Interaction logic for SpareGridWindow.xaml
    /// </summary>
    public partial class SpareGridWindow : Window
    {
       DataManager manager = DriveController.Instance.DataConnector.Spares;
       public SpareGridWindow()
        {            
            InitializeComponent();
            this.Title = manager.Name;
            grMain.Children.Add(new DataGridPro(manager));
        }
    }
}
