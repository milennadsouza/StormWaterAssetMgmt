using System;
using System.Collections.Generic;
using System.Text;

namespace Stormwater_Analysis
{
    class ManholePipeException: Exception
    {
       public ManholePipeException() : base("incorrect Pipe ID entered. Pipe ID does not exist")
           {
           }
        public ManholePipeException(string messg):base(messg)
        {

        }
    }
}
