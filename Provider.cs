
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
        public Dictionary<string, Skill> GetDefaultSkills()
        {
            return new Dictionary<string, Skill>()
            {
                { CharacterSkills.ATHLETICS, new Skill(CharacterSkills.ATHLETICS, 0) },
                { CharacterSkills.ACADEMICS, new Skill(CharacterSkills.ACADEMICS, 0) },
                { CharacterSkills.BURGLARY, new Skill(CharacterSkills.BURGLARY, 0) },
                { CharacterSkills.CONTACTS, new Skill(CharacterSkills.CONTACTS, 0) },
                { CharacterSkills.CRAFTS, new Skill(CharacterSkills.CRAFTS, 0) },
                { CharacterSkills.DECEIVE, new Skill(CharacterSkills.DECEIVE, 0) },
                { CharacterSkills.DRIVE, new Skill(CharacterSkills.DRIVE, 0) },
                { CharacterSkills.EMPATHY, new Skill(CharacterSkills.EMPATHY, 0) },
                { CharacterSkills.FIGHT, new Skill(CharacterSkills.FIGHT, 0) },
                { CharacterSkills.INVESTIGATE, new Skill(CharacterSkills.INVESTIGATE, 0) },
                { CharacterSkills.LORE, new Skill(CharacterSkills.LORE, 0) },
                { CharacterSkills.NOTICE, new Skill(CharacterSkills.NOTICE, 0) },
                { CharacterSkills.PHYSIQUE, new Skill(CharacterSkills.PHYSIQUE, 0) },
                { CharacterSkills.PROVOKE, new Skill(CharacterSkills.PROVOKE, 0) },
                { CharacterSkills.RAPPORT, new Skill(CharacterSkills.RAPPORT, 0) },
                { CharacterSkills.RESOURCES, new Skill(CharacterSkills.RESOURCES, 0) },
                { CharacterSkills.SHOOT, new Skill(CharacterSkills.SHOOT, 0) },
                { CharacterSkills.STEALTH, new Skill(CharacterSkills.STEALTH, 0) },
                { CharacterSkills.WILL, new Skill(CharacterSkills.WILL, 0) }
            };
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
                new string[] {
                    CommonActions.BASIC_ATTACK.Name
                }.ToList(),
                new string[] {
                    CommonActions.BLOCK.Name,
                     CommonActions.DODGE.Name,
                      CommonActions.BRACE.Name
                }.ToList(),
                3,
                3
            );
        }

        public Zone GetDefaultZone(string name)
        {
            return new Zone(name, null, null);
        }

        public Scene GetDefaultScene(string name)
        {
            return new Scene(name, Array.Empty<Aspect>(), null);
        }

        public SceneIndex GetEmptySceneIndex()
        {
            return new SceneIndex();
        }

        public WorldIndex GetEmptyWorld()
        {
            return new WorldIndex();
        }
    }

}