namespace Fate
{
    /// <summary>
    /// Stores an instance of each entity in the scene.
    /// Used for getting an instance from a Name in the scene.
    /// </summary>
    public class SceneIndex
    {
        public Dictionary<string, Character> Characters {get; set;}

        public SceneIndex(Dictionary<string, Character>? characters = null)
        {
            Characters = characters is null ? new() : characters;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return Characters.Keys.Sum((item) => item.GetHashCode());
            }
        }


        public override bool Equals(object? obj)
        {
            if (obj is SceneIndex otherSceneIndex)
            {
                if (Characters.Count != otherSceneIndex.Characters.Count)
                {
                    return false;
                }

                return !Characters.Except(otherSceneIndex.Characters).Any();
            }
            else
            {
                return base.Equals(obj);
            }
        }
    }
}
