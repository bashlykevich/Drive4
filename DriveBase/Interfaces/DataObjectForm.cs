using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects.DataClasses;

namespace DriveBase.Interfaces
{
    public interface DataObjectForm
    {
        EntityObject EntityObject
        {
            get;
        }
        void FillFormContent(EntityObject obj);
    }
}
