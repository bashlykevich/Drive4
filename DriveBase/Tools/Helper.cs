using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;

namespace DriveBase.Tools
{
    public class Helper
    {
        public static DataGridTextColumn GetDataGridTextColumn(string Header, string BindingName, double WidthInPercents)
        {
            DataGridTextColumn dc = new DataGridTextColumn();
            dc.Header = Header;
            dc.Binding = new Binding(BindingName);
            dc.Width = new DataGridLength(WidthInPercents, DataGridLengthUnitType.Star);
            return dc;
        }
    }
}
