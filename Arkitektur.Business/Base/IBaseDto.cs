namespace Arkitektur.Business.Base
{
    public interface IBaseDto
    {
        public int Id { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; init; }
    }
}
