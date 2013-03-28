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

namespace Drive4.Toolkit.UserControls.DataGrid
{
    /// <summary>
    /// Interaction logic for DataGridPro.xaml
    /// </summary>
    public partial class DataGridPro : UserControl
    {
        private Type EditWindowClass;
        private DataManager manager;

        public DataGridPro(DataManager _manager, Type _EditWindowClass)
        {
            InitializeComponent();
            manager = _manager;
            EditWindowClass = _EditWindowClass;
            foreach (DataGridColumn c in manager.DataColumns)
                dgItems.Columns.Add(c);         
        }
        void Refresh()
        {
            dgItems.ItemsSource = manager.Retrieve();
        }
        void Create()
        {
            Window EditWindow = (Window)Activator.CreateInstance(EditWindowClass, manager);
            EditWindow.Show();
        }
        void Edit()
        {            
            Window EditWindow = (Window)Activator.CreateInstance(EditWindowClass, manager, dgItems.SelectedItem as DataItem);
            EditWindow.Show();
        }
        void Delete()
        {
            foreach (DataItem item in dgItems.SelectedItems)
            {
                manager.Delete(item.ID);
            }
        }
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            Create();   
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if(dgItems.SelectedItems.Count >0)
                Edit();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgItems.SelectedItems.Count > 0)
                Delete();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
    }
}
