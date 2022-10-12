namespace RestExercise8.Models
{
    public class IPA
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Brand { get; set; }
        public double Proof { get; set; }
        public string? Grain { get; set; }

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

        public void ValidateName()
        {
            if (Name == null)
            {
                throw new ArgumentNullException("You need to type Name");
            }
            else if (Name.Length < 3)
            {
                throw new ArgumentOutOfRangeException("Name is too short");
            }
        }

        public void ValidateBrand()
        {
            if (Brand == null)
            {
                throw new ArgumentNullException("You need to type Brand");
            }
            else if (Brand.Length < 3)
            {
                throw new ArgumentOutOfRangeException("Brand string is too short");
            }
        }

        public void ValidateProof()
        {
            if (Proof < 4.5)
            {
                throw new ArgumentOutOfRangeException("Proof must be 4.5 or more");
            }
            else if (Proof > 20)
            {
                throw new ArgumentOutOfRangeException("Proof must be 20 or lower");
            }
        }

        public void ValidateGrain()
        {
            if (Grain == null)
            {
                throw new ArgumentNullException("You need to type Grain");
            }
            else if (Grain.Length < 3)
            {
                throw new ArgumentOutOfRangeException("Grain string is too short");
            }
        }

        public void Validate()
        {
            //ValidateId();
            ValidateName();
            ValidateBrand();
            ValidateProof();
            ValidateGrain();
        }
    }
}
