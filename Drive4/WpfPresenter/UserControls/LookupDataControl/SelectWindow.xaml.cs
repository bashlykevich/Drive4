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
using Drive4.Toolkit.Interfaces;
using Drive4.Core;
using System.Data.Objects.DataClasses;

namespace Drive4.WpfPresenter.UserControls.LookupDataControl
{
    /// <summary>
    /// Interaction logic for SelectWindow.xaml
    /// </summary>
    public partial class SelectWindow : Window
    {
        DataGridPro dg;
        public SelectWindow(DataManager manager)
        {
            InitializeComponent();
            this.Title = manager.Name;
            grMain.Children.Add(dg = new DataGridPro(manager, dgItems_MouseDoubleClick));            
        }
        EntityObject result;
        public EntityObject EntityObject
        {
            get
            {
                return result;
            }
        }
        private void dgItems_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SetResultAndCloseDialog();
        }
        void SetResultAndCloseDialog()
        {
            result = dg.dgItems.SelectedItem as EntityObject;
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
