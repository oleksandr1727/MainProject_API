using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Core.Dtos;
using Core.Interfaces;
using Data;
using Data.Entitites;
namespace MainProject_API.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class PetController : ControllerBase
        {
            private readonly IPetService petService;

            public PetController(IPetService petService)
            {
                this.petService = petService;
            }

            [HttpGet("all")]
            public IActionResult GetAll()
            {
                return Ok(petService.GetAll());
            }

            [HttpPost]
            public IActionResult Create(CreatePetDto model)
            {
                petService.Create(model);
                return Ok(model);
            }

            [HttpPut]
            public IActionResult Edit(EditPetDto model)
            {
                petService.Edit(model);
                return Ok(model);
            }

            [HttpDelete]
            public IActionResult Delete(int id)
            {
                petService.Delete(id);
                return Ok();
            }
        }
}
