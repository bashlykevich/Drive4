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
using DatabaseMSSQLCE.ADO;

namespace Drive4.WpfPresenter.UserControls.LookupDataControl
{
    /// <summary>
    /// Interaction logic for LookupDataControl.xaml
    /// </summary>
    public partial class LookupDataControl : UserControl
    {
        public static readonly DependencyProperty RecordIDProperty = DependencyProperty.Register("RecordID", typeof(int), typeof(LookupDataControl));                
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
            get;
            set;
        }
        
        public LookupDataControl()
        {
            InitializeComponent();
            edtRecordName.DataContext = null;
        }
        
        void UpdateRecordDisplayName()
        {           
            EntityObject entityObject = SourceDataManager.Retrieve(this.RecordID);
            UpdateRecordDisplayName(entityObject);            
        }        
        
        private void UpdateRecordDisplayName(EntityObject item)
        {
            if (item == null)
                return;
            edtRecordName.DataContext = item;            
            this.RecordID = (int)item.EntityKey.EntityKeyValues[0].Value;            
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            SelectWindow sw = new SelectWindow(SourceDataManager);
            sw.ShowDialog();
            UpdateRecordDisplayName(sw.EntityObject);
        }
                
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateRecordDisplayName();
        }
        public void InitLookupData(DataManager dm, string SourceFieldName)
        {
            this.SourceDataManager = dm;
            Binding b = new Binding(SourceFieldName);
            b.Source = this.DataContext;
            b.Mode = BindingMode.TwoWay;
            this.SetBinding(LookupDataControl.RecordIDProperty, b);
        }

    }
}
