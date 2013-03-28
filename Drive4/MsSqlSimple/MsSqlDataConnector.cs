using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Drive4.Toolkit.Interfaces;
using Drive4.MsSqlSimple.Components;
using System.Data.SqlClient;

namespace Drive4.MsSqlSimple
{
    class MsSqlDataConnector:DataConnector
    {
        SqlConnection OpenedConnection;
        public MsSqlDataConnector(string _ConnectionString)
        {
            OpenedConnection = new SqlConnection(_ConnectionString);
            OpenedConnection.Open();
        }
        public DataManager Spares
        {
            get { throw new NotImplementedException(); }
        }

        public DataManager Units
        {
            get { throw new NotImplementedException(); }
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
