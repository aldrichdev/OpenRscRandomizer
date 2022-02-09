using System;
using System.Collections.Generic;
using System.Text;

namespace OpenRscRandomizer.Library.Models
{
    public class GroundItemLoc
    {
        public int id { get; set; }
        public Coordinate pos { get; set; }
        public int amount { get; set; }
        public int respawn { get; set; }
    }
}
