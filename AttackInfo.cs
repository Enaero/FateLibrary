namespace Fate
{
    public class AttackInfo
    {
        public string Name {get; set;}
        public string SkillUsed {get; set;}
        public ICollection<string> ValidDefenseNames {get; set;}
        public string TargetStressName {get; set;}

        public AttackInfo(string name, string skillUsed, string targetStressName, ICollection<string> validDefenseNames)
        {
            Name = name;
            SkillUsed = skillUsed;
            ValidDefenseNames = new HashSet<string>(validDefenseNames);
            TargetStressName = targetStressName;
        }

        public override bool Equals(object? obj)
        {
            if (obj is AttackInfo otherAttackInfo)
            {
                return Name == otherAttackInfo.Name &&
                    SkillUsed == otherAttackInfo.SkillUsed &&
                    TargetStressName == otherAttackInfo.TargetStressName &&
                    ValidDefenseNames.Count == otherAttackInfo.ValidDefenseNames.Count &&
                    !ValidDefenseNames.Except(otherAttackInfo.ValidDefenseNames).Any();
            }
            else
            {
                return base.Equals(obj);
            }
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
