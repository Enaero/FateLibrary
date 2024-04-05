using System.Text;

namespace Fate
{
    public class Skill
    {
        public int Value {get; set;}

        public Skill(int value) 
        {
            Value = value;
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

        public override string ToString()
        {
            return $"SkillVal[{Value}]";
        }
    }

    public class CharacterSkills 
    {
        public Skill Academics {get; set;}
        public Skill Athletics {get; set;}
        public Skill Burglary {get; set;}
        public Skill Contacts {get; set;}
        public Skill Crafts {get; set;}
        public Skill Deceive {get; set;}
        public Skill Drive {get; set;}
        public Skill Empathy {get; set;}
        public Skill Fight {get; set;}
        public Skill Investigate {get; set;}
        public Skill Lore {get; set;}
        public Skill Notice {get; set;}
        public Skill Physique {get; set;}
        public Skill Provoke {get; set;}
        public Skill Rapport {get; set;}
        public Skill Resources {get; set;}
        public Skill Shoot {get; set;}
        public Skill Stealth {get; set;}
        public Skill Will {get; set;}

        public CharacterSkills() {
            Academics = new(0);
            Athletics = new(0);
            Burglary = new(0);
            Contacts = new(0);
            Crafts = new(0);
            Deceive = new(0);
            Drive = new(0);
            Empathy = new(0);
            Fight = new(0);
            Investigate = new(0);
            Lore = new(0);
            Notice = new(0);
            Physique = new(0);
            Provoke = new(0);
            Rapport = new(0);
            Resources = new(0);
            Shoot = new(0);
            Stealth = new(0);
            Will = new(0);
        }

        public CharacterSkills(
            Skill academics,
            Skill athletics,
            Skill burglary,
            Skill contacts,
            Skill crafts,
            Skill deceive,
            Skill drive,
            Skill empathy,
            Skill fight,
            Skill investigate,
            Skill lore,
            Skill notice,
            Skill physique,
            Skill provoke,
            Skill rapport,
            Skill resources,
            Skill shoot,
            Skill stealth,
            Skill will
        ) {
            Academics = academics;
            Athletics = athletics;
            Burglary = burglary;
            Contacts = contacts;
            Crafts = crafts;
            Deceive = deceive;
            Drive = drive;
            Empathy = empathy;
            Fight = fight;
            Investigate = investigate;
            Lore = lore;
            Notice = notice;
            Physique = physique;
            Provoke = provoke;
            Rapport = rapport;
            Resources = resources;
            Shoot = shoot;
            Stealth = stealth;
            Will = will;
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

        public override string ToString()
        {
            StringBuilder sb = new();
            foreach (Skill skill in GetAllSkills())
            {
                sb.AppendLine(skill.ToString());
            }

            return sb.ToString();
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
