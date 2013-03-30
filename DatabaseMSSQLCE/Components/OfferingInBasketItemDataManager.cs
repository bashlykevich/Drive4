using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Drive4.Toolkit.Interfaces;
using DatabaseMSSQLCE.ADO;

namespace Drive4.MsSqlCe.Components
{
    class OfferingInBasketItemDataManager:DataManager
    {
        DriveEntities db;
        public OfferingInBasketItemDataManager(DriveEntities db)
        {
            this.db = db;
        }

        public void Create(System.Data.Objects.DataClasses.EntityObject DataItemToCreate)
        {
            throw new NotImplementedException();
        }

        public void Update(System.Data.Objects.DataClasses.EntityObject DataItemToUpdate)
        {
            throw new NotImplementedException();
        }

        public void Delete(int ID)
        {
            throw new NotImplementedException();
        }

        public System.Data.Objects.DataClasses.EntityObject Retrieve(int ID)
        {
            throw new NotImplementedException();
        }
        public Type EditWindow
        {
            get;
            set;
        }
        public IEnumerable<System.Data.Objects.DataClasses.EntityObject> Retrieve()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<System.Data.Objects.DataClasses.EntityObject> Retrieve(Dictionary<string, string> SQLFilterParameters)
        {
            throw new NotImplementedException();
        }

        public System.Collections.IEnumerable DataColumns
        {
            get { throw new NotImplementedException(); }
        }

        public string Name
        {
            get { throw new NotImplementedException(); }
        }

        public Type EntityType
        {
            get { throw new NotImplementedException(); }
        }
    }
}