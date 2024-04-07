namespace Fate
{
    public class Character : FateEntity
    {
        public static readonly string PHYSICAL_STRESS_NAME = nameof(PhysicalStress);
        public static readonly string MENTAL_STRESS_NAME = nameof(MentalStress);

        public Dictionary<string, Skill> Skills {get; set;}
        public Stress PhysicalStress  {get; set;}
        public Stress MentalStress {get; set;}

        public uint FatePoints {get; set;}
        
        public uint FateRefresh {get; set;}
        
        public List<string> Attacks {get; set;}
        public List<string> Defenses {get; set;}

        public Character(
            string name,
            Dictionary<string, Skill> skills,
            Aspect[] aspects,
            Stress physicalStress,
            Stress mentalStress,
            List<string> attacks,
            List<string> defenses,
            uint fatePoints = 3,
            uint fateRefresh = 3)
            : base(name, aspects)
        {
            Skills = skills;
            PhysicalStress = physicalStress;
            MentalStress = mentalStress;
            FatePoints = fatePoints;
            FateRefresh = fateRefresh;

            Attacks = new(attacks);
            Defenses = new(defenses);
        }

        public Stress GetStress(string name)
        {
            if (name == PHYSICAL_STRESS_NAME)
            {
                return PhysicalStress;
            }
            else if (name == MENTAL_STRESS_NAME)
            {
                return MentalStress;
            }
            throw new ArgumentException($"Unknown stress name {name}");
        }

        public override int GetHashCode() 
        {
            return Name.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            if (obj is Character otherCharacter)
            {
                return base.Equals(otherCharacter) &&
                    Skills.Count == otherCharacter.Skills.Count &&
                    !Skills.Except(otherCharacter.Skills).Any() &&
                    PhysicalStress.Equals(otherCharacter.PhysicalStress) &&
                    MentalStress.Equals(otherCharacter.MentalStress) &&
                    FatePoints.Equals(otherCharacter.FatePoints) &&
                    FateRefresh.Equals(otherCharacter.FateRefresh) &&
                    Attacks.Count == otherCharacter.Attacks.Count &&
                    Defenses.Count == otherCharacter.Defenses.Count &&
                    !Attacks.Except(otherCharacter.Attacks).Any() &&
                    !Defenses.Except(otherCharacter.Defenses).Any();
            }
            else {
                return base.Equals(obj);
            }
        }

        public override string ToString()
        {
            return $"Character[Name: {Name}, " +
                $"Aspects: {Aspects.Length}, " + 
                $"FatePoints: {FatePoints}, " +
                $"FateRefresh: {FateRefresh}, " +
                $"PhysicalStress: {PhysicalStress}, " + 
                $"MentalStress: {MentalStress}]";
        }
    }
}