namespace Fate
{
    public class DieRoller
    {
        private readonly object _rollLock = new();

        private readonly Random _random;
        private readonly int[] _possibleValues;

        public int RolledValue {get; private set;}

        public DieRoller(int[] values, Random seed)
        {
            _random = seed;
            _possibleValues = values;
            Roll();
        }

        public DieRoller Roll()
        {
            lock(_rollLock)
            {
                int index = _random.Next(_possibleValues.Length);
                RolledValue = _possibleValues[index];
                return this;
            }
        }
    }

    public class DiceRoller
    {
        private readonly object _rollLock = new();
        private readonly DieRoller[] _dice;

        public DiceRoller(DieRoller[] dice)
        {
            _dice = dice;
        }

        /// <summary>
        /// Rolls the internal dice and returns itself for stacking function calls.
        /// Example: diceRoller.Roll().GetTotal();
        /// </summary>
        /// <returns>A reference to this FateDiceRoller</returns>
        public DiceRoller Roll()
        {
            lock(_rollLock)
            {
                foreach (DieRoller die in _dice)
                {
                    die.Roll();
                }

                return this;
            }
        }

        public int GetTotal() 
        {
            lock(_rollLock)
            {
                return _dice.Select(die => die.RolledValue).Sum();
            }
        }

        public DieRoller[] GetDice()
        {
            lock(_rollLock)
            {
                return _dice;
            }
        }
    }
}