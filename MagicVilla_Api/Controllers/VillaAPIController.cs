using AutoMapper;
using MagicVilla_Api.Models;
using MagicVilla_Api.Models.DTO;
using MagicVilla_Api.Repository.IRepository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_Api.Controllers
{
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        private readonly IVillaRepository _dbVilla;
        private readonly IMapper _mapper;
        public VillaAPIController(IVillaRepository dbVilla, IMapper mapper)
        {
            _dbVilla = dbVilla;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<VillaDTO>>> GetVillas()
        {
            IEnumerable<Villa> villaList = await _dbVilla.GetAll();
            return Ok(_mapper.Map<List<VillaDTO>>(villaList));
        }

        [HttpGet("{id:int}", Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VillaDTO>> GetVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var villa = await _dbVilla.Get(villa => villa.Id == id);
            if (villa == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<VillaDTO>(villa));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<VillaDTO>> CreateVilla([FromBody] VillaCreateDTO villaCreateDTO)
        {
            if (await _dbVilla.Get(villa => villa.Name.ToLower() == villaCreateDTO.Name.ToLower()) != null)
            {
                ModelState.TryAddModelError("CustomError", "A Villa with this Name already exists");
                return BadRequest(ModelState);
            }
            if (villaCreateDTO == null)
            {
                return BadRequest(villaCreateDTO);
            }

            Villa model = _mapper.Map<Villa>(villaCreateDTO);
            await _dbVilla.Create(model);

            return CreatedAtRoute("GetVilla", new { id = model.Id }, model);
        }

        [HttpDelete("{id:int}", Name = "DeleteVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VillaDTO>> DeleteVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var villa = await _dbVilla.Get(villa => villa.Id == id);
            if (villa == null)
            {
                return NotFound();
            }
            await _dbVilla.Remove(villa);

            return NoContent();
        }

        [HttpPut("{id:int}", Name = "UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<VillaDTO>> UpdateVilla(int id, [FromBody] VillaUpdateDTO villaUpdateDTO)
        {
            if (villaUpdateDTO == null || id != villaUpdateDTO.Id)
            {
                return BadRequest();
            }

            Villa model = _mapper.Map<Villa>(villaUpdateDTO);
            await _dbVilla.Update(model);            

            return NoContent();
        }

        [HttpPatch("{id:int}", Name = "PartialUpdateVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<VillaDTO>> PartialUpdateVilla(int id, JsonPatchDocument<VillaUpdateDTO> patchDTO)
        {
            if (patchDTO == null || id == 0)
            {
                return BadRequest();
            }
            var villa = await _dbVilla.Get(villa => villa.Id == id, tracked:false);
            VillaUpdateDTO villaUpdateDTO = _mapper.Map<VillaUpdateDTO>(villa);
            
            if (villa == null)
            {
                return BadRequest();
            }
            patchDTO.ApplyTo(villaUpdateDTO, ModelState);

            Villa model = _mapper.Map<Villa>(villaUpdateDTO);

            await _dbVilla.Update(model);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return NoContent();
        }
    }
}