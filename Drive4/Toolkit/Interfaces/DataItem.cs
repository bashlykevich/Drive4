using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drive4.Toolkit.Interfaces
{
    public interface DataItem
    {
        int ID
        {
            get;
        }
        string Name
        {
            get;
        }
        DateTime ModifiedOn
        {
            get;
        }
    }
}
