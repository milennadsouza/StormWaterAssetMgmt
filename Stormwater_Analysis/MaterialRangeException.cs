using System;
using System.Collections.Generic;
using System.Text;

namespace Stormwater_Analysis
{
    class MaterialRangeException : Exception
    {
        public MaterialRangeException() : base("incorrect material names entered")//constructor called when no message is passed with exception, but we are defaulting to a message being displayed
        {
        }

        public MaterialRangeException(string msg) : base(msg) //have to call the constructor of the base class
        {
        }
        private string extraparaminfo; //to be user within here
        public string paraminfo // public property that can be set or get. Set and Get methods created for the property
        {
            get
            {
                return extraparaminfo;
            }
            set
            {
                extraparaminfo = value;
            }
        }

    

    }
}
