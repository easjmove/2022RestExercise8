using RestExercise8.Models;

namespace RestExercise8.Managers
{
    public interface IIPAsManager
    {
        IPA Add(IPA newIpa);
        IPA? Delete(int Id);
        IEnumerable<IPA> GetAll(double? minimumProof, double? maximumProof, string nameFilter);
        IPA? GetById(int Id);
        IPA? Update(int Id, IPA updates);
    }
}