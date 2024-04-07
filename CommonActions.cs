namespace Fate
{
    public class CommonActions
    {
        // Common attack actions
        public static readonly AttackInfo BASIC_ATTACK = new(
            "Basic Attack",
            CharacterSkills.FIGHT,
            Character.PHYSICAL_STRESS_NAME,
            new string[] {"Dodge", "Block", "Brace"}
        );

        // Common defense actions
        public static readonly DefenseInfo DODGE = new(
            "Dodge",
            CharacterSkills.ATHLETICS
        );

        public static readonly DefenseInfo BLOCK = new(
            "Block",
            CharacterSkills.FIGHT
        );

        public static readonly DefenseInfo BRACE = new(
            "Brace",
            CharacterSkills.PHYSIQUE
        );
    }
}
