using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Drive4.Toolkit.Interfaces;
using DatabaseMSSQLCE.ADO;
using DriveBase.Tools;
using System.Windows.Controls;

namespace Drive4.MsSqlCe.Components
{
    class BrandDataManager : DataManager
    {
        DriveEntities db;
        public BrandDataManager(DriveEntities db)
        {
            this.db = db;
        }

        string name = "Бренды";
        int NextID
        {
            get
            {
                return db.Brands.NextId(x => x.ID);
            }
        }

        public void Create(System.Data.Objects.DataClasses.EntityObject DataItemToCreate)
        {
            Brand u = DataItemToCreate as Brand;
            u.ID = this.NextID;
            db.AddToBrands(u);
            db.SaveChanges();
        }

        public void Update(System.Data.Objects.DataClasses.EntityObject DataItemToUpdate)
        {
            Brand upd = DataItemToUpdate as Brand;
            Brand u = db.Brands.FirstOrDefault(x => x.ID == upd.ID);
            u.Name = upd.Name;
            u.ModifiedOn = upd.ModifiedOn;
            u.Description = upd.Description;
            db.SaveChanges();
        }

        public void Delete(int ID)
        {
            Brand u = db.Brands.FirstOrDefault(x => x.ID == ID);
            db.DeleteObject(u);
            db.SaveChanges();
        }

        public System.Data.Objects.DataClasses.EntityObject Retrieve(int ID)
        {
            return (from s in db.Brands where s.ID == ID select s) as Brand;
        }

        public IEnumerable<System.Data.Objects.DataClasses.EntityObject> Retrieve()
        {
            return from s in db.Brands select s;
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
            get { return typeof(Brand); }
        }
    }
}
