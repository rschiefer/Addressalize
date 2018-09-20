using System;
using System.Collections.Generic;
using System.Text;

namespace Addressalize.StandardData
{
    public class Tens : Dictionary<string, string>
    {
        public Tens()
        {
            this.Add("TWENTY", "2");
            this.Add("THIRTY", "3");
            this.Add("FORTY", "4");
            this.Add("FIFTY", "5");
            this.Add("SIXTY", "6");
            this.Add("SEVENTY", "7");
            this.Add("EIGHTY", "8");
            this.Add("NINTY", "9");
        }
    }
}
