﻿using System;
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
        string name = "Единицы измерения";
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
    }
}