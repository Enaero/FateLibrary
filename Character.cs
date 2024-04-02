namespace Fate
{
    public class Character : FateEntity
    {
        public CharacterSkills Skills;
        public Stress PhysicalStress;
        public Stress MentalStress;

        public uint FatePoints;
        
        public uint FateRefresh;

        public Character(
            string name,
            CharacterSkills skills,
            Aspect[] aspects,
            Stress physical,
            Stress mental,
            uint fatePoints = 3,
            uint refreshPoints = 3)
            : base(name, aspects)
        {
            Skills = skills;
            PhysicalStress = physical;
            MentalStress = mental;
            FatePoints = fatePoints;
            FateRefresh = refreshPoints;
        }

        public override int GetHashCode() 
        {
            return base.GetHashCode() + Name.GetHashCode();
        }
    }
}