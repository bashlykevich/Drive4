using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Drive4.Toolkit.Interfaces;
using DatabaseMSSQLCE.ADO;
using System.Windows.Controls;
using DriveBase.Tools;
using System.Diagnostics;

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
            Debug.Assert(u.UnitID != null);
            u.ID = this.NextID;
            u.ModifiedOn = DateTime.Now;
            db.AddToSpares(u);
            db.SaveChanges();
        }

        public void Update(System.Data.Objects.DataClasses.EntityObject DataItemToUpdate)
        {
            Spare upd = DataItemToUpdate as Spare;
            Debug.Assert(upd.UnitID != null);
            Spare u = db.Spares.FirstOrDefault(x => x.ID == upd.ID);            
            u = upd;
            u.ModifiedOn = DateTime.Now;
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
            Spare i = db.Spares.FirstOrDefault(x => x.ID == ID);
            return i;
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
                //columns.Add(Helper.GetDataGridTextColumn("ID", "ID", 0.1));
                columns.Add(Helper.GetDataGridTextColumn("Код магазина", "CodeI", 0.2));
                columns.Add(Helper.GetDataGridTextColumn("Код ШАТЕ-М", "CodeS", 0.2));
                columns.Add(Helper.GetDataGridTextColumn("Название", "Name", 0.4));                
                columns.Add(Helper.GetDataGridTextColumn("Потребность", "QDemand", 0.1));
                columns.Add(Helper.GetDataGridTextColumn("Остаток", "QRest", 0.1));
                //columns.Add(Helper.GetDataGridTextColumn("Описание", "Description", 0.20));
                //columns.Add(Helper.GetDataGridTextColumn("Дата изменения", "ModifiedOn", 0.20));
                //columns.Add(Helper.GetDataGridTextColumn("UnitID", "UnitID", 0.10));
                //columns.Add(Helper.GetDataGridTextColumn("BrandID", "BrandID", 0.10));
                //columns.Add(Helper.GetDataGridTextColumn("GroupID", "GroupID", 0.10));
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
