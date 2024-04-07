using System.Text;

namespace Fate
{
    public class Skill
    {
        public string Name {get; set;}
        public int Value {get; set;}

        public Skill(string name, int value) 
        {
            Value = value;
            Name = name;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Skill objSkill)
            {
                return objSkill.Value == Value && objSkill.Name == Name;
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() + Value;
        }

        public override string ToString()
        {
            return $"[{Name}:{Value}]";
        }
    }
}
