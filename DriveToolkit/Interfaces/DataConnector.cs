using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drive4.Toolkit.Interfaces
{
    public interface DataConnector
    {
        DataManager Spares
        {
            get;
        }
        DataManager Units
        {
            get;
        }
        DataManager Warehouses
        {
            get;
        }
        DataManager SpareGroups
        {
            get;
        }
        DataManager VatRates
        {
            get;
        }
        DataManager SpareOutgoes
        {
            get;
        }
        DataManager SpareIncomes
        {
            get;
        }        
        DataManager SettingsProfiles
        {
            get;
        }
        DataManager Sales
        {
            get;
        }
        DataManager ProfileBankAccounts
        {
            get;
        }
        DataManager Overpricings
        {
            get;
        }
        DataManager OfferingInBasketItems
        {
            get;
        }
        DataManager Invoices
        {
            get;
        }
        DataManager CurrencyRates
        {
            get;
        }
        DataManager Brands
        {
            get;
        }
        DataManager BankAccounts
        {
            get;
        }
        DataManager Banks
        {
            get;
        }
        DataManager Accounts
        {
            get;
        }
    }
}
