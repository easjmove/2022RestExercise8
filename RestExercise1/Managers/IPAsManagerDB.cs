using RestExercise8.Models;

namespace RestExercise8.Managers
{
    public class IPAsManagerDB : IIPAsManager
    {
        private RestContext _context;

        public IPAsManagerDB(RestContext context)
        {
            _context = context;
        }

        public IPA Add(IPA newIpa)
        {
            newIpa.Id = 0;
            _context.IPAs.Add(newIpa);
            _context.SaveChanges();
            return newIpa;
        }

        public IPA? Delete(int Id)
        {
            IPA? foundIPA = GetById(Id);

            if (foundIPA != null)
            {
                _context.IPAs.Remove(foundIPA);
                _context.SaveChanges();
            }
            return foundIPA;
        }

        public IEnumerable<IPA> GetAll(double? minimumProof, double? maximumProof, string nameFilter)
        {
            IEnumerable<IPA> ipas = from ipa in _context.IPAs
                                    where (minimumProof == null || ipa.Proof >= minimumProof)
                                    && (maximumProof == null || ipa.Proof <= maximumProof)
                                    && (nameFilter == null || ipa.Name.Contains(nameFilter))
                                    select ipa;
            return ipas;
        }

        public IPA? GetById(int Id)
        {
            return _context.IPAs.FirstOrDefault(ipa => ipa.Id == Id);
        }

        public IPA? Update(int Id, IPA updates)
        {
            IPA ipaToBeUpdated = GetById(Id);
            ipaToBeUpdated.Name = updates.Name;
            ipaToBeUpdated.Proof = updates.Proof;
            ipaToBeUpdated.Brand = updates.Brand;
            ipaToBeUpdated.Grain = updates.Grain;

            _context.SaveChanges();

            return ipaToBeUpdated;
        }
    }
}
