namespace Fate {
    public class Aspect {
        public string Name {get; private set;}

        public bool IsLimited {get; set;}
        public uint NumLimitedInvokes {get; private set;}

        /// <summary>
        /// Character Name to Free Invokes count.
        /// </summary>
        public Dictionary<string, uint> FreeInvokes {get; set;}

        public Aspect(string name, bool isLimited = false, uint numLimitedInvokes = 0) {
            Name = name;
            IsLimited = isLimited;
            NumLimitedInvokes = numLimitedInvokes;
            FreeInvokes = new();
        }

        public uint GetFreeInvokesFor(Character chara)
        {
            FreeInvokes.TryGetValue(chara.Name, out uint result);

            return result;
        }

        public void AddFreeInvokes(Character character, uint numInvokes) 
        {
            FreeInvokes.Add(character.Name, numInvokes);
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

            if (FreeInvokes.ContainsKey(invoker.Name) && FreeInvokes[invoker.Name] > 0) {
                // Invoker has a free use of this Aspect
                FreeInvokes[invoker.Name] -= 1;
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

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            if (obj is Aspect otherAspect)
            {
                if (IsLimited != otherAspect.IsLimited)
                {
                    return false;
                }

                if (Name != otherAspect.Name)
                {
                    return false;
                }

                if (NumLimitedInvokes != otherAspect.NumLimitedInvokes)
                {
                    return false;
                }

                if (FreeInvokes.Count != otherAspect.FreeInvokes.Count)
                {

                    return false;
                }

                foreach (var key in FreeInvokes.Keys)
                {
                    if (!otherAspect.FreeInvokes.TryGetValue(
                        key, out uint otherAspectFreeInvokes)) 
                    {
                        return false;
                    }
                    
                    if (FreeInvokes[key] != otherAspectFreeInvokes)
                    {
                        return false;
                    }
                }

                return true;
            }
            else
            {
                return base.Equals(obj);
            }
        }
    }
}
