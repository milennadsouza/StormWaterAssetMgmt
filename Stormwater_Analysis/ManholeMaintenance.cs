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
    /// <summary>
    /// Class to manage the Maintenance Records and Data of Manhole assets
    /// </summary>
    class ManholeMaintenance
    {
        private static int maintId;
        #region properties
        /// <summary>
        /// maintenanceIssues - takes in paragraphs of text describing any issues the officer finds.
        /// </summary>
        public int MaintenanceID { get; set; }
         public int ManholeID { get; set; }
         public string CoverCondition { get; set; }
         public string FrameCondition { get; set; }
         public string FrameSealCondition { get; set; }
         public string CheckedBy { get; set; }
        public DateTime LastMaintenanceDt { get; set; }
        public TypesOfMaintenance MaintenanceLevel { get; set; }
        public string MaintenanceIssues { get; set; }
        #endregion
         
        
        
        #region Constructor
        public ManholeMaintenance()
        {
            maintId = ++maintId;
            MaintenanceID = maintId;
        }
        #endregion
        
    }

}
