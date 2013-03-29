using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Drive4.Toolkit.Interfaces;
using DatabaseMSSQLCE.ADO;
using System.Windows.Controls;
using System.Windows.Data;
using DriveBase.Tools;

namespace Drive4.MsSqlCe.Components
{
    class UnitDataManager : DataManager
    {
        Type type = typeof(Unit);
        string name = "Единицы измерения";
        DriveEntities db;
        int NextID
        {
            get
            {
                return db.Units.NextId(x => x.ID);
            }
        }
        public UnitDataManager(DriveEntities db)
        {
            this.db = db;
        }

        public void Create(System.Data.Objects.DataClasses.EntityObject DataItemToCreate)
        {
            Unit u = DataItemToCreate as Unit;
            u.ID = this.NextID;
            db.AddToUnits(u);
            db.SaveChanges();
        }

        public void Update(System.Data.Objects.DataClasses.EntityObject DataItemToUpdate)
        {
            Unit upd = DataItemToUpdate as Unit;
            Unit u = db.Units.FirstOrDefault(x => x.ID == upd.ID);
            u.Name = upd.Name;
            u.ModifiedOn = upd.ModifiedOn;
            u.Description = upd.Description;
            db.SaveChanges();
        }

        public void Delete(int ID)
        {            
            Unit u = db.Units.FirstOrDefault(x => x.ID == ID);
            db.DeleteObject(u);
            db.SaveChanges();
        }

        public System.Data.Objects.DataClasses.EntityObject Retrieve(int ID)
        {
            return (from s in db.Units where s.ID == ID select s) as Unit;
        }

        public IEnumerable<System.Data.Objects.DataClasses.EntityObject> Retrieve()
        {
            return from s in db.Units select s;
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

        public string Name
        {
            get { return name; }
        }

        public Type EntityType
        {
            get { return type; }
        }
    }
}