namespace Fate {
    public class Aspect {
        public string Name {get; private set;}

        public bool IsLimited;
        public uint NumLimitedInvokes {get; private set;}
        private Dictionary<Character, uint> _freeInvokes {get; set;}

        public Aspect(string name, bool isLimited = false, uint numLimitedInvokes = 0) {
            Name = name;
            IsLimited = isLimited;
            NumLimitedInvokes = numLimitedInvokes;
            _freeInvokes = new();
        }

        public uint GetFreeInvokesFor(Character chara)
        {
            uint result = 0;
            _freeInvokes.TryGetValue(chara, out result);

            return result;
        }

        public void AddFreeInvokes(Character character, uint numInvokes) 
        {
            _freeInvokes.Add(character, numInvokes);
        }

        public void AddLimitedInvokes(uint numInvokesToAdd) 
        {
            NumLimitedInvokes += numInvokesToAdd;
        }

        /// <summary>
        /// Invokes this aspect. Will update both aspect and invoker if
        /// there are limited uses or a cost to be paid.
        /// </summary>
        /// <param name="invoker">The Character who is invoking this Aspect.</param>
        /// <returns>
        /// True if Aspect was successfully invoked. False if Character is unable to invokoe this Aspect.
        /// </returns>
        public bool Invoke(Character invoker)
        {
            if (IsLimited && NumLimitedInvokes <= 0) {
                // Aspect can't be invoked any more because its limited uses have ran out
                Logger.INFO($"{invoker.Name} cannot invoke aspect [{Name}]. No more limited invocations.");
                return false;
            }

            if (_freeInvokes.ContainsKey(invoker) && _freeInvokes[invoker] > 0) {
                // Invoker has a free use of this Aspect
                _freeInvokes[invoker] -= 1;
            }
            else
            {
                // Try to pay a Fate point to use this Aspect.
                if (invoker.FatePoints > 0) 
                {
                    invoker.FatePoints -= 1;
                }
                else
                {
                    // No fate points so we can't invoke it.
                    Logger.INFO($"{invoker.Name} cannot invoke aspect [{Name}]. No more fate points.");
                    return false;
                }
            }

            if (IsLimited && NumLimitedInvokes > 0)
            {
                // Use up one of the limited uses.
                NumLimitedInvokes -= 1;
            }
            return true;
        }

        public override string ToString()
        {
            return $"Aspect[{Name}]";
        }
    }
}
