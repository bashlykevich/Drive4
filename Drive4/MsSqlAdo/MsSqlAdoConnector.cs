using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Drive4.Toolkit.Interfaces;
using Drive4.MsSqlAdo.Components;

namespace Drive4.MsSqlAdo
{
    class MsSqlAdoConnector:DataConnector
    {
        ADO.driveEntities db;
        public MsSqlAdoConnector()
        {
            db = new ADO.driveEntities();
        }
        public DataManager Spares
        {
            get { throw new NotImplementedException(); }
        }

        public DataManager Units
        {
            get 
            {
                return new UnitDataManager(db);
            }
        }

        public DataManager Warehouses
        {
            get { throw new NotImplementedException(); }
        }

        public DataManager SpareGroups
        {
            get { throw new NotImplementedException(); }
        }
    }
}
