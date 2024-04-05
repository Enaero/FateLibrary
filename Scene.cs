namespace Fate
{
    public class Scene : FateEntity
    {
        public List<Zone> Zones {get; set;}

        public Scene(string name, Aspect[] aspects, List<Zone>? zones = null) 
            : base(name, aspects)
        {
            Zones = zones is null ? new() : zones.ToList();
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
        public override bool Equals(object? obj)
        {
            if (obj is Scene otherScene)
            {
                if (!base.Equals(otherScene))
                {
                    return false;
                }

                return Zones.Count == otherScene.Zones.Count &&
                    !Zones.Except(otherScene.Zones).Any();
            }
            else
            {
                return base.Equals(obj);
            }
        }
    }
}
