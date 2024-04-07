using System.Diagnostics;

namespace Fate
{
    /// <summary>
    /// Stateless system that performs combat operations on Fate data types.
    /// </summary>
    public class CombatSystem
    {
        private readonly IDiceRoller _DiceRoller;

        public CombatSystem(IDiceRoller diceRoller)
        {
            _DiceRoller = diceRoller;
        }

        /// <summary>
        /// Performs the attack by attacker on to defender, 
        /// modifying defender stress if necessary. Returns
        /// any remaining damage that the character was unable
        /// to absorb by stress.
        /// </summary>
        /// <param name="attacker">The attacking character.</param>
        /// <param name="attackInfo">The attack's information.</param>
        /// <param name="defender">The defending character.</param>
        /// <param name="defenseInfo">The chosen defense's information</param>
        /// <returns></returns>
        public int Attack(Character attacker, AttackInfo attackInfo, Character defender, DefenseInfo defenseInfo)
        {
            if (!attacker.Skills.TryGetValue(attackInfo.SkillUsed, out Skill? attackingSkill))
            {
                Logger.ERROR($"[Attack] {attackInfo.SkillUsed} not found in character skills. Assuming 0.");
            }
            int attackingSkillValue = attackingSkill is null ? 0 : attackingSkill.Value;

            if (!defender.Skills.TryGetValue(defenseInfo.SkillUsed, out Skill? defendingSkill))
            {
                Logger.ERROR($"[Defense] {defenseInfo.SkillUsed} not found in character skills. Assuming 0.");
            }
            int defendingSkillValue = defendingSkill is null ? 0 : defendingSkill.Value;

            int attackRoll = _DiceRoller.Roll().GetTotal();
            int defenseRoll = _DiceRoller.Roll().GetTotal();

            int attackValue = attackRoll + attackingSkillValue;
            int defenseValue = defenseRoll + defendingSkillValue;

            int shiftsOfDamage = attackValue - defenseValue;

            if (shiftsOfDamage > 0)
            {
                Stress targetStress = defender.GetStress(attackInfo.TargetStressName);
                // The damage that could not be absorbed by the target stress.
                return (int) targetStress.TakeStress((uint) shiftsOfDamage);
            }
            else {
                return 0;
            }
        }
    }
}
