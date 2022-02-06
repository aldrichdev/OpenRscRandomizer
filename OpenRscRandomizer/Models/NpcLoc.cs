using System;
using System.Collections.Generic;
using System.Text;

namespace OpenRscRandomizer.Models
{
    public class NpcLoc
    {
        public int id { get; set; }
        public Coordinate start { get; set; }
        public Coordinate min { get; set; }
        public Coordinate max { get; set; }
    }
}
