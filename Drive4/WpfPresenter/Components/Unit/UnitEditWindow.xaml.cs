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
using System.Data.Objects.DataClasses;
using DriveBase.Interfaces;

namespace Drive4.WpfPresenter.Components.Unit
{
    /// <summary>
    /// Interaction logic for UnitEditWindow.xaml
    /// </summary>
    public partial class UnitEditWindow : UserControl, DataObjectForm
    {
        private int ID = 0;
        public UnitEditWindow()
        {
            InitializeComponent();
        }

        public EntityObject EntityObject
        {
            get
            {
                DatabaseMSSQLCE.ADO.Unit u = new DatabaseMSSQLCE.ADO.Unit();
                u.ID = this.ID;
                u.Description = edtDescription.Text;                
                u.ModifiedOn = DateTime.Now;
                u.Name = edtName.Text;
                return u;
            }
        }


        public void FillFormContent(EntityObject item)
        {
            DatabaseMSSQLCE.ADO.Unit u = item as DatabaseMSSQLCE.ADO.Unit;
            edtDescription.Text = u.Description;
            this.ID = u.ID;
            edtName.Text = u.Name;
        }
    }
}
