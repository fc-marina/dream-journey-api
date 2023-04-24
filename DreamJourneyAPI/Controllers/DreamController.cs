using DreamJourneyAPI.Models;
using DreamJourneyAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DreamJourneyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DreamController : ControllerBase
    {
        private readonly IDreamRepository _dreamRepository;
        public DreamController(IDreamRepository dreamRepository)
        {
            _dreamRepository = dreamRepository;
        }

        [HttpGet]
        public async Task <ActionResult<List<DreamModel>>> GetAll() {
            List<DreamModel> dreams = await _dreamRepository.GetAll();
            return Ok(dreams);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DreamModel>> GetById(int id)
        {
            DreamModel dream = await _dreamRepository.GetById(id);
            return Ok(dream);
        }

        [HttpPost]
        public async Task<ActionResult<DreamModel>> Create([FromBody] DreamModel dreamModel)
        {
            DreamModel dream = await _dreamRepository.Create(dreamModel);
            return Ok(dream);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DreamModel>> Update([FromBody] DreamModel dreamModel, int id)
        {
            dreamModel.Id = id;
            DreamModel dream = await _dreamRepository.Update(dreamModel, id);
            return Ok(dream);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DreamModel>> Delete(int id)
        {
            bool isDreamDeleted = await _dreamRepository.Delete(id);
            return Ok(isDreamDeleted);
        }
    }
}
