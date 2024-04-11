namespace Fate
{
    public class ActionIndex
    {
        public Dictionary<string, AttackInfo> Attacks {get; set;}

        public Dictionary<string, DefenseInfo> Defenses {get; set;}

        public ActionIndex(
            Dictionary<string, AttackInfo> attacks,
            Dictionary<string, DefenseInfo> defenses)
        {
            Attacks = attacks;
            Defenses = defenses;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return Attacks.GetHashCode() + Defenses.GetHashCode();
            }
        }

        public override bool Equals(object? obj)
        {
            if (obj is ActionIndex other)
            {
                return Attacks.CollectionEquals(other.Attacks) && 
                    Defenses.CollectionEquals(other.Defenses);
            }
            return base.Equals(obj);
        }
    }
}
