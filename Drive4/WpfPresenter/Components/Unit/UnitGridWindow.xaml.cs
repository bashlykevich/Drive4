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

namespace Drive4.WpfPresenter.Components.Unit
{
    /// <summary>
    /// Interaction logic for UnitGridWindow.xaml
    /// </summary>
    public partial class UnitGridWindow : Window
    {
        DataGridPro dg;
        DataManager manager = DriveController.Instance.DataConnector.Units;
        public UnitGridWindow()
        {            
            InitializeComponent();
            this.Title = manager.Name;
            grMain.Children.Add(dg = new DataGridPro(manager, typeof(UnitEditWindow)));
        }
    }
}
