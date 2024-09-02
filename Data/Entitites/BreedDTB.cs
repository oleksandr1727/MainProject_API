using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entitites
{
    public class BreedDTB
    {
        public int BreedId { get; set; }
        public Breed Breed { get; set; }
        public int PetId { get; set; }
        public Pet Pet { get; set; }

    }
}
