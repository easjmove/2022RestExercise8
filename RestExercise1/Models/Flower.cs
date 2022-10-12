namespace RestExercise8.Models
{
    public class Flower
    {
        public int Id { get; set; }
        public string? Species { get; set; }
        public string? Color { get; set; }
        public int Height { get; set; }

        /// <summary>
        /// Not used in validate
        /// Could reserve an ID in a add method, and then not allowed to be saved
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void ValidateId()
        {
            if (Id < 1)
            {
                throw new ArgumentOutOfRangeException("Id must be a positive number!");
            }
        }

        public void ValidateSpecies()
        {
            if (Species == null)
            {
                throw new ArgumentNullException("You need to type Species");
            }
            else if (Species.Length > 50)
            {
                throw new ArgumentOutOfRangeException("Species name is too long");
            }
            else if (Species.Length < 3)
            {
                throw new ArgumentOutOfRangeException("Species name is too short");
            }
        }

        public void ValidateColor()
        {
            if (Color == null)
            {
                throw new ArgumentNullException("You need to type color");
            }
            else if (Color.Length > 50)
            {
                throw new ArgumentOutOfRangeException("Color name is too long");
            }
            else if (Color.Length < 3)
            {
                throw new ArgumentOutOfRangeException("Color name is too short");
            }
        }

        public void ValidateHeight()
        {
            if (Height < 1)
            {
                throw new ArgumentOutOfRangeException("Height must be a positive number");
            }
        }

        public void Validate()
        {
            //ValidateId();
            ValidateSpecies();
            ValidateColor();
            ValidateHeight();
        }
    }
}
