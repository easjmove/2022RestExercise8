using RestExercise8.Models;

namespace RestExercise8.Managers
{
    public interface IFlowersManager
    {
        Flower Add(Flower newFlower);
        Flower? Delete(int Id);
        IEnumerable<Flower> GetAll(string? speciesFilter, string? colorFilter);
        Flower? GetById(int Id);
        Flower? Update(int id, Flower updates);
    }
}