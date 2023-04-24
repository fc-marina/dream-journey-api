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

        /// <summary>
        /// Retorna a lista de sonhos
        /// </summary>
        /// <returns>ActionResult</returns>
        /// <response code="200">Caso a busca da lista tenha sido realizada com sucesso</response>
        [HttpGet]
        public async Task <ActionResult<List<DreamModel>>> GetAll() {
            List<DreamModel> dreams = await _dreamRepository.GetAll();
            return Ok(dreams);
        }

        /// <summary>
        /// Retorna o sonho cujo o id tenha sido informado
        /// </summary>
        /// <param name="id"> Para a busca de um sonho é obrigatório que seja necessariamente informado um id.</param>
        /// <returns>ActionResult</returns>
        /// <response code="200">Caso o id exista e a busca tenha sido realizada com sucesso</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<DreamModel>> GetById(int id)
        {
            DreamModel dream = await _dreamRepository.GetById(id);
            return Ok(dream);
        }

        /// <summary>
        /// Adiciona um sonho ao banco de dados
        /// </summary>
        /// <param name="dreamModel"> Para a criação de um sonho é obrigatório que sejam necessariamente informados os campos name e description.</param>
        /// <returns>ActionResult</returns>
        /// <response code="200">Caso inserção seja feita com sucesso</response>
        [HttpPost]
        public async Task<ActionResult<DreamModel>> Create([FromBody] DreamModel dreamModel)
        {
            DreamModel dream = await _dreamRepository.Create(dreamModel);
            return Ok(dream);
        }

        /// <summary>
        /// Atualiza, no banco de dados, o sonho cujo o id tenha sido informado
        /// </summary>
        /// <param name="dreamModel"> Para a atualização de um sonho adicione as novas informações nos campos que deseja atualizar. </param>
        /// <returns>ActionResult</returns>
        /// <response code="200">Caso a alteração tenha sido realizada com sucesso</response>
        [HttpPut("{id}")]
        public async Task<ActionResult<DreamModel>> Update([FromBody] DreamModel dreamModel, int id)
        {
            dreamModel.Id = id;
            DreamModel dream = await _dreamRepository.Update(dreamModel, id);
            return Ok(dream);
        }

        /// <summary>
        /// Retorna um booleano "true" quando excluído o sonho cujo o id foi informado
        /// </summary>
        /// <param name="id"> Para a exclusão de um sonho é obrigatório que seja informado um id. </param>
        /// <returns>ActionResult</returns>
        /// <response code="200">Caso o id exista e a exclusão tenha sido realizada com sucesso</response>
        [HttpDelete("{id}")]
        public async Task<ActionResult<DreamModel>> Delete(int id)
        {
            bool isDreamDeleted = await _dreamRepository.Delete(id);
            return Ok(isDreamDeleted);
        }
    }
}
