using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Drive4.Toolkit.Interfaces;
using DatabaseMSSQLCE.ADO;
using System.Windows.Controls;
using DriveBase.Tools;

namespace Drive4.MsSqlCe.Components
{
    class SpareGroupDataManager : DataManager
    {
        DriveEntities db;
        public SpareGroupDataManager(DriveEntities db)
        {
            this.db = db;
        }
        public Type EditWindow
        {
            get;
            set;
        }
        public void Create(System.Data.Objects.DataClasses.EntityObject DataItemToCreate)
        {
            SpareGroup u = DataItemToCreate as SpareGroup;
            u.ID = this.NextID;
            db.AddToSpareGroups(u);
            db.SaveChanges();
        }

        public void Update(System.Data.Objects.DataClasses.EntityObject DataItemToUpdate)
        {
            SpareGroup upd = DataItemToUpdate as SpareGroup;
            SpareGroup u = db.SpareGroups.FirstOrDefault(x => x.ID == upd.ID);
            u.Name = upd.Name;
            u.ModifiedOn = upd.ModifiedOn;
            u.Description = upd.Description;
            db.SaveChanges();
        }

        public void Delete(int ID)
        {
            SpareGroup u = db.SpareGroups.FirstOrDefault(x => x.ID == ID);
            db.DeleteObject(u);
            db.SaveChanges();
        }

        public System.Data.Objects.DataClasses.EntityObject Retrieve(int ID)
        {
            SpareGroup i = db.SpareGroups.FirstOrDefault(x => x.ID == ID);
            return i;
        }

        public IEnumerable<System.Data.Objects.DataClasses.EntityObject> Retrieve()
        {
            return from s in db.SpareGroups select s;
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
                columns.Add(Helper.GetDataGridTextColumn("ID", "ID", 0.1));
                columns.Add(Helper.GetDataGridTextColumn("Название", "Name", 0.30));
                columns.Add(Helper.GetDataGridTextColumn("Описание", "Description", 0.30));
                columns.Add(Helper.GetDataGridTextColumn("Дата изменения", "ModifiedOn", 0.30));
                return columns;
            }
        }

        string name = "Группы";
        public string Name
        {
            get { return name; }
        }

        public Type EntityType
        {
            get { return typeof(SpareGroup); }
        }
        int NextID
        {
            get
            {
                return db.SpareGroups.NextId(x => x.ID);
            }
        }

    }
}
