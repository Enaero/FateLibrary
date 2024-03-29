namespace Fate
{
    public class Character
    {
        public string Name {get; private set;}
        public CharacterSkills Skills;
        private Dictionary<string, Aspect> _aspects;
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
        {
            Name = name;
            Skills = skills;
            _aspects = aspects.ToDictionary(aspect => aspect.Name, aspect => aspect);
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