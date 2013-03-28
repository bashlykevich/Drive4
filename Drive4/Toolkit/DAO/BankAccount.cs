using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Drive4.Toolkit.Interfaces;

namespace Drive4.Toolkit.DAO
{
    public class BankAccount : DataItem
    {
        public BankAccount(int id, string name, DateTime modified)
        {
            ID = id;
            Name = name;
            ModifiedOn = modified;
        }
        public int ID
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public DateTime ModifiedOn
        {
            get;
            set;
        }
    }
}
