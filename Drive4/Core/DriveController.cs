﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Drive4.Toolkit.Interfaces;
using Drive4.MsSqlAdo;

namespace Drive4.Core
{
    public class DriveController
    {
        #region singleton
        private static DriveController instance;

        private DriveController()
        {            
            DataConnector = new MsSqlAdoConnector();
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