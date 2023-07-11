using BorjaProject.iws.api.Datos;
using BorjaProject.iws.api.Models;
using BorjaProject.iws.api.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BorjaProject.iws.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorjaP_Controller : ControllerBase
    {
        //se inicializa y se referencia el servicio de logger
        private readonly ILogger<BorjaP_Controller> _logger;
        private readonly BorjaDbContext _db;


        public BorjaP_Controller(ILogger<BorjaP_Controller> logger, BorjaDbContext db)
        {
            _logger = logger;
            _db = db;
        }
        [HttpGet]
        public ActionResult<IEnumerable<BorjaP_Dto>> GetBorjaPs()
        {
            _logger.LogInformation("Obtener todos los registros");

            return Ok(_db.BorjaPs.ToList());
        }


        [HttpGet("id:int", Name = "GetBorjaP")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<BorjaP_Dto> GetBorjaPsId(int Id)
        {
            if(Id == 0)
            {
                return BadRequest();
            }
            //var Borja= (BorjaPStore.StoreB.FirstOrDefault(v => v.Id == Id));
            var Borja = _db.BorjaPs.FirstOrDefault(p => p.Id == Id);
            if(Borja== null)
            {
                return NotFound();
            }
            return Ok(Borja);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<BorjaP_Dto> CrearBorjaP([FromBody] BorjaP_Dto borjaDto) 
        {
            //Revisando que las validaciones sean correctas
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //revisando con modelstate que no exista el nombre de un borjap
            if(_db.BorjaPs.FirstOrDefault(v => v.Name.ToLower()== borjaDto.Name.ToLower()) !=null)
            {
                ModelState.AddModelError("Nombre existente", "El registro con dicho nombre existe");
                return BadRequest(ModelState);
            }

            if(borjaDto == null)
            {
                return BadRequest(borjaDto);
            }
            if(borjaDto.Id> 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            //borjaDto.Id = BorjaPStore.StoreB.OrderByDescending(v => v.Id).FirstOrDefault().Id +1;
            //BorjaPStore.StoreB.Add(borjaDto);

            BorjaP Modelo = new()
            {
                //Id = borjaDto.Id
                Name = borjaDto.Name
                , Edad = borjaDto.Edad
                , Peso = borjaDto.Peso
            };

            _db.BorjaPs.Add(Modelo);
            _db.SaveChanges();

            return CreatedAtRoute("GetBorjaP", new {id= borjaDto.Id}, borjaDto);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteBorjaP(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var borjaDto = _db.BorjaPs.FirstOrDefault(v => v.Id == id);
            if(borjaDto == null)
            {
                return NotFound();
            }
            _db.BorjaPs.Remove(borjaDto);
            _db.SaveChanges(); 
            return NoContent();
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateBorjaP(int id, [FromBody]  BorjaP_Dto borjaPDto)
        {
            if (id == 0|| borjaPDto==null || id!=borjaPDto.Id) {
                return BadRequest();
            }
            //var borjaP = BorjaPStore.StoreB.FirstOrDefault(v => v.Id == id);
            //borjaP.Name= borjaPDto.Name;
            //borjaP.Edad= borjaPDto.Edad;
            //borjaP.Peso= borjaPDto.Peso;

            BorjaP modelo= new() { 
                Id = borjaPDto.Id,
                Name = borjaPDto.Name,
                Edad = borjaPDto.Edad,
                Peso =  borjaPDto.Peso,
            };
            _db.BorjaPs.Update(modelo);
            _db.SaveChanges();

            return NoContent();
        }

        //Metodo patch permite modificar unicamente unos atributos del objeto, al ocuparlo te pide:
        //  path-> ingresar un "/" y el atributo o atributos que se buscan modificar
        //  op  -> se indica que es replace
        //  value -> se indica el valor que se quiere cambiar 
        // Los otros dos se eliminan, pues no se ocupan 
        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdatePartialBorjaP(int id, JsonPatchDocument<BorjaP_Dto> patchBorjaDto)
        {
            if (patchBorjaDto == null || id ==0)
            {
                return BadRequest();
            }
            var borjaP = _db.BorjaPs.AsNoTracking().FirstOrDefault(v => v.Id == id);
            BorjaP_Dto dto = new()
            {
                Id = borjaP.Id,
                Name = borjaP.Name,
                Edad = borjaP.Edad,
                Peso = borjaP.Peso,
            };
            if (borjaP == null)
            {
                return BadRequest();
            }
            patchBorjaDto.ApplyTo(dto, ModelState);

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BorjaP modelo = new()
            {
                Id=dto.Id,
                Name = dto.Name,
                Edad = dto.Edad,
                Peso = dto.Peso,
            };

            _db.BorjaPs.Update(modelo);
            _db.SaveChanges();

            return NoContent();
        }

    }
}
