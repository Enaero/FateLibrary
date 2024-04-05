namespace Fate
{
    public class WorldIndex
    {
        /// <summary>
        /// A mapping of Scene.Name to the SceneIndex.
        /// So from a scene name you can construct the necessary
        /// characters and zones etc.
        /// </summary>
        public Dictionary<string, SceneIndex> Scenes {get; set;}

        public WorldIndex(Dictionary<string, SceneIndex>? scenes = null)
        {
            Scenes = scenes is null ? new() : scenes;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return Scenes.Keys.Sum((item) => item.GetHashCode());
            }
        }

        public override bool Equals(object? obj)
        {
            if (obj is WorldIndex otherWorld)
            {
                if (Scenes.Count != otherWorld.Scenes.Count)
                {
                    return false;
                }

                return !Scenes.Except(otherWorld.Scenes).Any();
            }
            else
            {
                return base.Equals(obj);
            }
        }
    }   
}
