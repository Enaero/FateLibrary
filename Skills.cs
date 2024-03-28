namespace Fate
{
    public class Skill
    {
        public int Value {get; private set;}

        public Skill(int value) 
        {
            Value = value;
        }

        public Skill() {
            Value = 0;
        }
    }

    public class CharacterSkills 
    {
        public Skill Academics = new();
        public Skill Athletics = new();
        public Skill Burglary = new();
        public Skill Contacts = new();
        public Skill Crafts = new();
        public Skill Deceive = new();
        public Skill Drive = new();
        public Skill Empathy = new();
        public Skill Fight = new();
        public Skill Investigate = new();
        public Skill Lore = new();
        public Skill Notice = new();
        public Skill Physique = new();
        public Skill Provoke = new();
        public Skill Rapport = new();
        public Skill Resources = new();
        public Skill Shoot = new();
        public Skill Stealth = new();
        public Skill Will = new();

        public CharacterSkills() {
            // public constructor for making default skills
        }
    }
}
