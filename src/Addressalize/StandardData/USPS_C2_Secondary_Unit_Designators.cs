using System;
using System.Collections.Generic;
using System.Text;

namespace Addressalize.StandardData
{
    public class USPS_C2_Secondary_Unit_Designators : Dictionary<string, string>
    {
        /// <summary>
        /// Secondary Unit Designators from USPS as of 2018.09.21.  https://pe.usps.com/text/pub28/28apc_003.htm
        /// </summary>
        public USPS_C2_Secondary_Unit_Designators()
        {
            this.Add("APARTMENT", "APT");
            this.Add("BASEMENT", "BSMT");
            this.Add("BUILDING", "BLDG");
            this.Add("DEPARTMENT", "DEPT");
            this.Add("FLOOR", "FL");
            this.Add("FRONT", "FRNT");
            this.Add("HANGER", "HNGR");
            this.Add("KEY", "KEY");
            this.Add("LOBBY", "LBBY");
            this.Add("LOT", "LOT");
            this.Add("LOWER", "LOWR"); 
            this.Add("OFFICE", "OFC");
            this.Add("PENTHOUSE", "PH");
            this.Add("PIER", "PIER");
            this.Add("REAR", "REAR");
            this.Add("ROOM", "RM");
            this.Add("Side", "SIDE");
            this.Add("SLIP", "SLIP");
            this.Add("SPACE", "SPC");
            this.Add("STOP", "STOP");
            this.Add("SUITE", "STE");
            this.Add("TRAILER", "TRLR");
            this.Add("UNIT", "UNIT");
            this.Add("UPPER", "UPPR");

        }
    }
}
