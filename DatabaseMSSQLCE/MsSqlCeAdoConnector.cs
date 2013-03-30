using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Drive4.Toolkit.Interfaces;
using Drive4.MsSqlCe.Components;
using DatabaseMSSQLCE.ADO;

namespace DatabaseMSSQLCE
{
    public class MsSqlCeAdoConnector: DataConnector
    {
        DriveEntities db;

        DataManager units;
        DataManager brands;
        DataManager spares;

        public MsSqlCeAdoConnector()
        {
            db = new DriveEntities();

            units = new UnitDataManager(db);
            brands = new BrandDataManager(db);
            spares = new SpareDataManager(db);
        }
        public DataManager Spares
        {
            get 
            {
                return spares;
            }
        }
        
        public DataManager Units
        {
            get {                
                return units;
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
            get { return brands; }
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
