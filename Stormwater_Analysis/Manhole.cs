using System;
using System.Collections.Generic;
using System.Text;

namespace Stormwater_Analysis
{
   /// <summary>
   /// Manhole is a class of Manhole information for each pipe that it is associated with. Many manhole ID's will be mapped to a single pipe.
   /// However, in the Pipe class, only one Manhole ID is mapped - since we track only the starting Manhole ID from the Pipe side.
   /// </summary>
    public class Manhole
    {
        // static private variable to generate unique manhole ID's.
        private static int manhole_value = 0;

        #region properties
        public int ManholeID { get; set; }
        public int PipeID { get; set; } //should be exception handled so user enters only PipeID's from the Pipe class
        public DateTime InstallationDt { get; set; }
        public string ManagedBy { get; set; }
        public Decimal DrainageArea { get; set; }
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
