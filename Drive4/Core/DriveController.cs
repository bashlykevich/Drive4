using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Drive4.Toolkit.Interfaces;
using Drive4.WpfPresenter.Components.Unit;
using Drive4.WpfPresenter.Components.Brand;
using Drive4.WpfPresenter.Components.Spare;

namespace Drive4.Core
{
    public class DriveController
    {
        #region singleton
        private static DriveController instance;

        private DriveController()
        {
            DataConnector = new DatabaseMSSQLCE.MsSqlCeAdoConnector();
            SetEditWindows();
        }
        void SetEditWindows()
        {
            DataConnector.Units.EditWindow = typeof(UnitEditWindow);
            DataConnector.Brands.EditWindow = typeof(BrandEditWindow);
            DataConnector.Spares.EditWindow = typeof(SpareEditWindow);
        }
        public static DriveController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DriveController();
                }
                return instance;
            }
        }
        #endregion

        public DataConnector DataConnector;
    }
}
