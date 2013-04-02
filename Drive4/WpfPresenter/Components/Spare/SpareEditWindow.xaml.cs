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
            ldUnit.SourceDataManager = DriveController.Instance.DataConnector.Units;
            ldBrand.SourceDataManager = DriveController.Instance.DataConnector.Brands;
            ldGroup.SourceDataManager = DriveController.Instance.DataConnector.SpareGroups;
        }
    }
}
