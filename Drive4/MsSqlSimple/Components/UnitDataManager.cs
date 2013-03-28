using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Drive4.Toolkit.Interfaces;
using System.Data.SqlClient;
using System.Windows.Controls;
using System.Windows.Data;
using Drive4.Toolkit.DAO;
using System.Data;

namespace Drive4.MsSqlSimple.Components
{
    class UnitDataManager//:DataManager
    {
        SqlConnection OpenedConnection;
        public UnitDataManager(SqlConnection ActiveConnection)
        {
            OpenedConnection = ActiveConnection;
        }
        
        public void Create(DataItem DataItemToCreate)
        {
            string sql = @"INSERT INTO [drive].[dbo].[unit] ([name] ,[ModifiedOn]) VALUES (@Name ,@ModifiedOn)";

            using (SqlCommand sqlComm = OpenedConnection.CreateCommand())
            {                
                sqlComm.CommandText = sql;

                sqlComm.Parameters.Add("@Name", SqlDbType.VarChar);
                sqlComm.Parameters.Add("@ModifiedOn", SqlDbType.DateTime);

                sqlComm.Parameters["@Name"].Value = DataItemToCreate.Name;
                sqlComm.Parameters["@ModifiedOn"].Value = DataItemToCreate.ModifiedOn;

                sqlComm.ExecuteNonQuery();
            }
        }

        public void Update(DataItem DataItemToUpdate)
        {
            string sql = @"UPDATE [drive].[dbo].[unit]
                           SET [name] = @Name,
                               [ModifiedOn] = @ModifiedOn
                           WHERE [ID] = @ID";

            using (SqlCommand sqlComm = OpenedConnection.CreateCommand())
            {
                sqlComm.CommandText = sql;

                sqlComm.Parameters.Add("@ID", SqlDbType.Int);
                sqlComm.Parameters.Add("@Name", SqlDbType.VarChar);
                sqlComm.Parameters.Add("@ModifiedOn", SqlDbType.DateTime);

                sqlComm.Parameters["@ID"].Value = DataItemToUpdate.ID;
                sqlComm.Parameters["@Name"].Value = DataItemToUpdate.Name;
                sqlComm.Parameters["@ModifiedOn"].Value = DataItemToUpdate.ModifiedOn;

                sqlComm.ExecuteNonQuery();
            }
        }

        public void Delete(int ID)
        {
            string sql = "DELETE FROM DBO.UNIT WHERE [ID] = " + ID.ToString();            
            using (SqlCommand command = new SqlCommand(sql, OpenedConnection))
            {
                command.ExecuteNonQuery();
            }
        }

        public DataItem Retrieve(int ID)
        {
            string sql = "SELECT * FROM DBO.UNIT WHERE [ID] = " + ID.ToString();

            DataItem item = new Unit();
            using (SqlCommand command = new SqlCommand(sql, OpenedConnection))
            {
                SqlDataReader sqlReader = command.ExecuteReader();
                try
                {
                    while (sqlReader.Read())
                    {                        
                        string Name = (string)sqlReader["Name"];
                        DateTime date = (DateTime)sqlReader["ModifiedOn"];
                        item = new Unit(ID, Name, date);                        
                    }
                }               
                finally
                {
                    sqlReader.Close();
                }
            }
            return item;
        }

        public IEnumerable<DataItem> Retrieve()
        {
            string sql = "SELECT * FROM DBO.UNIT";
            List<DataItem> items = new List<DataItem>();
            using (SqlCommand command = new SqlCommand(sql, OpenedConnection))
            {
                SqlDataReader sqlReader = command.ExecuteReader();
                try
                {
                    while (sqlReader.Read())
                    {
                        int ID = (int)sqlReader["ID"];
                        string Name = (string)sqlReader["Name"];
                        DateTime date = (DateTime)sqlReader["ModifiedOn"];
                        Unit i = new Unit(ID, Name, date);
                        items.Add(i);                       
                    }
                }
            
                finally
                {
                    sqlReader.Close();
                }
            }
            return items;
        }

        public IEnumerable<DataItem> Retrieve(Dictionary<string, string> SQLFilterParameters)
        {
            string sql = "SELECT * FROM DBO.UNIT";
            
            // FILTERS
            if (SQLFilterParameters.Count > 0)
            {
                sql += " WHERE ";
                foreach (var pair in SQLFilterParameters)
                {
                    sql += pair.Key + " " + pair.Value + " AND ";
                }
                sql = sql.Substring(0, sql.Length - 5);
            }

            List<DataItem> items = new List<DataItem>();
            using (SqlCommand command = new SqlCommand(sql, OpenedConnection))
            {
                SqlDataReader sqlReader = command.ExecuteReader();
                try
                {
                    while (sqlReader.Read())
                    {
                        int ID = (int)sqlReader["ID"];
                        string Name = (string)sqlReader["Name"];
                        DateTime date = (DateTime)sqlReader["ModifiedOn"];
                        Unit i = new Unit(ID, Name, date);
                        items.Add(i);
                    }
                }               
                finally
                {
                    sqlReader.Close();
                }
            }
            return items;
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
