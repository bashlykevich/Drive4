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
using Drive4.WpfPresenter.Components.Spare;

namespace Drive4.Toolkit.UserControls.EditWindow
{
    /// <summary>
    /// Interaction logic for EditWindowPro.xaml
    /// </summary>
    public partial class EditWindowPro : Window
    {
        DataManager manager;
        bool IsNewEntity = false;
        UserControl FormContent;    

        public EditWindowPro(DataManager _manager, Type EditWindowClass)
        {            
            InitializeComponent();
            manager = _manager;
            IsNewEntity = true;
            FormContent = (UserControl)Activator.CreateInstance(EditWindowClass);            
            grContent.Children.Add(FormContent);
            this.Title = manager.Name;
            FillFormContent();
        }
        public EditWindowPro(DataManager _manager, Type EditWindowClass,EntityObject item)
        {            
            InitializeComponent();
             manager = _manager;
            IsNewEntity = false;
            FormContent = (UserControl)Activator.CreateInstance(EditWindowClass);                        
            grContent.Children.Add(FormContent);
            this.Title = manager.Name;
            FillFormContent(item);
        }
        private void FillFormContent()
        {
            this.DataContext = Activator.CreateInstance(manager.EntityType);
        }
        private void FillFormContent(EntityObject item)
        {
            this.DataContext = item;
        }
        private EntityObject GetItemFromForm()
        {
            return this.DataContext as EntityObject;
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
