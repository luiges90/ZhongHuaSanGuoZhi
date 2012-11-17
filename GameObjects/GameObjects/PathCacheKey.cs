namespace GameObjects
{
    internal class PathCacheKey
    {
        public Architecture a1;
        public Architecture a2;
        public PathCacheKey(Architecture a1, Architecture a2)
        {
            this.a1 = a1;
            this.a2 = a2;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            PathCacheKey p = (PathCacheKey)obj;
            return p.a1.ID == this.a1.ID && p.a2.ID == this.a2.ID;
        }

        public override int GetHashCode()
        {
            return this.a1.ID * 37 + this.a2.ID;
        }
    }
}
