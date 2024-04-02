namespace Fate
{
    public class Scene : FateEntity
    {
        private readonly Dictionary<string, FateEntity> _entities;

        public Scene(string name, Aspect[] aspects) : base(name, aspects)
        {
            _entities = new();
        }

        public FateEntity? GetEntity(string name)
        {
            if (_entities.TryGetValue(name, out FateEntity? result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public bool RemoveEntity(string name)
        {
            return _entities.Remove(name);
        }
    }
}
