namespace Senegocia.WebApi.Entities
{
    public interface IEntity
    {
        int Id { get; }
    }

    public class Entity : IEntity
    {
        public int Id { get; protected set; }
    }
}
