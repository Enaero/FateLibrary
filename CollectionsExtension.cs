namespace Fate
{
    public static class CollectionsExtension
    {
        public static bool CollectionEquals<T>(this ICollection<T> self, ICollection<T> other)
        {
            if (other is null)
            {
                return false;
            }
            else
            {
                return self.Count == other.Count && !self.Except(other).Any();
            }
        }
    }
}
