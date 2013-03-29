using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data.Objects.DataClasses;

namespace Drive4.Toolkit.Interfaces
{
    public interface DataManager
    {
        Type EntityType
        {
            get;
        }
        string Name
        {
            get;
        }
        void Create(EntityObject DataItemToCreate);
        void Update(EntityObject DataItemToUpdate);
        void Delete(int ID);
        EntityObject Retrieve(int ID);
        IEnumerable<EntityObject> Retrieve();
        IEnumerable<EntityObject> Retrieve(Dictionary<string, string> SQLFilterParameters);
        IEnumerable DataColumns { get;}
    }

}
