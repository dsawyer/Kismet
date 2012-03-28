using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace KismetDataTypes
{
    /// <summary>
    /// Small class that models, on a simpler scale for the sake of
    /// of the xml and Level class, a pickup item
    /// </summary>
    public class Pickup
    {
        // The name/id of the pickup item
        public string Name;
        // The type of item it is
        public string Type;
        // The position in the world where the item is located
        public Vector2 Position;
    }
}
