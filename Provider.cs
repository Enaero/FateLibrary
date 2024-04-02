
namespace Fate
{
    public class DependencyProvider
    {
        public DependencyProvider()
        {
            // no-op
        }

        /// <summary>
        /// Gets a 4dF DiceRoller. Rolles 4 Fate dice,
        /// with each Fate die rolling a -1, 0, or 1.
        /// </summary>
        /// <returns>Fate Dice Roller</returns>
        public DiceRoller GetFateDice()
        {
            int[] possibleValues = new[] {-1, 0, 1};
            int seed = (int) System.DateTime.Now.Ticks;

            DieRoller[] dice = new DieRoller[4] {
                new(possibleValues, new Random(seed)),
                new(possibleValues, new Random(seed + 1)),
                new(possibleValues, new Random(seed + 2)),
                new(possibleValues, new Random(seed + 3)),
            };

            return new DiceRoller(dice);
        }

        /// <summary>
        /// Default skills is defined as 0 for every skill.
        /// </summary>
        /// <returns>Skills at 0 each.</returns>
        public CharacterSkills GetDefaultSkills()
        {
            return new CharacterSkills();
        }

        public Stress GetDefaultStress(string name)
        {
            return new Stress(name, 3, 0);
        }

        public Character GetDefaultCharacter(string name)
        {
            return new Character(
                name,
                GetDefaultSkills(),
                Array.Empty<Aspect>(),
                GetDefaultStress("Physical"),
                GetDefaultStress("Mental"),
                3,
                3
            );
        }
    }

}