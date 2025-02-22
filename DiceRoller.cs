namespace Fate
{
    public interface IDieRoller
    {
        IDieRoller Roll();
    }

    public class DieRoller : IDieRoller
    {
        private readonly object _RollLock = new();

        private readonly Random _Random;
        private readonly int[] _PossibleValues;

        public int RolledValue {get; private set;}

        public DieRoller(int[] values, Random seed)
        {
            _Random = seed;
            _PossibleValues = values;
            Roll();
        }

        public IDieRoller Roll()
        {
            lock(_RollLock)
            {
                int index = _Random.Next(_PossibleValues.Length);
                RolledValue = _PossibleValues[index];
                return this;
            }
        }

        public override string ToString()
        {
            return $"df[{RolledValue}]";
        }
    }

    public interface IDiceRoller
    {
        IDiceRoller Roll();
        int GetTotal();
        DieRoller[] GetDice();
    }

    public class DiceRoller : IDiceRoller
    {
        private readonly object _RollLock = new();
        private readonly DieRoller[] _Dice;

        public DiceRoller(DieRoller[] dice)
        {
            _Dice = dice;
        }

        /// <summary>
        /// Rolls the internal dice and returns itself for stacking function calls.
        /// Example: diceRoller.Roll().GetTotal();
        /// </summary>
        /// <returns>A reference to this FateDiceRoller</returns>
        public IDiceRoller Roll()
        {
            lock(_RollLock)
            {
                foreach (DieRoller die in _Dice)
                {
                    die.Roll();

                }
                return this;
            }
        }

        public int GetTotal() 
        {
            lock(_RollLock)
            {
                return _Dice.Select(die => die.RolledValue).Sum();
            }
        }

        public DieRoller[] GetDice()
        {
            lock(_RollLock)
            {
                return _Dice;
            }
        }
    }
}