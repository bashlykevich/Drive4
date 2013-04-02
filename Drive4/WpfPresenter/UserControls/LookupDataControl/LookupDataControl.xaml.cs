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

namespace Drive4.WpfPresenter.UserControls.LookupDataControl
{
    /// <summary>
    /// Interaction logic for LookupDataControl.xaml
    /// </summary>
    public partial class LookupDataControl : UserControl
    {
        public static readonly DependencyProperty RecordIDProperty = DependencyProperty.Register("RecordID", typeof(int), typeof(LookupDataControl));
        public static readonly DependencyProperty SourceDataManagerProperty = DependencyProperty.Register("SourceDataManager", typeof(DataManager), typeof(LookupDataControl));
        public int RecordID
        {
            get
            {
                return (int)this.GetValue(RecordIDProperty);
            }
            set
            {
                this.SetValue(RecordIDProperty, value);
            }
        }
        public DataManager SourceDataManager
        {
            get
            {
                return this.GetValue(SourceDataManagerProperty) as DataManager;
            }
            set
            {
                this.SetValue(SourceDataManagerProperty, value);
            }
        }
        /*
        public string Name
        {
            get
            {
                return base.Name;
            }
            set
            {
                base.Name = value;
            }
        }*/
        /*public LookupDataControl()
        {
            InitializeComponent();
            SetDisplayNameBinding();
        }*/
        public LookupDataControl()
        {
            InitializeComponent();
        }
        public LookupDataControl(int RecordID, DataManager SourceDataManager)
        {
            InitializeComponent();
            this.RecordID = RecordID;
            this.SourceDataManager = SourceDataManager;
            SetDisplayNameBinding();
        }
        void SetDisplayNameBinding()
        {                        
            edtRecordName.SetBinding(TextBox.TextProperty, "Name");
        }
     
        private void UpdateRecordDisplayName(int RecordID)
        {

            if (RecordID > 0)
            {
                this.DataContext = SourceDataManager.Retrieve(RecordID);
            }
            else
            {
                this.DataContext = null;
            }
        }
        private void UpdateRecordDisplayName(EntityObject item)
        {
            this.DataContext = item;
        }
        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            SelectWindow sw = new SelectWindow(SourceDataManager);
            sw.ShowDialog();
            UpdateRecordDisplayName(sw.EntityObject);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateRecordDisplayName(this.RecordID);
        }
    }
}
