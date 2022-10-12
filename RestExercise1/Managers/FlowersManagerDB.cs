using RestExercise8.Models;

namespace RestExercise8.Managers
{
    public class FlowersManagerDB : IFlowersManager
    {
        private RestContext _context;

        public FlowersManagerDB(RestContext context)
        {
            _context = context;
        }

        public Flower Add(Flower newFlower)
        {
            newFlower.Id = 0;
            _context.Flowers.Add(newFlower);
            _context.SaveChanges();
            return newFlower;
        }

        public Flower? Delete(int Id)
        {
            Flower? foundFlower = GetById(Id);

            if (foundFlower != null)
            {
                _context.Flowers.Remove(foundFlower);
                _context.SaveChanges();
            }
            return foundFlower;
        }

        public IEnumerable<Flower> GetAll(string? speciesFilter, string? colorFilter)
        {
            IEnumerable<Flower> flowers = from flower in _context.Flowers
                                          where (speciesFilter == null || flower.Species.Contains(speciesFilter))
                                          && (colorFilter == null || flower.Color.Contains(colorFilter))
                                          select flower;
            return flowers;
        }

        public Flower? GetById(int Id)
        {
            return _context.Flowers.FirstOrDefault(flower => flower.Id == Id);
        }

        public Flower? Update(int id, Flower updates)
        {
            Flower flowerToBeUpdated = GetById(id);
            flowerToBeUpdated.Species = updates.Species;
            flowerToBeUpdated.Color = updates.Color;
            flowerToBeUpdated.Height = updates.Height;

            _context.SaveChanges();

            return flowerToBeUpdated;
        }
    }
}
