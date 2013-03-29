using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Drive4.Toolkit.Interfaces;
using Drive4.MsSqlAdo.Components;
using DatabaseMSSQL.ADO;

namespace Drive4.MsSqlAdo
{
    class MsSqlAdoConnector:DataConnector
    {
        driveEntities db;
        public MsSqlAdoConnector()
        {
            db = new driveEntities();
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


        public DataManager VatRates
        {
            get { throw new NotImplementedException(); }
        }

        public DataManager SpareOutgoes
        {
            get { throw new NotImplementedException(); }
        }

        public DataManager SpareIncomes
        {
            get { throw new NotImplementedException(); }
        }

        public DataManager SettingsProfiles
        {
            get { throw new NotImplementedException(); }
        }

        public DataManager Sales
        {
            get { throw new NotImplementedException(); }
        }

        public DataManager ProfileBankAccounts
        {
            get { throw new NotImplementedException(); }
        }

        public DataManager Overpricings
        {
            get { throw new NotImplementedException(); }
        }

        public DataManager OfferingInBasketItems
        {
            get { throw new NotImplementedException(); }
        }

        public DataManager Invoices
        {
            get { throw new NotImplementedException(); }
        }

        public DataManager CurrencyRates
        {
            get { throw new NotImplementedException(); }
        }

        public DataManager Brands
        {
            get { throw new NotImplementedException(); }
        }

        public DataManager BankAccounts
        {
            get { throw new NotImplementedException(); }
        }

        public DataManager Banks
        {
            get { throw new NotImplementedException(); }
        }

        public DataManager Accounts
        {
            get { throw new NotImplementedException(); }
        }
    }
}
