using System;
using System.Collections.Generic;
using System.Text;

namespace Addressalize.StandardData
{
    public class Directions : Dictionary<string, string>
    {
        public Directions()
        {
            this.Add("NORTH", "N");
            this.Add("EAST", "E");
            this.Add("SOUTH", "S");
            this.Add("WEST", "W");
            this.Add("NORTHEAST", "NE");
            this.Add("NORTHWEST", "NW");
            this.Add("SOUTHEAST", "SE");
            this.Add("SOUTHWEST", "SW");
        }
    }
}
