using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Drive4.Toolkit.Interfaces;
using System.Data.Objects.DataClasses;
using DatabaseMSSQL.ADO;
using System.Windows.Controls;
using System.Windows.Data;

namespace Drive4.MsSqlAdo.Components
{
    class UnitDataManager : DataManager
    {
        driveEntities db;
        public UnitDataManager(driveEntities _db)
        {
            db = _db;
        }

        public void Create(EntityObject item)
        {
            db.AddTounits(item as unit);
            db.SaveChanges();
        }

        public void Update(EntityObject item)
        {
            unit upd = item as unit;
            unit i = db.units.FirstOrDefault(x => x.id == upd.id);
            i = upd;
            db.SaveChanges();
        }

        public void Delete(int ID)
        {         
            unit i = db.units.FirstOrDefault(x => x.id == ID);
            db.DeleteObject(i);
            db.SaveChanges();
        }

        public EntityObject Retrieve(int ID)
        {
            EntityObject eo = db.units.FirstOrDefault(x => x.id == ID);
            return eo;
        }

        public IEnumerable<EntityObject> Retrieve()
        {            
            return db.units;
        }

        public IEnumerable<EntityObject> Retrieve(Dictionary<string, string> SQLFilterParameters)
        {
            return db.units;
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
                // Name
                dc = new DataGridTextColumn();
                dc.Header = "ModifiedOn";
                dc.Binding = new Binding("ModifiedOn");
                columns.Add(dc);
                return columns;
            }
        }
    }
}
