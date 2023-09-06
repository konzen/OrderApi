namespace Order.Entity
{
    public abstract class Entity
    {
        public int Id { get; set; }

        public byte[]? Version { get; set; }
    }
}
