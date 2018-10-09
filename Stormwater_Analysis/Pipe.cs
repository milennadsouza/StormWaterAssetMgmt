using System;
using System.Collections.Generic;
using System.Text;

namespace Stormwater_Analysis
{
    class Pipe
    {
        

        #region properties
        public string Pipe_ID { get; set; }
        public decimal Size { get; set; }
        public string Dimensions { get; set; }
        public string Material { get; set; }
        public string Road_Crossing { get; set; }
        public string Soil_Type { get; set; }
        public decimal Ground_Slope { get; set; }
        public bool Railway_Crossing { get; set; }
        public string Critical_Infrastructure { get; set; }
        public string Critical_Structure { get; set; }
        public int Maintenance_Records_ID { get; set; }
        #endregion

        #region Constructor
        



        #endregion


    }

    class Manhole
    {
        #region properties
        public int ManholeID { get; set; }
        public int MyProperty { get; set; }
        #endregion

    }
}
