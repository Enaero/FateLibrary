namespace Fate
{
    public class Character : FateEntity
    {
        public CharacterSkills Skills {get; set;}
        public Stress PhysicalStress  {get; set;}
        public Stress MentalStress {get; set;}

        public uint FatePoints {get; set;}
        
        public uint FateRefresh {get; set;}
        
        public Character(
            string name,
            CharacterSkills skills,
            Aspect[] aspects,
            Stress physicalStress,
            Stress mentalStress,
            uint fatePoints = 3,
            uint fateRefresh = 3)
            : base(name, aspects)
        {
            Skills = skills;
            PhysicalStress = physicalStress;
            MentalStress = mentalStress;
            FatePoints = fatePoints;
            FateRefresh = fateRefresh;
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
                    Skills.Equals(otherCharacter.Skills) &&
                    PhysicalStress.Equals(otherCharacter.PhysicalStress) &&
                    MentalStress.Equals(otherCharacter.MentalStress) &&
                    FatePoints.Equals(otherCharacter.FatePoints) &&
                    FateRefresh.Equals(otherCharacter.FateRefresh);
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