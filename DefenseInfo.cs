namespace Fate
{
    public class DefenseInfo
    {
        public string Name {get; set;}
        public string SkillUsed {get; set;}

        public DefenseInfo(string name, string skillUsed)
        {
            Name = name;
            SkillUsed = skillUsed;
        }

        public override bool Equals(object? obj)
        {
            if (obj is DefenseInfo other)
            {
                return Name == other.Name &&
                    SkillUsed == other.SkillUsed;
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
