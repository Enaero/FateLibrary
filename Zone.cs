
using System.Collections.Immutable;

namespace Fate
{
    public class Zone
    {
        /// <summary>
        /// Unique identifier to this zone.
        /// </summary>
        public string Name {get; set;}

        /// <summary>
        /// All the different Zones that this Zone connects to.
        /// Key: The direction of the connected zone, e.g. "up", "forward".
        /// Value: The Name of the connected zone.
        /// </summary>
        public Dictionary<string, string> Connections {get; set;}

        /// <summary>
        /// The FateEntities in the scene, identified by their name.
        /// </summary>
        public List<string> Entities {get; set;}

        public Zone(string name, List<string>? entities = null, Dictionary<string, string>? connections = null)
        {
            Name = name;
            Entities = entities is null ? new() : entities;
            Connections = connections is null ? new() : connections;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Zone otherZone)
            {
                if (Name != otherZone.Name)
                {
                    return false;
                }

                if (Connections.Count != otherZone.Connections.Count)
                {
                    return false;
                }
                
                if (Connections.Except(otherZone.Connections).Any())
                {
                    return false;
                }

                if (Entities.Count != otherZone.Entities.Count) {
                    return false;
                }

                return !Entities.Except(otherZone.Entities).Any();
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
