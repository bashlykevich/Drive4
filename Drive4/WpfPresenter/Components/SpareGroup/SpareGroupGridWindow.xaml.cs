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
using Drive4.Core;
using Drive4.Toolkit.Interfaces;
using Drive4.Toolkit.UserControls.DataGrid;

namespace Drive4.WpfPresenter.Components.SpareGroup
{
    /// <summary>
    /// Interaction logic for SpareGroupGridWindow.xaml
    /// </summary>
    public partial class SpareGroupGridWindow : Window
    {
        DataManager manager = DriveController.Instance.DataConnector.SpareGroups;
        public SpareGroupGridWindow()
        {
            InitializeComponent();
            this.Title = manager.Name;
            grMain.Children.Add(new DataGridPro(manager));
        }
    }
}
