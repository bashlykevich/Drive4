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
            Window EditWindow = new EditWindowPro(manager, EditWindowClass);            
            EditWindow.Show();
        }
        void Edit()
        {
            Window EditWindow = new EditWindowPro(manager, EditWindowClass, dgItems.SelectedItem as EntityObject);            
            EditWindow.Show();
        }
        void Delete()
        {
            foreach (EntityObject item in dgItems.SelectedItems)
            {
                manager.Delete((int)item.EntityKey.EntityKeyValues[0].Value);
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
