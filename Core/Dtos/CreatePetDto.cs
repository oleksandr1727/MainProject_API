using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class CreatePetDto
    {
        public string Name { get; set; }
        public string? ImageUrl { get; set; }
        public decimal YearsOld { get; set; }
        public string Breed { get; set; }
        public string? Description { get; set; }
    }
}