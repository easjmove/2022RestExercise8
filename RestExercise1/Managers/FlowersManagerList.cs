using RestExercise8.Models;

namespace RestExercise8.Managers
{
    public class FlowersManagerList : IFlowersManager
    {
        private static int _nextID = 1;
        private static readonly List<Flower> _data = new List<Flower>()
        {
            new Flower(){Id = _nextID++, Species="Violet", Height=10, Color= "Violet" },
            new Flower(){Id = _nextID++, Species="Rose", Height=10, Color= "red" },
            new Flower(){Id = _nextID++, Species="Daffodill", Height=10, Color= "yellow" }
        };

        public IEnumerable<Flower> GetAll(string? speciesFilter, string? colorFilter)
        {
            List<Flower> result = new List<Flower>(_data);
            if (speciesFilter != null)
            {
                result = result.FindAll(flower => flower.Species != null
                && flower.Species.Contains(speciesFilter, StringComparison.InvariantCultureIgnoreCase));
            }
            if (colorFilter != null)
            {
                result = result.FindAll(flower => flower.Color != null
                && flower.Color.Contains(colorFilter, StringComparison.InvariantCultureIgnoreCase));
            }
            return result;
        }

        public Flower? GetById(int Id)
        {
            return _data.Find(flower => flower.Id == Id);
        }

        public Flower Add(Flower newFlower)
        {
            newFlower.Validate();
            newFlower.Id = _nextID++;
            _data.Add(newFlower);
            return newFlower;
        }

        public Flower? Delete(int Id)
        {
            Flower? foundFlower = GetById(Id);
            if (foundFlower == null) return null;
            _data.Remove(foundFlower);
            return foundFlower;
        }

        public Flower? Update(int id, Flower updates)
        {
            updates.Validate();
            Flower? flower = GetById(id);
            if (flower == null) return null;
            flower.Species = updates.Species;
            flower.Color = updates.Color;
            flower.Height = updates.Height;
            return flower;
        }
    }
}
