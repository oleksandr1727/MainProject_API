using Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IPetService
    {
        void Delete(int Id);
        void Create(CreatePetDto model);
        void Edit(EditPetDto model);
        PetDto? Get(int Id);
        IEnumerable<PetDto> GetAll();
    }
}