using System.Diagnostics;

namespace Fate
{
    public interface IAttackBuilder
    {
        /// <summary>
        /// Does the builder have everything it needs to construct an attack.
        /// </summary>
        /// <returns></returns>
        public bool CanAttack();
        public IAttackBuilder WithAttackerSkill(Skill skill);
        public IAttackBuilder WithDefenderSkill(Skill skill);
        public IAttackBuilder WithDefenderStress(Stress stress);
        public IAttackBuilder WithDiceRoller(DiceRoller diceRoller);

        /// <summary>
        /// Performs the attack. If CanAttack() returns false, will no-op 
        /// and log an error.
        /// </summary>
        /// <returns>The number of shits that could not be handled 
        /// by the defender's stress. A positive value probably means
        /// a consequence should be taken.
        /// </returns>
        public int Attack();
    }

    public class AttackBuilder : IAttackBuilder
    {
        private Skill? _AttackingSkill;
        private Skill? _DefendingSkill;
        private Stress? _DefenderStress;

        private DiceRoller? _DiceRoller;

        public AttackBuilder()
        {
        }

        public int Attack()
        {
            if (!CanAttack())
            {
               StackTrace stackTrace = new StackTrace(true);
               Logger.ERROR("Attack was called when it is not ready.\n" + stackTrace.ToString());
               return 0;
            }

            int attackDiceTotal = _DiceRoller!.Roll().GetTotal();
            int attackTotal = _AttackingSkill!.Value + attackDiceTotal;

            int defenseDiceTotal = _DiceRoller!.Roll().GetTotal();
            int defenseTotal = defenseDiceTotal + _DefendingSkill!.Value;

            int shifts = attackTotal - defenseTotal;

            if (shifts > 0)
            {
                return (int)_DefenderStress!.TakeStress((uint) shifts);
            }
            return 0;
        }

        public bool CanAttack()
        {
            return _AttackingSkill is not null &&
                _DefendingSkill is not null &&
                _DefenderStress is not null &&
                _DiceRoller is not null;
        }

        public IAttackBuilder WithAttackerSkill(Skill skill)
        {
            _AttackingSkill = skill;
            return this;
        }

        public IAttackBuilder WithDefenderSkill(Skill skill)
        {
            _DefendingSkill = skill;
            return this;
        }

        public IAttackBuilder WithDefenderStress(Stress stress)
        {
            _DefenderStress = stress;
            return this;
        }

        public IAttackBuilder WithDiceRoller(DiceRoller diceRoller)
        {
            _DiceRoller = diceRoller;
            return this;
        }
    }
}
