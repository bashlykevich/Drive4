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
    class BankDataManager : DataManager
    {
        DriveEntities db;
        public BankDataManager(DriveEntities db)
        {
            this.db = db;
        }
        
        string name = "Банки";       
        int NextID
        {
            get
            {
                return db.Banks.NextId(x => x.ID);
            }
        }
    
        public void Create(System.Data.Objects.DataClasses.EntityObject DataItemToCreate)
        {
            Bank u = DataItemToCreate as Bank;
            u.ID = this.NextID;
            db.AddToBanks(u);
            db.SaveChanges();
        }

        public void Update(System.Data.Objects.DataClasses.EntityObject DataItemToUpdate)
        {
            Bank upd = DataItemToUpdate as Bank;
            Bank u = db.Banks.FirstOrDefault(x => x.ID == upd.ID);
            u.Name = upd.Name;
            u.ModifiedOn = upd.ModifiedOn;
            u.Address = upd.Address;
            db.SaveChanges();
        }

        public void Delete(int ID)
        {
            Bank u = db.Banks.FirstOrDefault(x => x.ID == ID);
            db.DeleteObject(u);
            db.SaveChanges();
        }

        public System.Data.Objects.DataClasses.EntityObject Retrieve(int ID)
        {
            return (from s in db.Banks where s.ID == ID select s) as Bank;
        }

        public IEnumerable<System.Data.Objects.DataClasses.EntityObject> Retrieve()
        {
            return from s in db.Banks select s;
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
                //columns.Add(Helper.GetDataGridTextColumn("Описание", "Description", 0.30));
                columns.Add(Helper.GetDataGridTextColumn("Дата изменения", "ModifiedOn", 0.30));                              
                return columns;
            }
        }

        public string Name
        {
            get { return name; }
        }
    }
}
