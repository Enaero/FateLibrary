namespace Fate
{
    public class Skill
    {
        public int Value {get; private set;}

        public Skill(int value) 
        {
            Value = value;
        }

        public Skill()
        {
            Value = 0;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Skill objSkill)
            {
                return objSkill.Value == Value;
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() + Value;
        }
    }

    public class CharacterSkills 
    {
        public Skill Academics;
        public Skill Athletics;
        public Skill Burglary;
        public Skill Contacts;
        public Skill Crafts;
        public Skill Deceive;
        public Skill Drive;
        public Skill Empathy;
        public Skill Fight;
        public Skill Investigate;
        public Skill Lore;
        public Skill Notice;
        public Skill Physique;
        public Skill Provoke;
        public Skill Rapport;
        public Skill Resources;
        public Skill Shoot;
        public Skill Stealth;
        public Skill Will;

        public CharacterSkills() {
            Academics = new();
            Athletics = new();
            Burglary = new();
            Contacts = new();
            Crafts = new();
            Deceive = new();
            Drive = new();
            Empathy = new();
            Fight = new();
            Investigate = new();
            Lore = new();
            Notice = new();
            Physique = new();
            Provoke = new();
            Rapport = new();
            Resources = new();
            Shoot = new();
            Stealth = new();
            Will = new();
        }

        public override bool Equals(object? obj)
        {
            if (obj is CharacterSkills otherSkills)
            {
                Skill[] allSkills = GetAllSkills();
                Skill[] otherAllSkills = otherSkills.GetAllSkills();

                if (allSkills.Length != otherAllSkills.Length)
                {
                    return false;
                }

                for (int i = 0; i < allSkills.Length; ++i)
                {
                    if (!allSkills[i].Equals(otherAllSkills[i]))
                    {
                        return false;
                    }
                }
                return true;
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            int result = 0;
            Skill[] allSkills = GetAllSkills();
    
            unchecked 
            {
                foreach (Skill skill in allSkills) 
                {
                    result *= skill.Value;
                    result <<= 2;
                    result += skill.Value;
                }
                result += base.GetHashCode();
            }


            return result;
        }

        private Skill[] GetAllSkills()
        {
            return new Skill[] {
                Academics,
                Athletics,
                Burglary,
                Contacts,
                Crafts,
                Deceive,
                Drive,
                Empathy,
                Fight,
                Investigate,
                Lore,
                Notice,
                Physique,
                Provoke,
                Rapport,
                Resources,
                Shoot,
                Stealth,
                Will
            };
        }
    }
}
