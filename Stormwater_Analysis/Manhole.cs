using System;
using System.Collections.Generic;
using System.Text;

namespace Stormwater_Analysis
{
   
    class Manhole
    {
        // static private variable to generate unique manhole ID's.
        private static int manhole_value = 0;

        #region properties
        public int ManholeID { get; set; }
        public DateTime InstallationDt { get; set; }
        public string ManagedBy { get; set; }
        public string DrainageArea { get; set; }
        #endregion

        #region Constructor
        public Manhole()
        {
            manhole_value = manhole_value++;
            ManholeID = manhole_value;
        }
        #endregion
    }

}
