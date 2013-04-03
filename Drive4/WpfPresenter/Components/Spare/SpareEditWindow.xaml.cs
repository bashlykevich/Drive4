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
using Drive4.WpfPresenter.UserControls.LookupDataControl;
using Drive4.Core;
using System.Data.Objects.DataClasses;

namespace Drive4.WpfPresenter.Components.Spare
{
    /// <summary>
    /// Interaction logic for SpareEditWindow.xaml
    /// </summary>
    public partial class SpareEditWindow : UserControl
    {
        public SpareEditWindow()
        {
            InitializeComponent();                                                            
        }   
      
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ldUnit.InitLookupData(DriveController.Instance.DataConnector.Units, "UnitID");
            ldBrand.InitLookupData(DriveController.Instance.DataConnector.Brands, "BrandID");
            ldGroup.InitLookupData(DriveController.Instance.DataConnector.SpareGroups, "GroupID");           
        }        

    }
}
