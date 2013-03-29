using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Drive4.Toolkit.Interfaces;
using DatabaseMSSQLCE.ADO;
using System.Windows.Controls;
using System.Windows.Data;

namespace Drive4.MsSqlCe.Components
{
    class UnitDataManager : DataManager
    {
        DriveEntities db;
        public UnitDataManager(DriveEntities db)
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

        public IEnumerable<System.Data.Objects.DataClasses.EntityObject> Retrieve()
        {
            return db.Units;
        }

        public IEnumerable<System.Data.Objects.DataClasses.EntityObject> Retrieve(Dictionary<string, string> SQLFilterParameters)
        {
            throw new NotImplementedException();
        }

        public System.Collections.IEnumerable DataColumns
        {
            get
            {
                List<DataGridColumn> columns = new List<DataGridColumn>();
                DataGridTextColumn dc = new DataGridTextColumn();
                dc.Header = "ID";
                dc.Binding = new Binding("ID");
                columns.Add(dc);

                dc = new DataGridTextColumn();
                dc.Header = "Name";
                dc.Binding = new Binding("Name");
                columns.Add(dc);

                dc = new DataGridTextColumn();
                dc.Header = "Description";
                dc.Binding = new Binding("Description");
                columns.Add(dc);                                

                dc = new DataGridTextColumn();
                dc.Header = "ModifiedOn";
                dc.Binding = new Binding("ModifiedOn");
                columns.Add(dc);
                
                
                return columns;
            }
        }
    }
}