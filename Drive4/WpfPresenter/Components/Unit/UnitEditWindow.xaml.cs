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

namespace Drive4.WpfPresenter.Components.Unit
{
    /// <summary>
    /// Interaction logic for UnitEditWindow.xaml
    /// </summary>
    public partial class UnitEditWindow : UserControl
    {
        public UnitEditWindow()
        {
            InitializeComponent();
        }
        public EntityObject GetItemFromFields()
        {
            DatabaseMSSQLCE.ADO.Unit u = new DatabaseMSSQLCE.ADO.Unit();

            return u;
        }
    }
}
