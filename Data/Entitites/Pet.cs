using System.ComponentModel.DataAnnotations;

namespace Data.Entitites
{
    public class Pet
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int YearsOld { get; set; }
        [Range(0.1, 30)]
        public ICollection<BreedDTB> Breed { get; set; }
        public string Description { get; set; }

        [Url(ErrorMessage = "URL Addres must be valid")]
        public string? ImageUrl { get; set; }
    }
}