using AutoMapper;
using Core.Dtos;
using Core.Interfaces;
using Data;
using Data.Entitites;
using Data.DbContext;
using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using Core.Exceptions;

namespace Core.Service
{
    public class PetService:IPetService
    {
        private readonly IMapper mapper;
        private readonly PetsDbContext ctx;

        public PetService(PetsDbContext ctx, IMapper mapper)
        {
            this.ctx = ctx;
            this.mapper = mapper;
        }

        public void Create(CreatePetDto model)
        {
            ctx.Pet.Add(mapper.Map<Pet>(model));
            ctx.SaveChanges();
        }

        public void Delete(int Id)
        {
            var pet = ctx.Pet.Find(Id);
            if (pet == null) throw new HttpException($"Product with id:{Id} not found.", HttpStatusCode.NotFound);

            ctx.Pet.Remove(pet);
            ctx.SaveChanges();
        }

        public void Edit(EditPetDto model)
        {
            ctx.Pet.Update(mapper.Map<Pet>(model));
            ctx.SaveChanges();
        }

        public PetDto? Get(int Id)
        {
            var pet = ctx.Pet.Find(Id);
            if(pet == null) throw new HttpException($"Product with id:{Id} not found.", HttpStatusCode.NotFound);

            ctx.Entry(pet).Reference(x => x.Breed).Load();

            return mapper.Map<PetDto>(pet);
        }

        public IEnumerable<PetDto> GetAll()
        {
            return mapper.Map<List<PetDto>>(ctx.Pet.ToList());
        }
    }
}
