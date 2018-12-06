using System;
using System.Collections.Generic;
using System.Text;
enum TypesOfMaintenance{
    HighLevel,
    LowLevel,
    MediumLevel
}
namespace Stormwater_Analysis
{
    class Maintenance
    {
        private static int maintId;
        #region properties
        int MaintenanceID { get; set; }
        string MaintenanceOfficer { get; set; }
        DateTime LastMaintenanceDt { get; set; }
        TypesOfMaintenance MaintenanceType { get; set; }
        string MaintenanceIssues { get; set; }
        #endregion
        
        #region Constructor
        public Maintenance()
        {
            maintId = ++maintId;
            MaintenanceID = maintId;
        }
        #endregion
    }

}
