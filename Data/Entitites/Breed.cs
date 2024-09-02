using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entitites
{
    public class Breed
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category CategoryId { get; set; }
        public ICollection<BreedDTB> BreedDTB { get; set; }
    }
}
