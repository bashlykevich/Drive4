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
using System.Data.Objects.DataClasses;

namespace Drive4.Toolkit.UserControls.EditWindow
{
    /// <summary>
    /// Interaction logic for EditWindowPro.xaml
    /// </summary>
    public partial class EditWindowPro : Window
    {
        DataManager manager;
        bool IsNewEntity = false;
        public EditWindowPro(DataManager _manager, Type EditWindowClass)
        {
            InitializeComponent();
            manager = _manager;
            IsNewEntity = true;
            grContent.Children.Add((UserControl)Activator.CreateInstance(EditWindowClass));
        }
        public EditWindowPro(DataManager _manager, Type EditWindowClass,EntityObject item)
        {
            InitializeComponent();
            manager = _manager;
            IsNewEntity = false;
            grContent.Children.Add((UserControl)Activator.CreateInstance(EditWindowClass));
        }
        private EntityObject GetItemFromForm()
        {
            throw new NotImplementedException();
        }
        private void Post()
        {
            EntityObject item = GetItemFromForm();
            if (IsNewEntity)
            {
                manager.Create(item);
            }
            else
            {
                manager.Update(item);
            }
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            SaveAndClose();
        }
        void SaveAndClose()
        {
            Post();
            Close();
        }
        void CloseWithoutSaving()
        {
            Close();
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            CloseWithoutSaving();
        }
    }
}
