namespace Fate
{
    public class Stress
    {
        public string Name {get; private set;}
        public uint Capacity;
        public uint Current;

        public Stress(string name, uint capacity, uint current = 0)
        {
            Name = name;
            Capacity = capacity;
            Current = current;
        }

        /// <summary>
        /// Takes stress and returns any extra shifts that need
        /// to be handles via consequences or something else.
        /// </summary>
        /// <param name="stressTaken">The number of shifts taken.</param>
        /// <returns>The remaining number of shifts after taking stress.</returns>
        public uint TakeStress(uint stressTaken)
        {
            if (Current + stressTaken > Capacity)
            {
                uint remainder = Current + stressTaken - Capacity;
                Current = Capacity;
                return remainder;
            }
            Current += stressTaken;
            return 0;
        }

        /// <summary>
        /// Heals stress and returns any excess healing that occured.
        /// </summary>
        /// <param name="stressHealed">Amount of stress to heal.</param>
        /// <returns>Excess healing</returns>
        public uint HealStress(uint stressHealed)
        {
            if (stressHealed > Current) 
            {
                uint excessHealing = stressHealed - Current;
                Current = 0;
                return excessHealing;
            }
            Current -= stressHealed;
            return 0;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Stress otherStress)
            {
                return otherStress.Capacity == Capacity &&
                    otherStress.Current == Current &&
                    otherStress.Name == Name;
            }
            else
            {
                return base.Equals(obj);
            }
        }

        public override int GetHashCode()
        {
            unchecked {
                return Name.GetHashCode() + (int) Current + (int) Capacity + base.GetHashCode();
            }
        }
    }
}
