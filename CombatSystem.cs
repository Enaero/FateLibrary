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
        private Skill? _attackingSkill;
        private Skill? _defendingSkill;
        private Stress? _defenderStress;

        private DiceRoller? _diceRoller;

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

            int attackDiceTotal = _diceRoller!.Roll().GetTotal();
            int attackTotal = _attackingSkill!.Value + attackDiceTotal;

            int defenseDiceTotal = _diceRoller!.Roll().GetTotal();
            int defenseTotal = defenseDiceTotal + _defendingSkill!.Value;

            int shifts = attackTotal - defenseTotal;

            if (shifts > 0)
            {
                return (int)_defenderStress!.TakeStress((uint) shifts);
            }
            return 0;
        }

        public bool CanAttack()
        {
            return _attackingSkill is not null &&
                _defendingSkill is not null &&
                _defenderStress is not null &&
                _diceRoller is not null;
        }

        public IAttackBuilder WithAttackerSkill(Skill skill)
        {
            _attackingSkill = skill;
            return this;
        }

        public IAttackBuilder WithDefenderSkill(Skill skill)
        {
            _defendingSkill = skill;
            return this;
        }

        public IAttackBuilder WithDefenderStress(Stress stress)
        {
            _defenderStress = stress;
            return this;
        }

        public IAttackBuilder WithDiceRoller(DiceRoller diceRoller)
        {
            _diceRoller = diceRoller;
            return this;
        }
    }
}
