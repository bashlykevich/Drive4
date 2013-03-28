using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drive4.Toolkit.Interfaces
{
    public interface DataConnector
    {
        DataManager Spares
        {
            get;
        }
        DataManager Units
        {
            get;
        }
        DataManager Warehouses
        {
            get;
        }
        DataManager SpareGroups
        {
            get;
        }
    
    }
}
