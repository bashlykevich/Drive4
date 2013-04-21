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
using Drive4.Toolkit.UserControls.DataGrid;
using Drive4.Core;
using Drive4.Toolkit.Interfaces;
using System.Collections;

namespace Drive4.WpfPresenter.Components.Spare
{
    /// <summary>
    /// Interaction logic for SpareWorkspaceWindow.xaml
    /// </summary>
    public partial class SpareWorkspaceWindow : UserControl
    {
        DataManager manager = DriveController.Instance.DataConnector.Spares;
        DataManager GroupsManager = DriveController.Instance.DataConnector.SpareGroups;
        public SpareWorkspaceWindow()
        {
            InitializeComponent();
            grGridContainer.Children.Add(new DataGridPro(manager));
            LoadGroups();
        }
        void LoadGroups()
        {
            IList list = new ArrayList();
            list.Add(GroupsManager.Retrieve(1));
            tvGroups.ItemsSource = list;
        }
    }
}
