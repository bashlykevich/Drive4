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
using Drive4.Toolkit.Interfaces;
using System.Data.Objects.DataClasses;
using Drive4.Toolkit.UserControls.EditWindow;

namespace Drive4.Toolkit.UserControls.DataGrid
{
    /// <summary>
    /// Interaction logic for DataGridPro.xaml
    /// </summary>
    public partial class DataGridPro : UserControl
    {        
        private DataManager manager;

        public DataGridPro(DataManager _manager)
        {
            InitializeComponent();
            dgItems.MouseDoubleClick += dgItems_MouseDoubleClick;
            manager = _manager;            
            foreach (DataGridColumn c in manager.DataColumns)
                dgItems.Columns.Add(c);         
        }
        public DataGridPro(DataManager _manager, MouseButtonEventHandler method)
        {
            InitializeComponent();
            dgItems.MouseDoubleClick += method;
            manager = _manager;
            foreach (DataGridColumn c in manager.DataColumns)
                dgItems.Columns.Add(c);
        }
        void Refresh()
        {            
            dgItems.ItemsSource = manager.Retrieve();
        }
        void Create()
        {
            Window EditWindow = new EditWindowPro(manager, manager.EditWindow);
            EditWindow.ShowDialog();
            Refresh();            
        }
        void Edit()
        {
            if (dgItems.SelectedItem != null)
            {
                Window EditWindow = new EditWindowPro(manager, manager.EditWindow, dgItems.SelectedItem as EntityObject);
                EditWindow.Show();
                Refresh();
            }
        }
        void Delete()
        {            
            List<int> IDs = new List<int>();
            foreach (EntityObject item in dgItems.SelectedItems)
            {
                IDs.Add((int)item.EntityKey.EntityKeyValues[0].Value);
            }
            foreach (int ID in IDs)
            {
                manager.Delete(ID);
            }
        }
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            Create();   
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Edit();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Delete();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void dgItems_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Edit();
        }
    }
}
