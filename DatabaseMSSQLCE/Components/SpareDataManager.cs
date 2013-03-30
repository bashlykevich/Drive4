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
    class SpareDataManager:DataManager
    {
        DriveEntities db;
        public SpareDataManager(DriveEntities db)
        {
            this.db = db;
        }
              string name = "Запчасти";       
        int NextID
        {
            get
            {
                return db.Spares.NextId(x => x.ID);
            }
        }
     

        public void Create(System.Data.Objects.DataClasses.EntityObject DataItemToCreate)
        {
            Spare u = DataItemToCreate as Spare;
            u.ID = this.NextID;
            u.ModifiedOn = DateTime.Now;
            db.AddToSpares(u);
            db.SaveChanges();
        }

        public void Update(System.Data.Objects.DataClasses.EntityObject DataItemToUpdate)
        {
            Spare upd = DataItemToUpdate as Spare;
            Spare u = db.Spares.FirstOrDefault(x => x.ID == upd.ID);
            u = upd;
            //u.Name = upd.Name;
            u.ModifiedOn = DateTime.Now;
            //u.Description = upd.Description;
            db.SaveChanges();
        }

        public void Delete(int ID)
        {
            Spare u = db.Spares.FirstOrDefault(x => x.ID == ID);
            db.DeleteObject(u);
            db.SaveChanges();
        }

        public System.Data.Objects.DataClasses.EntityObject Retrieve(int ID)
        {
            return (from s in db.Spares where s.ID == ID select s) as Spare;
        }

        public IEnumerable<System.Data.Objects.DataClasses.EntityObject> Retrieve()
        {
            return from s in db.Spares select s;
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
            get { return typeof(Spare); }
        }

        public Type EditWindow
        {
            get;
            set;
        }
    }
}
